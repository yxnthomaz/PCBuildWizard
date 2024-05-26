using System;

namespace PCBuildWizard.Main.Domain.Products.Shared
{
    public class Range<T> : IEquatable<Range<T>> where T : struct, IComparable<T>
    {
        public T Begin { get; protected set; }

        public T End { get; protected set; }

        public Range(T begin, T end)
        {
            /* TODO: validations */

            Begin = begin;
            End = end;
        }

        public bool Contains(T point)
        {
            return Begin.CompareTo(point) <= 0 && End.CompareTo(point) >= 0;
        }

        public bool Equals(Range<T> other)
        {
            if (other == null)
                return false;

            return new { Begin, End }
                .Equals(new { other.Begin, other.End });
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Range<T>);
        }

        public override int GetHashCode()
        {
            return new { Begin, End }.GetHashCode();
        }
    }
}
