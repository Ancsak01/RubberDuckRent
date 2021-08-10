using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RubberDuckRent.Models;

namespace RubberDuckRent.Controllers
{
    public class RentalApiController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        [Route("api/rental/addCompanies")]
        public IHttpActionResult addCompanies(Company model)
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    Database.Companies company = new Database.Companies();
                    company.name = model.name;
                    company.stock_of_ducks = model.stock_of_ducks;
                    entity.Companies.Add(company);
                    entity.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                    throw;
                }
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}