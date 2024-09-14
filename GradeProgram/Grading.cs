namespace GradeProgram
{
    public class Grading
    {
        public string GetGrades(double? percentage)
        {
            if (percentage == 0 || percentage == null)
                throw new ArgumentException("Percentage cannot be zero and null");

            if (percentage >= 90)
                return "A";
            else if (percentage >= 80)
                return "B";
            else if (percentage >= 70)
                return "C";
            else if (percentage >= 60)
                return "D";
            else
                return "E";
        }
    }
}