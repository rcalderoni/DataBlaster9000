using System.Collections.Generic;
using System.IO;
using System.Linq;
using DataBlaster9000.Models;
using DataBlaster9000.Extensions;

namespace DataBlaster9000.Repositories.DataContexts
{
    public class FileDataContext
    {
        private const string FilePath = "/Files/";

        private readonly FileDataModel _file;

        public FileDataContext(FileDataModel file)
        {
            _file = file;
        }

        public FileDataModel LoadFile()
        {
            return new FileDataModel
            {
                Uid = _file.Uid,
                Lines = File.ReadAllLines(CsvFile()).ToList()    
            };
        }

        public void WriteFile()
        {
            File.WriteAllText(CsvFile(), _file.Lines.ToCsv());
        }

        public void ReplaceAllLines(IEnumerable<string> newLines)
        {
            _file.Lines = newLines.ToList();
            WriteFile();
        }

        private string CsvFile()
        {
            return FilePath + _file.Uid + ".csv";
        }
    }
}