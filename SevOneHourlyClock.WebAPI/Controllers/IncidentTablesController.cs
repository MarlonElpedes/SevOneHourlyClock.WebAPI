using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SevOneHourlyClock.WebAPI.DAL;

namespace SevOneHourlyClock.WebAPI.Controllers
{
    public class IncidentTablesController : ApiController
    {
        private IMDevDBEntities db = new IMDevDBEntities();

        // GET: api/IncidentTables
        public IQueryable<IncidentTable> GetIncidentTables()
        {
            return db.IncidentTables;
        }

        // GET: api/IncidentTables/5
        [ResponseType(typeof(IncidentTable))]
        public IHttpActionResult GetIncidentTable(int id)
        {
            IncidentTable incidentTable = db.IncidentTables.Find(id);
            if (incidentTable == null)
            {
                return NotFound();
            }

            return Ok(incidentTable);
        }

        // PUT: api/IncidentTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncidentTable(int id, IncidentTable incidentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incidentTable.id)
            {
                return BadRequest();
            }

            db.Entry(incidentTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncidentTableExists(id))
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

        // POST: api/IncidentTables
        [ResponseType(typeof(IncidentTable))]
        public IHttpActionResult PostIncidentTable(IncidentTable incidentTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IncidentTables.Add(incidentTable);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = incidentTable.id }, incidentTable);
        }

        // DELETE: api/IncidentTables/5
        [ResponseType(typeof(IncidentTable))]
        public IHttpActionResult DeleteIncidentTable(int id)
        {
            IncidentTable incidentTable = db.IncidentTables.Find(id);
            if (incidentTable == null)
            {
                return NotFound();
            }

            db.IncidentTables.Remove(incidentTable);
            db.SaveChanges();

            return Ok(incidentTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncidentTableExists(int id)
        {
            return db.IncidentTables.Count(e => e.id == id) > 0;
        }
    }
}