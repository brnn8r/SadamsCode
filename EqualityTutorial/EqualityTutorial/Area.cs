using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualityTutorial
{
    struct Area : IEquatable<Area>, IComparable<Area>, IComparable
    {
        /// <summary>
        /// The magnitude of the Area's first dimension
        /// </summary>
        public int FirstDimension { get; private set; }

        /// <summary>
        /// the magnitude of the Area's second dimentsion
        /// </summary>
        public int SecondDimension { get; private set; }

        public int Magnitude
        {
            get
            {
                return FirstDimension * SecondDimension;
            }
        }

        public Area(int firstDimension, int secondDimension) : this()
        {
            this.FirstDimension = firstDimension;
            this.SecondDimension = secondDimension;
        }
       
        public override bool Equals(object obj)
        {            
            return (obj is Area) && Equals((Area)obj);
        }

        public bool Equals(Area other)
        {
            return this.Magnitude == other.Magnitude;
        }

        public override int GetHashCode()
        {
            return FirstDimension.GetHashCode() ^ SecondDimension.GetHashCode();
        }

        public static bool operator ==(Area ab, Area xy)
        {
            return ab.Equals(xy);
        }

        public static bool operator !=(Area ab, Area xy)
        {
            return !ab.Equals(xy);
        }

        public int CompareTo(object other)
        {
            if (!(other is Area))
            {
                throw new InvalidOperationException("CompareTo: not an Area");
            }
            return CompareTo((Area)other);
        }

        public int CompareTo(Area other)
        {
            return this.Magnitude - other.Magnitude;
        }

    }
}
