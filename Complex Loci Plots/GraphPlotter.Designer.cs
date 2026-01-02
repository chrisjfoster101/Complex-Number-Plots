namespace Forms_Implicits
{
    partial class GraphPlotter
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
            this.GraphPlot = new System.Windows.Forms.PictureBox();
            this.LHS = new System.Windows.Forms.TextBox();
            this.RHS = new System.Windows.Forms.TextBox();
            this.PlotButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.XBox = new System.Windows.Forms.TextBox();
            this.YBox = new System.Windows.Forms.TextBox();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.InequalityBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.GraphPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphPlot
            // 
            this.GraphPlot.BackColor = System.Drawing.Color.White;
            this.GraphPlot.Location = new System.Drawing.Point(12, 12);
            this.GraphPlot.Name = "GraphPlot";
            this.GraphPlot.Size = new System.Drawing.Size(512, 512);
            this.GraphPlot.TabIndex = 1;
            this.GraphPlot.TabStop = false;
            // 
            // LHS
            // 
            this.LHS.Location = new System.Drawing.Point(12, 530);
            this.LHS.Name = "LHS";
            this.LHS.Size = new System.Drawing.Size(156, 20);
            this.LHS.TabIndex = 2;
            this.LHS.Text = "mod(z-2+i)";
            // 
            // RHS
            // 
            this.RHS.Location = new System.Drawing.Point(228, 530);
            this.RHS.Name = "RHS";
            this.RHS.Size = new System.Drawing.Size(153, 20);
            this.RHS.TabIndex = 3;
            this.RHS.Text = "3";
            // 
            // PlotButton
            // 
            this.PlotButton.Location = new System.Drawing.Point(429, 528);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(75, 23);
            this.PlotButton.TabIndex = 5;
            this.PlotButton.Text = "Plot";
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Zoom Info:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Centre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Re:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(530, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Im:";
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(566, 96);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(100, 20);
            this.SizeBox.TabIndex = 11;
            this.SizeBox.Text = "10";
            // 
            // XBox
            // 
            this.XBox.Location = new System.Drawing.Point(553, 182);
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(100, 20);
            this.XBox.TabIndex = 12;
            this.XBox.Text = "0";
            // 
            // YBox
            // 
            this.YBox.Location = new System.Drawing.Point(553, 208);
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(100, 20);
            this.YBox.TabIndex = 13;
            this.YBox.Text = "0";
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.LoadingLabel.Location = new System.Drawing.Point(548, 264);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(97, 25);
            this.LoadingLabel.TabIndex = 14;
            this.LoadingLabel.Text = "Loading...";
            this.LoadingLabel.Visible = false;
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ErrorLabel.Location = new System.Drawing.Point(550, 335);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(40, 17);
            this.ErrorLabel.TabIndex = 18;
            this.ErrorLabel.Text = "Error";
            this.ErrorLabel.Visible = false;
            // 
            // InequalityBox
            // 
            this.InequalityBox.AllowDrop = true;
            this.InequalityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InequalityBox.Location = new System.Drawing.Point(174, 530);
            this.InequalityBox.Name = "InequalityBox";
            this.InequalityBox.Size = new System.Drawing.Size(48, 21);
            this.InequalityBox.TabIndex = 19;
            // 
            // GraphPlotter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(769, 574);
            this.Controls.Add(this.InequalityBox);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.LoadingLabel);
            this.Controls.Add(this.YBox);
            this.Controls.Add(this.XBox);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PlotButton);
            this.Controls.Add(this.RHS);
            this.Controls.Add(this.LHS);
            this.Controls.Add(this.GraphPlot);
            this.Name = "GraphPlotter";
            this.Text = "Implicit Graph Plotter";
            ((System.ComponentModel.ISupportInitialize)(this.GraphPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox GraphPlot;
        private System.Windows.Forms.TextBox LHS;
        private System.Windows.Forms.TextBox RHS;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.TextBox XBox;
        private System.Windows.Forms.TextBox YBox;
        private System.Windows.Forms.Label LoadingLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.ComboBox InequalityBox;
    }
}

