using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace LME
{
    public partial class GameWindow : Form
    {

        private Game game = new Game();
        private Graphics g;

        public GameWindow()
        {
            Debug.WriteLine("starting game");
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
           if (g == null) g = Canvas.CreateGraphics();
            game.StartGraphics(g);
        }

        private void GameWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.StopGame();
        }
    }
}
