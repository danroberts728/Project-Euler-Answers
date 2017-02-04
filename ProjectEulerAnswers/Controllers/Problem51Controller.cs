using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem51Controller : Controller
    {
        // GET: Problem51
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            List<int> permutations = new List<int>();
            int startNumber = 56003;
            int nextNumber = startNumber;
            for (int i = 0; i < 100000; ++i)
            {
                int nextPrime = GenerateNextPrime(nextNumber);
                nextNumber = nextPrime;

                string nextPrime_str = nextPrime.ToString();
                bool viableCandidate = false;
                for (int j = 0; j < nextPrime_str.Length - 3; j++)
                {
                    // to be considered, you need 3 of the same digit
                    if(nextPrime_str.Count(f => f == nextPrime_str[j]) == 3)
                    {
                        viableCandidate = true;
                        break;
                    }
                }
                if(!viableCandidate)
                {
                    continue;
                }

                int strength = ThreeDigitReplacementFamilyStrength(nextPrime, out permutations);
                if (strength >= 8)
                {
                    answer += nextPrime.ToString();
                    break;
                }
            }

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
            for (int i = 2; i < Math.Ceiling(Math.Sqrt(n)); ++i)
            {
                if (n % i == 0) { return false; }
            }
            return true;
        }

        private int GenerateNextPrime(int startNumber)
        {
            int firstNumberToTest = startNumber + 1;
            if (firstNumberToTest % 2 == 0)
            {
                // If it's even, let's adjust to next odd number
                firstNumberToTest++;
            }
            int nextCandidate = firstNumberToTest;
            while (!IsPrime(nextCandidate))
            {
                // This number is not prime, go to the next odd number
                nextCandidate += 2;
            }
            return nextCandidate;
        }

        private int ThreeDigitReplacementFamilyStrength(int n, out List<int> permutations)
        {
            permutations = new List<int>();
            string n_str = n.ToString();
            int firstIndex = -1;
            int secondIndex = -1;
            int thirdIndex = -1;

            // Find the 3 digits to replace
            for (int j = 0; j < n_str.Length - 3; j++)
            {
                // to be considered, you need 3 of the same digit
                if (n_str.Count(f => f == n_str[j]) == 3)
                {
                    firstIndex = n_str.IndexOf(n_str[j]);
                    secondIndex = n_str.IndexOf(n_str[j], firstIndex + 1);
                    thirdIndex = n_str.IndexOf(n_str[j], secondIndex + 1);
                    break;
                }
            }
            if(firstIndex == secondIndex || secondIndex == thirdIndex || firstIndex == thirdIndex)
            {
                throw new ArgumentException();
            }

            int strength = 0;
            for(int i = 0; i < 10; i++)
            {
                char i_str = i.ToString().ToCharArray()[0];
                StringBuilder sb = new StringBuilder(n_str);
                sb[firstIndex] = i_str;
                sb[secondIndex] = i_str;
                sb[thirdIndex] = i_str;
                int test_int = int.Parse(sb.ToString());
                if(IsPrime(test_int) && test_int.ToString().Length == n_str.Length) // Ignore leading zero numbers
                {
                    permutations.Add(test_int);
                    strength++;
                }
            }
            return strength;
        }
    }
}