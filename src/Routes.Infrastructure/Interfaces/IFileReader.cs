using System.Collections.Generic;

namespace Routes.Infrastructure.Interfaces
{
    public interface IFileReader
    {
        IEnumerable<string> ReadFileLines(string path);
    }
}
