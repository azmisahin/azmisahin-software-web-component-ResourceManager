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
        public iResourceManager SetLang(string languageId)
        {
            instance.ChangeLang(languageId);
            return this;
        }

        /// <summary>
        /// From Resource Type
        /// </summary>
        /// <param name="resourceType"></param>
        /// <returns></returns>
        public iResourceManager From(ResourceType resourceType)
        {
            instance.SetResourceType(resourceType);
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

        #region Set
        public Models.Resource.LocaleStringResource SetModel(Models.Resource.LocaleStringResource model)
        {
            return new LocalizationSetManager().SetModel(model);
        } 
        #endregion
    }
}