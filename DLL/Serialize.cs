using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DAL
{
    public class Serialize<T> where T : class
    {

        private string fileName;
        IFormatter formatter = new BinaryFormatter();
        public Serialize(string fileName)
        {
            this.fileName = fileName;
        }

        public virtual void Save(T[] data)
        {
            using (FileStream fstream = new FileStream(fileName + ".bin", FileMode.Create))
            {
                if (data != null)
                    formatter.Serialize(fstream, data);
            }
        }

        public virtual T[] Load()
        {

            using (FileStream fstream = new FileStream(fileName + ".bin", FileMode.Open))
            {
                T[] deserializedS = (T[])formatter.Deserialize(fstream);
                return deserializedS;
            }
        }


    }
}
