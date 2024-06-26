﻿using FluentAssertions;
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
            // Given
            decimal size = 24;
            DisplayResolution displayResolution = new DisplayResolution("FHD", 1920, 1080);
            PanelType panelType = PanelType.IPS;
            short refreshRate = 165;
            bool curved = false;

            // When
            Display display = new Display(size, displayResolution, panelType, refreshRate, curved);

            // Then
            display.Size.Should().Be(size);
            displayResolution.Should().Be(displayResolution);
            display.PanelType.Should().Be(panelType);
            display.Curved.Should().Be(curved);
        }

        [TestMethod]
        public void ShouldCalculatePixelsPerInch()
        {
            // Given
            DisplayResolution displayResolution = new DisplayResolution("FHD", 1920, 1080);
            Display display = new Display(24m, displayResolution, PanelType.IPS, 165, false);

            // When
            decimal pixelsPerInch = Math.Round(display.PixelsPerInch, 1);

            // Then
            pixelsPerInch.Should().Be(91.8m);
        }
    }
}
