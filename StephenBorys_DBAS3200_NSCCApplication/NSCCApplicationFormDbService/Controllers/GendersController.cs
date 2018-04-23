using NSCCApplicationFormDataLayer;
using NSCCApplicationFormDataLayer.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
namespace SchoolDbService.Controllers
{
    public class GendersController : ODataController
    {
        NSCCApplicationDbContext db = new NSCCApplicationDbContext();
        private bool GenderExists(string key)
        {
            return db.Gender.Any(c => c.Code == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Gender> Get()
        {
            return db.Gender;
        }
        [EnableQuery]
        public SingleResult<Gender> Get([FromODataUri] string key)
        {
            IQueryable<Gender> result = db.Gender.Where(c => c.Code == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Gender gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Gender.Add(gender);
            await db.SaveChangesAsync();
            return Created(gender);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Gender> gender)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Gender.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            gender.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        //DELETE

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var course = await db.Gender.FindAsync(key);
            if (course == null)
            {
                return NotFound();
            }
            db.Gender.Remove(course);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}