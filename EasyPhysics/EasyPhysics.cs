using System;
using System.Windows.Forms;

namespace EasyPhysics
{
    public partial class EasyPhysics : Form
    {
        public EasyPhysics ()
        {
            InitializeComponent();
        }

        private void kinematic_button_Click (object sender, EventArgs e)
        {
            this.Hide();
            var kinematics = new Kinematics();
            kinematics.Show();
        }
    }
}
