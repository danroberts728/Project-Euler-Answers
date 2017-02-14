using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem57Controller : Controller
    {
        // GET: Problem57
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            BigInteger numerator = 3;
            BigInteger denominator = 2;
            int count = 0;
            string results = string.Empty;

            for(int i=1;i<=1000;i++)
            {
                BigInteger n = numerator + denominator * 2;
                BigInteger d = numerator + denominator;

                if (numPlaces(numerator) > numPlaces(denominator))
                {
                    results += string.Format("{0}/{1}<br/> ", numerator, denominator);
                    count++;
                }

                numerator = n;
                denominator = d;
            }
            results = results.Substring(0, results.Length - 2);
            answer = count.ToString() + "<br/>" + results;

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        int numPlaces(BigInteger n)
        {
            if (n >= 10)
            {
                return 1 + numPlaces(n / 10);
            }
            else
            {
                return 1;
            }
        }
    }
}