namespace Atomic
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnSearchOrView = new System.Windows.Forms.Button();
            this.lblNameOfTheSoftware = new System.Windows.Forms.Label();
            this.btnCreateFam = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearchOrView
            // 
            this.btnSearchOrView.Location = new System.Drawing.Point(12, 91);
            this.btnSearchOrView.Name = "btnSearchOrView";
            this.btnSearchOrView.Size = new System.Drawing.Size(100, 100);
            this.btnSearchOrView.TabIndex = 2;
            this.btnSearchOrView.Text = "Search families";
            this.btnSearchOrView.UseVisualStyleBackColor = true;
            this.btnSearchOrView.Click += new System.EventHandler(this.btnSearchOrView_Click);
            // 
            // lblNameOfTheSoftware
            // 
            this.lblNameOfTheSoftware.AutoSize = true;
            this.lblNameOfTheSoftware.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfTheSoftware.Location = new System.Drawing.Point(134, 29);
            this.lblNameOfTheSoftware.Name = "lblNameOfTheSoftware";
            this.lblNameOfTheSoftware.Size = new System.Drawing.Size(252, 24);
            this.lblNameOfTheSoftware.TabIndex = 3;
            this.lblNameOfTheSoftware.Text = "Homestay Management System";
            // 
            // btnCreateFam
            // 
            this.btnCreateFam.Location = new System.Drawing.Point(408, 91);
            this.btnCreateFam.Name = "btnCreateFam";
            this.btnCreateFam.Size = new System.Drawing.Size(100, 100);
            this.btnCreateFam.TabIndex = 2;
            this.btnCreateFam.Text = "Create new family";
            this.btnCreateFam.UseVisualStyleBackColor = true;
            this.btnCreateFam.Click += new System.EventHandler(this.btnCreateFam_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 2;
            this.button1.Text = "View all family";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 215);
            this.Controls.Add(this.lblNameOfTheSoftware);
            this.Controls.Add(this.btnCreateFam);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSearchOrView);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Atomic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchOrView;
        private System.Windows.Forms.Label lblNameOfTheSoftware;
        private System.Windows.Forms.Button btnCreateFam;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}

