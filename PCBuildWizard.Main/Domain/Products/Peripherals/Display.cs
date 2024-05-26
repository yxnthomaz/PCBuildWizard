using System;

namespace PCBuildWizard.Main.Domain.Products.Peripherals
{
    public class Display : IEquatable<Display>
    {
        protected Display() { }

        public Display(decimal size, DisplayResolution resolution, PanelType panelType, short refreshRate, bool curved)
        {
            if (size <= 0m)
                throw new ArgumentOutOfRangeException(nameof(size));

            if (resolution == null)
                throw new ArgumentNullException(nameof(resolution));

            if (!Enum.IsDefined(typeof(PanelType), panelType))
                throw new ArgumentOutOfRangeException(nameof(panelType));

            if (refreshRate <= 0)
                throw new ArgumentOutOfRangeException(nameof(refreshRate));

            Size = size;
            Resolution = resolution;
            PanelType = panelType;
            RefreshRate = refreshRate;
            Curved = curved;
        }

        public virtual decimal Size { get; protected set; }

        public virtual DisplayResolution Resolution { get; protected set; }

        public virtual PanelType PanelType { get; protected set; }

        public virtual short RefreshRate { get; protected set; }

        public virtual bool Curved { get; protected set; }

        public virtual decimal PixelsPerInch { get { return Resolution.Rows / Height; } }

        public virtual decimal AspectRatio { get { return (decimal)Resolution.Columns / Resolution.Rows; } }

        public virtual decimal Height
        {
            get
            {
                return Size / (decimal)Math.Sqrt(Math.Pow((double)AspectRatio, 2.0) + 1);
            }
        }

        public virtual decimal Width { get { return AspectRatio * Height; } }

        public virtual decimal Area { get { return Height * Width; } }

        public virtual bool Equals(Display other)
        {
            if (other == null)
                return false;

            return new { Size, Resolution, PanelType, RefreshRate }
                .Equals(new { other.Size, other.Resolution, other.PanelType, other.RefreshRate });
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Display);
        }

        public override int GetHashCode()
        {
            return new { Size, Resolution, PanelType, RefreshRate }.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Size} {Resolution}";
        }
    }
}
