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
    public class CampusesController : ODataController
    {
        NSCCApplicationDbContext db = new NSCCApplicationDbContext();
        private bool CampusExists(int key)
        {
            return db.Campuss.Any(c => c.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Campus> Get()
        {
            return db.Campuss;
        }
        [EnableQuery]
        public SingleResult<Campus> Get([FromODataUri] int key)
        {
            IQueryable<Campus> result = db.Campuss.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Campus campus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Campuss.Add(campus);
            await db.SaveChangesAsync();
            return Created(campus);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Campus> campus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Campuss.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            campus.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampusExists(key))
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
            var course = await db.Campuss.FindAsync(key);
            if (course == null)
            {
                return NotFound();
            }
            db.Campuss.Remove(course);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}