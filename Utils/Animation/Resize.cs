namespace Utils.Animation
{
	static public class
		Animation
	{
		//
		/// <summary>
		/// Resize the control to the specified width and height
		/// </summary>
		/// <param name="element"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="pixelsPerStep"></param>
		/// <param name="delayPerStep"></param>
		//

		static public void
			Resize(
				Control element,
				
				int width,
				int height,
				int pixelsPerStep = 10,
				int delayPerStep = 5,

				Action? callback = null
			)
		{
			bool incrementWidth = element.Width < width;
			bool incrementHeight = element.Height < height;

			int widthChange = incrementWidth ? width - element.Width : element.Width - width;
			int heightChange = incrementHeight ? height - element.Height : element.Height - height;

			var widthPixelsPerStep = (int) Math.Ceiling((double)(widthChange / pixelsPerStep));
			var heightPixelsPerStep = (int) Math.Ceiling((double)(heightChange / pixelsPerStep));

			_ = Task.Run(async () =>
			{
				while (true)
				{
					bool widthReached = element.Width == width;
					bool heightReached = element.Height == height;

					if (widthReached && heightReached) break;

					if (!widthReached)
					{
						int change = incrementWidth

							? ((element.Width + widthPixelsPerStep) > width
								? width - element.Width : widthPixelsPerStep)

							: ((element.Width - widthPixelsPerStep) < width
								? element.Width - width : widthPixelsPerStep);

						element.Invoke(() => element.Width += incrementWidth ? change : -change);
					}

					if (!heightReached)
					{
						int change = incrementHeight

							? ((element.Height + heightPixelsPerStep) > height
								? height - element.Height : heightPixelsPerStep)

							: ((element.Height - heightPixelsPerStep) < height
								? element.Height - height : heightPixelsPerStep);

						element.Invoke(() => element.Height += incrementHeight ? change : -change);
					}

					await Task.Delay(delayPerStep);
				}

				callback?.Invoke();
			});
		}
	}
}
