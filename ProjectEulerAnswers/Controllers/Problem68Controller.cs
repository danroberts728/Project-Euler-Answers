using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem68Controller : Controller
    {
        // GET: Problem68
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            int[] fiveGon = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            long largestanswerCandidate = 0;
            
            while(NextPermutation(fiveGon))
            {
                if(Is16DigitMagicFiveGon(fiveGon))
                {
                    string candidate_str = fiveGon[0].ToString() + fiveGon[1].ToString() + fiveGon[2].ToString();
                    candidate_str += fiveGon[3].ToString() + fiveGon[2].ToString() + fiveGon[4].ToString();
                    candidate_str += fiveGon[5].ToString() + fiveGon[4].ToString() + fiveGon[6].ToString();
                    candidate_str += fiveGon[7].ToString() + fiveGon[6].ToString() + fiveGon[8].ToString();
                    candidate_str += fiveGon[9].ToString() + fiveGon[8].ToString() + fiveGon[1].ToString();
                    long candidate = long.Parse(candidate_str);
                    if(candidate > largestanswerCandidate)
                    {
                        largestanswerCandidate = candidate;
                    }
                }
            }
            answer = largestanswerCandidate.ToString();

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private bool Is16DigitMagicFiveGon(int[] candidate)
        {
            bool retval = true;
            if(candidate.Length != 10)
            {
                // Can't be a 5-gon
                retval = false;
            }
            else if(candidate[0] != 10 && candidate[3] != 10 && candidate[5] != 10 && candidate[7] != 10 && candidate[9] != 10)
            {
                // Can't be 16-digit
                retval = false;
            }
            else if(candidate[0] > candidate[3] || candidate[0] > candidate[5] || candidate[0] > candidate[7] || candidate[0] > candidate[9])
            {
                // We must start with the lowest outer node, so we'll do this again
                retval = false;
            }
            else
            {
                int sum = candidate[0] + candidate[1] + candidate[2];
                if(candidate[3]+candidate[2]+candidate[4] != sum)
                {
                    retval = false;
                }
                else if(candidate[5]+candidate[4]+candidate[6] != sum)
                {
                    retval = false;
                }
                else if(candidate[7]+candidate[6]+candidate[8] != sum)
                {
                    retval = false;
                }
                else if(candidate[9]+candidate[8]+candidate[1] != sum)
                {
                    retval = false;
                }
            }
            return retval;
        }

        private bool NextPermutation(int[] numList)
        {
            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0) return false;

            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }

            var tmp = numList[largestIndex];
            numList[largestIndex] = numList[largestIndex2];
            numList[largestIndex2] = tmp;

            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                tmp = numList[i];
                numList[i] = numList[j];
                numList[j] = tmp;
            }

            return true;
        }
        
    }

}