using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem60Controller : Controller
    {
        // GET: Problem60
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            List<int> primes = GeneratePrimesNaive(10000);
            foreach(int p in primes)
            {
                primesHash.Add(p);
            }
            int concatenation = 0;
            for(int a = 0; a < primes.Count; a++)
            {
                for(int b = 0; b < primes.Count; b++)
                {
                    // ab, ba
                    concatenation = int.Parse(primes[a].ToString() + primes[b].ToString());
                    if (!IsPrime(concatenation))
                    {
                        continue;
                    }
                    concatenation = int.Parse(primes[b].ToString() + primes[a].ToString());
                    if (!IsPrime(concatenation))
                    {
                        continue;
                    }

                    for (int c = 0; c < primes.Count; c++)
                    {
                        // ac, bc, ca, cb
                        concatenation = int.Parse(primes[a].ToString() + primes[c].ToString());
                        if (!IsPrime(concatenation))
                        {
                            continue;
                        }
                        concatenation = int.Parse(primes[b].ToString() + primes[c].ToString());
                        if (!IsPrime(concatenation))
                        {
                            continue;
                        }
                        concatenation = int.Parse(primes[c].ToString() + primes[a].ToString());
                        if (!IsPrime(concatenation))
                        {
                            continue;
                        }
                        concatenation = int.Parse(primes[c].ToString() + primes[b].ToString());
                        if (!IsPrime(concatenation))
                        {
                            continue;
                        }

                        for (int d = 0; d < primes.Count; d++)
                        {
                            // ad, bd, cd, da, db, dc
                            concatenation = int.Parse(primes[a].ToString() + primes[d].ToString());
                            if (!IsPrime(concatenation))
                            {
                                continue;
                            }
                            concatenation = int.Parse(primes[b].ToString() + primes[d].ToString());
                            if (!IsPrime(concatenation))
                            {
                                continue;
                            }
                            concatenation = int.Parse(primes[c].ToString() + primes[d].ToString());
                            if (!IsPrime(concatenation))
                            {
                                continue;
                            }
                            concatenation = int.Parse(primes[d].ToString() + primes[a].ToString());
                            if (!IsPrime(concatenation))
                            {
                                continue;
                            }
                            concatenation = int.Parse(primes[d].ToString() + primes[b].ToString());
                            if (!IsPrime(concatenation))
                            {
                                continue;
                            }
                            concatenation = int.Parse(primes[d].ToString() + primes[c].ToString());
                            if (!IsPrime(concatenation))
                            {
                                continue;
                            }


                            for (int e = 0; e < primes.Count; e++)
                            {
                                // ae, be, ce, de, ea, eb, ec, ed
                                concatenation = int.Parse(primes[a].ToString() + primes[e].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                concatenation = int.Parse(primes[b].ToString() + primes[e].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                concatenation = int.Parse(primes[c].ToString() + primes[e].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                concatenation = int.Parse(primes[d].ToString() + primes[e].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                concatenation = int.Parse(primes[e].ToString() + primes[a].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                concatenation = int.Parse(primes[e].ToString() + primes[b].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                concatenation = int.Parse(primes[e].ToString() + primes[c].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                concatenation = int.Parse(primes[e].ToString() + primes[d].ToString());
                                if (!IsPrime(concatenation))
                                {
                                    continue;
                                }
                                answer = (primes[a] + primes[b] + primes[c] + primes[d] + primes[e]).ToString();
                                goto breakLoops;
                            }
                        }
                    }
                }
            }
            breakLoops:
            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private bool IsPrime(int n)
        {
            if (n == 1) { return false; }
            if (n == 2) { return true; }
            if (primesHash.Contains(n)) { return true; }
            for (int i = 2; i < Math.Ceiling(Math.Sqrt(n)); ++i)
            {
                if (n % i == 0) { return false; }
            }
            primesHash.Add(n);
            return true;
        }

        HashSet<int> primesHash = new HashSet<int>();
        private List<int> GeneratePrimesNaive(int limit)
        {
            List<int> primes = new List<int>();
            primes.Add(2);
            int nextPrime = 3;
            while (nextPrime <= limit)
            {
                int sqrt = (int)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (int)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }
    }
}