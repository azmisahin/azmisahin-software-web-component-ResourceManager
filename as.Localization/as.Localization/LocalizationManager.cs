using System;
using System.Collections.Generic;
using @as.Localization.Models;
using System.Configuration;//System.Configuration.dll
using System.Linq;
using System.IO;

namespace @as.Localization
{
    /// <summary>
    /// Localization Manager
    /// </summary>
    public class LocalizationManager : iLocalizationManager
    {
        #region Field
        private List<Models.Resource.LocaleStringResource> Repostory { get; set; }
        private int languageId { get; set; }
        private string resourceFile { get; set; }
        #endregion

        #region ctor
        public LocalizationManager()
        {
            languageId = Convert.ToInt32(getAppKey("Localization.LanguageId"));
            resourceFile = getAppKey("Localization.ResourceFile");
            Load();
        }
        /// <summary>
        /// Load And ReLoad
        /// </summary>
        private void Load()
        {
            Repostory = getData(languageId);
        }
        #endregion

        #region Property
        /// <summary>
        /// Get All Resource
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public List<Models.Resource.LocaleStringResource> GetAllResources(int languageId)
        {
            return Repostory;
        }

        /// <summary>
        /// Get Resource
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public string GetResource(string resourceName)
        {
            var resource = Repostory.Where(x => x.name == resourceName).FirstOrDefault();
            string result = resource == null ? resourceName : resource.value;
            return result;
        }

        /// <summary>
        /// Get Resource By id
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        public string GetResource(string resourceName, int languageId)
        {
            return Repostory.Where(x => x.name == resourceName & x.languageId == languageId).FirstOrDefault().value;
        }

        /// <summary>
        /// Cgange Language
        /// </summary>
        /// <param name="languageId"></param>
        public void ChangeLang(int languageId)
        {
            this.languageId = languageId;
            Load();
        }
        #endregion

        #region Configuration
        /// <summary>
        /// Application Key
        /// </summary>
        /// <param name="key">appSettings Key</param>
        /// <returns>value</returns>
        private string getAppKey(string key)
        {
            var value = ConfigurationManager.AppSettings[key].ToString();
            return value;
        }
        #endregion

        #region Function
        
        /// <summary>
        /// get Data By Id
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        private List<Models.Resource.LocaleStringResource> getData(int languageId)
        {
            Repostory = new List<Models.Resource.LocaleStringResource>();
            Repostory = getDataFromCode();
            //Repostory = getDataFromXml();
            //Repostory = getDataFromDatabase();

            return Repostory.Where(x => x.languageId == languageId).ToList();
        }

        /// <summary>
        /// get Data From Code
        /// </summary>
        /// <returns></returns>
        private List<Models.Resource.LocaleStringResource> getDataFromCode()
        {
            #region English Resource
            #region Log
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = 0, name = "Data.Log", value = "Log" });
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = 0, name = "Data.Log.id", value = "Log Id" });
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = 0, name = "Data.Log.info", value = "Log Information" });
            #endregion
            #endregion

            #region Turkish Resource
            #region Log
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = 1, name = "Data.Log", value = "Log" });
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = 1, name = "Data.Log.id", value = "Log Id" });
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = 1, name = "Data.Log.info", value = "Log Bilgisi" });
            #endregion
            #endregion

            return Repostory;
        }

        /// <summary>
        /// get Data From Xml
        /// </summary>
        /// <returns></returns>
        private List<Models.Resource.LocaleStringResource> getDataFromXml()
        {
            List<Models.Resource.LocaleStringResource> result = new List<Models.Resource.LocaleStringResource>();
            string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string FullPath = BaseDirectory + resourceFile;
            if (File.Exists(FullPath))
                result = new StreamManager<Models.Resource.root>().Deserialize(FullPath).data.ToList();
            return result;
        }

        /// <summary>
        /// Database Base
        /// </summary>
        /// <returns></returns>
        private List<Models.Resource.LocaleStringResource> getDataFromDatabase()
        {
            List<Models.Resource.LocaleStringResource> result = new List<Models.Resource.LocaleStringResource>();
            string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string FullPath = BaseDirectory + resourceFile;
            if (File.Exists(FullPath))
                result = new StreamManager<Models.Resource.root>().Deserialize(FullPath).data.ToList();
            return result;
        }    
        #endregion
    }
}
