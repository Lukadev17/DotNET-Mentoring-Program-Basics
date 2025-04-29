using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class FileSystemVisitor
    {
        private readonly string _startPath;
        private readonly Func<string, bool> _filter;

        public FileSystemVisitor(string startPath, Func<string, bool> filter = null)
        {
            _startPath = startPath;
            _filter = filter;
        }

        public IEnumerable<string> Traverse()
        {
            if (!Directory.Exists(_startPath))
                throw new DirectoryNotFoundException($"Directory not found: {_startPath}");

            foreach (var item in TraverseInternal(_startPath))
            {
                yield return item;
            }
        }

        private IEnumerable<string> TraverseInternal(string path)
        {
            IEnumerable<string> directories = new List<string>();
            IEnumerable<string> files = new List<string>();

            try
            {
                directories = Directory.GetDirectories(path);
                files = Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException)
            {
            }

            foreach (var dir in directories)
            {
                if (_filter == null || _filter(dir))
                {
                    yield return dir;
                }

                foreach (var innerItem in TraverseInternal(dir))
                {
                    yield return innerItem;
                }
            }

            foreach (var file in files)
            {
                if (_filter == null || _filter(file))
                {
                    yield return file;
                }
            }
        }
    }
}

