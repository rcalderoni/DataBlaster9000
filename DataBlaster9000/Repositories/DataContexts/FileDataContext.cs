using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataBlaster9000.Models;
using DataBlaster9000.Extensions;

namespace DataBlaster9000.Repositories.DataContexts
{
    public class FileDataContext
    {
        private const string FilePath = "/UserFiles/";

        public FileDataModel LoadFile(FileDataModel file)
        {
            return new FileDataModel
            {
                Uid = file.Uid,
                Lines = File.ReadAllLines(CsvFile(file)).ToList()    
            };
        }

        public void WriteFile(FileDataModel file)
        {
            File.WriteAllText(CsvFile(file), file.Lines.ToCsv());
        }

        public void ReplaceAllLines(IEnumerable<string> newLines, FileDataModel file)
        {
            file.Lines = newLines.ToList();
            WriteFile(file);
        }

        private string CsvFile(FileDataModel file)
        {
            return FilePath + file.Uid + ".csv";
        }
    }
}