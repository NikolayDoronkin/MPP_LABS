using System;
using System.IO;

namespace SecondTask
{
    public class Data : Object
    {
        private string Old;
        private string Current;

        public string OldPath => Old;

        public string CurrentPath => Current;

        public Data(string oldPath, string currentPath)
        {
            Old = oldPath;
            Current = currentPath;
        }
    }
}