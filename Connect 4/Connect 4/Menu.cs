using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_4
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void playWithAI_Click(object sender, EventArgs e)
        {
            Game_Display game_Display = new Game_Display(true);
            game_Display.Show();
            this.Hide();
        }

        private void playWithPlayer_Click(object sender, EventArgs e)
        {
            Game_Display game_Display = new Game_Display(false);
            game_Display.Show();
            this.Hide();
        }
    }
}
