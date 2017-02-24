using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem61Controller : Controller
    {
        List<int> triangleNumbers = GetAllFourDigitTriangleNumbers();
        List<int> squareNumbers = GetAllFourDigitSquareNumbers();
        List<int> pentagonalNumbers = GetAllFourDigitPentagonalNumbers();
        List<int> hexagonalNumbers = GetAllFourDigitHexagonalNumbers();
        List<int> heptagonalNumbers = GetAllFourDigitHeptagonalNumbers();
        List<int> octagonalNumbers = GetAllFourDigitOctagonalNumbers();

        // GET: Problem61
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            foreach (int firstNumber in triangleNumbers)
            {
                List<int> superList = squareNumbers.Concat(pentagonalNumbers).Concat(hexagonalNumbers).Concat(heptagonalNumbers).Concat(octagonalNumbers).ToList();

                int firstNumberFirstTwo = firstNumber / 100;
                int firstNumberLastTwo = firstNumber % 100;
                // First is abcd. Find cdef
                foreach(int secondNumber in superList.Where(x => x > firstNumberLastTwo * 100 && x < (firstNumberLastTwo+1)*100))
                {
                    int secondNumberLastTwo = secondNumber % 100;
                    // Second number is cdef. Find efgh
                    foreach (int thirdNumber in superList.Where(x => x > secondNumberLastTwo * 100 && x < (secondNumberLastTwo + 1) * 100))
                    {
                        int thirdNumberLastTwo = thirdNumber % 100;
                        // Third number is efgh. Find ijkl
                        foreach (int fourthNumber in superList.Where(x => x > thirdNumberLastTwo * 100 && x < (thirdNumberLastTwo + 1) * 100))
                        {
                            int fourthNumberLastTwo = fourthNumber % 100;
                            foreach (int fifthNumber in superList.Where(x => x > fourthNumberLastTwo * 100 && x < (fourthNumberLastTwo + 1) * 100))
                            {
                                int fifthNumberLastTwo = fifthNumber % 100;
                                foreach (int sixthNumber in superList.Where(x => x > fifthNumberLastTwo * 100 && x < (fifthNumberLastTwo + 1) * 100))
                                {
                                    int sixthNumberLastTwo = sixthNumber % 100;
                                    if (sixthNumberLastTwo == firstNumberFirstTwo)
                                    {
                                        if(AllNumbersInUniqueSequences(firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber, sixthNumber))
                                        {
                                            answer = (firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber + sixthNumber).ToString();
                                            goto Foo;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }
            Foo:

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private bool AllNumbersInUniqueSequences(int first, int second, int third, int fourth, int fifth, int sixth)
        {
            bool retval = false;
            List<int> allNumbers = new List<int> { first, second, third, fourth, fifth, sixth };

            List<int> ts = triangleNumbers.Where(x => allNumbers.Contains(x)).ToList();
            List<int> ss = squareNumbers.Where(x => allNumbers.Contains(x)).ToList();
            List<int> ps = pentagonalNumbers.Where(x => allNumbers.Contains(x)).ToList();
            List<int> hxs = hexagonalNumbers.Where(x => allNumbers.Contains(x)).ToList();
            List<int> hps = heptagonalNumbers.Where(x => allNumbers.Contains(x)).ToList();
            List<int> os = octagonalNumbers.Where(x => allNumbers.Contains(x)).ToList();

            ts.RemoveAll(x => ss.Contains(x) || ps.Contains(x) || hxs.Contains(x) || hps.Contains(x) || os.Contains(x));
            ss.RemoveAll(x => ts.Contains(x) || ps.Contains(x) || hxs.Contains(x) || hps.Contains(x) || os.Contains(x));
            ps.RemoveAll(x => ts.Contains(x) || ss.Contains(x) || hxs.Contains(x) || hps.Contains(x) || os.Contains(x));
            hxs.RemoveAll(x => ts.Contains(x) || ss.Contains(x) || ps.Contains(x) || hps.Contains(x) || os.Contains(x));
            hps.RemoveAll(x => ts.Contains(x) || ss.Contains(x) || hxs.Contains(x) || hxs.Contains(x) || os.Contains(x));
            os.RemoveAll(x => ts.Contains(x) || ss.Contains(x) || ps.Contains(x) || hxs.Contains(x) || hps.Contains(x));

            retval = ts.Count == 1 && ss.Count == 1 && ps.Count == 1 && hxs.Count == 1 && hps.Count == 1 && os.Count == 1;

            return retval;
        }

        private List<int> ItemsWithFirstTwo(List<int> sequence, int firstTwo)
        {
            List<int> retval = new List<int>();
            retval = sequence.Where(x => x > firstTwo * 100 && x < (firstTwo + 1) * 100).ToList();
            return retval;
        }

        private static List<int> GetAllFourDigitTriangleNumbers()
        {
            List<int> retval = new List<int>();
            int n = 1;
            int value = 0;
            while(value < 10000)
            {
                value = n * (n + 1) / 2;
                if(value > 999 && value < 10000)
                {
                    retval.Add(value);
                }
                n++;
            }

            return retval;
        }

        private static List<int> GetAllFourDigitSquareNumbers()
        {
            List<int> retval = new List<int>();
            int n = 1;
            int value = 0;
            while (value < 10000)
            {
                value = n * n;
                if (value > 999 && value < 10000)
                {
                    retval.Add(value);
                }
                n++;
            }

            return retval;
        }

        private static List<int> GetAllFourDigitPentagonalNumbers()
        {
            List<int> retval = new List<int>();
            int n = 1;
            int value = 0;
            while (value < 10000)
            {
                value = n * (3 * n - 1) / 2;
                if (value > 999 && value < 10000)
                {
                    retval.Add(value);
                }
                n++;
            }

            return retval;
        }

        private static List<int> GetAllFourDigitHexagonalNumbers()
        {
            List<int> retval = new List<int>();
            int n = 1;
            int value = 0;
            while (value < 10000)
            {
                value = n * (2 * n - 1);
                if (value > 999 && value < 10000)
                {
                    retval.Add(value);
                }
                n++;
            }

            return retval;
        }

        private static List<int> GetAllFourDigitHeptagonalNumbers()
        {
            List<int> retval = new List<int>();
            int n = 1;
            int value = 0;
            while (value < 10000)
            {
                value = n * (5 * n - 3) / 2;
                if (value > 999 && value < 10000)
                {
                    retval.Add(value);
                }
                n++;
            }

            return retval;
        }

        private static List<int> GetAllFourDigitOctagonalNumbers()
        {
            List<int> retval = new List<int>();
            int n = 1;
            int value = 0;
            while (value < 10000)
            {
                value = n * (3 * n - 2);
                if (value > 999 && value < 10000)
                {
                    retval.Add(value);
                }
                n++;
            }

            return retval;
        }
    }

}