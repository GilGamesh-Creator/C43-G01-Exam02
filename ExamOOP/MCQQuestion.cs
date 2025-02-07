using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark) : base(header, body, mark) { }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} [Marks: {Mark}]");
            for (int i = 0; i < AnswerList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AnswerList[i].AnswerText}");
            }
        }
    }
}
