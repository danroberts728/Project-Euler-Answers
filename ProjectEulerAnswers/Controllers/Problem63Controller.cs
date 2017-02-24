using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem63Controller : Controller
    {
        // GET: Problem63
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            int count = 0;
            for(int n = 0; n < 1000; n++)
            {
                for(int exp = 0; exp < 100; exp++)
                {
                    BigInteger value = BigInteger.Pow(n, exp);
                    if (value != 0 && value.ToString().Length == exp)
                    {
                        count++;
                    }
                }
            }
            answer += count.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private List<BigInteger> GetAllNDigitNumbers(int n)
        {
            List<BigInteger> retval = new List<BigInteger>();
            BigInteger lowerValue = BigInteger.Pow(10, n - 1);
            BigInteger upperValue = BigInteger.Pow(10, n);
            for(BigInteger i = lowerValue; i < upperValue; i++)
            {
                retval.Add(i);
            }
            return retval;
        }
    }
}