namespace @as.Localization
{
    /// <summary>
    /// Resource
    /// </summary>
    public class Resource
    {
        #region Field
        private static ResourceManager instance = null;
        #endregion

        #region Property
        /// <summary>
        /// Manager Access
        /// </summary>
        public static iResourceManager Manager
        {
            get { return instance = null != instance ? instance : new ResourceManager(); }
        } 
        #endregion
    }
}
