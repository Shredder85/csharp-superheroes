﻿namespace Utilities.FileIO
{
	public static partial class
		FileSystem
	{
		//
		/// <summary></summary>
		/// 
		/// <param name="path">The path to the file.</param>
		/// <param name="content">The data that should be added to the file.</param>
		/// <param name="overwrite">Boolean indicating if the current content should be overwritten.</param>
		/// 
		/// <returns>Boolean (async) indicating the result of the operation.</returns>

		public static Task<bool>
			WriteAsync(string path, string content, bool overwrite = true)
		{
			return Task.Run(async ()=>
			{
				try
				{
					using var writer = new StreamWriter(path, append: !overwrite);
					await writer.WriteAsync(content);

					return true;
				}
				catch (Exception exception)
				{
					DevTools.Error("file-system/write-async", exception);
				}

				return false;
			});
		}

		//
		/// <summary></summary>
		/// 
		/// <param name="path">The path to the file.</param>
		/// <param name="content">The data that should be added to the file.</param>
		/// 
		/// <returns>Boolean (async) indicating the result of the operation.</returns>

		public static Task<bool>
			AppendAsync(string path, string content) =>
				WriteAsync(path, content, overwrite: false);
	}
}
