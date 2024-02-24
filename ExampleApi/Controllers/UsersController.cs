using ExampleApi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleApi.Controllers
{
    public class UsersController : ApiController
    {
        private ExampleDbEntities db = new ExampleDbEntities();

        public IHttpActionResult GetUsers()
        {
            return Ok(db.User);
        }

        public IHttpActionResult PutUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult PostUser(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return Ok();
        }
    }
}
