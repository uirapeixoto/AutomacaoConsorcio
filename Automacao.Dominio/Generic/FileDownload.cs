using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Automacao.Domain.Generic
{
    public class FileDownload
    {

        public string Name { get; set; }
        public string TypeName { get; set; }
        public int Lenght { get; set; }
        public byte[] ByteFile { get; set; }
    }
}
