using ProjectEulerAnswers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectEulerAnswers.Utility;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem70Controller : Controller
    {
        // GET: Problem70
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ProjectEulerAnswer answer = new ProjectEulerAnswer();

            List<int> primes = PrimesUtility.Generate(5000).ToList();
            primes.RemoveAll(x => x <= 2000);
            long bestN = 1;
            long bestPhi = 1;
            double bestRatio = double.PositiveInfinity;
            for(int i = 0; i < primes.Count; i++)
            {
                for(int j = 0; j < primes.Count; j++)
                {
                    long n = primes[i] * primes[j];
                    if(n > 10000000)
                    {
                        break;
                    }

                    long phi = (primes[i] - 1) * (primes[j] - 1);
                    double ratio = ((double)n) / phi;

                    if(isPerm(phi, n) && bestRatio > ratio)
                    {
                        bestN = n;
                        bestPhi = phi;
                        bestRatio = ratio;
                    }
                }
            }
            answer.Answer = bestN.ToString(); ;

            stopwatch.Stop();
            stopwatch.Reset();

            return View(answer);
        }

        private bool isPerm(long m, long n)
        {
            int[] arr = new int[10];

            long temp = n;
            while (temp > 0)
            {
                arr[temp % 10]++;
                temp /= 10;
            }

            temp = m;
            while (temp > 0)
            {
                arr[temp % 10]--;
                temp /= 10;
            }


            for (int i = 0; i < 10; i++)
            {
                if (arr[i] != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}