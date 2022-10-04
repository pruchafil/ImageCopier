using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCopier
{
    class Copier
    {
        private byte[] _bytes;
        private string _copyPath;

        public bool IsActive { get; set; } = true;

        public Copier(byte[] bytes, string copyPath)
        {
            _bytes = bytes;
            _copyPath = copyPath;
        }

        public void Proceed()
        {
            ulong i = 0;
            while (IsActive)
            {
                File.WriteAllBytes(_copyPath + i++, _bytes);
            }
        }
    }
}
