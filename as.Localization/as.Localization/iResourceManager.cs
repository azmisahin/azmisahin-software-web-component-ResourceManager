namespace @as.Localization
{
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
        iResourceManager SetLang(int languageId);

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
    }
}
