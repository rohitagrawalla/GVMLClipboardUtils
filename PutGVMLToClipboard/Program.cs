using System;
using System.IO;
using System.Windows;

namespace PutGVMLToClipboard
{
   internal class Program
   {
      [STAThread]
      static void Main( string[] args )
      {
         if(args.Length < 1)
         {
            printUsage();
            return;
         }

         string gvmlFile = args[0];
         if(!File.Exists(gvmlFile))
         {
            Console.WriteLine( $"{gvmlFile} does not exist on disk" );
         }

         Clipboard.SetData( "Art::GVML ClipFormat", new MemoryStream(File.ReadAllBytes( gvmlFile )) );

         return;
      }

      private static void printUsage()
      {
         Console.WriteLine( "PutGVMLToClipboard <gvml zip file path>" );
      }
   }
}
