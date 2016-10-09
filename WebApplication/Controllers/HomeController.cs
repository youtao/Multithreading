using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            SaveFileAsync();
            return View();
        }

        private Task SaveFileAsync()
        {
            return Task.Run(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                for (int i = 0; i < 10000000; i++) { }
                stopwatch.Stop();
                var str = string.Format("线程:{0},完成时间:{1},消耗时间:{2}毫秒",
                    Thread.CurrentThread.ManagedThreadId,
                    DateTime.Now,
                    stopwatch.ElapsedMilliseconds);
                var path = Path.Combine("d:test", Guid.NewGuid().ToString("N") + ".txt");
                System.IO.File.Create(path);

            });
        }
    }
}