namespace @as.Localization
{
    /// <summary>
    /// Resource Manager
    /// </summary>
    public class ResourceManager : iResourceManager
    {
        #region Field
        private LocalizationManager instance = null;
        #endregion

        #region Ctor
        /// <summary>
        /// Resource Manager Initalize
        /// </summary>
        public ResourceManager()
        {
            instance = null != instance ? instance : new LocalizationManager();
        }
        #endregion

        #region Property
        /// <summary>
        /// Set Lang
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public iResourceManager SetLang(int languageId)
        {
            instance.ChangeLang(languageId);
            return this;
        }

        /// <summary>
        /// Get Resource
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public string Get(string resourceName)
        {
            return instance.GetResource(resourceName: resourceName);
        }

        /// <summary>
        /// Ger Resource By Model
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public string GetByModel(string tableName, string name, int primaryKey)
        {
            return name;
        }
        #endregion
    }
}