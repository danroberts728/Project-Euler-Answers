using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;

namespace ProjectEulerAnswers.Controllers
{
    public class Problem62Controller : Controller
    {
        // GET: Problem62
        public ActionResult Index()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string answer = string.Empty;

            List<BigInteger> cubes = GetCubes(0, 10000);
            List<string> stringCubes = cubes.Select(x => string.Concat(x.ToString().OrderBy(c => c))).ToList();
            string maxRepeated = stringCubes.GroupBy(s => s)
                .Where(x => x.Count() == 5)
                .First().Key;
            int indexOfFirstPermutation = stringCubes.IndexOf(maxRepeated);
            answer = cubes[indexOfFirstPermutation].ToString();
            

            stopwatch.Stop();
            ViewBag.Answer = $"{answer}";
            ViewBag.ElapsedTime = $"{stopwatch.ElapsedMilliseconds} ms";
            stopwatch.Reset();

            return View();
        }

        private List<BigInteger> GetCubes(int start, int count)
        {
            List<BigInteger> retval = new List<BigInteger>();
            for(int i = start; i< start+count; i++)
            {
                BigInteger cube = (BigInteger) i * (BigInteger) i * (BigInteger) i;
                retval.Add(cube);
            }
            return retval;
        }
    }
}