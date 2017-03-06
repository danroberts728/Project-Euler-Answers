using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem69Controller : Controller
    {
        IEnumerable<int> PrimeNumbers { get; set; }

        // GET: Problem69
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;            

            PrimeNumbers = Primes(1000000);
            double result = 1;
            foreach(int p in PrimeNumbers)
            {
                if (result*p >= 1000000)
                {
                    break;
                }
                result *= p;
            }
            answer = result.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private int phi(int n)
        {
            double result = n;
            foreach(int p in PrimeNumbers)
            {
                if (p*p > n)
                {
                    break;
                }
                if(n % p == 0)
                {
                    while(n % p == 0)
                    {
                        n /= p;
                    }
                    result *= 1.0 - (1.0 / (double)p);
                }
            }
            if(n > 1)
            {
                result *= 1.0 - (1.0 / (double)n);
            }

            return (int) result;
        }

        public static IEnumerable<int> Primes(int bound)
        {
            if (bound < 2) yield break;
            //The first prime number is 2
            yield return 2;

            BitArray composite = new BitArray((bound - 1) / 2);
            int limit = ((int)(Math.Sqrt(bound)) - 1) / 2;
            for (int i = 0; i < limit; i++)
            {
                if (composite[i]) continue;
                //The first number not crossed out is prime
                int prime = 2 * i + 3;
                yield return prime;
                //cross out all multiples of this prime, starting at the prime squared
                for (int j = (prime * prime - 2) >> 1; j < composite.Count; j += prime)
                {
                    composite[j] = true;
                }
            }
            //The remaining numbers not crossed out are also prime
            for (int i = limit; i < composite.Count; i++)
            {
                if (!composite[i]) yield return 2 * i + 3;
            }
        }
    }
}