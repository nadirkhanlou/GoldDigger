using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldDiggerGUI
{
    public partial class Menu : Form
    {
        String _path;

        public Menu()
        {
            InitializeComponent();
        }

        private void InputBrowserBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _path = openFileDialog.FileName;
                selectedFileLabel.Text = _path + " is selected.";
                GameBoardCreatorBtn.Enabled = true;
            }
        }

        private void GameBoardCreatorBtn_Click(object sender, EventArgs e)
        {
            GameBoard board = new GameBoard(this, _path);
            this.Hide();
            board.ShowDialog();

        }
    }
}
