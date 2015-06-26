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
        private string languageId { get; set; }
        private string resourceFolder { get; set; }
        private ResourceType resourceType { get; set; }
        #endregion

        #region ctor
        public LocalizationManager()
        {
            languageId = getAppKey("Localization.LanguageId");
            resourceFolder = getAppKey("Localization.ResourceFolder");
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
        public List<Models.Resource.LocaleStringResource> GetAllResources(string languageId)
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
        public string GetResource(string resourceName, string languageId)
        {
            return Repostory.Where(x => x.name == resourceName & x.languageId == languageId).FirstOrDefault().value;
        }

        /// <summary>
        /// Cgange Language
        /// </summary>
        /// <param name="languageId"></param>
        public void ChangeLang(string languageId)
        {
            this.languageId = languageId;
            Load();
        }

        public void SetResourceType(ResourceType resourceType)
        {
            this.resourceType = resourceType;
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
        private List<Models.Resource.LocaleStringResource> getData(string languageId)
        {
            Repostory = new List<Models.Resource.LocaleStringResource>();

            switch (this.resourceType)
            {
                case ResourceType.Code:
                    Repostory = getDataFromCode();
                    break;
                case ResourceType.XmlFile:
                    Repostory = getDataFromXml(languageId);
                    break;
                case ResourceType.Database:
                    Repostory = getDataFromDatabase();
                    break;
                default:
                    Repostory = getDataFromXml(languageId);
                    break;
            }

            return Repostory.Where(x => x.languageId == languageId).ToList();
        }

        /// <summary>
        /// get Data From Code
        /// </summary>
        /// <returns></returns>
        private List<Models.Resource.LocaleStringResource> getDataFromCode()
        {
            #region Base
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = "en", name = "Test.Data", value = "Test Base Language" });
            #endregion

            #region Sample
            Repostory.Add(new Models.Resource.LocaleStringResource { languageId = "tr", name = "Test.Data", value = "Örnek Bir Test Değeri" });
            #endregion

            return Repostory;
        }

        /// <summary>
        /// get Data From Xml
        /// </summary>
        /// <returns></returns>
        private List<Models.Resource.LocaleStringResource> getDataFromXml(string language)
        {
            List<Models.Resource.LocaleStringResource> result = new List<Models.Resource.LocaleStringResource>();
            string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string FullPath = BaseDirectory + resourceFolder + "Resource." + languageId + ".resx";//Resource.resx
            if (File.Exists(FullPath))
            {
                result = new StreamManager<Models.Resource.root>().Deserialize(FullPath).data.ToList();
                result = (from item in result
                          select new Models.Resource.LocaleStringResource { languageId = language, comment = item.comment, name = item.name, value = item.value })
                         .ToList();
            }
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
            string FullPath = BaseDirectory + resourceFolder;
            if (File.Exists(FullPath))
                result = new StreamManager<Models.Resource.root>().Deserialize(FullPath).data.ToList();
            return result;
        }
        #endregion
    }
}
