using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class FilePacker
    {
        private readonly Packer packer;

        public FilePacker(Packer packer)
        {
            this.packer = packer;
        }

        public void Packed (string inputFilePath,  string outputFilePath, CancellationToken cancellationToken)
        {
            FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            FileStream outputStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            packer.Pack(inputStream, outputStream, cancellationToken);
        }

        public void UnPacked (string inputFilePath, string outputFilePath, CancellationToken cancellationToken)
        {
            FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            FileStream outputStream = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write);

            packer.UnPack(inputStream, outputStream, cancellationToken);
        }
    }
}
