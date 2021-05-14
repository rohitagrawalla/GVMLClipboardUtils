using System;
using System.IO;
using System.Windows;

namespace ConsoleApp2
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			var dataObject = Clipboard.GetDataObject();
			var formats = dataObject.GetFormats();

			foreach (var format in formats)
			{
				Console.Out.WriteLine(format);
			}

			var data = dataObject.GetData("Art::GVML ClipFormat");

			if (data != null)
			{
				var file = File.Create("c:\\users\\rohit\\desktop\\GVML.zip");
				var ms = data as MemoryStream;
				var bytes = ms.ToArray();
				file.Write(bytes, 0, bytes.Length);
				file.Close();
			}
		}
	}
}