using ProjectEulerAnswers.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem73Controller : Controller
    {
        // GET: Problem73
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ProjectEulerAnswer answer = new ProjectEulerAnswer();

            long totalCount = 0;
            int[] counts = new int[12001];    // e.g. counts[12000] is number of elements in the range when d = 12000
            for (int d = 5; d < counts.Length; d++) // Need to start with d=5 because we need at least one fraction that falls in here to work right
            {
                int maxNumerator = d%2==0 ? (d/2)-1 : d/2;
                int minNumerator = d%3==0 ? (d/3)+1 : d/3;
                counts[d] += maxNumerator - minNumerator; // How many numerators between 1/2 and 1/3
                for (int j = d * 2; j < counts.Length; j += d)
                {
                    // Every multiple of d will be reduced by this number of elements
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