using ExampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleApi.Controllers
{
    public class RolesController : ApiController
    {
        private ExampleDbEntities db = new ExampleDbEntities();

        public IHttpActionResult GetRoles()
        {
            return Ok(db.Role);
        }
    }
}
