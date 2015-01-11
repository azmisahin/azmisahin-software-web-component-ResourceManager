using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace @as.Localization
{
    /// <summary>
    /// Stream Manager
    /// </summary>
    public class StreamManager<T>
    {
        #region Field
        private Encoding encoding = Encoding.UTF8;
        #endregion

        #region Property
        /// <summary>
        /// Deserialize By FileName
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public T Deserialize(string filename)
        {
            FileStream streamReader = new FileStream(filename, FileMode.Open);
            return getDeserialize(streamReader);
        }

        /// <summary>
        /// get Deserialize
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns></returns>
        private T getDeserialize(FileStream streamReader)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            return (T)xmlSerializer.Deserialize(streamReader);
        } 
        #endregion
    }
}
