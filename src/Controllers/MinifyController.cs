using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Minify.Interfaces;
using Minify.Model;

namespace Minify.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinifyController : ControllerBase
    {
        public MinifyController(IRepository Bdd = null)
        {
            if (Bdd == null)
            {
                bdd = new MongoRepository();
            }
            else
            {
                bdd = Bdd;
            }
        }

        public IRepository bdd;
        
        [HttpPost]
        public void Add([FromBody] MinifyData data)
        {
            var id = new TokenGenerator();
            data._id = id.Generate();
            data.Key = data._id;
            bdd.Add(data);
        }

        [HttpGet]
        public IEnumerable<MinifyData> Get()
        {
            return bdd.Get();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            bdd.Delete(id);
        }
    }
}