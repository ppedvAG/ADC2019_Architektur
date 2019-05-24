using Bogus;
using ppedv.ADC2019.Data.EF;
using ppedv.ADC2019.Model;
using ppedv.ADC2019.Model.Contracts;
using System;

namespace ppedv.ADC2019.Logic
{
    public class Core
    {
        public IRepository Repository { get; private set; }

        public Core(IRepository repo) //di in here
        {
            Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        {

        }

        public void CreateDemoData()
        {

            var kundenFaker = new Faker<Kunde>()
                                .RuleFor(x => x.Name, x => x.Name.FullName())
                                .RuleFor(x => x.GebDatum, x => x.Date.Past(40));

            var k1 = kundenFaker.Generate();
            var k2 = kundenFaker.Generate();
            var k3 = kundenFaker.Generate();

            var standortFaker = new Faker<Standort>()
                                    .RuleFor(x => x.Name, x => x.Address.City());

            var s1 = standortFaker.Generate();
            var s2 = standortFaker.Generate();

            var autoFaker = new Faker<Auto>()
                                  .RuleFor(x => x.Farbe, x => x.Commerce.Color())
                                  .RuleFor(x => x.Hersteller, x => x.Vehicle.Manufacturer())
                                  .RuleFor(x => x.Modell, x => x.Vehicle.Model());

            var a1 = autoFaker.Generate();
            var a2 = autoFaker.Generate();
            var a3 = autoFaker.Generate();

            var vm1 = new Vermietung() { StartStandort = s1, ZielStandort = s2, Auto = a1, Kunde = k1, Datum = DateTime.Now.AddDays(-15), Ende = DateTime.Now.AddDays(-11) };
            var vm2 = new Vermietung() { StartStandort = s1, ZielStandort = s1, Auto = a2, Kunde = k2, Datum = DateTime.Now.AddDays(-95), Ende = DateTime.Now.AddDays(-87) };
            var vm3 = new Vermietung() { StartStandort = s2, ZielStandort = s2, Auto = a3, Kunde = k3, Datum = DateTime.Now.AddDays(-45), Ende = DateTime.Now.AddDays(-31) };

            Repository.Add(vm1);
            Repository.Add(vm2);
            Repository.Add(vm3);

            Repository.SaveAll();

        }

    }
}
