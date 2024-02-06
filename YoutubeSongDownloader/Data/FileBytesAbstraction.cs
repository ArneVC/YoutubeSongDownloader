using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSongDownloader.Data
{
    public class FileBytesAbstraction : TagLib.File.IFileAbstraction
    {
        public FileBytesAbstraction(string name, byte[] bytes)
        {
            Name = name;

            var stream = new MemoryStream(bytes);
            ReadStream = stream;
            WriteStream = stream;
        }
        public void CloseStream(Stream stream)
        {
            stream.Dispose();
        }
        public string Name { get; private set; }
        public Stream ReadStream { get; private set; }
        public Stream WriteStream { get; private set; }
    }
}
