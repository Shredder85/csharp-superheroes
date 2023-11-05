using Utils.Animation;
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

		private void
			OnResizeButtonClick(object? sender, MouseEventArgs e)
		{
			Animation.Resize(
				element: this,
				targetWidth: new Random(Guid.NewGuid().ToString().GetHashCode()).Next(300,750),
				targetHeight: new Random(Guid.NewGuid().ToString().GetHashCode()).Next(300, 750),
				callback: ()=> Print.Log("animate", "animation completed")
				);
		}
	}
}