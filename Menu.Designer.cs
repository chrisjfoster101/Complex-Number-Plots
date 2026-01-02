
namespace Forms_Implicits
{
    partial class Menu
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
            this.LociButton = new System.Windows.Forms.Button();
            this.RevisionButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LociButton
            // 
            this.LociButton.Location = new System.Drawing.Point(166, 151);
            this.LociButton.Name = "LociButton";
            this.LociButton.Size = new System.Drawing.Size(116, 63);
            this.LociButton.TabIndex = 0;
            this.LociButton.Text = "Complex Loci Plotter";
            this.LociButton.UseVisualStyleBackColor = true;
            this.LociButton.Click += new System.EventHandler(this.LociButton_Click);
            // 
            // RevisionButton
            // 
            this.RevisionButton.Location = new System.Drawing.Point(369, 151);
            this.RevisionButton.Name = "RevisionButton";
            this.RevisionButton.Size = new System.Drawing.Size(116, 63);
            this.RevisionButton.TabIndex = 1;
            this.RevisionButton.Text = "Revision Questions";
            this.RevisionButton.UseVisualStyleBackColor = true;
            this.RevisionButton.Click += new System.EventHandler(this.RevisionButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(288, 272);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 408);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RevisionButton);
            this.Controls.Add(this.LociButton);
            this.Name = "Menu";
            this.Text = "Complex Loci Revision (Menu)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LociButton;
        private System.Windows.Forms.Button RevisionButton;
        private System.Windows.Forms.Button ExitButton;
    }
}