using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Nightmare_Realm.PlayingField;

namespace Nightmare_Realm
{
    public partial class MainWindow : Form
    {
        private PlayingField game = new PlayingField();
        public MainWindow()
        {
            InitializeComponent();
            game.FillField();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DrawAll();
            bool end = CheckLamps();
            if (end)
                timer1.Stop();
        }

        private bool CheckLamps()
        {
            bool a, b, c;
            a = game.isActiveLine(1);
            b = game.isActiveLine(2);
            c = game.isActiveLine(3);
            if (a)
                lamp1.Image = Image.FromFile(@"Assets\active.png");
            else
                lamp1.Image = Image.FromFile(@"Assets\deactive.png");
            if (b)
                lamp2.Image = Image.FromFile(@"Assets\active.png");
            else
                lamp2.Image = Image.FromFile(@"Assets\deactive.png");
            if (c)
                lamp3.Image = Image.FromFile(@"Assets\active.png");
            else
                lamp3.Image = Image.FromFile(@"Assets\deactive.png");
            return a && b && c;
        }

        private void Reset_images()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string pb_name = "pictureBox" + (i + 1) + "_" + (j + 1);
                    Controls[pb_name].Visible = false;
                }

            }
        }

        public void DrawAll()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    string pb_name = "pictureBox" + (i + 1) + "_" + (j + 1);
                    Square temp = game.getSquare(i, j);
                    if (temp.Can_be_displayed())
                    {
                        Controls[pb_name].Visible = true;
                        Controls[pb_name].BackgroundImage = temp.Img();
                    }
                    else
                        Controls[pb_name].Visible = false;

                }

            }
        }
        //Не спрашивайте про то что будет происходить дальше. Просто так надо
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            game.readPos(1, 1);
        }

        private void pictureBox2_1_Click(object sender, EventArgs e)
        {
            game.readPos(2, 1);
        }

        private void pictureBox3_1_Click(object sender, EventArgs e)
        {
            game.readPos(3, 1);
        }

        private void pictureBox4_1_Click(object sender, EventArgs e)
        {
            game.readPos(4, 1);
        }

        private void pictureBox5_1_Click(object sender, EventArgs e)
        {
            game.readPos(5, 1);
        }

        private void pictureBox1_2_Click(object sender, EventArgs e)
        {
            game.readPos(1, 2);
        }

        private void pictureBox2_2_Click(object sender, EventArgs e)
        {
            game.readPos(2, 2);
        }

        private void pictureBox3_2_Click(object sender, EventArgs e)
        {
            game.readPos(3, 2);
        }

        private void pictureBox4_2_Click(object sender, EventArgs e)
        {
            game.readPos(4, 2);
        }

        private void pictureBox5_2_Click(object sender, EventArgs e)
        {
            game.readPos(5, 2);
        }

        private void pictureBox1_3_Click(object sender, EventArgs e)
        {
            game.readPos(1, 3);
        }

        private void pictureBox2_3_Click(object sender, EventArgs e)
        {
            game.readPos(2, 3);
        }

        private void pictureBox3_3_Click(object sender, EventArgs e)
        {
            game.readPos(3, 3);
        }

        private void pictureBox4_3_Click(object sender, EventArgs e)
        {
            game.readPos(4, 3);
        }

        private void pictureBox5_3_Click(object sender, EventArgs e)
        {
            game.readPos(5, 3);
        }

        private void pictureBox1_4_Click(object sender, EventArgs e)
        {
            game.readPos(1, 4);
        }

        private void pictureBox2_4_Click(object sender, EventArgs e)
        {
            game.readPos(2, 4);
        }

        private void pictureBox3_4_Click(object sender, EventArgs e)
        {
            game.readPos(3, 4);
        }

        private void pictureBox4_4_Click(object sender, EventArgs e)
        {
            game.readPos(4, 4);
        }

        private void pictureBox5_4_Click(object sender, EventArgs e)
        {
            game.readPos(5, 4);
        }

        private void pictureBox1_5_Click(object sender, EventArgs e)
        {
            game.readPos(1, 5);
        }

        private void pictureBox2_5_Click(object sender, EventArgs e)
        {
            game.readPos(2, 5);
        }

        private void pictureBox3_5_Click(object sender, EventArgs e)
        {
            game.readPos(3, 5);
        }

        private void pictureBox4_5_Click(object sender, EventArgs e)
        {
            game.readPos(4, 5);
        }

        private void pictureBox5_5_Click(object sender, EventArgs e)
        {
            game.readPos(5, 5);
        }
    }
}
