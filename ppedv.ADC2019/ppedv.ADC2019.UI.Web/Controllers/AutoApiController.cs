using ppedv.ADC2019.Logic;
using ppedv.ADC2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ppedv.ADC2019.UI.Web.Controllers
{
    public class AutoApiController : ApiController
    {
        Core core = new Core();
        // GET: api/AutoApi
        public IEnumerable<Auto> Get()
        {
            return core.UnitOfWork.AutoRepository.GetAll();
        }

        // GET: api/AutoApi/5
        public Auto Get(int id)
        {
            return core.UnitOfWork.AutoRepository.GetById(id);
        }

        // POST: api/AutoApi
        public void Post([FromBody]Auto auto)
        {
            core.UnitOfWork.AutoRepository.Add(auto);
            core.UnitOfWork.SaveAll();
        }

        // PUT: api/AutoApi/5
        public void Put(int id, [FromBody]Auto auto)
        {
            core.UnitOfWork.AutoRepository.Update(auto);
            core.UnitOfWork.SaveAll();
        }

        // DELETE: api/AutoApi/5
        public void Delete(int id)
        {
            var loaded = core.UnitOfWork.AutoRepository.GetById(id);
            if (loaded != null)
            {
                core.UnitOfWork.AutoRepository.Delete(loaded);
                core.UnitOfWork.SaveAll();
            }

        }
    }
}
