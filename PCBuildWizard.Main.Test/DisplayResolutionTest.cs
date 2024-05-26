using PCBuildWizard.Main.Domain.Products.Peripherals;

namespace TestProject1
{
    [TestClass]
    public class DisplayResolutionTest
    {
        [TestMethod]
        public void ShouldCreateDisplayResolution()
        {
            //given
            string name = "QHD";
            int columns = 2560;
            int rows = 1440;

            //when
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);

            //then
            Assert.AreEqual(name, displayResolution.Name);
            Assert.AreEqual(columns, displayResolution.Columns);
            Assert.AreEqual(rows, displayResolution.Rows);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotCreateDisplayResolutionWithInvalidName()
        {
            //given
            string name = " ";
            int columns = 2560;
            int rows = 1440;

            //when, then
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotCreateColumnsWithInvalidNumber()
        {
            //given
            string name = "QHD";
            int columns = 0;
            int rows = 1440;

            //when, then
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldNotCreateRowsWithInvalidNumber()
        {
            //given
            string name = "QHD";
            int columns = 2560;
            int rows = -5;

            //when, then
            DisplayResolution displayResolution = new DisplayResolution(name, columns, rows);
        }

        [TestMethod]
        public void ShouldCalculateDisplayResolutionPixels()
        {

            //given
            DisplayResolution displayResolution = new DisplayResolution("QHD", 2560, 1440);

            //when
            int pixels = displayResolution.Pixels;

            //then
            Assert.AreEqual(3_686_400m, pixels);
        }
    }
}