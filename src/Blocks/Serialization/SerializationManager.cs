namespace Rovidi.Blocks.Serialization
{
    using System;
    using System.Linq;
    using System.Xml.Serialization;
    using System.IO;
    using System.Text;
    using System.Runtime.Serialization.Json;

    /// <summary>
    /// TODO: Provide summary section in the documentation header.
    /// </summary>
    public class SerializationManager
    {
        #region Public Methods

        #region XML Serialization

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string XmlSerialize<T>(T item)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringBuilder stringBuilder = new StringBuilder();
            using (StringWriter writer = new StringWriter(stringBuilder))
            {
                serializer.Serialize(writer, item);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string XmlSerialize(object item)
        {
            Type type = item.GetType();
            XmlSerializer serializer = new XmlSerializer(type);
            StringBuilder stringBuilder = new StringBuilder();
            using (StringWriter writer = new StringWriter(stringBuilder))
            {
                serializer.Serialize(writer, item);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(string xmlData)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(xmlData))
            {
                T entity = (T)serializer.Deserialize(reader);
                return entity;
            }
        }

        #endregion


        #region JSON Serialization

        public static string JsonSerialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            
            serializer.WriteObject(stream, obj);
            
            string retVal = Encoding.Default.GetString(stream.ToArray());
            stream.Dispose();
            
            return retVal;
        }

        public static T JsonDeserialize<T>(string json)
        {
            T obj = Activator.CreateInstance<T>();
            MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            
            obj = (T)serializer.ReadObject(stream);
            
            stream.Close();
            stream.Dispose();
            
            return obj;
        }


        #endregion


        #endregion
    }
}
