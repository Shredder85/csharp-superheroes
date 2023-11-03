using Utils;
using Utils.Debug;

//
///
/// C#: Superheroes registry
/// 
/// A learning project to develop knowledge about object-oriented programming (OOP)
/// and three-layered application structures. Shared with the humble intent of
/// spreading the knowledge gained to future students of the programme.
/// 
/// Created by Erik Riklund
/// https://github.com/Shredder85
/// 
/// Bachelor Programme of Systems Sciences
/// Örebro University, 2023
///
//

namespace App
{
	public partial class App : Form
	{
		public App()
		{
			//
			/// run the application
			//

			try
			{
				InitializeComponent();

				ResizeButton.MouseClick += OnResizeButtonClick;
			}

			//
			/// catch any drifting exceptions (on the main thread)
			/// to avoid crashing the application
			//

			catch (Exception exception)
			{
				Print.Error("app", exception);
			}
		}

		private async void
			OnResizeButtonClick(object? sender, MouseEventArgs e)
		{

		}

		//{
			//Print.Log("resize", "button clicked");
				
			//int initialWidth = Width;
			//int initialHeight = Height;

			//Print.Log("resize", $"width: {initialWidth}, height: {initialHeight}");

			//int desiredWidth = Convert.ToInt32(initialWidth * 0.9);
			//int desiredHeight = Convert.ToInt32(initialHeight * 0.9);

			//Print.Log("resize", $"d-width: {desiredWidth}, d-height: {desiredHeight}");

			//while (Width > desiredWidth)
			//{
			//	Width -= 5;
			//	Height -= 5;

			//	await Task.Delay(1);
			//}
		//}
	}
}