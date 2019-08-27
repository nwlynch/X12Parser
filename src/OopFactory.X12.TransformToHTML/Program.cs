using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using OopFactory.X12.Parsing;
using OopFactory.X12.Parsing.Model;
using OopFactory.X12.Transformations;
using System.Diagnostics;
using System.Xml;

namespace OopFactory.X12.TransformToHTML
{
    class Program
    {
        static void Main(string[] args)
        {           
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: TransformToHTML <Filename.edi> <Filename.html>");
                return;
            }
            string mydoc = args[0];
            
            if (!File.Exists(mydoc)) {
                Console.WriteLine("Source File " + mydoc + " not found... ");
                return;
            }

            var htmlService = new X12HtmlTransformationService(new X12EdiParsingService(suppressComments: false));

            Stream ediFile = new FileStream(mydoc, FileMode.Open, FileAccess.Read);

            string html = htmlService.Transform(new StreamReader(ediFile).ReadToEnd());

            string extension = Path.GetExtension(mydoc);
            string htmlfile = mydoc.Replace(extension, ".html");

            using (StreamWriter outputFile = new StreamWriter(htmlfile))
            {
                outputFile.WriteLine(html);
            }
            if (File.Exists(htmlfile))
            {
                Console.WriteLine("File: " + htmlfile + " created");
            }
            else
            {
                Console.WriteLine("File: " + htmlfile + " was not created");
            }

        }
    }
}
