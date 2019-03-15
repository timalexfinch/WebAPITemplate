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
using WebAPITemplate.Models;

namespace WebAPITemplate.Controllers
{
    /// <summary>
    /// This Controller contains a bunch of functions to access the AdventureWorks Products data
    /// </summary>
    public class ProductsController : ApiController
    {
        private AdventureWorks db = new AdventureWorks();

        // GET: api/Products
        /// <summary>
        /// Gets all the Products from the AdventureWorks Database
        /// </summary>
        /// <returns>Returns the data as a JSON list</returns>
        public IQueryable<Product> GetProducts()
        {
           // db.Configuration.ProxyCreationEnabled = false;
            return db.Products;
        }

        // GET: api/Products/5
        /// <summary>
        /// Gets just a single AdventureWorks Product
        /// </summary>
        /// <param name="id">The unique id of the product you want</param>
        /// <returns>a single product</returns>
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
           // db.Configuration.ProxyCreationEnabled = false;
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        /// <summary>
        /// Inserts a new Product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        /// <summary>
        /// Posts a Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
        }

        /// <summary>
        /// Deletes a Product
        /// </summary>
        /// <param name="id">id of the product to delete</param>
        /// <returns></returns>
        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
           // db.Configuration.ProxyCreationEnabled = false;
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
           // db.Configuration.ProxyCreationEnabled = false;
            return db.Products.Count(e => e.ProductID == id) > 0;
        }
    }
}