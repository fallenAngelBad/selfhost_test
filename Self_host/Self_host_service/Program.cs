﻿using Self_host_service.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace Self_host_service
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var config = new HttpSelfHostConfiguration("http://localhost:8080");

            config.MapHttpAttributeRoutes();
            
            //config.Routes.MapHttpRoute(
            //    "API Default", "api/{controller}/{id}",
            //    new { id = RouteParameter.Optional });

            
            //очистить таблицу
            //WorkerDB.TableClear("Exchangerates");

            //загрузка котировок текущего месяца
            WorkerDB.AddExchangeratesCurrentMounth();
            
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Press Enter to quit.");
                Console.ReadLine();
            }

        }
    }
}
