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
            Assert.AreEqual(name, displayResolution.Name);
            Assert.AreEqual(columns, displayResolution.Columns);
            Assert.AreEqual(rows, displayResolution.Rows);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotCreateDisplayResolutionWithInvalidName()
        {
            // Given
            string name = " ";
            int columns = 2560;
            int rows = 1440;

            // When, Then
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotCreateColumnsWithInvalidNumber()
        {
            // Given
            string name = "QHD";
            int columns = 0;
            int rows = 1440;

            // When, Then
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotCreateRowsWithInvalidNumber()
        {
            // Given
            string name = "QHD";
            int columns = 2560;
            int rows = -5;

            // When, Then
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);
        }

        [TestMethod]
        public void ShouldCalculateDisplayResolutionPixels()
        {
            // Given
            DisplayResolution displayResolution = new DisplayResolution("QHD", 2560, 1440);

            // When
            int pixels = displayResolution.Pixels;

            // Then
            Assert.AreEqual(3_686_400m, pixels);
        }
    }
}