using ProjectEulerAnswers.Models;
using ProjectEulerAnswers.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem71Controller : Controller
    {
        // GET: Problem71
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ProjectEulerAnswer answer = new ProjectEulerAnswer();

            answer.Answer = FindLeftOfThreeSevenths().Numerator.ToString();


            stopwatch.Stop();
            answer.ElapsedMs = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            return View(answer);
        }

        private Rational FindLeftOfThreeSevenths()
        {
            Rational threeSevenths = new Rational(3, 7);
            for (int d = 999999; d > 1; d--)
            {
                for (int n = d - 1; n > 0; n--)
                {
                    Rational number = new Rational(n, d);
                    if (number < threeSevenths)
                    {
                        return number;

                    }
                }
            }
            return new Rational(1, 2);
        }
    }
}