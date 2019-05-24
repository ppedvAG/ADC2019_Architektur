using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.ADC2019.Model;

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


        [TestMethod]
        public void EfContext_CRUD_Auto()
        {
            var auto = new Auto()
            {
                Farbe = $"Blau_{Guid.NewGuid()}",
                Hersteller = "Baudi",
                Modell = "B889"
            };

            var neueFarbe = $"Rot_{Guid.NewGuid()}";

            using (var con = new EfContext())
            {
                //INSERT
                con.Autos.Add(auto);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //READ (INSERT)
                var loaded = con.Autos.Find(auto.Id);
                Assert.AreEqual(auto.Farbe, loaded.Farbe);

                //UPDATE
                loaded.Farbe = neueFarbe;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //READ (UPDATE)
                var loaded = con.Autos.Find(auto.Id);
                Assert.AreEqual(neueFarbe, loaded.Farbe);

                //DELETE
                con.Autos.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check DELETE
                var loaded = con.Autos.Find(auto.Id);
                Assert.IsNull(loaded);
            }
        }
    }
}
