using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace @as.Localization.Test
{
    [TestClass]
    public class ResourceTest
    {
        [TestMethod]
        public void ResourceManagerTest()
        {
            var resultLangBase = Resource
                .Manager
                .SetLang(0)
                .Get("Data.Log.info");
            var resultLangOne = Resource
                .Manager
                .SetLang(1)
                .Get("Data.Log.info");
            Console.WriteLine(string.Format("Base : {0}  One:{1}", resultLangBase,resultLangOne));
        }
    }
}
