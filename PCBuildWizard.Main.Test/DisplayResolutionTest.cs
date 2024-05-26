using FluentAssertions;
using PCBuildWizard.Main.Domain.Products.Peripherals;

namespace TestProject1
{
    [TestClass]
    public class DisplayResolutionTest
    {
        [TestMethod]
        public void ShouldCreateDisplayResolution()
        {
            // Given
            string name = "QHD";
            int columns = 2560;
            int rows = 1440;

            // When
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);

            // Then
            displayResolution.Name.Should().Be(name);
            displayResolution.Columns.Should().Be(columns);
            displayResolution.Rows.Should().Be(rows);
        }

        [TestMethod]
        public void ShouldNotCreateDisplayResolutionWithInvalidName()
        {
            // Given
            string name = " ";
            int columns = 2560;
            int rows = 1440;

            // When
            var action = () => new DisplayResolution(name, columns, rows);

            // Then
            action.Should().ThrowExactly<ArgumentOutOfRangeException>();

        }

        [TestMethod]
        public void ShouldNotCreateColumnsWithInvalidNumber()
        {
            // Given
            string name = "QHD";
            int columns = 0;
            int rows = 1440;

            // When
            var action = () => new DisplayResolution(name, columns, rows);

            // Then
            action.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void ShouldNotCreateRowsWithInvalidNumber()
        {
            // Given
            string name = "QHD";
            int columns = 2560;
            int rows = -5;

            // When
            var action = () => new DisplayResolution(name, columns, rows);

            // Then
            action.Should().ThrowExactly<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void ShouldCalculateDisplayResolutionPixels()
        {
            // Given
            DisplayResolution displayResolution = new DisplayResolution("QHD", 2560, 1440);

            // When
            int pixels = displayResolution.Pixels;

            // Then
            pixels.Should().Be(3_686_400);
        }
    }
}