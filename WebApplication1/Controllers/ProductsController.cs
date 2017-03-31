using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return repository.GetAll();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        // POST: api/Products
        public void Post([FromBody]Product value)
        {
            repository.Add(value);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product value)
        {
            value.Id = id;
            if (!repository.Update(value))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
            repository.Remove(id);
        }
    }
}
