using System.Collections.Generic;
using @as.Localization.Models;

namespace @as.Localization
{
    /// <summary>
    /// Localization Manager
    /// </summary>
    public interface iLocalizationManager
    {
        /// <summary>
        /// Get All Resources
        /// </summary>
        /// <param name="languageId"></param>
        /// <returns></returns>
        List<Models.Resource.LocaleStringResource> GetAllResources(string languageId);

        /// <summary>
        /// Get Resource Name
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        string GetResource(string resourceName);

        /// <summary>
        /// Get Resource Name And Id
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="languageId"></param>
        /// <returns></returns>
        string GetResource(string resourceName, string languageId);

        /// <summary>
        /// Chaning Default Language Ad Chan
        /// </summary>
        /// <param name="languageId"></param>
        void ChangeLang(string languageId);

        /// <summary>
        /// Set Resource Type
        /// Default XmlFile = 1
        /// </summary>
        /// <param name="resourceType"></param>
        void SetResourceType(ResourceType resourceType);
    }
}
