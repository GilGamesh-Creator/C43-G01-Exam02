using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamOOP
{
    public abstract class Exam : ICloneable
    {
        public int ExamDurationMinutes { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }

        public Exam(int examDurationMinutes, int numberOfQuestions)
        {
            ExamDurationMinutes = examDurationMinutes;
            NumberOfQuestions = numberOfQuestions;
            Questions = new List<Question>();
        }

        public abstract void ShowExam();

        public void TakeExam()
        {
            Console.Clear();
            Console.WriteLine("Starting the exam...");
            var stopwatch = Stopwatch.StartNew();
            var userAnswers = new Dictionary<int, int>();
            int totalMarks = 0;

            for (int i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}:");
                Questions[i].DisplayQuestion();
                Console.Write("Your answer (enter the ID of your choice): ");
                userAnswers[i] = int.Parse(Console.ReadLine());

                if (userAnswers[i] == Questions[i].CorrectAnswerId)
                    totalMarks += Questions[i].Mark;
            }

            stopwatch.Stop();
            Console.Clear();
            Console.WriteLine("Exam finished!");

            if (this is FinalExam)
            {
                Console.WriteLine("\nYour answers:");
                for (int i = 0; i < Questions.Count; i++)
                {
                    Console.WriteLine($"\nQuestion {i + 1}:");
                    Questions[i].DisplayQuestion();
                    Console.WriteLine($"Your answer: {Questions[i].AnswerList.Find(a => a.AnswerId == userAnswers[i]).AnswerText}");
                }
                Console.WriteLine($"\nYour grade: {totalMarks} out of {CalculateTotalMarks()}");
            }
            else if (this is PracticalExam)
            {
                Console.WriteLine("\nCorrect Answers:");
                for (int i = 0; i < Questions.Count; i++)
                    Console.WriteLine($"Question {i + 1}: {Questions[i].AnswerList.Find(a => a.AnswerId == Questions[i].CorrectAnswerId).AnswerText}");
            }

            Console.WriteLine($"\nElapsed time: {stopwatch.Elapsed.ToString(@"hh\:mm\:ss")}");
        }

        private int CalculateTotalMarks()
        {
            int total = 0;
            foreach (var q in Questions) total += q.Mark;
            return total;
        }

        public object Clone() => MemberwiseClone();
    }
}
