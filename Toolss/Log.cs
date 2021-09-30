using System;
using System.IO;

namespace Toolss
{
    /// <summary>
    /// Clase singleto LOG
    /// </summary>
    public sealed class Log
    {

        private static Log _instance = null;
        private string _path ;
        private static object _protect = new object();

        public static Log GetInstance(string path) {

            lock (_protect)
            { 
                if (_instance == null)
                {
                    _instance = new Log(path); 
                }
            }
            return _instance;
        }

        private Log(string path)
        {
            _path = path;
        }


        public void Save(string message)
        {
            if(_path != null)
            File.AppendAllText(_path, message + Environment.NewLine);
        }
    }
}
