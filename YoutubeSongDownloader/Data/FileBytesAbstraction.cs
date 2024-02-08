using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeSongDownloader.Data
{
    public class FileBytesAbstraction : TagLib.File.IFileAbstraction
    {
        private readonly MemoryStream readStream;
        private readonly MemoryStream writeStream;

        public FileBytesAbstraction(string name, byte[] bytes)
        {
            Name = name;
            readStream = new MemoryStream(bytes);
            writeStream = new MemoryStream(bytes);
        }

        public void CloseStream(Stream stream)
        {
            // Only dispose the memory stream if it's not shared
            if (stream == writeStream)
                stream.Dispose();
        }

        public string Name { get; private set; }
        public Stream ReadStream => readStream;
        public Stream WriteStream => writeStream;
    }
}
