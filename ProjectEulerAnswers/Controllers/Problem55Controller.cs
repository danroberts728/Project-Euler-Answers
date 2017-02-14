using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem55Controller : Controller
    {
        // GET: Problem55
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            int count = 0;
            for(int n = 1; n < 10000; n++)
            {
                if(IsLychrelNumber(n))
                {
                    count++;
                }
            }
            answer = count.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();

        }

        private bool IsLychrelNumber(int n)
        {
            bool retval = true;
            BigInteger answer = n;
            for (int i = 0; i < 50; i++)
            {
                answer = ReverseAndAdd(answer);
                if(IsPalindromic(answer))
                {
                    retval = false;
                    break;
                }
            }
            return retval;
        }

        private BigInteger ReverseAndAdd(BigInteger n)
        {
            BigInteger nReverse = ReverseNumber(n);
            return n + nReverse;
        }

        private bool IsPalindromic(BigInteger n)
        {
            string nStr = n.ToString();
            return nStr == ReverseString(nStr).ToString();
        }

        private string ReverseString(string a)
        {
            char[] nChar = a.ToString().ToCharArray();
            Array.Reverse(nChar);
            return new string(nChar);
        }

        private BigInteger ReverseNumber(BigInteger n)
        {
            char[] nChar = n.ToString().ToCharArray();
            Array.Reverse(nChar);
            return BigInteger.Parse(new string(nChar));
        }
    }
}