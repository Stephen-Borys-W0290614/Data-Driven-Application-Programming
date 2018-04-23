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
    public class CoursesController : ODataController
    {
        SchoolDbContext db = new SchoolDbContext();
        private bool CourseExists(int key)
        {
            return db.Courses.Any(c => c.CourseID == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //CRUD
        //GET
        [EnableQuery]
        public IQueryable<Course> Get()
        {
            return db.Courses;
        }
        [EnableQuery]
        public SingleResult<Course> Get([FromODataUri] int key)
        {
            IQueryable<Course> result = db.Courses.Where(c => c.CourseID == key);
            return SingleResult.Create(result);
        }

        //POST
        public async Task<IHttpActionResult> Post(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Courses.Add(course);
            await db.SaveChangesAsync();
            return Created(course);
        }

        //UPDATE

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Course> course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Courses.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            course.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(key))
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
            var course = await db.Courses.FindAsync(key);
            if (course == null)
            {
                return NotFound();
            }
            db.Courses.Remove(course);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}