using System;

namespace DN3 {
    public struct Vector {
        double x, y, z;

        // Konstruktor
        public Vector(double x, double y, double z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        // Indexer
        public double this[int index] {
            get {
                switch (index) {
                    case 0: return x;
                    case 1: return y;
                    case 2: return z;
                    default: throw new IndexOutOfRangeException("Index out of range.");
                }
            }
            set {
                switch (index) {
                    case 0: x = value; break;
                    case 1: y = value; break;
                    case 2: z = value; break;
                    default: throw new IndexOutOfRangeException("Index out of range.");
                }
            }
        }

        // Operationen
        public static Vector operator +(Vector a, Vector b) => new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector operator -(Vector a, Vector b) => new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector operator *(Vector a, Vector b) => new Vector(
            a.y * b.z - a.z * b.y,
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x
        );
        public static Vector operator *(Vector a, double scalar) => new Vector(a.x * scalar, a.y * scalar, a.z * scalar);
        public static Vector operator *(double scalar, Vector a) => a * scalar;
        public static Vector operator /(Vector a, double scalar) => new Vector(a.x / scalar, a.y / scalar, a.z / scalar);

        // Euklidische Norm
        public static explicit operator double(Vector a) => Math.Sqrt(a.x * a.x + a.y * a.y + a.z * a.z);
        public static implicit operator Vector(double scalar) => new Vector(scalar, 0, 0);

        public override bool Equals(object obj) {
            if (obj is Vector other) {
                return nearlyEqual(x, other.x) && nearlyEqual(y, other.y) && nearlyEqual(z, other.z);
            }
            return false;
        }

        public override int GetHashCode() {
            return x.GetHashCode() ^ y.GetHashCode() ^ z.GetHashCode();
        }

        public static bool operator ==(Vector a, Vector b) => a.Equals(b);
        public static bool operator !=(Vector a, Vector b) => !a.Equals(b);

        public override string ToString() {
            return "[" + x + ", " + y + ", " + z + "]";
        }

        // Helper function for double comparison
        private static bool nearlyEqual(double a, double b) {
            const double epsilon = 1E-10;
            const double MinNormal = 2.2250738585072014E-308d;
            double absA = Math.Abs(a);
            double absB = Math.Abs(b);
            double diff = Math.Abs(a - b);
            if (a.Equals(b)) {
                return true;
            } else if (a == 0 || b == 0 || absA + absB < MinNormal) {
                return diff < (epsilon * MinNormal);
            } else {
                return diff / (absA + absB) < epsilon;
            }
        }
    }

    internal class MainClass {
        public static void Test() {
            Vector a = new Vector(1, 2, 3);
            Vector b = new Vector(4, 5, 6);
            Vector c = a * b;
            Console.WriteLine(c);  // Expected Output: [-3.0, 6.0, -3.0]
        }

        public static void Main2(string[] args) {
            Test();
        }
    }
}
