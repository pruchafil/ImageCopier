using System.IO;

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

            var format = _copyPath.LastIndexOf('.');
            var first = _copyPath.Substring(0, format);
            var second = _copyPath.Substring(format);

            while (IsActive)
            {
                File.WriteAllBytes(first + i++ + second, _bytes);
            }
        }
    }
}
