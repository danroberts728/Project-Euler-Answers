using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Numerics;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem53Controller : Controller
    {
        // GET: Problem53
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            int countValues = 0;
            for(int n = 1; n <= 100; n++)
            {
                for(int r = 1; r <= n; r++)
                {
                    BigInteger result = CalculatenCr(n, r);
                    if(result > 1000000)
                    {
                        countValues++;
                    }

                }
            }
            answer = string.Format("{0:n0}", countValues);

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private BigInteger CalculatenCr(int n, int r)
        {
            if (n < r)
            {
                throw new ArgumentOutOfRangeException();
            }
            List<int> nFactorialFactors = Enumerable.Range(1, n).ToList();
            List<int> rFactorialFactors = Enumerable.Range(1, r).ToList();
            List<int> nMinusrFactorialFactors = Enumerable.Range(1, n - r).ToList();

            List<int> numeratorFactors = nFactorialFactors;
            List<int> denomenatorFactors = rFactorialFactors.Concat(nMinusrFactorialFactors).ToList();

            // Remove common factors
            List<int> factorsToRemove = new List<int>();
            foreach(int factor in numeratorFactors)
            {
                if(denomenatorFactors.Contains(factor))
                {
                    factorsToRemove.Add(factor);
                }
            }
            foreach(int commonFactor in factorsToRemove)
            {
                numeratorFactors.Remove(commonFactor);
                denomenatorFactors.Remove(commonFactor);
            }

            if (numeratorFactors.Contains(0))
            {
                numeratorFactors.Remove(0);
            }
            if (denomenatorFactors.Contains(0))
            {
                denomenatorFactors.Remove(0);
            }
            if (!numeratorFactors.Contains(1) || numeratorFactors.Count == 0)
            {
                numeratorFactors.Add(1);
            }
            if (!denomenatorFactors.Contains(1) || numeratorFactors.Count == 0)
            {
                denomenatorFactors.Add(1);
            }

            BigInteger numerator = 1;
            foreach(int f in numeratorFactors)
            {
                numerator *= f;
            }
            BigInteger denominator = 1;
            foreach(int f in denomenatorFactors)
            {
                denominator *= f;
            }

            return numerator / denominator;
        }
    }
}