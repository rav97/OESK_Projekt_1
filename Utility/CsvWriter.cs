using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESK_Projekt_I
{
    public class CsvWriter
    {
        private const string folderPath = @"..\..\Results\";

        private StringBuilder builder;
        private string fileName;

        public CsvWriter(string file, params string[] columns)
        {
            builder = new StringBuilder(CreateLine(columns));
            fileName = file;
        }

        public void WriteLine(params object[] values)
        {
            builder.Append(CreateLine(values));
        }

        public void Save()
        {
            File.WriteAllText(folderPath+fileName, builder.ToString());
        }

        private string CreateLine(object[] headers)
        {
            string output = string.Empty;

            for(int i=0;i<headers.Length;i++)
            {
                if (i < headers.Length - 1)
                    output += headers[i].ToString() + ";";
                else
                    output += headers[i].ToString();
            }

            return output+"\n";
        }

    }
}
