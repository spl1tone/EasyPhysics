using EasyPhysics.Tasks.Kinematics;
using System;

namespace EasyPhysics
{
    internal static class Program
    {
        [STAThread]
        static void Main ()
        {
            /*  Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new Form1());*/

            var angeledMove = new AngledMovement() { Angle = 45, AllTime = 4 };
            angeledMove.SolveTask();
            angeledMove.FindAbsoluteV(2.0);
            Console.Read();
        }
    }
}
