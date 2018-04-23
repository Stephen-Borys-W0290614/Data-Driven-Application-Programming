using SchoolDbModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
namespace SchoolDbService.Controllers
{
    public class DepartmentsController : ODataController
    {
        SchoolDbContext db = new SchoolDbContext();
        private bool DepartmentExists(int key)
        {
            return db.Departments.Any(d => d.DepartmentID == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Department> Get()
        {
            return db.Courses;
        }
        [EnableQuery]
        public SingleResult<Department> Get([FromODataUri] int key)
        {
            IQueryable<Department> result = db.Courses.Where(c => c.CourseID == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Courses.Add(department);
            await db.SaveChangesAsync();
            return Created(department);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Department> department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Departments.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            department.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(key))
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
            var department = await db.Departments.FindAsync(key);
            if (department == null)
            {
                return NotFound();
            }
            db.Courses.Remove(department);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}