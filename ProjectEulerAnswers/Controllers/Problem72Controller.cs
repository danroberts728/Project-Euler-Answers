using ProjectEulerAnswers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem72Controller : Controller
    {
        // GET: Problem72
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ProjectEulerAnswer answer = new ProjectEulerAnswer();

            long totalCount = 0;
            int[] counts = new int[1000001];    // e.g. counts[1000000] is number of elements when d = 1000000
            for (int d = 2; d < counts.Length; d++)
            {
                counts[d] += d - 1; // Before reduction, d has d-1 elements: 1/d, 2/d, ... (d-1)/d
                for (int j = d * 2; j < counts.Length; j += d)
                {
                    // Every multiple of d will be reduced by this number of elements
                    // i.e.: f(2) = 1, f(4) = 2. So f(8) = (8-1) - 1 - 2
                    // This will bring it below zero so we only need one pass
                    counts[j] -= counts[d];
                }
                totalCount += counts[d];
            }
            answer.Answer = totalCount.ToString();

            stopwatch.Stop();
            answer.ElapsedMs = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            return View(answer);
        }
    }
}