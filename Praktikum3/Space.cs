using System;
using System.Collections.Generic;
using System.Text;

namespace DN3 {
    public class Space {

        const double TwoPi = 2 * Math.PI;

        static void Main(string[] args) {
            Vector omegaEarth, omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;

            InitOmegaVectors(out omegaEarth, out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth, omegaSun, omegaGalaxy, rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is " + speed + " km/s");
            Console.ReadLine();
        }

        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy) {
            // ω = 2π / T
            omegaEarth = new Vector(0, TwoPi / (24 * 3600), 0); // 24 hours in seconds
            omegaSun = new Vector(0, TwoPi / (365.25 * 24 * 3600), 0); // 365.25 days in seconds
            omegaGalaxy = new Vector(0, TwoPi / (225e6 * 365.25 * 24 * 3600), 0); // 225 million years in seconds
        }

        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            rEarth = new Vector(6370, 0, 0); // in km
            rSun = new Vector(149.6e6, 0, 0); // in km
            rGalaxy = new Vector(25_000 * 9.46e12, 0, 0); // 25,000 light years to km
        }

        public static double CalcSpeed(Vector omegaEarth, Vector omegaSun, Vector omegaGalaxy, Vector rEarth, Vector rSun, Vector rGalaxy) {
            Vector vEarth = omegaEarth * rEarth;
            Vector vSun = omegaSun * rSun;
            Vector vGalaxy = omegaGalaxy * rGalaxy;

            // Total speed
            Vector vTotal = vEarth + vSun + vGalaxy;

            // Return the magnitude (euklidische Norm) of the resulting vector
            return (double)vTotal;
        }
    }
}