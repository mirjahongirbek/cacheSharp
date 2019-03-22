using Microsoft.AspNetCore.Http;
using System;

using System.Threading.Tasks;
using Entity;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Cache.Middleware
{
    public class AddMiddleware
    {
        private readonly RequestDelegate _next;
       // TimeService _timeService;

        public AddMiddleware(RequestDelegate next)
        {
            _next = next;
           // _timeService = timeService;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Method!="POST" || context.Request.Path.Value.ToLower() != "/add")
            {
                await _next.Invoke(context);
            }
            else
            {
                Run(context);
            }
        }
        private void Run(HttpContext context)
        {
          
            using (var reader = new StreamReader(context.Request.Body))
            {
                //reader.read
               var array= reader.ReadToEnd();
               var data= Newtonsoft.Json.JsonConvert.DeserializeObject<AddModal>(array);
                foreach(var i in data.Data)
                {
                    var tip=i.Value.GetType();
                    if(i.Value is System.String)
                    {
                        continue;
                    }
                    else if(i.Value is Newtonsoft.Json.Linq.JArray)
                    {
                       var arrrr= (Newtonsoft.Json.Linq.JArray)i.Value;
                        Console.WriteLine("Array"+array[0]);
                    }
                    else if(i.Value is Newtonsoft.Json.Linq.JObject)
                    {
                       var item= (JObject)i.Value;
                        Console.WriteLine("Object ");
                    }
                }
                

                Console.WriteLine(data.Id);
            }
               
        }
    }

}
