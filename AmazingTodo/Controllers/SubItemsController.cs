using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AmazingTodo.Models;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AmazingTodo.Controllers
{
    public class SubItemsController : ApiController
    {
        //private SubItemsContext db = new SubItemsContext();
        private readonly AmazingTodoContext db = new AmazingTodoContext();

        // GET api/SubItems
        public IEnumerable<SubbItem> GetSubbItems()
        {
            return db.SubItems.AsEnumerable();
        }

        // GET api/SubItems/5
        public SubbItem GetSubbItem(int id)
        {
            SubbItem subbitem = db.SubItems.Find(id);
            if (subbitem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return subbitem;
        }

        // PUT api/SubItems/5
        public HttpResponseMessage PutSubbItem(int id, SubbItem subbitem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != subbitem.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(subbitem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/SubItems
        public HttpResponseMessage PostSubbItem(SubbItem subbitem)
        {
            if (ModelState.IsValid)
            {
                db.SubItems.Add(subbitem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subbitem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subbitem.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/SubItems/5
        public HttpResponseMessage DeleteSubbItem(int id)
        {
            SubbItem subbitem = db.SubItems.Find(id);
            if (subbitem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.SubItems.Remove(subbitem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, subbitem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}