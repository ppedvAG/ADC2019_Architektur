using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.ADC2019.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_database()
        {
            //Arrange
            var con = new EfContext();
            if (con.Database.Exists())
                con.Database.Delete();

            //Act
            con.Database.Create();

            //Assert
            Assert.IsTrue(con.Database.Exists());
        }
    }
}
