using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace EcuriesDuLoupWin
{
    public class BinarySerialiserManager<T> : SerialiserManager<T>
    {
        public String FilePath { get; set; }

        private BinaryFormatter formatter;

        public BinarySerialiserManager()
        {
            this.formatter = new BinaryFormatter(); 
        }

        public T Get()
        {
            T t;
            this.formatter = new BinaryFormatter();
            FileStream fs = null;
            try
            {
                fs = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read);
                 t=  (T)this.formatter.Deserialize(fs);
            }
            catch
            {
                t = default(T);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return t;
        }

        public void Save(T t)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(this.FilePath, FileMode.OpenOrCreate, FileAccess.Write);
                this.formatter.Serialize(fs, t);
            }
            catch
            {
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}
