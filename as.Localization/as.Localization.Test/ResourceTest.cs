using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace @as.Localization.Test
{
    [TestClass]
    public class ResourceTest
    {
        [TestMethod]
        public void ResourceManagerNotingTest()
        {
            var key = "Nothing Content";
            var lang = "en";
            var result = Resource
                .Manager
                .SetLang(lang)
                .From(ResourceType.XmlFile)
                .Get(key);

            Console.WriteLine(string.Format("Lang : {0}\n Key : {1}\n Result : {2}", lang, key, result));
        }

        [TestMethod]
        public void ResourceManagerTest()
        {
            var key = "Test.Data";
            var lang = "en";
            var result = Resource
                .Manager
                .SetLang(lang)
                .From(ResourceType.XmlFile)
                .Get(key);

            Console.WriteLine(string.Format("Lang : {0}\n Key : {1}\n Result : {2}", lang, key, result));
        }

        [TestMethod]
        public void ResourceManagerTestSample()
        {
            var key = "Test.Data";
            var lang = "tr";
            var result = Resource
                .Manager
                .SetLang(lang)
                .From(ResourceType.XmlFile)
                .Get(key);

            Console.WriteLine(string.Format("Lang : {0}\n Key : {1}\n  Result : {2}", lang, key, result));
        }
    }
}
