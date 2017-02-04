using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem95Controller : Controller
    {
        private Dictionary<int,int> SumOfDivisors { get; set; }
        private HashSet<int> KnownChainLinks { get; set; }

        // GET: Problem95
        public ActionResult Index()
        {
            SumOfDivisors = new Dictionary<int, int>();
            KnownChainLinks = new HashSet<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            List<int> longestChain = new List<int>();
            List<int> currentChain = new List<int>();
            
            for (int i = 2; i < 1000000; i++)
            {
                if(KnownChainLinks.Contains(i))
                {
                    // We've already been down this road
                    continue;
                }
                if (IsAmicableChainBelowOneMillion(i, out currentChain))
                {
                    if(currentChain.Count > longestChain.Count)
                    {
                        longestChain = currentChain;
                    }
                }
                KnownChainLinks.UnionWith(currentChain);
            }
            answer = longestChain[0].ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private int CalculateSumOfDivisors(int n)
        {
            if(!SumOfDivisors.ContainsKey(n))
            {
                SumOfDivisors[n] = GetProperDivisors(n).Sum();
            }
            return SumOfDivisors[n];
        }

        private bool IsAmicableChainBelowOneMillion(int n, out List<int> chain)
        {
            chain = new List<int>();
            bool retval = false;

            int currentElement = n;
            while (currentElement < 1000000)
            {
                chain.Add(currentElement);

                if (currentElement == n && chain.Count > 1)
                {
                    retval = true;
                    break;
                }

                if (chain.Count(f => f == currentElement) > 1)
                {
                    // Converging to 0 or to an endless cycle
                    KnownChainLinks.UnionWith(chain);
                    chain.Clear();
                    return false;
                }

                currentElement = CalculateSumOfDivisors(currentElement);
            }

            return retval;
        }

        private List<int> GetProperDivisors(int n)
        {
            List<int> retval = new List<int>();
            for(int i = 1; i <= n/2; i++)
            {
                if(n % i == 0)
                {
                    retval.Add(i);
                }
            }
            return retval;
        }
    }
}