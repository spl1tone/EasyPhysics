using System;

namespace EasyPhysics.Tasks.Kinematics
{
    internal sealed class AngledMovement : StaticValues
    {
        public int? Angle { get; set; }
        public double? HalfTime { get; set; } = null;
        public double? AllTime { get; set; } = null;
        public double? V0 { get; set; } = null;
        public double? VX0 { get; set; } = null;
        public double? VY0 { get; set; } = null;
        public double? Hmax { get; set; } = null;
        public double? S { get; set; } = null;


        private const int RoundCount = 3;

        public void SolveTask ()
        {
            if (Angle != null) {
                if (HalfTime != null) {
                    FindAllTime();
                    FindHmax();
                    FindV0();
                    FindVX0();
                    FindVY0();
                    FindS();
                }
                else if (AllTime != null) {
                    FindHalfTime();
                    FindHmax();
                    FindV0();
                    FindVX0();
                    FindVY0();
                    FindS();
                }
                else if (V0 != null) {
                    FindVX0();
                    FindVY0();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    FindS();
                }
                else if (VX0 != null) {
                    FindV0();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    FindVY0();
                    FindS();
                }
                else if (VY0 != null) {
                    FindV0();
                    FindVX0();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    FindS();
                }
                else if (Hmax != null) {
                    FindHalfTime();
                    FindAllTime();
                    FindV0();
                    FindVX0();
                    FindVY0();
                    FindS();
                }
                else if (S != null) {
                    FindV0();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    FindVX0();
                    FindVY0();
                }
            }
        }

        private void FindV0 ()
        {
            if (HalfTime != null) {
                V0 = Math.Round((G * (double)HalfTime) / DeegresForSin(), RoundCount);
            }
            else if (S != null) {
                V0 = Math.Round(Math.Sqrt(((double)S * G) / (2.0 * DeegresForCos() * DeegresForSin())), RoundCount);
            }
            else if (VX0 != null) {
                V0 = Math.Round((double)VX0 / DeegresForCos(), RoundCount);
            }
            else if (VY0 != null) {
                V0 = Math.Round((double)VY0 / DeegresForSin(), RoundCount);
            }
            Console.WriteLine($"V0 is {V0}");
        }

        private void FindVX0 ()
        {
            if (V0 != null) {
                VX0 = Math.Round((double)V0 * DeegresForCos(), RoundCount);
                Console.WriteLine($"VX0 is {VX0}");
            }
        }

        private void FindVY0 ()
        {
            if (V0 != null) {
                VY0 = Math.Round((double)V0 * DeegresForSin(), RoundCount);
                Console.WriteLine($"VY0 is {VY0}");
            }
        }



        private void FindAllTime ()
        {
            if (HalfTime != null) {
                AllTime = Math.Round(2.0 * (double)HalfTime, RoundCount);
            }
            Console.WriteLine($"All time is {AllTime}");
        }

        private void FindS ()
        {
            if (VX0 != null && AllTime != null) {
                S = Math.Round((double)VX0 * (double)AllTime, RoundCount);
            }
            Console.WriteLine($"S is {S}");
        }

        private void FindHmax ()
        {
            /* h = voy * t - gt^2 / 2
             * v = voy - g*t
             * voy = gt, hmax => v = 0
             * v0y = v0 * sin(Angle)
             * hmax = g*t^2 / 2, where t = HalfTime
             */
            if (HalfTime != null) {
                Hmax = Math.Round((G * Math.Pow((double)HalfTime, 2)) / 2, RoundCount);
            }

            Console.WriteLine($"Hmax is {Hmax}");

        }

        private void FindHalfTime ()
        {
            /*voy = gt, hmax => v = 0
             * v0y = v0 * sin(Angle)
             * 1.thalf = v0y/g 
             * 2.thalf = (v0 * sin(Angle) )/ g
             * 3.thalf = √(2h/g)
             */

            if (AllTime != null) {
                HalfTime = Math.Round((double)AllTime / 2.0, RoundCount);
            }

            else if (V0 != null) {
                HalfTime = Math.Round(((double)V0 * DeegresForSin()) / G, RoundCount);
            }

            else if (Hmax != null) {
                HalfTime = Math.Round(Math.Sqrt((2 * (double)Hmax) / G), RoundCount);
            }
            Console.WriteLine($"Half time is {HalfTime}");
        }

        private double DeegresForSin ()
        {
            // return Math.Round(((double)Angle * Math.PI) / 180.0, RoundCount);

            var result = 0.0;

            switch (Angle) {
                case 0:
                    result = 0.0;
                    break;
                case 30:
                    result = 0.5;
                    break;
                case 45:
                    result = Math.Sqrt(2) / 2.0;
                    break;
                case 60:
                    result = Math.Sqrt(3) / 2.0;
                    break;
                case 90:
                    result = 1.0;
                    break;
            }

            return Math.Round(result, RoundCount);
        }

        private double DeegresForCos ()
        {
            // return Math.Round(((double)Angle * Math.PI) / 180.0, RoundCount);

            var result = 0.0;

            switch (Angle) {
                case 0:
                    result = 1.0;
                    break;
                case 30:
                    result = Math.Sqrt(3) / 2.0;
                    break;
                case 45:
                    result = Math.Sqrt(2) / 2.0;
                    break;
                case 60:
                    result = 0.5;
                    break;
                case 90:
                    result = 0.0;
                    break;
            }

            return Math.Round(result, RoundCount);
        }


        public void FindAbsoluteV (double t)
        {
            var VX = VX0;
            var VY = 0.0;
            var V = 0.0;

            if (t < HalfTime) {
                VY = Math.Round((double)VY0 - (G * t), RoundCount);
            }
            if (t == HalfTime) {
                VY = 0.0;
            }
            if (t > HalfTime) {
                VY = Math.Round((double)VY0 + (G * t), RoundCount);
            }
            V = Math.Round(Math.Sqrt(Math.Pow((double)VY, 2) + Math.Pow((double)VX, 2)), RoundCount);

            Console.WriteLine($"Absolute V after {t} seconds => {V}");
        }

        public void AbsoluteS (double t)
        {
            var Sabsolute = 0.0;
            var VX = VX0;
            if (t < AllTime) {
                Sabsolute = Math.Round((double)VX * t, RoundCount);
            }
            Console.WriteLine($"Absolute S after {t} seconds => {Sabsolute}");
        }

    }
}
