using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Utilities
{
    public static class XmlSerializerTool
    {
        #region Properties
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Methods
        public static T DeserializeObjectList<T>(string xmlPath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T result;
            using (TextReader textReader = new StreamReader(xmlPath))
            {
                result = (T)serializer.Deserialize(textReader);
            }
            return result;
        }

        public static void InsertSerializedObject<T>(string xmlPath, T objectToBeSerialized)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textWriter = new StreamWriter(xmlPath))
            {
                serializer.Serialize(textWriter, objectToBeSerialized);
            }
        }
        #endregion
    }
}