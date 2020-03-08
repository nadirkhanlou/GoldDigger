using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoldDigger;

namespace GoldDiggerGUI
{
    public partial class GameBoard : Form
    {
        Form _parent;
        String _path;
        int _width;
        int _height;
        PictureBox[,] _sprites;
        PictureBox _agent;
        GoldDiggerSolver solver;

        public GameBoard(Form parent, String _path)
        {
            InitializeComponent();
            string input = System.IO.File.ReadAllText(_path);
            GenerateGameBoard(input);
            solver = new GoldDiggerSolver(_path);
        }

        public void GenerateGameBoard(string input)
        {
            int offsetX = 5;
            int scaleFactor = 1;
            String[] inputLines = input.Split('\n');
            String[] sizes = inputLines[0].Split(' ');
            _height = int.Parse(sizes[0]);
            _width = int.Parse(sizes[1]);

            String[] positions = inputLines[_height * _width + 1].Split(' ');
            int agentPos = int.Parse(positions[0]);
            _agent = new PictureBox();
            _agent.Location = new System.Drawing.Point((int)(offsetX + 32 * scaleFactor * (agentPos % _width - 1) + 2), (int)(32 * scaleFactor * (agentPos / _height) + 2));
            _agent.Name = "agent";
            _agent.BackColor = Color.Transparent;
            _agent.Size = new System.Drawing.Size((int)(28 * scaleFactor), (int)(28 * scaleFactor));
            _agent.TabIndex = 0;
            _agent.TabStop = false;
            _agent.SizeMode = PictureBoxSizeMode.StretchImage;
            _agent.Image = GoldDiggerGUI.Properties.Resources.Hat_man;
            ((System.ComponentModel.ISupportInitialize)(_agent)).EndInit();
            this.Controls.Add(_agent);

            _sprites = new PictureBox[_width, _height];

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {

                    String[] block = inputLines[_width * i + j + 1].Split(' ');
                    

                    if (block[0].Trim() == "0")
                    {
                        PictureBox up = new PictureBox();
                        up.Location = new System.Drawing.Point((int)(offsetX + 32 * scaleFactor * i), (int)(32 * scaleFactor * j));
                        up.Name = "up +" + i.ToString() + "_" + j.ToString();
                        up.Size = new System.Drawing.Size((int)(32 * scaleFactor), (int)(2 * scaleFactor));
                        up.TabIndex = 0;
                        up.TabStop = false;
                        up.SizeMode = PictureBoxSizeMode.StretchImage;
                        up.Image = GoldDiggerGUI.Properties.Resources.horizontal_wall;
                        ((System.ComponentModel.ISupportInitialize)(up)).EndInit();
                        this.Controls.Add(up);
                    }

                    if (block[1].Trim() == "0")
                    {
                        PictureBox right = new PictureBox();
                        right.Location = new System.Drawing.Point((int)(offsetX + 32 * scaleFactor * i + 32), (int)(32 * scaleFactor * j));
                        right.Name = "right +" + i.ToString() + "_" + j.ToString();
                        right.Size = new System.Drawing.Size((int)(2 * scaleFactor), (int)(32 * scaleFactor));
                        right.TabIndex = 0;
                        right.TabStop = false;
                        right.SizeMode = PictureBoxSizeMode.StretchImage;
                        right.Image = GoldDiggerGUI.Properties.Resources.vertical_wall;
                        ((System.ComponentModel.ISupportInitialize)(right)).EndInit();
                        this.Controls.Add(right);
                    }

                    if (block[2].Trim() == "0")
                    {
                        PictureBox down = new PictureBox();
                        down.Location = new System.Drawing.Point((int)(offsetX + 32 * scaleFactor * i), (int)(32 * scaleFactor * j + 32));
                        down.Name = "down +" + i.ToString() + "_" + j.ToString();
                        down.Size = new System.Drawing.Size((int)(32 * scaleFactor), (int)(2 * scaleFactor));
                        down.TabIndex = 0;
                        down.TabStop = false;
                        down.SizeMode = PictureBoxSizeMode.StretchImage;
                        down.Image = GoldDiggerGUI.Properties.Resources.horizontal_wall;
                        ((System.ComponentModel.ISupportInitialize)(down)).EndInit();
                        this.Controls.Add(down);
                    }

                    if (block[3].Trim() == "0")
                    {
                        PictureBox left = new PictureBox();
                        left.Location = new System.Drawing.Point((int)(offsetX + 32 * scaleFactor * i), (int)(32 * scaleFactor * j));
                        left.Name = "left +" + i.ToString() + "_" + j.ToString();
                        left.Size = new System.Drawing.Size((int)(2 * scaleFactor), (int)(32 * scaleFactor));
                        left.TabIndex = 0;
                        left.TabStop = false;
                        left.SizeMode = PictureBoxSizeMode.StretchImage;
                        left.Image = GoldDiggerGUI.Properties.Resources.vertical_wall;
                        ((System.ComponentModel.ISupportInitialize)(left)).EndInit();
                        this.Controls.Add(left);
                    }
                    
                }
            }

            ResumeLayout();
        }
    }
} // GoldDiggerGUI
