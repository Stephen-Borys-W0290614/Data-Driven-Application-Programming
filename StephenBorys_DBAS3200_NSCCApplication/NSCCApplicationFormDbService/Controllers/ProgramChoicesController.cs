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
    public class ProgramChoicesController : ODataController
    {
        NSCCApplicationDbContext db = new NSCCApplicationDbContext();
        private bool ProgramChoiceExists(int key)
        {
            return db.ProgramChoice.Any(c => c.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<ProgramChoice> Get()
        {
            return db.ProgramChoice;
        }
        [EnableQuery]
        public SingleResult<ProgramChoice> Get([FromODataUri] int key)
        {
            IQueryable<ProgramChoice> result = db.ProgramChoice.Where(c => c.Id == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(ProgramChoice progChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.ProgramChoice.Add(progChoice);
            await db.SaveChangesAsync();
            return Created(progChoice);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<ProgramChoice> progChoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.ProgramChoice.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            progChoice.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramChoiceExists(key))
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
            var progChoice = await db.ProgramChoice.FindAsync(key);
            if (progChoice == null)
            {
                return NotFound();
            }
            db.ProgramChoice.Remove(progChoice);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}