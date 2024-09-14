using GradeProgram;

namespace Grade.Test
{
    public class GradeTest
    {
        private readonly Grading gradeUnit;

        public GradeTest()
        {
            gradeUnit = new Grading();
        }

        [Fact]
        public void GetGrades_GivenPercentage_ReturnsGrade()
        {
            //Arrange
            double percentage = 20.0;
            string expected = "E";

            //Act
            string actual = gradeUnit.GetGrades(percentage);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetGrades_GivenPercentage_IsNull_ThrowsException()
        {
            //Arrange
            double? percentage = null;

            //Act
            //Assert
            Assert.Throws<ArgumentException>(()=> gradeUnit.GetGrades(percentage));
        }

        [Fact]
        public void GetGrades_GivenPercentage_IsZero_ThrowsException()
        {
            //Arrange
            double? percentage = 0;

            //Act
            //Assert
            ArgumentException exception = Assert.Throws<ArgumentException>(() => gradeUnit.GetGrades(percentage));
            Assert.Equal("Percentage cannot be zero and null", exception.Message);
        }
    }
}