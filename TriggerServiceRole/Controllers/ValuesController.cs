﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TriggerService;

namespace TriggerServiceRole.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post(string callback)
        {
            IFrontEndSharedState state = new FrontEnd();

            // scope
            // Trigger[] triggers

            HttpClient c = new HttpClient();
            HttpResponseMessage rsp = c.GetAsync(callback).Result;

            var rawTriggers = rsp.Content.ReadAsAsync<TriggerRaw[]>().Result;
            //var triggers = Trigger.FromWire(rawTriggers).ToArray();

            state.AddTriggers(callback, rawTriggers);
        }

        private Trigger[] Read(string content)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(string callback)
        {

        }
    }
}