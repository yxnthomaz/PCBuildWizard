using System;

namespace PCBuildWizard.Main.Domain.Products.Peripherals
{
    public class DisplayResolution : IEquatable<DisplayResolution>
    {
        protected DisplayResolution() { }

        public DisplayResolution(string name, int columns, int rows)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentOutOfRangeException(nameof(name));

            if (columns <= 0)
                throw new ArgumentOutOfRangeException(nameof(columns));

            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));

            Name = name;
            Columns = columns;
            Rows = rows;
        }

        public virtual int Id { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual int Columns { get; protected set; }

        public virtual int Rows { get; protected set; }

        public virtual int Pixels { get { return Columns * Rows; } }

        public virtual string Description
        {
            get
            {
                return $"{Name} ({Columns} x {Rows})";
            }
        }

        public virtual bool Equals(DisplayResolution other)
        {
            if (other == null)
                return false;

            return new { Columns, Rows }.Equals(new { other.Columns, other.Rows });
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DisplayResolution);
        }

        public override int GetHashCode()
        {
            return new { Columns, Rows }.GetHashCode();
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
