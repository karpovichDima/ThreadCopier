
using System;

namespace ConsoleAutofacDI.Model
{
    class Screen
    {
        public int Bright { get; set; }
        public float Size { get; set; }
        public string Resolution { get; set; }

        protected bool Equals(Screen other)
        {
            return Bright == other.Bright && Size.Equals(other.Size) && string.Equals(Resolution, other.Resolution);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Screen) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Bright;
                hashCode = (hashCode * 397) ^ Size.GetHashCode();
                hashCode = (hashCode * 397) ^ (Resolution != null ? Resolution.GetHashCode() : 0);
                return hashCode;
            }
        }

       
    }
}
