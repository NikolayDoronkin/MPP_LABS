using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace SecondTask
{
    public class FileCopier : IFileCopier
    {
        private Data _data { get; set; }
        private readonly List<string> _catalogs;

        private const int Size = 10;
        private readonly Thread[] _threadPool;
        private static int _counter = 0;

        public static int Counter => _counter;

        public FileCopier(string oldPath, string currentPath)
        {
            if (!Directory.Exists(oldPath))
            {
                throw new DirectoryNotFoundException("Old Path isn't exist");
            }

            if (!Directory.Exists(currentPath))
            {
                throw new DirectoryNotFoundException("Current Path isn't exist");
            }

            _data = new Data(oldPath, currentPath);
            _catalogs = new List<string>();
            SearchDirectories(oldPath);

            _threadPool = new Thread[Size];
            for (var index = 0; index < Size; index++)
            {
                _threadPool[index] = Thread.CurrentThread;
            }
        }

        public void CopyFiles()
        {
            CopyFilesFromDirectory(_data);
            foreach (var catalog in _catalogs)
            {
                for (var index = 0; index < _threadPool.Length; index++)
                {
                    if ((_threadPool[index].ThreadState & ThreadState.Aborted) == 0)
                    {
                        var data = new Data(_data.OldPath + catalog, _data.CurrentPath + catalog);
                        _threadPool[index] = new Thread(CopyFilesFromDirectory);
                        _threadPool[index].Start(data);
                    }
                }
            }
        }

        private void CopyFilesFromDirectory(object obj)
        {
            lock (_catalogs)
            {
                var data = (Data) obj;
                var foundFiles = Directory.GetFiles(data.OldPath);
                _counter += foundFiles.Length;
                if (!Directory.Exists(data.CurrentPath))
                {
                    Directory.CreateDirectory(data.CurrentPath);
                }

                foreach (var file in foundFiles)
                {
                    var relativePath = file.Replace(data.OldPath, "").Replace("\\", "/");
                    var curPath = data.CurrentPath + relativePath;

                    var fileInfo = new FileInfo(file);
                    fileInfo.CopyTo(curPath, true);
                }
            }
        }

        private void SearchDirectories(string path)
        {
            var foundFiles = Directory.GetDirectories(path);
            foreach (var directory in foundFiles)
            {
                var indexOf = directory.IndexOf("\\", StringComparison.Ordinal);
                var substring = directory[indexOf..];
                _catalogs.Add(substring.Replace("\\", "/"));
                SearchDirectories(directory);
            }
        }
    }
}