using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem64Controller : Controller
    {
        // GET: Problem64
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            int count = 0;
            for(int n  = 1; n <= 10000; n++)
            {
                if(IsContinuedFractionOdd(n))
                {
                    count++;
                }
            }
            answer = count.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private bool IsContinuedFractionOdd(int s)
        {
            bool retval = false;
            if (Math.Sqrt(s) == Math.Floor(Math.Sqrt(s)))
            {
                retval = false;
            }
            else
            {
                int period = 0;
                int m = 0;
                int d = 1;
                int a0 = (int)Math.Floor(Math.Sqrt(s));
                int a = a0;
                do
                {
                    m = d * a - m;
                    d = (s - m * m) / d;
                    a = (a0 + m) / d;
                    period++;
                } while (a != 2 * a0);
                retval = period % 2 == 1;
            }
            return retval;
        }
    }
}