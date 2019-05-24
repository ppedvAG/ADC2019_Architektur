using ppedv.ADC2019.Data.EF;
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

    }
}
