using System;
using System.Windows.Forms;

namespace EasyPhysics
{
    public partial class Kinematics : Form
    {
        public Kinematics ()
        {
            InitializeComponent();
        }

        private void angledMove_button_Click (object sender, EventArgs e)
        {
            this.Hide();
            var angledMove = new AngledMove();
            angledMove.Show();
        }
    }
}
