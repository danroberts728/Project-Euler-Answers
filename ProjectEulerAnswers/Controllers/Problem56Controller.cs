using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem56Controller : Controller
    {
        // GET: Problem56
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            BigInteger largestSum = 0;
            for(int a = 1; a<100; a++)
            {
                for(int b = 1; b<100; b++)
                {
                    BigInteger sum = SumDigits(BigInteger.Pow(a, b));
                    if(sum > largestSum)
                    {
                        largestSum = sum;
                    }
                }
            }
            answer = largestSum.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private BigInteger SumDigits(BigInteger n)
        {
            BigInteger retval = 0;
            foreach(char c in n.ToString().ToCharArray())
            {
                int digit = int.Parse(c.ToString());
                retval += digit;
            }
            return retval;
        }
    }
}