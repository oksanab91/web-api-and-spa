using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApiAndSPA.Controllers
{
    public class TraineesController : ApiController
    {
        private TraineeDbEntities db = new TraineeDbEntities();

        // GET: api/Trainees
        public IQueryable<Trainee> GetTrainee()
        {
            return db.Trainee;
        }

        // GET: api/Trainees/5
        [ResponseType(typeof(Trainee))]
        public IHttpActionResult GetTrainee(int id)
        {
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return NotFound();
            }

            return Ok(trainee);
        }

        // PUT: api/Trainees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrainee(int id, Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trainee.TraineeId)
            {
                return BadRequest();
            }

            db.Entry(trainee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraineeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Trainees
        [ResponseType(typeof(Trainee))]
        public IHttpActionResult PostTrainee(Trainee trainee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trainee.Add(trainee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trainee.TraineeId }, trainee);
        }

        // DELETE: api/Trainees/5
        [ResponseType(typeof(Trainee))]
        public IHttpActionResult DeleteTrainee(int id)
        {
            Trainee trainee = db.Trainee.Find(id);
            if (trainee == null)
            {
                return NotFound();
            }

            db.Trainee.Remove(trainee);
            db.SaveChanges();

            return Ok(trainee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TraineeExists(int id)
        {
            return db.Trainee.Count(e => e.TraineeId == id) > 0;
        }
    }
}