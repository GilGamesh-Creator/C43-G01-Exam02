using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ExamOOP
{       
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Do you want to Create an exam? (y/n): ");
            if (Console.ReadLine().ToLower() != "y") return;

            Console.Clear();
            Console.Write("Exam type (1: Final, 2: Practical): ");
            int examType = int.Parse(Console.ReadLine());

            Console.Write("Duration (minutes): ");
            int duration = int.Parse(Console.ReadLine());

            Console.Write("Number of questions: ");
            int qCount = int.Parse(Console.ReadLine());

            Exam exam = examType == 1 ? new FinalExam(duration, qCount) : new PracticalExam(duration, qCount);

            for (int i = 0; i < qCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"Question {i + 1}:");

                if (exam is FinalExam)
                {
                    Console.Write("Choose Question type (1: T/F, 2: MCQ): ");
                    int qType = int.Parse(Console.ReadLine());
                    ProcessQuestion(exam, qType == 1);
                }
                else
                {
                    ProcessQuestion(exam, false);
                }
            }

            Console.Clear();
            Console.Write("Do you want to Begin the exam? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.Clear();
                exam.TakeExam();
            }
        }

        static void ProcessQuestion(Exam exam, bool isTrueFalse)
        {
            Console.Write("Header of Question: ");
            string header = Console.ReadLine();

            Console.Write("Body of Question: ");
            string body = Console.ReadLine();

            Console.Write("Marks: ");
            int marks = int.Parse(Console.ReadLine());

            Question q;
            if (isTrueFalse)
            {
                q = new TrueFalseQuestion(header, body, marks);
                q.AnswerList.Add(new Answer(1, "True"));
                q.AnswerList.Add(new Answer(2, "False"));
            }
            else
            {
                q = new MCQQuestion(header, body, marks);
                Console.Write("Number of options: ");
                int optCount = int.Parse(Console.ReadLine());

                for (int j = 0; j < optCount; j++)
                {
                    Console.Write($"Option {j + 1}: ");
                    q.AnswerList.Add(new Answer(j + 1, Console.ReadLine()));
                }
            }

            Console.Write(isTrueFalse ?
                "Correct answer ID (1=True, 2=False): " :
                "Correct answer ID: ");
            q.CorrectAnswerId = int.Parse(Console.ReadLine());

            exam.Questions.Add(q);
        }
    }
}
