namespace GoldDiggerGUI
{
    partial class GameBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PolicyValueIterationPanel = new System.Windows.Forms.Panel();
            this.qLearningPanel = new System.Windows.Forms.Panel();
            this.nIterationText = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.qTable = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.gammaText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PolicyValueIterationPanel.SuspendLayout();
            this.qLearningPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "policy iteration";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "show policy";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "value iteration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Policy/Value Iteration",
            "Q Learning"});
            this.comboBox1.Location = new System.Drawing.Point(475, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Policy/Value Iteration";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PolicyValueIterationPanel
            // 
            this.PolicyValueIterationPanel.Controls.Add(this.button1);
            this.PolicyValueIterationPanel.Controls.Add(this.button2);
            this.PolicyValueIterationPanel.Controls.Add(this.checkBox1);
            this.PolicyValueIterationPanel.Location = new System.Drawing.Point(475, 62);
            this.PolicyValueIterationPanel.Name = "PolicyValueIterationPanel";
            this.PolicyValueIterationPanel.Size = new System.Drawing.Size(200, 115);
            this.PolicyValueIterationPanel.TabIndex = 4;
            // 
            // qLearningPanel
            // 
            this.qLearningPanel.Controls.Add(this.nIterationText);
            this.qLearningPanel.Controls.Add(this.button6);
            this.qLearningPanel.Controls.Add(this.checkBox2);
            this.qLearningPanel.Controls.Add(this.button4);
            this.qLearningPanel.Controls.Add(this.qTable);
            this.qLearningPanel.Controls.Add(this.button5);
            this.qLearningPanel.Controls.Add(this.button3);
            this.qLearningPanel.Location = new System.Drawing.Point(475, 62);
            this.qLearningPanel.Name = "qLearningPanel";
            this.qLearningPanel.Size = new System.Drawing.Size(305, 396);
            this.qLearningPanel.TabIndex = 5;
            this.qLearningPanel.Visible = false;
            // 
            // nIterationText
            // 
            this.nIterationText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.nIterationText.Location = new System.Drawing.Point(192, 373);
            this.nIterationText.Name = "nIterationText";
            this.nIterationText.Size = new System.Drawing.Size(62, 20);
            this.nIterationText.TabIndex = 6;
            this.nIterationText.Text = "100";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(79, 372);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(107, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "n Iteration";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(12, 376);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(52, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Index";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(114, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Q learning iteration without animation";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // qTable
            // 
            this.qTable.AutoScroll = true;
            this.qTable.Location = new System.Drawing.Point(12, 61);
            this.qTable.Name = "qTable";
            this.qTable.Size = new System.Drawing.Size(213, 311);
            this.qTable.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(4, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "Print Q table";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Q learning iteration";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // gammaText
            // 
            this.gammaText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gammaText.Location = new System.Drawing.Point(837, 65);
            this.gammaText.Name = "gammaText";
            this.gammaText.Size = new System.Drawing.Size(44, 20);
            this.gammaText.TabIndex = 7;
            this.gammaText.Text = "0.9";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(786, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Gamma:";
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 460);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gammaText);
            this.Controls.Add(this.qLearningPanel);
            this.Controls.Add(this.PolicyValueIterationPanel);
            this.Controls.Add(this.comboBox1);
            this.Name = "GameBoard";
            this.Text = "GameBoard";
            this.Load += new System.EventHandler(this.GameBoard_Load);
            this.PolicyValueIterationPanel.ResumeLayout(false);
            this.PolicyValueIterationPanel.PerformLayout();
            this.qLearningPanel.ResumeLayout(false);
            this.qLearningPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel PolicyValueIterationPanel;
        private System.Windows.Forms.Panel qLearningPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel qTable;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox nIterationText;
        private System.Windows.Forms.TextBox gammaText;
        private System.Windows.Forms.Label label1;
    }
}