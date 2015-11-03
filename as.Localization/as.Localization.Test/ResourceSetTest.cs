using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace @as.Localization.Test
{
    [TestClass]
    public class ResourceSetTest
    {
        [TestMethod]
        public void ResourceManagerTest()
        {
            var key = "Test.Data";
            var lang = "en";
            var result = Resource
                .Manager
                .SetModel(
                new Models.Resource.LocaleStringResource
                {
                    name = key,
                    languageId = lang,
                    value = "Test.Data Value",
                    comment = "Test.Data Commmet"
                });

            Console.WriteLine(string.Format("Lang : {0}\n Key : {1}\n Result : {2}", lang, key, result));
        }

        [TestMethod]
        public void ResourceManagerTestSample()
        {
            var key = "Test.Data";
            var lang = "tr";
            var result = Resource
                .Manager
                .SetModel(
                new Models.Resource.LocaleStringResource
                {
                    name = key,
                    languageId = lang,
                    value = "Test.Veri Değer",
                    comment = "Test.Veri Açıklama"
                });

            Console.WriteLine(string.Format("Lang : {0}\n Key : {1}\n Result : {2}", lang, key, result));
        }
    }
}
