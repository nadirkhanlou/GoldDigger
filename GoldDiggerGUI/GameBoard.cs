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
using GoldDiggerActions;

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
        GoldDiggerSolver _solver;
        int _timerSteps;
        int _xStep;
        int _yStep;
        int[] _result;
        int _resultIndex;
        Timer _movementTimer = new Timer
        {
            Interval = 40
        };

        public GameBoard(Form parent, String _path)
        {
            InitializeComponent();
            string input = System.IO.File.ReadAllText(_path);
            GenerateGameBoard(input);
            _solver = new GoldDiggerSolver(_path);
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
            int agentY = (agentPos % _height);
            if (agentY == 0)
                agentY = _height;
            _agent.Location = new System.Drawing.Point((int)(offsetX + 32 * scaleFactor * ((agentPos - 1) / _width) + 2), (int)(32 * scaleFactor * (agentY - 1) + 2));
            _agent.Name = "agent";
            _agent.BackColor = Color.Transparent;
            _agent.Size = new System.Drawing.Size((int)(28 * scaleFactor), (int)(28 * scaleFactor));
            _agent.TabIndex = 0;
            _agent.TabStop = false;
            _agent.SizeMode = PictureBoxSizeMode.StretchImage;
            _agent.Image = GoldDiggerGUI.Properties.Resources.Hat_man;
            ((System.ComponentModel.ISupportInitialize)(_agent)).EndInit();
            this.Controls.Add(_agent);

            for(int i = 1; i < positions.Length; i++)
            {
                PictureBox gold = new PictureBox();
                int goldY = int.Parse(positions[i]) % (_height);
                if (goldY == 0)
                    goldY = _height;
                gold.Location = new System.Drawing.Point((int)(offsetX + 32 * scaleFactor * ((int.Parse(positions[i]) - 1) / _width) + 2), (int)(32 * scaleFactor * (goldY - 1) + 2));
                gold.Name = "gold" + i.ToString();
                gold.Size = new System.Drawing.Size((int)(28 * scaleFactor), (int)(28 * scaleFactor));
                gold.TabIndex = 0;
                gold.TabStop = false;
                gold.SizeMode = PictureBoxSizeMode.StretchImage;
                gold.Image = GoldDiggerGUI.Properties.Resources.Grass;
                ((System.ComponentModel.ISupportInitialize)(gold)).EndInit();
                this.Controls.Add(gold);
            }

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
            //var task = Task.Run(async () => await MoveRight());
        }

        void Move(object sender, EventArgs e)
        {
            _timerSteps -= 1;
            _agent.Location = new System.Drawing.Point(_agent.Location.X + _xStep, _agent.Location.Y + _yStep);
            if (_timerSteps <= 0)
            {
                Console.Write(_result[_resultIndex].ToString());
                _movementTimer.Stop();
                _resultIndex++;
                if (_resultIndex < _result.Length)
                    PlayAction(_result[_resultIndex]);
            }
        }

        void MoveRight()
        {
            _timerSteps = 16;
            _xStep = 2;
            _yStep = 0;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        void MoveLeft()
        {
            _timerSteps = 16;
            _xStep = -2;
            _yStep = 0;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        void MoveUp()
        {
            _timerSteps = 16;
            _xStep = 0;
            _yStep = -2;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        void MoveDown()
        {
            _timerSteps = 16;
            _xStep = 0;
            _yStep = 2;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            _agent.Location = new System.Drawing.Point(_agent.Location.X + 2, _agent.Location.Y + 0); 
        }

        void PlayAction(int action)
        {
            switch (action)
            {
                case (int)AgentAction.Dig:

                    break;
                case (int)AgentAction.Down:
                    MoveDown();
                    break;
                case (int)AgentAction.Left:
                    MoveLeft();
                    break;
                case (int)AgentAction.Right:
                    MoveRight();
                    break;
                case (int)AgentAction.Up:
                    MoveUp();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _result = _solver.ValueIteration();
            _resultIndex = 0;
            for(int i = 0; i < _result.Length; i++)
                Console.Write(_result[i].ToString() + " ");
            _movementTimer.Tick += new System.EventHandler(Move);
            PlayAction(_result[_resultIndex]);
        }
    }
} // GoldDiggerGUI
