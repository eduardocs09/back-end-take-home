using System.Collections.Generic;
using System.IO;
using Routes.Infrastructure.Interfaces;

namespace Routes.Infrastructure.FileHandler
{
    public class FileReader : IFileReader
    {
        public IEnumerable<string> ReadFileLines(string path)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(path))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
            return lines;
        }
    }
}
