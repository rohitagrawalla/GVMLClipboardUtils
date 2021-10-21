using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace ExtractGvml
{
   class Program
   {
      public static class KnownFolder
      {
         public static readonly Guid Downloads = new Guid( "374DE290-123F-4565-9164-39C4925E467B" );
      }

      [DllImport( "shell32.dll", CharSet = CharSet.Unicode )]
      static extern int SHGetKnownFolderPath( [MarshalAs( UnmanagedType.LPStruct )] Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath );


      [STAThread]
      static void Main( string[] args )
      {
         string downloads;
         SHGetKnownFolderPath( KnownFolder.Downloads, 0, IntPtr.Zero, out downloads );

         var dataObject = Clipboard.GetDataObject();
         var data = dataObject.GetData( "Art::GVML ClipFormat" );

         if( data != null )
         {
            var file = File.Create( Path.Combine( new string[] { downloads, $"{DateTime.Now.ToString( "yyyy-dd-M--HH-mm-ss" )}-GVML.zip" } ) );
            var ms = data as MemoryStream;
            var bytes = ms.ToArray();
            file.Write( bytes, 0, bytes.Length );
            file.Close();
         }
      }
   }
}