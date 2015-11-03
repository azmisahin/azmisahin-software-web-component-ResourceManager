namespace @as.Localization
{
    using System.Linq;
    /// <summary>
    /// Set Locatizaton Manager
    /// </summary>
    public class LocalizationSetManager:LocalizationManager,iLocalizationSetManager
    {
        /// <summary>
        /// Set Resource
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Models.Resource.LocaleStringResource SetModel(Models.Resource.LocaleStringResource model)
        {
            ChangeLang(model.languageId);
            var defaultValue = GetResource(model.name);
            var result = model;
            var item = Repostory
                .Where(x => x.name == model.name && x.languageId == model.languageId);
            if (item.Count() == 0)//Create
            {
                create(model);
            }
            else//update
            {
                update(model);
            }
            return result;
        }

        /// <summary>
        /// Update Resource
        /// </summary>
        /// <param name="model"></param>
        private void update(Models.Resource.LocaleStringResource model)
        {
            for (int x = 0; x < Repostory.Count;x++)
            {
                if (Repostory[x].name == model.name && Repostory[x].languageId == model.languageId)
                    {
                        Repostory[x] = model;
                        break;
                    }
            }
        }

        /// <summary>
        /// Create Resource
        /// </summary>
        /// <param name="model"></param>
        private void create(Models.Resource.LocaleStringResource model)
        {
            Repostory.Add(model);
        }
    }
}
