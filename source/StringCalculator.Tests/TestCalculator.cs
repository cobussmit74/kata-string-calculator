using System;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace StringKata.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        [Test]
        public void Constructor_Creates()
        {
            //Arrange
            //Act
            var actual = new Calculator();
            //Assert
            Expect(actual).To.Not.Be.Null();
        }

        private static Calculator CreateCalculator()
        {
            return new Calculator();
        }

        [Test]
        public void Add_GivenEmpty_String_Returns0()
        {
            //Arrange
            var expected = 0;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add(string.Empty);
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenOneNumber_ReturnsSameNumber()
        {
            //Arrange
            var expected = 7;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("7");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenTwoDigitNumber_ReturnsSameNumber()
        {
            //Arrange
            var expected = 72;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("72");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenTwoNumbers_WithCommaSeparator_ReturnsSum()
        {
            //Arrange
            var expected = 9;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("7,2");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenThreeNumbers_WithCommaSeparator_ReturnsSum()
        {
            //Arrange
            var expected = 15;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("7,2,6");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenThreeNumbers_WithCommaAndNewLineSeparators_ReturnsSum()
        {
            //Arrange
            var expected = 15;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("7,2\n6");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenNumbers_WithCustomSeparator_ReturnsSum()
        {
            //Arrange
            var expected = 20;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("//;\n2;18");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenNegativeNumber_ThrowsException()
        {
            //Arrange
            var expected = "Negatives not allowed";
            var calc = CreateCalculator();
            //Act
            Expect(() => calc.Add("-1"))
                .To.Throw<Exception>()
                .With.Message.Containing(expected);
        }

        [Test]
        public void Add_GivenNegativeNumber_ThrowsWithNumberInMessage()
        {
            //Arrange
            var expected = "Negatives not allowed : -1";
            var calc = CreateCalculator();
            //Act
            Expect(() => calc.Add("-1"))
                .To.Throw<Exception>()
                .With.Message.Containing(expected);
        }

        [Test]
        public void Add_GivenNegativeNumbers_ThrowsWithNumbersInMessage()
        {
            //Arrange
            var expected = "Negatives not allowed : -1,-8";
            var calc = CreateCalculator();
            //Act
            Expect(() => calc.Add("-1,-8"))
                .To.Throw<Exception>()
                .With.Message.Containing(expected);
        }

        [Test]
        public void Add_GivenNegativeAndPositiveNumbers_ThrowsWithOnlyNegNumbersInMessage()
        {
            //Arrange
            var expected = "Negatives not allowed : -1,-8";
            var calc = CreateCalculator();
            //Act
            Expect(() => calc.Add("-1,6,-8"))
                .To.Throw<Exception>()
                .With.Message.Containing(expected);
        }

        [Test]
        public void Add_GivenNumbersLargerThan1000_IgnoresThem()
        {
            //Arrange
            var expected = 4;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("4,1001");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenNumbersEqualTo1000_SumsThem()
        {
            //Arrange
            var expected = 1004;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("4,1000");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenNumbers_WithLongCustomSeparatorInBrackets_ReturnsSum()
        {
            //Arrange
            var expected = 7;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("//[;;]\n3;;4");
            //Assert
            Expect(actual).To.Equal(expected);
        }

        [Test]
        public void Add_GivenNumbers_WithMultipleLongCustomSeparatorInBrackets_ReturnsSum()
        {
            //Arrange
            var expected = 9;
            var calc = CreateCalculator();
            //Act
            var actual = calc.Add("//[;;][**]\n3;;4**2");
            //Assert
            Expect(actual).To.Equal(expected);
        }
    }
}