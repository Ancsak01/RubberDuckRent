using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RubberDuckRent.Models;

namespace RubberDuckRent.Controllers
{
    public class CompanyApiController : ApiController
    {
        //POST
        [HttpPost]
        [Route("api/companycrud/addCompanies")]
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

        //GET
        [HttpGet]
        [Route("api/companycrud/getCompanies")]
        public IHttpActionResult getCompanies()
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    List<Database.Companies> res = new List<Database.Companies>();
                    res = entity.Companies.ToList();
                    return Ok(res);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                    throw;
                }
            }
        }

        //PUT
        [HttpPut]
        [Route("api/companycrud/updateCompanies")]
        public IHttpActionResult updateCompanies(Company model)
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    if (entity.Companies.Where(f => f.name == model.name && f.stock_of_ducks == model.stock_of_ducks).Count() > 0)
                    {
                        Database.Companies company = entity.Companies.FirstOrDefault(f => f.name == model.name && f.stock_of_ducks == model.stock_of_ducks);
                        company.name = model.name;
                        company.stock_of_ducks = model.stock_of_ducks;
                        entity.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                    throw;
                }
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/companycrud/deleteCompanies")]
        public IHttpActionResult deleteCompanies(int id)
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    if (entity.Companies.First(f => f.id == id) != null)
                    {
                        Database.Companies company = entity.Companies.First(f =>f.id == id);
                        entity.Companies.Remove(company);
                        entity.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                    throw;
                }
            }
        }
    }
    public class DuckApiController : ApiController
    {
        //POST
        [HttpPost]
        [Route("api/duckcrud/addDuck")]
        public IHttpActionResult addDuck(Duck model)
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    Database.Ducks duck = new Database.Ducks();
                    int companyId = entity.Companies.First(f => f.name == model.manufactured_by).id;
                    duck.type = model.type;
                    duck.color = model.color;
                    duck.manufactured_by = companyId;
                    entity.Ducks.Add(duck);
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

        //GET
        [HttpGet]
        [Route("api/duckcrud/getDucks")]
        public IHttpActionResult getDucks()
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    List<Database.Ducks> res = new List<Database.Ducks>();
                    res = entity.Ducks.ToList();
                    return Ok(res);
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                    throw;
                }
            }
        }

        //PUT
        [HttpPut]
        [Route("api/duckcrud/updateDuck")]
        public IHttpActionResult updateDuck(Duck model)
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    int manufacturerId = entity.Companies.First(f => f.name == model.manufactured_by).id;
                    if (entity.Ducks.Where(f => f.manufactured_by == manufacturerId && f.type == model.type && f.color == model.color).Count() > 0)
                    {
                        Database.Ducks duck = entity.Ducks.FirstOrDefault(f => f.manufactured_by == manufacturerId && f.type == model.type && f.color == model.color);
                        duck.type = model.type;
                        duck.color = model.color;
                        duck.manufactured_by = manufacturerId;
                        entity.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                    throw;
                }
            }
        }

        //DELETE
        [HttpDelete]
        [Route("api/duckcrud/deleteDuck")]
        public IHttpActionResult deleteDuck(int id)
        {
            using (Database.RubberDuckRentEntities entity = new Database.RubberDuckRentEntities())
            {
                try
                {
                    if (entity.Ducks.First(f => f.id == id) != null)
                    {
                        Database.Ducks duck = entity.Ducks.First(f => f.id == id);
                        entity.Ducks.Remove(duck);
                        entity.SaveChanges();
                        return Ok();
                    }
                    return BadRequest();
                }
                catch (Exception ex)
                {
                    return InternalServerError(ex);
                    throw;
                }
            }
        }
    }
}