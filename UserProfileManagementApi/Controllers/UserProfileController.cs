using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using UserProfileManagementApi.Data.Context;
using UserProfileManagementApi.Data.Domain;

namespace UserProfileManagementApi.Controllers
{
    [RoutePrefix("api/userprofiles")]
    public class UserProfileController : ApiController
    {
        private UserProfileDbContext db = new UserProfileDbContext();

        //[HttpPost]
        //[Route("/login")]
        //public async Task<IHttpActionResult> LoginUser(string email, string password)
        //{

        //}

        // GET: api/userprofiles
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetUserProfiles()
        {
            var userProfiles = await db.UserProfile.ToListAsync();
            return Ok(userProfiles);
        }

        // GET: api/userprofiles/5
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> GetUserProfile(int id)
        {
            var userProfile = await db.UserProfile.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return Ok(userProfile);
        }

        // POST: api/userprofiles
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> PostUserProfile(UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UserProfile.Add(userProfile);
            await db.SaveChangesAsync();

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // PUT: api/userprofiles/5
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> PutUserProfile(int id, UserProfile userProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(userProfile).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/userprofiles/5
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IHttpActionResult> DeleteUserProfile(int id)
        {
            var userProfile = await db.UserProfile.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            db.UserProfile.Remove(userProfile);
            await db.SaveChangesAsync();

            return Ok(userProfile);
        }

        private bool UserProfileExists(int id)
        {
            return db.UserProfile.Count(e => e.Id == id) > 0;
        }
    }
}