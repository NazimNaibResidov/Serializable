using Seralisition.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Seralisition.Core
{
   public class XmlSeralize
    {
        public static void Seralize(IDataProvider provider,string fileNameWithOutExtension)
        {
            
           
            FileStream stream = new FileStream(fileNameWithOutExtension+".xml", FileMode.OpenOrCreate);

            XmlSerializer serializer = new XmlSerializer(provider.GetType());
            serializer.Serialize(stream, provider);
            stream.Dispose();
        }
        public static IDataProvider DeSeraliz(IDataProvider provider, string fileNameWithOutExtension)
        {

            try
            {
                FileStream stream = new FileStream(fileNameWithOutExtension + ".xml", FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(IDataProvider));
                var objects = serializer.Deserialize(stream);
                stream.Dispose();
                return (IDataProvider)objects;
            }
            catch (FileNotFoundException )
            {

                MessageBox.Show("the file name not exists pleace tyr agen ");
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("file can not find");
            }
            throw new NullReferenceException(nameof(IDataProvider));

           
        }
    }
}
