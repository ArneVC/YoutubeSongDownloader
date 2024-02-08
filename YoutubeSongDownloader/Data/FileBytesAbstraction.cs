using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSongDownloader.Data
{
    public class FileBytesAbstraction : TagLib.File.IFileAbstraction
    {
        private readonly byte[] bytes;
        public FileBytesAbstraction(string name, byte[] bytes)
        {
            Name = name;
            this.bytes = bytes;
        }
        public void CloseStream(Stream stream)
        {
            if (stream is MemoryStream memoryStream)
                memoryStream.Dispose();
        }
        public string Name { get; private set; }
        public Stream ReadStream => new MemoryStream(bytes);
        public Stream WriteStream => new MemoryStream(bytes.Length);
    }
}
