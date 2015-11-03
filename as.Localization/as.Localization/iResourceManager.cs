namespace @as.Localization
{
    /// <summary>
    /// Resource Type
    /// </summary>
    public enum ResourceType
    {        
        /// <summary>
        /// inline Code
        /// </summary>
        Code = 0,
        
        /// <summary>
        /// Xml File
        /// </summary>
        
        XmlFile,
        /// <summary>
        /// Database
        /// </summary>
        Database
    }

    /// <summary>
    /// Resource Manager Interface
    /// </summary>
    public interface iResourceManager
    {
        /// <summary>
        /// Set Lang
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        iResourceManager SetLang(string languageId);

        /// <summary>
        /// From Resource Type
        /// Default XmlFile = 1
        /// </summary>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        iResourceManager From(ResourceType resourceType);

        /// <summary>
        /// Get Resource
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        string Get(string resourceName);

        /// <summary>
        /// Get Resource By ---
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        string GetByModel(string tableName, string name, int primaryKey);

        /// <summary>
        /// Set Resource
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        @as.Localization.Models.Resource.LocaleStringResource SetModel(@as.Localization.Models.Resource.LocaleStringResource model);
    }
}
