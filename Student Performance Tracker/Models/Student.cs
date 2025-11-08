using System;
using System.ComponentModel.DataAnnotations;

namespace StudentPerformanceWeb.Models
{
    public class Student
    {
        public static int TotalStudents = 0; //Static variable
        public readonly string SchoolName = "ABC High School"; //Read-only variable

        [Required]
        public int ID { get; set; } //Instance variable

        [Required]
        public string Name { get; set; }

        [Range(0, 100)]
        public float MathMarks { get; set; }

        [Range(0, 100)]
        public float ScienceMarks { get; set; }

        [Range(0, 100)]
        public float EnglishMarks { get; set; }

        public Student()
        {
            TotalStudents++;
        }

        public float CalculateAverage()
        {
            float avg = (MathMarks + ScienceMarks + EnglishMarks) / 3; //Local variable
            return avg;
        }

        public string GetGrade()
        {
            float avg = CalculateAverage();
            string grade;

            if (avg >= 90)
            {
                if (avg > 95)
                    grade = "A+";
                else
                    grade = "A";
            }
            else if (avg >= 75)
                grade = "B";
            else if (avg >= 60)
                grade = "C";
            else
                grade = "D";

            return grade;
        }

        public string GetRemarks()
        {
            switch (GetGrade())
            {
                case "A+": return "Outstanding!";
                case "A": return "Excellent!";
                case "B": return "Very Good!";
                case "C": return "Good.";
                default: return "Needs Improvement.";
            }
        }
    }
}
