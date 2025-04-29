using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class FileSystemVisitorEventArgs : EventArgs
    {
        public string Path { get; set; }
        public bool Abort { get; set; }
        public bool Exclude { get; set; }

        public FileSystemVisitorEventArgs(string path)
        {
            Path = path;
            Abort = false;
            Exclude = false;
        }
    }
}
