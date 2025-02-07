using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public class FinalExam : Exam
    {
        public FinalExam(int duration, int count) : base(duration, count) { }
        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam ({ExamDurationMinutes} minutes):");
            foreach (var q in Questions) q.DisplayQuestion();
        }
    }
}
