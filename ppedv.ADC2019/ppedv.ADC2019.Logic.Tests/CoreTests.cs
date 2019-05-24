using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.ADC2019.Model;
using ppedv.ADC2019.Model.Contracts;

namespace ppedv.ADC2019.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben_negative_days_throw_ArgumentException()
        {
            var core = new Core(null);

            Assert.ThrowsException<ArgumentException>(() => core.GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben(-1, DateTime.Now));
        }

        [TestMethod]
        public void Core_GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben()
        {
            var repoMock = new Mock<IRepository<Kunde>>();
            repoMock.Setup(x => x.Query()).Returns(() =>
            {
                var k1 = new Kunde() { Name = "Fred" };
                k1.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-15) });
                var k2 = new Kunde() { Name = "Wilma" };
                k2.Vermietungen.Add(new Vermietung() { Ende = DateTime.Now.AddDays(-45) });

                return new[] { k1, k2 }.AsQueryable();
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepo<Kunde>()).Returns(repoMock.Object);

            var core = new Core(uowMock.Object);

            var result = core.GetAllKundenDieSeitXTagenNichtMehrGebuchtHaben(30, DateTime.Now);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Wilma", result.First().Name);

        }
    }
}
