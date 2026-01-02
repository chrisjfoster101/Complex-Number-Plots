namespace Forms_Implicits
{
    partial class QuestionPicker
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
            this.label1 = new System.Windows.Forms.Label();
            this.CircleBox = new System.Windows.Forms.CheckBox();
            this.HalfLineBox = new System.Windows.Forms.CheckBox();
            this.LineBox = new System.Windows.Forms.CheckBox();
            this.InequalityBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RecommendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "What question types would you like to be tested on?";
            // 
            // CircleBox
            // 
            this.CircleBox.AutoSize = true;
            this.CircleBox.Location = new System.Drawing.Point(12, 43);
            this.CircleBox.Name = "CircleBox";
            this.CircleBox.Size = new System.Drawing.Size(52, 17);
            this.CircleBox.TabIndex = 1;
            this.CircleBox.Text = "Circle";
            this.CircleBox.UseVisualStyleBackColor = true;
            // 
            // HalfLineBox
            // 
            this.HalfLineBox.AutoSize = true;
            this.HalfLineBox.Location = new System.Drawing.Point(12, 66);
            this.HalfLineBox.Name = "HalfLineBox";
            this.HalfLineBox.Size = new System.Drawing.Size(68, 17);
            this.HalfLineBox.TabIndex = 2;
            this.HalfLineBox.Text = "Half-Line";
            this.HalfLineBox.UseVisualStyleBackColor = true;
            // 
            // LineBox
            // 
            this.LineBox.AutoSize = true;
            this.LineBox.Location = new System.Drawing.Point(12, 89);
            this.LineBox.Name = "LineBox";
            this.LineBox.Size = new System.Drawing.Size(46, 17);
            this.LineBox.TabIndex = 3;
            this.LineBox.Text = "Line";
            this.LineBox.UseVisualStyleBackColor = true;
            // 
            // InequalityBox
            // 
            this.InequalityBox.AutoSize = true;
            this.InequalityBox.Location = new System.Drawing.Point(416, 43);
            this.InequalityBox.Name = "InequalityBox";
            this.InequalityBox.Size = new System.Drawing.Size(79, 17);
            this.InequalityBox.TabIndex = 5;
            this.InequalityBox.Text = "Inequalities";
            this.InequalityBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(413, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Would you like questions with inequalities? (harder)";
            // 
            // EnterButton
            // 
            this.EnterButton.Location = new System.Drawing.Point(350, 282);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(75, 23);
            this.EnterButton.TabIndex = 7;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Note: there will also be a few other questions at the end";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "You must select at least one question type!";
            this.label4.Visible = false;
            // 
            // RecommendButton
            // 
            this.RecommendButton.Location = new System.Drawing.Point(12, 112);
            this.RecommendButton.Name = "RecommendButton";
            this.RecommendButton.Size = new System.Drawing.Size(95, 23);
            this.RecommendButton.TabIndex = 10;
            this.RecommendButton.Text = "Recommended";
            this.RecommendButton.UseVisualStyleBackColor = true;
            this.RecommendButton.Click += new System.EventHandler(this.RecommendButton_Click);
            // 
            // QuestionPicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 398);
            this.Controls.Add(this.RecommendButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InequalityBox);
            this.Controls.Add(this.LineBox);
            this.Controls.Add(this.HalfLineBox);
            this.Controls.Add(this.CircleBox);
            this.Controls.Add(this.label1);
            this.Name = "QuestionPicker";
            this.Text = "QuestionPicker";
            this.Load += new System.EventHandler(this.QuestionPicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CircleBox;
        private System.Windows.Forms.CheckBox HalfLineBox;
        private System.Windows.Forms.CheckBox LineBox;
        private System.Windows.Forms.CheckBox InequalityBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RecommendButton;
    }
}