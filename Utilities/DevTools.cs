using System.Diagnostics;
using System.Xml.Serialization;
using Utilities.FileIO;

namespace Utilities
{
	//
	/// <summary>Provides methods that help out in presenting and
	/// logging information, warnings and exceptions.</summary>

	public static class 
		DevTools
	{
		//
		/// <summary>Display information about the provided exception,
		/// and optionally save the event to the error log.</summary>
		/// 
		/// <param name="trace">The trace identifier used to located the source.</param>
		/// <param name="exception">The thrown Exception object.</param>
		/// <param name="log">Boolean specifying whether the error should be saved to the log.</param>

		public async static void
			Error(string trace, Exception exception, bool log = false)
		{
			if (log)
			{
				if (await FileSystem.EnsureFileExists("error.log"))
				{
					try
					{
						var error = new ExceptionInfo
						{
							Type = exception.GetType().Name,
							Message = exception.Message,
							StackTrace = exception.StackTrace ?? string.Empty
						};

						var serializer = new XmlSerializer(typeof(ExceptionInfo));
						using var writer = new StreamWriter("error.log", append: true);

						writer.WriteLine("<ExceptionInfo>");
						serializer.Serialize(writer, error);
						writer.WriteLine("</ExceptionInfo>");
					}

					catch (Exception x)
					{
						Output("exception", trace, x.Message);
					}
				}
			}

			Output("exception", trace, exception.Message);
		}

		//
		/// <summary>Print the provided warning.</summary>
		/// 
		/// <param name="trace">The trace identifier used to located the source.</param>
		/// <param name="message">The warning that should be printed to the debug output.</param>

		public static void
			Warning(string trace, string message) => Output("warning", trace, message);

		//
		/// <summary>Print the provided event info.</summary>
		/// 
		/// <param name="trace">The trace identifier used to located the source.</param>
		/// <param name="message">The warning that should be printed to the debug output.</param>

		public static void
			Event(string trace, string message) => Output("event", trace, message);

		//
		/// <summary>Print a message to the debug output.</summary>
		/// 
		/// <param name="type">The type of message</param>
		/// <param name="trace">The trace identifier used to located the source.</param>
		/// <param name="message">The message that should be displayed</param>

		public static void
			Output(string type, string trace, string message)
		{
			if (Enabled)
			{
				Debug.WriteLine($"[{type}]: {message} @{trace}");
			}
		}

		//
		/// <summary>Controls whether output should be printed.</summary>

		public static bool Enabled { get; set; } = true;
	}

	//
	/// <summary>Object model used when logging exceptions.</summary>

	public class ExceptionInfo
	{
		public string Type { get; set; } = string.Empty;

		public string Message { get; set; } = string.Empty;

		public string StackTrace { get; set; } = string.Empty;
	}
}
