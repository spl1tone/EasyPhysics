using System;

namespace EasyPhysics.Tasks.Kinematics
{
    internal sealed class AngledMovement : StaticValues
    {
        public int? Angle { get; set; }
        public double? HalfTime { get; set; } = null;
        public double? AllTime { get; set; } = null;
        public double? V0 { get; set; } = null;
        public double? V0X { get; set; } = null;
        public double? V0Y { get; set; } = null;
        public double? Hmax { get; set; } = null;
        public double? SX { get; set; } = null;

        private const int RoundCount = 3;

        public string Formulas { get; set; }

        public void SolveTask ()
        {
            if (Angle != null) {
                if (HalfTime != null) {
                    FindAllTime();
                    FindHmax();
                    FindV0();
                    FindV0X();
                    FindV0Y();
                    FindSX();
                    Formulas = $"1. tпольоту = tпідйому * 2\n" +
                        $"2. hmax = (g * tпідйому^2) / 2\n" +
                        $"3. v0 = (g * tпідйому)/ sin({Angle})\n" +
                        $"4. v0x = v0 * cos({Angle})\n" +
                        $"5. voy = v0 * sin({Angle})\n" +
                        $"6. Sx = v0x * tпольоту\n";
                }
                else if (AllTime != null) {
                    FindHalfTime();
                    FindHmax();
                    FindV0();
                    FindV0X();
                    FindV0Y();
                    FindSX();
                    Formulas = $"1. tпідйому = tпольоту / 2\n" +
                        $"2. hmax = (g * tпідйому^2) / 2\n" +
                        $"3. v0 = (g * tпідйому)/ sin({Angle})\n" +
                        $"4. v0x = v0 * cos({Angle})\n" +
                        $"5. voy = v0 * sin({Angle})\n" +
                        $"6. Sx = v0x * tпольоту";
                }
                else if (V0 != null) {
                    FindV0X();
                    FindV0Y();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    FindSX();
                    Formulas = $"1. v0x = v0 * cos({Angle})\n" +
                        $"2. voy = v0 * sin({Angle})\n" +
                        $"3. tпідйому = v0y / g\n" +
                        $"4. tпольоту = tпідйому * 2\n" +
                        $"5. hmax = (g * tпідйому^2) / 2\n" +
                        $"6. Sx = v0x * tпольоту";
                }
                else if (V0X != null) {
                    FindV0();
                    FindV0Y();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    FindSX();
                    Formulas = $"1. v0 = v0x / cos({Angle})\n" +
                        $"2. voy = v0 * sin({Angle})\n" +
                        $"3. tпідйому = v0y / g\n" +
                        $"4. tпольоту = tпідйому * 2\n" +
                        $"5. hmax = (g * tпідйому^2) / 2\n" +
                        $"6. Sx = v0x * tпольоту";
                }
                else if (V0Y != null) {
                    FindV0();
                    FindV0X();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    FindSX();
                    Formulas = $"1. v0 = v0y / sin({Angle})\n" +
                        $"2. vox = v0 * cos({Angle})\n" +
                        $"3. tпідйому = v0y / g\n" +
                        $"4. tпольоту = tпідйому * 2\n" +
                        $"5. hmax = (g * tпідйому^2) / 2\n" +
                        $"6. Sx = v0x * tпольоту";
                }
                else if (Hmax != null) {
                    FindHalfTime();
                    FindAllTime();
                    FindV0();
                    FindV0X();
                    FindV0Y();
                    FindSX();
                    Formulas = $"1. tпідйому = √(2h/g)\n" +
                        $"2. tпольоту = tпідйому * 2\n" +
                        $"3. v0 = (g * tпідйому)/ sin({Angle})\n" +
                        $"4. vox = v0 * cos({Angle})\n" +
                        $"5. voy = v0 * sin({Angle})\n" +
                        $"6. Sx = v0x * tпольоту";
                }
                else if (SX != null) {
                    FindV0();
                    FindV0X();
                    FindV0Y();
                    FindHalfTime();
                    FindAllTime();
                    FindHmax();
                    Formulas = $"1. v0 = √(Sx * g)/ 2 * cos({Angle}) * sin({Angle})\n" +
                        $"2. vox = v0 * cos({Angle})\n" +
                        $"3. voy = v0 * sin({Angle})\n" +
                        $"4. tпідйому = v0y / g\n" +
                        $"5.tпольоту = tпідйому * 2\n" +
                        $"6. hmax = (g * tпідйому^2) / 2";
                }
            }
        }

        private void FindV0 ()
        {
            if (HalfTime != null) {
                V0 = Math.Round((G * (double)HalfTime) / DeegresForSin(), RoundCount);
            }
            else if (SX != null) {
                V0 = Math.Round(Math.Sqrt(((double)SX * G) / (2.0 * DeegresForCos() * DeegresForSin())), RoundCount);
            }
            else if (V0X != null) {
                V0 = Math.Round((double)V0X / DeegresForCos(), RoundCount);
            }
            else if (V0Y != null) {
                V0 = Math.Round((double)V0Y / DeegresForSin(), RoundCount);
            }
            // Console.WriteLine($"V0 => {V0} м/c");
        }

        private void FindV0X ()
        {
            if (V0 != null) {
                V0X = Math.Round((double)V0 * DeegresForCos(), RoundCount);
                //  Console.WriteLine($"VX0 => {VX0} м/c");
            }
        }

        private void FindV0Y ()
        {
            if (V0 != null) {
                V0Y = Math.Round((double)V0 * DeegresForSin(), RoundCount);
                //  Console.WriteLine($"VY0 => {VY0} м/c");
            }
        }



        private void FindAllTime ()
        {
            if (HalfTime != null) {
                AllTime = Math.Round(2.0 * (double)HalfTime, RoundCount);
            }
            //  Console.WriteLine($"t польоту => {AllTime} с");
        }

        private void FindSX ()
        {
            if (V0X != null && AllTime != null) {
                SX = Math.Round((double)V0X * (double)AllTime, RoundCount);
            }
            // Console.WriteLine($"S => {SX} м");
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

            // Console.WriteLine($"h max => {Hmax} м");

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
            //  Console.WriteLine($"t підйому => {HalfTime} с");
        }

        private double DeegresForSin ()
        {
            double radians = (double)Angle * (Math.PI / 180);
            double value = Math.Sin(radians);
            return Math.Round(value, RoundCount);
        }

        private double DeegresForCos ()
        {
            double radians = (double)Angle * (Math.PI / 180);
            double value = Math.Cos(radians);
            return Math.Round(value, RoundCount);
        }




        public double FindAbsoluteV (double t)
        {
            var VX = V0X;
            var VY = 0.0;
            var V = 0.0;

            if (t < HalfTime) {
                VY = Math.Round((double)V0Y - (G * t), RoundCount);
                V = Math.Round(Math.Sqrt(Math.Pow((double)VY, 2) + Math.Pow((double)VX, 2)), RoundCount);
            }
            if (t == HalfTime) {
                VY = 0.0;
            }
            if (t > HalfTime && t < AllTime) {
                VY = Math.Round((double)V0Y + (G * t), RoundCount);
                V = Math.Round(Math.Sqrt(Math.Pow((double)VY, 2) + Math.Pow((double)VX, 2)), RoundCount);
            }
            if (t >= AllTime) {
                V = 0.0;
            }
            //  Console.WriteLine($"Absolute V after {t} seconds => {V} м/c");

            return V;
        }

        public double FindAbsoluteS (double t)
        {
            var Sabsolute = 0.0;
            var VX = V0X;
            if (t <= AllTime) {
                Sabsolute = Math.Round((double)VX * t, RoundCount);
            }
            if (t > AllTime) {
                Sabsolute = (double)SX;
            }
            //  Console.WriteLine($"Absolute S after {t} seconds => {Sabsolute} м");
            return Sabsolute;
        }

        public double FindAbsoluteH (double t)
        {
            var Habsolute = 0.0;

            if (t < HalfTime) {
                Habsolute = Math.Round((double)V0Y * t - (G * Math.Pow(t, 2)) / 2, RoundCount);
            }
            if (t == HalfTime) {
                Habsolute = (double)Hmax;
            }
            if (t >= AllTime) {
                Habsolute = 0.0;
            }
            if (t > HalfTime && t <= AllTime) {
                Habsolute = Math.Round((double)V0Y * t - (G * Math.Pow(t, 2)) / 2, RoundCount);
            }

            //  Console.WriteLine($"Absolute H after {t} seconds => {Habsolute} м");

            return Habsolute;
        }

    }
}
