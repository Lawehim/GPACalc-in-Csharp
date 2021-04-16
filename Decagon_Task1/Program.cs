using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class GPAcalculator
    {
        //Let's declare a global variable of List type to hold a number of information concerning the courses offered by the user.
        static string Name = String.Empty;
        static double GPA = 0;
        static int numberOfCoursesOffered;
        static List<string> coursesOffered = new List<string>();
        static List<int> courseUnit = new List<int>();
        static List<int> score = new List<int>();
        static List<int> gradeUnit = new List<int>();
        static List<char> grade = new List<char>();


        //This method returns the username
        public static string UserName()
        {
            Console.Write("Enter your name below: ");
            try
            {
                Name = Console.ReadLine();
            }
            catch(Exception)
            {
                Console.WriteLine("An error occured");
            }
            return Name;

        }

        // This method prompt the user to itiratively enter the course name, based on the number of courses the user enter as input
        public static List<string> CourseNameAndCode()
        {
            Console.Write("How many courses do you offer? ");
            numberOfCoursesOffered = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfCoursesOffered; i++)
            {
                Console.Write("Enter course name and code here , example is Mth101: ");
                coursesOffered.Add(Console.ReadLine());
            }
            return coursesOffered;
        }


        //  This method prompt the user to itiratively enter the course unit, based on the courses the user enter as input
        public static List<int> CourseUnit()
        {
            for (int i = 1; i <= numberOfCoursesOffered; i++)
            {
                Console.Write("Enter course unit here in the order of courses entered, example, if MTH101 is 3 credits, enter 3: ");
                courseUnit.Add(int.Parse(Console.ReadLine()));
            }
            return courseUnit;
        }

        //This method prompt the user to itiratively enter the score obtained, based on the courses the user enter as input
        public static List<int> CourseScore()
        {

            for (int i = 1; i <= numberOfCoursesOffered; i++)
            {
                Console.Write("Enter score obtained here in the order of courses entered. Score should be between 0 to 100: ");
                score.Add(int.Parse(Console.ReadLine()));
            }
            return score;
        }

        //This method checks the score of the user and match it against a predefined letter grade and update the grade List.
        public static List<char> CheckGrade()
        {
            foreach (int k in score)
            {
                if (k >= 70)
                {
                    grade.Add('A');
                }
                else if (k >= 60)
                {
                    grade.Add('B');
                }
                else if (k >= 50)
                {
                    grade.Add('C');
                }
                else if (k >= 45)
                {
                    grade.Add('D');
                }
                else if (k >= 40)
                {
                    grade.Add('E');
                }
                else
                {
                    grade.Add('F');
                }
            }
            return grade;
        }

        // This method matches the score obtained with grade unit and update the gradeUnit List.
        public static List<int> CheckGradeUnit()
        {
            foreach (int k in score)
            {
                if (k >= 70)
                {
                    gradeUnit.Add(5);
                }
                else if (k >= 60)
                {
                    gradeUnit.Add(4);
                }
                else if (k >= 50)
                {
                    gradeUnit.Add(3);
                }
                else if (k >= 45)
                {
                    gradeUnit.Add(2);
                }
                else if (k >= 40)
                {
                    gradeUnit.Add(1);
                }
                else
                {
                    gradeUnit.Add(0);
                }
            }
            return gradeUnit;
        }
        //This method computes the gpa from the data obtained and returns
        public static double gpa()
        {
            int total_grade_unit, total_quality_point;
            List<int> quality_point = new List<int>();
            for (int t = 0; t < gradeUnit.Count; t++)
            {
                quality_point.Add(gradeUnit[t] * courseUnit[t]);
            }
            total_quality_point = quality_point.Sum();
            total_grade_unit = gradeUnit.Sum();
            double Gpa = total_quality_point / total_grade_unit;
            return Gpa;
        }

        //Let's draw the table and populate it
        public static void DrawTable(List<string> courseCode, List<int> courseUnit, List<Char> grade, List<int> gradeUnit, double gpa)
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Course Code   |   Course Unit   |   Grade   | GradeUnit |");
            Console.WriteLine("---------------------------------------------------------");
            for (int i = 0; i <= courseCode.Count - 1; i++)
            {
                Console.WriteLine("|       {0}     |      {1}       |    {2}      |   {3}     |", courseCode[i], courseUnit[i], grade[i], gradeUnit[i]);
            }
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("{0}, your      Gpa    is    {1}  ", Name, gpa);
        }

        //Lets run our code by calling the various methods in the main method
        static void Main(string[] args)
        {
            UserName();
            CourseNameAndCode();
            CourseUnit();
            CourseScore();
            CheckGrade();
            CheckGradeUnit();
            GPA = gpa();
            DrawTable(coursesOffered, courseUnit, grade, gradeUnit, GPA);
        }
    }
}
