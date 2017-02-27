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
        int[] Primes { get; set; }
        // GET: Problem69
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            Primes = ESieve(2, 100000);


            int maxRatio = 0;
            int maxN = 0;
            for(int n = 1; n <= 1000000; n++)
            {
                int totient = Totient(n);
                int ratio = n / totient;
                if(ratio > maxRatio)
                {
                    maxRatio = ratio;
                    maxN = n;
                }
            }
            answer = maxN.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private int Totient(int n)
        {
            int totient = n;
            int currentNum = n;
            int temp = 0;
            int p = 0;
            int p_m1 = 0;

            int i = 2;
            while (Primes[i] < n)
            {
                if (Primes[i] > currentNum)
                {
                    break;
                }
                temp = currentNum / p;
                if (temp * Primes[i] == currentNum)
                {
                    currentNum = temp;
                    i--;
                    if(p_m1 != p)
                    {
                        p_m1 = p;
                        totient -= totient / p;
                    }
                }
            }
            return totient;
        }

        public int[] ESieve(int lowerLimit, int upperLimit)
        {

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));

            if (lowerLimit < 3)
            {
                numbers.Add(2);
                lowerLimit = 3;
            }

            for (int i = (lowerLimit - 1) / 2; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }
    }
}