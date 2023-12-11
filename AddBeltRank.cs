using Karate_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate
{
    public partial class AddBeltRank : Form
    {
        public AddBeltRank()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                }
            }
            base.WndProc(ref m);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSaveForADD_Click(object sender, EventArgs e)
        {
            if (TxtBeltName.Text == string.Empty || TxtTestFess.Text == string.Empty)
            {
                Form New = new FormForWrongNotExist("Plese Enter Rank Name / Tests Fees");
                New.ShowDialog();
                return;
            }


            if (clsBeltRanks.AddNewBeltRank(TxtBeltName.Text, Convert.ToInt32(TxtTestFess.Text)) != 0)
            {
                Form New = new FormForRithThing("Belt Successfully Added");
                New.ShowDialog();
                return;
            }
            else
            {
                Form New = new FormForWrongNotExist("Belt Does Not  Added");
                New.ShowDialog();
                return;
            }

            TxtBeltName.Text = string.Empty;
            TxtTestFess.Text = string.Empty;
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The white belt is the starting point for all beginners. It represents purity, innocence, and the beginning of the karate journey.");
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The yellow belt signifies the first step towards progress. It represents the earth and the growth of the seed as the student starts to develop basic techniques and knowledge.");
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The orange belt represents the sunrise, symbolizing the student's increasing knowledge and understanding of karate. At this stage, the student begins to refine their techniques and gain more confidence.");
        }

        private void guna2CirclePictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The green belt represents the growth of a plant as the student's skills continue to develop. It signifies a deeper understanding of karate principles and the ability to apply techniques effectively.");
        }

        private void guna2CirclePictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The blue belt represents the sky and the vastness of knowledge that lies ahead. At this stage, the student demonstrates a higher level of proficiency and commitment to their training.");
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" The purple belt signifies the transition from intermediate to advanced level. It represents the dawn of a new stage in the student's journey, where they start to refine their techniques and focus on more complex movements.");
        }

        private void guna2CirclePictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The brown belt represents maturity and stability. It signifies the student's advanced level of skill and knowledge, as well as their dedication to continuous improvement.");
        }

        private void guna2CirclePictureBox9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The black belt is the ultimate goal for many karate practitioners. It represents mastery, expertise, and a deep understanding of karate principles. It is important to note that there are multiple degrees or levels within the black belt, indicating further progression and expertise.");
        }






    }
}
