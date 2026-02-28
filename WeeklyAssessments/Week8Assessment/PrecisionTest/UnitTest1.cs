using Week8Assessment;

namespace PrecisionTest
{
    public class Tests
    {
        private EmployeeBonus emp;

        [SetUp]
        public void Setup()
        {
            emp = new EmployeeBonus();
        }

        //[Test]
        //public void aadi()
        //{
        //    Assert.Pass();
        //}
        [TestCase(500000,5,6,1.1,95,123200)]
        [TestCase(400000, 4, 8, 1.0, 80, 60480)]
        [TestCase(1000000, 5, 15, 1.5, 95, 280000)]
        [TestCase(0, 5, 6, 1.1, 95, 0)]
        [TestCase(300000, 2, 3, 1.0, 90, 13500)]
        [TestCase(600000, 3, 0, 1.0, 100, 64800)]
        [TestCase(900000, 5, 11, 1.2, 100, 226800)]
        [TestCase(555555, 4, 6, 1.13, 92, 118649.88)]
        public void Test(decimal baseSalary, int rating, int experience, decimal multiplier,
                         double attendancePercentage, decimal expected)
        {
            emp.BaseSalary = baseSalary;
            emp.PerformanceRating = rating;
            emp.YearsOfExperience = experience;
            emp.DepartmentMultiplier = multiplier;
            emp.AttendancePercentage = attendancePercentage;

            var result = emp.NetAnnualBonus;
            Assert.That(result, Is.EqualTo(expected));
        }

        
        
    }
}
