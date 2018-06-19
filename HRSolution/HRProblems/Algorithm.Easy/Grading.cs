using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRProblems;

namespace Algorithm.Easy.HRProblems
{
    public class Grading : IProblem
    {
        public string Run()
        {
            int[] grades = { 100, 99, 92,37, 85, 73, 67, 38, 33, 94 };
            int[] adjusted = gradingStudents(grades);
            string printable = String.Join(",", adjusted);
            return printable;
        }

        private static int[] gradingStudents(int[] grades)
        {
            int[] newGrades = new int[grades.Length];
            for (int i = 0; i < grades.Length; i++)
            {
                newGrades[i] = AdjustGrade(grades[i]);
            }
            return newGrades;
        }

        private static int AdjustGrade(int grade)
        {
            //it would be nice to memoize this...
            if (grade < 38)
                return grade;

            if (grade % 5 == 0)
                return grade;

            int distanceToNextMultiple = 0;
            while ((grade + distanceToNextMultiple) % 5 != 0)
            {
                distanceToNextMultiple++;
            }

            int adjusted = (distanceToNextMultiple < 3) ? grade + distanceToNextMultiple : grade;
            return adjusted;
        }

        
    }
}
