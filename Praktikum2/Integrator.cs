using System;

namespace DN2 {
    class MainClass {
        const int STEPS = 100;
        const double EPS = 1E-5;
    
        public static void Main(string[] args) {
            Console.WriteLine("Linear fixed [0..10]: "+Integrator.Integrate(x => x,  0,10,STEPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Linear fixed [5..15]: "+Integrator.Integrate(x => x,  5,15,STEPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Linear adapt [0..10]: "+Integrator.Integrate(x => x,   0,10,EPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Square fixed [0..10]: "+Integrator.Integrate(x => x*x, 0,10,STEPS)+" steps: "+Integrator.Steps);
            Console.WriteLine("Square adapt [0..10]: "+Integrator.Integrate(x => x*x, 0,10,EPS)+" steps: "+Integrator.Steps);
            Console.ReadLine();
        }
    }
  
    public class Integrator {
        public static int Steps;

        public static double Integrate(Func<double, double> f, double start, double end, int steps) {
            double stepSize = (end - start) / steps;
            double sum = 0.5 * (f(start) + f(end));

            for (int i = 1; i < steps; i++) {
                sum += f(start + i * stepSize);
            }

            return sum * stepSize;
        }

  
        public static double Integrate(Func<double, double> f, double start, double end, double eps) {
            double integralOld = 0.0, integralNew;
            int steps = 1;
            double stepSize;

            do {
                steps *= 2;
                stepSize = (end - start) / steps;
                integralNew = 0.5 * (f(start) + f(end));

                for (int i = 1; i < steps; i++) {
                    integralNew += f(start + i * stepSize);
                }

                integralNew *= stepSize;

                if (Math.Abs(integralNew - integralOld) <= eps) {
                    break;
                }

                integralOld = integralNew;

            } while (true);  // Diese Schleife wird abgebrochen, sobald die Bedingung im Inneren erfüllt ist

            Steps = steps;

            return integralNew;
        }


    }

}