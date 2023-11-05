using Utils.Debug;
using System.Reflection;

namespace Utils.Animation
{
	static public class
		Animation
	{
		//
		/// <summary>
		/// Resize animation for Windows Forms Control objects
		/// </summary>
		/// 
		/// <param name="element">
		/// The Control object that should be resized
		/// </param>
		/// 
		/// <param name="targetWidth">
		/// The new width for the specified object
		/// </param>
		/// 
		/// <param name="targetHeight">
		/// The new height for the specified object
		/// </param>
		/// 
		/// <param name="tickRate">
		/// The number of frames for the animation
		/// </param>
		/// 
		/// <param name="delayPerTick">
		/// The delay between each animation frame (in milliseconds)
		/// </param>
		/// 
		/// <param name="callback">
		/// Delegate that should be invoked when the animation is completed
		/// </param>
		//

		static public void
			Resize(
				Control element,
				
				int targetWidth,
				int targetHeight,
				
				int tickRate = 5,
				int delayPerTick = 10,
				Action? callback = null
			)
		{
			Task<bool> resizer(
				Control element,
				string propertyName,
				int targetSize
				)
			{
				const int lowestAllowedChangePerTick = 5;

				return Task.Run(async () =>
				{
					try
					{
						if (element.GetType().GetProperty(propertyName)
							is PropertyInfo property)
						{
							var initialSize = (int)(property.GetValue(element) ?? 0);
							bool isIncrease = initialSize < targetSize;

							int totalChange = isIncrease ? targetSize - initialSize : initialSize - targetSize;
							int changePerTick = totalChange / tickRate;

							if (changePerTick < lowestAllowedChangePerTick)
							{
								element.Invoke(() => property.SetValue(element, targetSize));
							}
							else
							{
								for (int i = 1; i <= tickRate; i++)
								{
									element.Invoke(() =>
									{
										property.SetValue(element,
											initialSize + (i * (isIncrease ? changePerTick : -changePerTick))
											);
									});

									await Task.Delay(delayPerTick);
								}
							}
						}

						return true;
					}

					catch (Exception x)
					{
						Print.Error("resizer", x);
					}

					return false;
				});
			}

			_ = Task.Run(
				async ()=>
				{
					try
					{
						await Task.WhenAll(
							resizer(
								element,
								"Width",
								targetWidth
								),
							resizer(
								element,
								"Height",
								targetHeight
								)
							);

						element.Invoke(() => {
							element.Width = targetWidth;
							element.Height = targetHeight;
						});

						callback?.Invoke();
					}

					catch (Exception x)
					{
						Print.Error("resize", x);
					}
				});
		}
	}
}
