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
    public class ProgramsController : ODataController
    {
        NSCCApplicationDbContext db = new NSCCApplicationDbContext();
        private bool ProgramExists(int key)
        {
            return db.Programs.Any(c => c.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Program> Get()
        {
            return db.Programs;
        }
        [EnableQuery]
        public SingleResult<Program> Get([FromODataUri] int key)
        {
            IQueryable<Program> result = db.Programs.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Programs.Add(program);
            await db.SaveChangesAsync();
            return Created(program);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Program> program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Programs.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            program.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(key))
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
            var program = await db.Programs.FindAsync(key);
            if (program == null)
            {
                return NotFound();
            }
            db.Programs.Remove(program);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}