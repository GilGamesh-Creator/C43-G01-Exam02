using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, int mark) : base(header, body, mark) { }
        
        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}: {Body} [Marks: {Mark}]");
            Console.WriteLine("1 - True");
            Console.WriteLine("2 - False");
        }
    }
}
