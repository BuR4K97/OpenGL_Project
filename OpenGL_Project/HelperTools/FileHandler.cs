using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OpenGL_Project.HelperTools
{
    class FileHandler : IDisposable
    {
        private readonly string _filePath;
        private readonly Encoding _encoding;
        private string _sourceData;

        public FileHandler(string filePath, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            this._filePath = filePath;
            this._encoding = encoding;
            this._sourceData = null;
        }

        public bool ExtractData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(_filePath, _encoding))
                {
                    _sourceData = reader.ReadToEnd();
                }
                return true;
            }
            catch (IOException exception) { Console.WriteLine(exception.Message); }
            return false;
        }

        public string GetSourceData()
        {
            if (_sourceData == null) throw new NullSourceDataException();
            return _sourceData;
        }

        public void SetSourceData(string sourceData)
        {
            this._sourceData = sourceData;
        }

        public bool OverrideData()
        {
            if (_sourceData == null) throw new NullSourceDataException();

            try
            {
                using (StreamWriter writer = new StreamWriter(_filePath, false, _encoding))
                {
                    writer.Write(_sourceData);
                }
                return true;
            }
            catch (IOException exception) { Console.WriteLine(exception.Message); }
            return false;
        }

        public void Dispose() {}
    }
}
