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
        List<Models.Resource.LocaleStringResource> GetAllResources(int languageId);

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
        string GetResource(string resourceName, int languageId);

        /// <summary>
        /// Chaning Default Language Ad Chan
        /// </summary>
        /// <param name="languageId"></param>
        void ChangeLang(int languageId);
    }
}
