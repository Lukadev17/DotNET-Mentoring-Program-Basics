using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class FileSystemVisitor 
    {
        public event EventHandler Start;
        public event EventHandler Finish;
        public event EventHandler<FileSystemVisitorEventArgs> FileFound;
        public event EventHandler<FileSystemVisitorEventArgs> DirectoryFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredFileFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredDirectoryFound;

        private readonly string _startPath;
        private readonly Func<string, bool> _filter;
        private bool _abort;

        public FileSystemVisitor(string startPath, Func<string, bool> filter = null)
        {
            _startPath = startPath;
            _filter = filter;
        }

        public IEnumerable<string> Traverse()
        {
            Start?.Invoke(this, EventArgs.Empty);

            foreach (var item in TraverseInternal(_startPath))
            {
                if (_abort)
                    yield break; 

                yield return item;
            }

            Finish?.Invoke(this, EventArgs.Empty);
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
                var args = new FileSystemVisitorEventArgs(dir);
                DirectoryFound?.Invoke(this, args);

                if (args.Abort)
                {
                    _abort = true;
                    yield break;
                }
                if (!args.Exclude)
                {
                    if (_filter == null || _filter(dir))
                    {
                        var filteredArgs = new FileSystemVisitorEventArgs(dir);
                        FilteredDirectoryFound?.Invoke(this, filteredArgs);

                        if (filteredArgs.Abort)
                        {
                            _abort = true;
                            yield break;
                        }
                        if (!filteredArgs.Exclude)
                        {
                            yield return dir;
                        }
                    }
                }

                foreach (var innerItem in TraverseInternal(dir))
                {
                    if (_abort)
                        yield break;
                    yield return innerItem;
                }
            }

            foreach (var file in files)
            {
                var args = new FileSystemVisitorEventArgs(file);
                FileFound?.Invoke(this, args);

                if (args.Abort)
                {
                    _abort = true;
                    yield break;
                }
                if (!args.Exclude)
                {
                    if (_filter == null || _filter(file))
                    {
                        var filteredArgs = new FileSystemVisitorEventArgs(file);
                        FilteredFileFound?.Invoke(this, filteredArgs);

                        if (filteredArgs.Abort)
                        {
                            _abort = true;
                            yield break;
                        }
                        if (!filteredArgs.Exclude)
                        {
                            yield return file;
                        }
                    }
                }
            }
        }
    }
}
