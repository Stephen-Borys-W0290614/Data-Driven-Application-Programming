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
    public class CitizenshipsController : ODataController
    {
        NSCCApplicationDbContext db = new NSCCApplicationDbContext();
        private bool CitizenExists(int key)
        {
            return db.Citizenship.Any(c => c.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Citizenship> Get()
        {
            return db.Citizenship;
        }
        [EnableQuery]
        public SingleResult<Citizenship> Get([FromODataUri] int key)
        {
            IQueryable<Citizenship> result = db.Citizenship.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Citizenship citizenship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Citizenship.Add(citizenship);
            await db.SaveChangesAsync();
            return Created(citizenship);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Citizenship> citizenship)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Citizenship.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            citizenship.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitizenExists(key))
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
            var course = await db.Citizenship.FindAsync(key);
            if (course == null)
            {
                return NotFound();
            }
            db.Citizenship.Remove(course);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}