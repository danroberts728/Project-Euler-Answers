using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using ProjectEulerAnswers.Models;

namespace ProjectEulerAnswers.Controllers
{
    public class AnswersController : Controller
    {
        // GET: Answers
        public ActionResult Index(int problem)
        {
            switch (problem)
            {
                case 44:
                    return Problem44();
                case 50:
                    return Problem50();
                case 51:
                    return Problem51();
                case 54:
                    return Problem54();
                default:
                    return View();
            }
        }

        private int GetPentagonNumber(int n)
        {
            return n * (3 * n - 1) / 2;
        }

        private bool IsPentagonal(int P)
        {
            double n = (Math.Sqrt(24 * P + 1) + 1) / 6;
            return n % 1 == 0;
        }

        public ActionResult Problem44()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;
            List<int> first5000PentagonNumbers = new List<int>();
            for (int i = 1; i <= 5000; i++)
            {
                first5000PentagonNumbers.Add(GetPentagonNumber(i));
            }
            for (int k = 0; k < first5000PentagonNumbers.Count; k++)
            {
                for (int j = 0; j < k; j++)
                {
                    int sum = first5000PentagonNumbers[j] + first5000PentagonNumbers[k];
                    int diff = first5000PentagonNumbers[k] - first5000PentagonNumbers[j];
                    if (IsPentagonal(sum) && IsPentagonal(diff))
                    {
                        answer = diff.ToString();
                        break;
                    }
                }
                if (answer != string.Empty)
                {
                    break;
                }
            }
            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();
            return View("_Problem44");
        }

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

        public ActionResult Problem50()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            List<int> primesBelowAMillion = GeneratePrimesNaive(1000000);
            int primesBelowAMillionCount = primesBelowAMillion.Count;
            int primeCandidate = 0;
            int primeCandidateNumberOfTerms = 0;
            for (int startIndex = 0; startIndex < primesBelowAMillionCount; startIndex++)
            {
                int sum = 0;
                int currentIndex = startIndex;
                if (primesBelowAMillionCount - startIndex < primeCandidateNumberOfTerms)
                {
                    // We can no longer have enough prime terms to beat the current max number of terms
                    break;
                }
                while (sum < 1000000)
                {
                    int currentNumberOfTerms = currentIndex - startIndex;
                    sum += primesBelowAMillion[currentIndex];
                    if (currentNumberOfTerms > primeCandidateNumberOfTerms && primesBelowAMillion.Contains(sum))
                    {
                        // New Match!
                        primeCandidate = sum;
                        primeCandidateNumberOfTerms = currentIndex - startIndex;
                    }
                    currentIndex++;
                }
            }

            answer = primeCandidate.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();
            return View("_Problem50");
        }
        
        private void ReadPokerHands(string filepath, out List<string> player1, out List<string> player2)
        {
            player1 = new List<string>();
            player2 = new List<string>();

            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(filepath);
            while ((line = file.ReadLine()) != null)
            {
                player1.Add(line.Substring(0, 14));
                player2.Add(line.Substring(15, 14));
            }
        }

        public ActionResult Problem54()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            List<string> player1Cards, player2Cards;
            ReadPokerHands(@"c:\users\droberts\documents\visual studio 2015\Projects\ProjectEulerAnswers\ProjectEulerAnswers\data\p054_poker.txt", out player1Cards, out player2Cards);

            int player1WinsCount = 0;
            for(int i = 0; i < player1Cards.Count; i++)
            {
                Hand player1Hand = new Hand(player1Cards[i]);
                Hand player2Hand = new Hand(player2Cards[i]);
                bool player1IsWinner = player1Hand.Beats(player2Hand);
                player1WinsCount += player1IsWinner
                    ? 1
                    : 0;
            }
            answer = player1WinsCount.ToString();
            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();
            return View("_Problem54");

        }

        public ActionResult Problem51()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();
            return View("_Problem51");
        }
    }
}