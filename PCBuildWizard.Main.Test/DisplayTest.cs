using PCBuildWizard.Main.Domain.Products.Peripherals;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace TestProject1
{
    [TestClass]
    public class DisplayTest
    {
        [TestMethod]
        public void ShouldCreateDisplay()
        {
            // given
            decimal size = 24;
            DisplayResolution displayResolution = new DisplayResolution("FHD", 1920, 1080);
            PanelType panelType = PanelType.IPS;
            short refreshRate = 165;
            bool curved = false;

            //when
            Display display = new Display(size, displayResolution, panelType, refreshRate, curved);

            //then
            Assert.AreEqual(size, display.Size);
            Assert.AreEqual(displayResolution, display.Resolution);
            Assert.AreEqual(panelType, display.PanelType);
            Assert.AreEqual(curved, display.Curved);
        }

        [TestMethod]
        public void ShouldCalculatePixelsPerInch()
        {
            //Given
            DisplayResolution displayResolution = new DisplayResolution("FHD", 1920, 1080);
            Display display = new Display(24m, displayResolution, PanelType.IPS, 165, false);

            //When
            decimal pixelsPerInch = Math.Round(display.PixelsPerInch, 1);

            //Then
            Assert.AreEqual(91.8m, pixelsPerInch);
        }
    }
}
