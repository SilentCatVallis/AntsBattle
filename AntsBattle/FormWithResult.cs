using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntsBattle
{
    public partial class FormWithResult : Form
    {
        private int WhiteScore;
        private int BlackScore;
        private World world;
        public FormWithResult(World world)
        {
            WhiteScore = world.WhiteScore;
            BlackScore = world.BlackScore;
            foreach (var obj in world.Objects)
            {
                if (obj.GetColourOrNone() == AntColour.Black)
                    BlackScore += 3;
                if (obj.GetColourOrNone() == AntColour.White)
                    WhiteScore += 3;
            }
            this.world = world;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            Text = "Results";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Width = 600;
            var g = e.Graphics;
            g.DrawString(world.WhiteAntAI.PlayerName + " score: " + WhiteScore, new Font("Arial", 16), new SolidBrush(Color.Black), 5, 5);
            g.DrawString(world.BlackAntAI.PlayerName + " score: " + BlackScore, new Font("Arial", 16), new SolidBrush(Color.Black), 5, 55);
        }
    }
}
