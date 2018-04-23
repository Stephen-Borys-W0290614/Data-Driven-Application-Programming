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
using System.Web.OData.Routing;

namespace SchoolDbService.Controllers
{
    public class ProvinceStatesController : ODataController
    {
        NSCCApplicationDbContext db = new NSCCApplicationDbContext();
        private bool ProvinceStateExists(string key, string key2)
        {
            return db.ProvinceState.Any(c => c.Code == key && c.CountryCode == key2);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<ProvinceState> Get()
        {
            return db.ProvinceState;
        }
        [EnableQuery]
        [ODataRoute("ProvinceStates(Code={key1},CountryCode={key2})")]
        public SingleResult<ProvinceState> Get([FromODataUri] string key1, [FromODataUri] string key2)
        {
            IQueryable<ProvinceState> result = db.ProvinceState.Where(c => c.Code == key1 
            && c.CountryCode == key2);
            return SingleResult.Create(result);
        }


        //POST
        public async Task<IHttpActionResult> Post(ProvinceState provinceState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.ProvinceState.Add(provinceState);
            await db.SaveChangesAsync();
            return Created(provinceState);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] string key, string key2, Delta<ProvinceState> provinceState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.ProvinceState.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            provinceState.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinceStateExists(key, key2))
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


        [ODataRoute("ProvinceStates(Code={key1},CountryCode={key2})")]
        public async Task<IHttpActionResult> Delete([FromODataUri] string key1, [FromODataUri] string key2)
        {
            var ProvinceStates = await db.ProvinceState.FindAsync(key1, key2);
            if (ProvinceStates == null)
            {
                return NotFound();
            }
            db.ProvinceState.Remove(ProvinceStates);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }//End Delete
    }
}