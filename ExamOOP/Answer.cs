using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public class Answer : ICloneable, IComparable<Answer>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }

        public object Clone() => new Answer(AnswerId, AnswerText);
        public int CompareTo(Answer other) => AnswerId.CompareTo(other.AnswerId);
        public override string ToString() => $"{AnswerId}: {AnswerText}";
    }
}
