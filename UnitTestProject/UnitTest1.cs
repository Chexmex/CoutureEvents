using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoutureEvents.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BadServiceID()
        {
            ProductModel model = new ProductModel { ServiceID = -1 };
           
        }
    }
}
