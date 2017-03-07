using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEulerAnswers.Models
{
    public class ProjectEulerAnswer
    {
        public string Answer { get; set; }
        public double ElapsedMs { get; set; }

        public override string ToString()
        {
            return Answer.ToString();
        }
    }
}