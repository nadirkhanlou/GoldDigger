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
        int _agentPos;
        double _scaleFactor;
        PictureBox[] _directions;
        bool _qLearningFlag;
        List<int> _golds;
        int _offsetX;
        Label[,] qTableArray;
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
            _offsetX = 5;
            _scaleFactor = 1;

            String[] inputLines = input.Split('\n');
            String[] sizes = inputLines[0].Split(' ');
            _height = int.Parse(sizes[0]);
            _width = int.Parse(sizes[1]);

            _golds = new List<int>();

            if (_width > 10 || _height > 10)
                _scaleFactor = .5f;

            String[] positions = inputLines[_height * _width + 1].Split(' ');
            int agentPos = int.Parse(positions[0]);
            _agent = new PictureBox();
            int agentY = (agentPos % _height);
            if (agentY == 0)
                agentY = _height;
            _agent.Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * ((agentPos - 1) / _height) + 2)), (int)(_scaleFactor * (32 * (agentY - 1) + 2)));
            _agent.Name = "agent";
            _agent.BackColor = Color.Transparent;
            _agent.Size = new System.Drawing.Size((int)(28 * _scaleFactor), (int)(28 * _scaleFactor));
            _agent.TabIndex = 0;
            _agent.TabStop = false;
            _agent.SizeMode = PictureBoxSizeMode.StretchImage;
            _agent.Image = GoldDiggerGUI.Properties.Resources.Hat_man;
            ((System.ComponentModel.ISupportInitialize)(_agent)).EndInit();
            this.Controls.Add(_agent);
            _agentPos = agentPos;

            for(int i = 1; i < positions.Length; i++)
            {
                PictureBox gold = new PictureBox();
                _golds.Add(int.Parse(positions[i]));
                int goldY = int.Parse(positions[i]) % (_height);
                if (goldY == 0)
                    goldY = _height;
                gold.Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * ((int.Parse(positions[i]) - 1) / _height) + 2)), (int)(_scaleFactor *(32 * (goldY - 1) + 2)));
                gold.Name = "gold" + i.ToString();
                gold.Size = new System.Drawing.Size((int)(28 * _scaleFactor), (int)(28 * _scaleFactor));
                gold.TabIndex = 0;
                gold.TabStop = false;
                gold.SizeMode = PictureBoxSizeMode.StretchImage;
                gold.Image = GoldDiggerGUI.Properties.Resources.Gold;
                ((System.ComponentModel.ISupportInitialize)(gold)).EndInit();
                this.Controls.Add(gold);
            }

            _sprites = new PictureBox[_width, _height];
            _directions = new PictureBox[_width* _height];

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {

                    String[] block = inputLines[_height * i + j + 1].Split(' ');

                    _directions[i * _height + j] = new PictureBox();
                    _directions[i * _height + j].Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * i + 2)), (int)(_scaleFactor * (32 * j + 2)));
                    _directions[i * _height + j].Name = "" + i.ToString() + "_" + j.ToString();
                    _directions[i * _height + j].Size = new System.Drawing.Size((int)(28 * _scaleFactor), (int)(28 * _scaleFactor));
                    _directions[i * _height + j].TabIndex = 0;
                    _directions[i * _height + j].TabStop = false;
                    _directions[i * _height + j].SizeMode = PictureBoxSizeMode.StretchImage;
                    _directions[i * _height + j].Image = GoldDiggerGUI.Properties.Resources.horizontal_wall;
                    _directions[i * _height + j].Visible = false;
                    ((System.ComponentModel.ISupportInitialize)(_directions[i * _height + j])).EndInit();
                    this.Controls.Add(_directions[i * _height + j]);

                    if (block[0].Trim() == "0")
                    {
                        PictureBox up = new PictureBox();
                        up.Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * i)), (int)(_scaleFactor * (32 * j)));
                        up.Name = "up +" + i.ToString() + "_" + j.ToString();
                        up.Size = new System.Drawing.Size((int)(32 * _scaleFactor), (int)(2 * _scaleFactor));
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
                        right.Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * i + 32)), (int)(_scaleFactor * (32 * j)));
                        right.Name = "right +" + i.ToString() + "_" + j.ToString();
                        right.Size = new System.Drawing.Size((int)(2 * _scaleFactor), (int)(32 * _scaleFactor));
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
                        down.Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * i)), (int)(_scaleFactor * (32 * j + 32)));
                        down.Name = "down +" + i.ToString() + "_" + j.ToString();
                        down.Size = new System.Drawing.Size((int)(32 * _scaleFactor), (int)(2 * _scaleFactor));
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
                        left.Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * i)), (int)(_scaleFactor * (32 * j)));
                        left.Name = "left +" + i.ToString() + "_" + j.ToString();
                        left.Size = new System.Drawing.Size((int)(2 * _scaleFactor), (int)(32 * _scaleFactor));
                        left.TabIndex = 0;
                        left.TabStop = false;
                        left.SizeMode = PictureBoxSizeMode.StretchImage;
                        left.Image = GoldDiggerGUI.Properties.Resources.vertical_wall;
                        ((System.ComponentModel.ISupportInitialize)(left)).EndInit();
                        this.Controls.Add(left);
                    }
                    
                }
            }

            qTableArray = new Label[_width * _height, 5];
            for (int i = 0; i < _width * _height; ++i)
            {
                qTableArray[i, 0] = new Label();
                qTableArray[i, 0].Parent = qTable;
                qTableArray[i, 0].Location = new System.Drawing.Point(qLearningPanel.Location.X, qLearningPanel.Location.Y + i * 30);
                qTableArray[i, 0].Text = (i + 1).ToString();
                this.Controls.Add(qTableArray[i, 0]);
            }
            qTable.AutoScroll = false;
            qTable.HorizontalScroll.Enabled = false;
            qTable.HorizontalScroll.Visible = false;
            qTable.HorizontalScroll.Maximum = 0;
            qTable.AutoScroll = true;

            ResumeLayout();
            //var task = Task.Run(async () => await MoveRight());
        }

        void Move(object sender, EventArgs e)
        {
            _timerSteps -= 1;
            _agent.Location = new System.Drawing.Point((int)(_agent.Location.X + _xStep * _scaleFactor), _agent.Location.Y + (int)(_yStep * _scaleFactor));
            if (_timerSteps <= 0)
            {
                _movementTimer.Stop();
                if (!_qLearningFlag) {
                    if (!_golds.Contains(_agentPos))
                        PlayAction(_result[_agentPos - 1]);
                }
                else if (!_golds.Contains(_agentPos))
                {
                    QLearningAct();
                }

            }
        }

        void MoveRight()
        {
            _timerSteps = 16;
            _agentPos += _height;
            _xStep = 2;
            _yStep = 0;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        void MoveLeft()
        {
            _timerSteps = 16;
            _agentPos -= _height;
            _xStep = -2;
            _yStep = 0;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        void MoveUp()
        {
            _timerSteps = 16;
            _agentPos -= 1;
            _xStep = 0;
            _yStep = -2;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        void MoveDown()
        {
            _timerSteps = 16;
            _agentPos += 1;
            _xStep = 0;
            _yStep = 2;
            _movementTimer.Enabled = true;
            //_movementTimer.Tick += new System.EventHandler(Move);
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            _movementTimer.Tick += new System.EventHandler(Move);
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            _agent.Location = new System.Drawing.Point(_agent.Location.X + 2, _agent.Location.Y + 0); 
        }

        void PlayAction(int action)
        {
            switch (action)
            {
                //case (int)AgentAction.Dig:

                //    break;
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
            _result = _solver.PolicyIteration();
            _qLearningFlag = false;
            for (int i = 0; i < _result.Length; ++i)
            {
                Console.Write(i.ToString() + " " + Enum.GetName(typeof(AgentAction), _result[i]) + "\n");
                switch (_result[i])
                {
                    //case (int)AgentAction.Dig:
                    //    _directions[i].Image = GoldDiggerGUI.Properties.Resources.Dig;
                    //    _directions[i].BringToFront();
                    //    break;
                    case (int)AgentAction.Down:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Down;
                        break;
                    case (int)AgentAction.Left:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Left;
                        break;
                    case (int)AgentAction.Right:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Right;
                        break;
                    case (int)AgentAction.Up:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Up;
                        break;
                }
                _agent.BringToFront();
                _directions[i].Visible = checkBox1.Checked;
            }
            PlayAction(_result[_agentPos - 1]);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _directions.Length; ++i)
            {
                
                _directions[i].Visible = checkBox1.Checked;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _result = _solver.ValueIteration();
            _qLearningFlag = false;
            for (int i = 0; i < _result.Length; ++i)
            {
                Console.Write(i.ToString() + " " + Enum.GetName(typeof(AgentAction), _result[i]) + "\n");
                switch (_result[i])
                {
                    //case (int)AgentAction.Dig:

                    //    break;
                    case (int)AgentAction.Down:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Down;
                        break;
                    case (int)AgentAction.Left:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Left;
                        break;
                    case (int)AgentAction.Right:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Right;
                        break;
                    case (int)AgentAction.Up:
                        _directions[i].Image = GoldDiggerGUI.Properties.Resources.Up;
                        break;
                }
                _directions[i].Visible = checkBox1.Checked;
            }
            PlayAction(_result[_agentPos - 1]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                PolicyValueIterationPanel.Visible = true;
                qLearningPanel.Visible = false;
                
            }
            else
            {
                PolicyValueIterationPanel.Visible = false;
                qLearningPanel.Visible = true;
            }
        }

        private void QLearningAct()
        {
            int res = _solver.QLearningAct();
            _qLearningFlag = true;
            if (_result == null)
            {
                _result = new int[_width * _height];
                for (int i = 0; i < _width * _height; ++i)
                    _result[i] = -1;
            }
            _result[_agentPos - 1] = res;
            PlayAction(_result[_agentPos - 1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_golds.Contains(_agentPos))
            {
                _agentPos = _solver.AgentRandomPosition() + 1;
                int agentY = (_agentPos % _height);
                if (agentY == 0)
                    agentY = _height;
                _agent.Location = new System.Drawing.Point((int)(_scaleFactor * (_offsetX + 32 * ((_agentPos - 1) / _height) + 2)), (int)(_scaleFactor * (32 * (agentY - 1) + 2)));
            }
            QLearningAct();
        }
    }
} // GoldDiggerGUI
