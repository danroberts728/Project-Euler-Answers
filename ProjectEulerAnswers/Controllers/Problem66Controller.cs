using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem66Controller : Controller
    {
        // GET: Problem66
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            BigInteger overallMinimalX = 0;
            int bestD = 0;
            for(int D = 1; D <= 1000; D++)
            {
                BigInteger minimalX = FindMinimalSolutionInX(D);
                if(minimalX > overallMinimalX)
                {
                    overallMinimalX = minimalX;
                    bestD = D;
                }
            }
            answer = bestD.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private BigInteger FindMinimalSolutionInX(int D)
        {
            BigInteger retval = -1;
            if (Math.Sqrt(D) == Math.Floor(Math.Sqrt(D)))
            {
                // Squares don't count
                retval = -1;
            }
            else
            {
                BigInteger m = 0;
                BigInteger d = 1;
                BigInteger a0 = (int)Math.Floor(Math.Sqrt(D));
                BigInteger a = a0;
                BigInteger h_m1 = 1;
                BigInteger h = a;
                BigInteger k_m1 = 0;
                BigInteger k = 1;

                // Fundamental solution via continued fractions (Wikipedia: Pell's equation)
                // The pair (x,y) solving Pell's equation with minimal x satisfies x=h, y=k for some i
                // Find the first h convergent that solves the x**2 - D*y**2 = 1
                do
                {
                    m = d * a - m;
                    d = (D - m * m) / d;
                    a = (a0 + m) / d;

                    BigInteger h_m2 = h_m1;
                    h_m1 = h;
                    BigInteger k_m2 = k_m1;
                    k_m1 = k;

                    h = a * h_m1 + h_m2;
                    k = a * k_m1 + k_m2;

                } while (h*h - D*k*k != 1);
                retval = h;
            }
            return retval;
        }
    }
}