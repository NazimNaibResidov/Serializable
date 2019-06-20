using Seralisition.Data;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Seralisition.Core
{
    public  class BinareySeralize
    {
        public static void BinarySeralize(IDataProvider pupils,string fileNameAndExstention)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileNameAndExstention, FileMode.OpenOrCreate);
            formatter.Serialize(fileStream, pupils);
            fileStream.Dispose();
        }
        public static IDataProvider BinaryDeseralize(string fileNameAndExstention)
        {
            try
            {
            FileStream fileStream = new FileStream(fileNameAndExstention,FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
             
            return  (IDataProvider) formatter.Deserialize(fileStream);

            }
            catch (FileNotFoundException )
            {
                MessageBox.Show("file Name not exists curret context");

            }
            catch(NullReferenceException e)
            {
               MessageBox.Show(e.Message);
            }
            catch(Exception e)
            {
               MessageBox.Show(e.Message);
            }
           
           throw new NullReferenceException(nameof(IDataProvider));
            

           
           

          
        }
    }
}
