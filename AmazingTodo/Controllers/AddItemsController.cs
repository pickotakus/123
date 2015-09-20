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

namespace AmazingTodo.Controllers
{
    public class AddItemsController : ApiController
    {
        //private AddItemsContext db = new AddItemsContext();
        private readonly AmazingTodoContext db = new AmazingTodoContext();

        // GET api/AddItems
        public IEnumerable<AdditionalItem> GetAdditionalItems()
        {
            return db.AddItems.AsEnumerable();
        }

        // GET api/AddItems/5
        public AdditionalItem GetAdditionalItem(int id)
        {
            AdditionalItem additionalitem = db.AddItems.Find(id);
            if (additionalitem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return additionalitem;
        }

        // PUT api/AddItems/5
        public HttpResponseMessage PutAdditionalItem(int id, AdditionalItem additionalitem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != additionalitem.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(additionalitem).State = EntityState.Modified;

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

        // POST api/AddItems
        public HttpResponseMessage PostAdditionalItem(AdditionalItem additionalitem)
        {
            if (ModelState.IsValid)
            {
                db.AddItems.Add(additionalitem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, additionalitem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = additionalitem.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/AddItems/5
        public HttpResponseMessage DeleteAdditionalItem(int id)
        {
            AdditionalItem additionalitem = db.AddItems.Find(id);
            if (additionalitem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.AddItems.Remove(additionalitem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, additionalitem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}