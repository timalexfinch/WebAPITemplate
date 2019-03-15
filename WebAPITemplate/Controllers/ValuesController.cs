using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITemplate.Controllers
{
    /// <summary>
    /// This is the example Controller provided by Microsoft. 
    /// </summary>
    public class ValuesController : ApiController
    {

        /// <summary>
        /// A function to get a list of names
        /// </summary>
        /// <returns>Returns an array of strings</returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "alan", "helen" };
        }

        /// <summary>
        /// A function to generate the word "Sausages!"
        /// </summary>
        /// <param name="id">Give me a number</param>
        /// <returns>Sausages!</returns>
        public string Get(int id)
        {
            return "Sausages!";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
