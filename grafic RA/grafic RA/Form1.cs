using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafic_RA
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Compile_Click(object sender, EventArgs e)
        {

        }

        private void Graph_Click(object sender, EventArgs e)
        {
            Graphics paint= Paint.CreateGraphics();
            Pen lapiz = new Pen(Color.Black);
            Brush brocha = new SolidBrush(Color.Black);

            paint.DrawLine(lapiz, 10, 10, 200, 200);
            paint.DrawLine(lapiz, 10, 200, 200, 10);
            paint.DrawRectangle(lapiz, 300, 100, 200, 200);
            paint.DrawEllipse(lapiz, 300, 100, 200, 200);
        }

        
    }
}
