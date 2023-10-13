using EasyPhysics.Tasks.Kinematics;
using System.Windows.Forms;

namespace EasyPhysics
{
    public partial class AngledMove : Form
    {
        public AngledMove ()
        {
            InitializeComponent();
        }

        private void solve_button_Click (object sender, System.EventArgs e)
        {
            var angle = int.Parse(Angle_text.Text);


            var task = new AngledMovement() {
                Angle = string.IsNullOrEmpty(Angle_text.Text) ? (int?)null : int.Parse(Angle_text.Text),
                HalfTime = string.IsNullOrEmpty(HalfT_text.Text) ? (double?)null : double.Parse(HalfT_text.Text),
                AllTime = string.IsNullOrEmpty(AllT_text.Text) ? (double?)null : double.Parse(AllT_text.Text),
                V0 = string.IsNullOrEmpty(v0_text.Text) ? (double?)null : double.Parse(v0_text.Text),
                V0X = string.IsNullOrEmpty(v0x_text.Text) ? (double?)null : double.Parse(v0x_text.Text),
                V0Y = string.IsNullOrEmpty(v0y_text.Text) ? (double?)null : double.Parse(v0y_text.Text),
                Hmax = string.IsNullOrEmpty(hmax_text.Text) ? (double?)null : double.Parse(hmax_text.Text),
                SX = string.IsNullOrEmpty(sx_text.Text) ? (double?)null : double.Parse(sx_text.Text)
            };

            task.SolveTask();


            if (!string.IsNullOrEmpty(t1_text.Text)) {
                var t = double.Parse(t1_text.Text);
                var absoluteV = task.FindAbsoluteV(t);
                var absoluteS = task.FindAbsoluteS(t);
                var absoluteH = task.FindAbsoluteH(t);

                output_text.Text = $"Кут = {task.Angle}\nt підйому = {task.HalfTime} с\nt польоту = {task.AllTime} с\n" +
               $"v0 = {task.V0} м/c\nv0x = {task.V0X} м/c\nv0y = {task.V0Y} м/c\n" +
               $"hmax = {task.Hmax} м\nsx = {task.SX} м" +
               $"\nv({t1_text.Text}) = {absoluteV} м/c\ns({t1_text.Text}) = {absoluteS} м\nh({t1_text.Text}) = {absoluteH} м";
            }
            else {
                output_text.Text = $"Кут = {task.Angle}\nt підйому = {task.HalfTime} с\nt польоту = {task.AllTime} с\n" +
               $"v0 = {task.V0} м/c\nv0x = {task.V0X} м/c\nv0y = {task.V0Y} м/c\n" +
               $"hmax = {task.Hmax} м\nsx = {task.SX} м";
            }


        }

        private void clear_button_Click (object sender, System.EventArgs e)
        {
            output_text.Text = string.Empty;
            Angle_text.Text = string.Empty;
            HalfT_text.Text = string.Empty;
            AllT_text.Text = string.Empty;
            v0_text.Text = string.Empty;
            v0x_text.Text = string.Empty;
            v0y_text.Text = string.Empty;
            hmax_text.Text = string.Empty;
            sx_text.Text = string.Empty;
            t1_text.Text = string.Empty;
        }
    }
}
