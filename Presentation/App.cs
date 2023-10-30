using Utilities;

//
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

namespace PL
{
	public partial class App : Form
	{
		public App()
		{
			try
			{
				InitializeComponent();
				CustomizeLookAndFeel();
			}

			catch (Exception exception)
			{
				DevTools.Error("app", exception, log: true);
			}
		}

		private void CustomizeLookAndFeel()
		{

		}
	}
}