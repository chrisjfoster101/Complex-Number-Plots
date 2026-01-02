namespace Forms_Implicits
{
    partial class Revision
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
            this.NextButton = new System.Windows.Forms.Button();
            this.GraphBox = new System.Windows.Forms.PictureBox();
            this.QuestionBox = new System.Windows.Forms.RichTextBox();
            this.AnswerLHS = new System.Windows.Forms.TextBox();
            this.AnswerRHS = new System.Windows.Forms.TextBox();
            this.AnswerInequality = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ShapeBox = new System.Windows.Forms.ComboBox();
            this.StyleBox = new System.Windows.Forms.ComboBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.QuestionNumLabel = new System.Windows.Forms.Label();
            this.CorrectLabel = new System.Windows.Forms.Label();
            this.SwitchAnswerButton = new System.Windows.Forms.Button();
            this.CorrectAnswerLabel1 = new System.Windows.Forms.Label();
            this.CorrectAnswerLabel2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GraphBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(883, 568);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 0;
            this.NextButton.Text = "Enter";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // GraphBox
            // 
            this.GraphBox.Location = new System.Drawing.Point(12, 12);
            this.GraphBox.Name = "GraphBox";
            this.GraphBox.Size = new System.Drawing.Size(512, 512);
            this.GraphBox.TabIndex = 1;
            this.GraphBox.TabStop = false;
            this.GraphBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphBox_MouseDown);
            // 
            // QuestionBox
            // 
            this.QuestionBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.QuestionBox.EnableAutoDragDrop = true;
            this.QuestionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.QuestionBox.Location = new System.Drawing.Point(530, 43);
            this.QuestionBox.Name = "QuestionBox";
            this.QuestionBox.ReadOnly = true;
            this.QuestionBox.Size = new System.Drawing.Size(428, 102);
            this.QuestionBox.TabIndex = 3;
            this.QuestionBox.Text = "";
            // 
            // AnswerLHS
            // 
            this.AnswerLHS.Location = new System.Drawing.Point(530, 162);
            this.AnswerLHS.Name = "AnswerLHS";
            this.AnswerLHS.Size = new System.Drawing.Size(152, 20);
            this.AnswerLHS.TabIndex = 4;
            // 
            // AnswerRHS
            // 
            this.AnswerRHS.Location = new System.Drawing.Point(729, 161);
            this.AnswerRHS.Name = "AnswerRHS";
            this.AnswerRHS.Size = new System.Drawing.Size(152, 20);
            this.AnswerRHS.TabIndex = 5;
            // 
            // AnswerInequality
            // 
            this.AnswerInequality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AnswerInequality.FormattingEnabled = true;
            this.AnswerInequality.Items.AddRange(new object[] {
            "=",
            "<",
            ">",
            "≤",
            "≥"});
            this.AnswerInequality.Location = new System.Drawing.Point(688, 161);
            this.AnswerInequality.Name = "AnswerInequality";
            this.AnswerInequality.Size = new System.Drawing.Size(35, 21);
            this.AnswerInequality.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Drawing tools:";
            // 
            // ShapeBox
            // 
            this.ShapeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShapeBox.FormattingEnabled = true;
            this.ShapeBox.Items.AddRange(new object[] {
            "Circle",
            "Half-line",
            "Line",
            "Point"});
            this.ShapeBox.Location = new System.Drawing.Point(530, 240);
            this.ShapeBox.Name = "ShapeBox";
            this.ShapeBox.Size = new System.Drawing.Size(152, 21);
            this.ShapeBox.TabIndex = 8;
            // 
            // StyleBox
            // 
            this.StyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StyleBox.FormattingEnabled = true;
            this.StyleBox.Items.AddRange(new object[] {
            "Line",
            "Line with fill",
            "Fill with no line"});
            this.StyleBox.Location = new System.Drawing.Point(688, 240);
            this.StyleBox.Name = "StyleBox";
            this.StyleBox.Size = new System.Drawing.Size(152, 21);
            this.StyleBox.TabIndex = 9;
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(530, 267);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(88, 32);
            this.DrawButton.TabIndex = 10;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(883, 251);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(527, 302);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(29, 13);
            this.InstructionLabel.TabIndex = 12;
            this.InstructionLabel.Text = "label";
            this.InstructionLabel.Visible = false;
            // 
            // QuestionNumLabel
            // 
            this.QuestionNumLabel.AutoSize = true;
            this.QuestionNumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.QuestionNumLabel.Location = new System.Drawing.Point(530, 12);
            this.QuestionNumLabel.Name = "QuestionNumLabel";
            this.QuestionNumLabel.Size = new System.Drawing.Size(56, 15);
            this.QuestionNumLabel.TabIndex = 13;
            this.QuestionNumLabel.Text = "Question";
            // 
            // CorrectLabel
            // 
            this.CorrectLabel.AutoSize = true;
            this.CorrectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.CorrectLabel.Location = new System.Drawing.Point(697, 361);
            this.CorrectLabel.Name = "CorrectLabel";
            this.CorrectLabel.Size = new System.Drawing.Size(46, 15);
            this.CorrectLabel.TabIndex = 15;
            this.CorrectLabel.Text = "Correct";
            this.CorrectLabel.Visible = false;
            // 
            // SwitchAnswerButton
            // 
            this.SwitchAnswerButton.Location = new System.Drawing.Point(411, 530);
            this.SwitchAnswerButton.Name = "SwitchAnswerButton";
            this.SwitchAnswerButton.Size = new System.Drawing.Size(113, 23);
            this.SwitchAnswerButton.TabIndex = 16;
            this.SwitchAnswerButton.Text = "See Correct Answer";
            this.SwitchAnswerButton.UseVisualStyleBackColor = true;
            this.SwitchAnswerButton.Visible = false;
            this.SwitchAnswerButton.Click += new System.EventHandler(this.SwitchAnswerButton_Click);
            // 
            // CorrectAnswerLabel1
            // 
            this.CorrectAnswerLabel1.AutoSize = true;
            this.CorrectAnswerLabel1.Location = new System.Drawing.Point(589, 387);
            this.CorrectAnswerLabel1.Name = "CorrectAnswerLabel1";
            this.CorrectAnswerLabel1.Size = new System.Drawing.Size(112, 13);
            this.CorrectAnswerLabel1.TabIndex = 17;
            this.CorrectAnswerLabel1.Text = "The correct answer is:";
            this.CorrectAnswerLabel1.Visible = false;
            // 
            // CorrectAnswerLabel2
            // 
            this.CorrectAnswerLabel2.AutoSize = true;
            this.CorrectAnswerLabel2.Location = new System.Drawing.Point(589, 400);
            this.CorrectAnswerLabel2.Name = "CorrectAnswerLabel2";
            this.CorrectAnswerLabel2.Size = new System.Drawing.Size(35, 13);
            this.CorrectAnswerLabel2.TabIndex = 18;
            this.CorrectAnswerLabel2.Text = "label3";
            this.CorrectAnswerLabel2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Shape:                                        Style:";
            // 
            // Revision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 603);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CorrectAnswerLabel2);
            this.Controls.Add(this.CorrectAnswerLabel1);
            this.Controls.Add(this.SwitchAnswerButton);
            this.Controls.Add(this.CorrectLabel);
            this.Controls.Add(this.QuestionNumLabel);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.StyleBox);
            this.Controls.Add(this.ShapeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnswerInequality);
            this.Controls.Add(this.AnswerRHS);
            this.Controls.Add(this.AnswerLHS);
            this.Controls.Add(this.QuestionBox);
            this.Controls.Add(this.GraphBox);
            this.Controls.Add(this.NextButton);
            this.Name = "Revision";
            this.Text = "Revision";
            this.Load += new System.EventHandler(this.Revision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraphBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.PictureBox GraphBox;
        private System.Windows.Forms.RichTextBox QuestionBox;
        private System.Windows.Forms.TextBox AnswerLHS;
        private System.Windows.Forms.TextBox AnswerRHS;
        private System.Windows.Forms.ComboBox AnswerInequality;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ShapeBox;
        private System.Windows.Forms.ComboBox StyleBox;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.Label QuestionNumLabel;
        private System.Windows.Forms.Label CorrectLabel;
        private System.Windows.Forms.Button SwitchAnswerButton;
        private System.Windows.Forms.Label CorrectAnswerLabel1;
        private System.Windows.Forms.Label CorrectAnswerLabel2;
        private System.Windows.Forms.Label label2;
    }
}