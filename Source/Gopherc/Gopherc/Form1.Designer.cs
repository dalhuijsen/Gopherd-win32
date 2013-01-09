namespace Gopherc
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Backward = new System.Windows.Forms.ToolStripMenuItem();
            this.Forward = new System.Windows.Forms.ToolStripMenuItem();
            this.Bar = new System.Windows.Forms.TextBox();
            this.Canvas = new System.Windows.Forms.WebBrowser();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Backward,
            this.Forward});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Backward
            // 
            this.Backward.Enabled = false;
            this.Backward.Name = "Backward";
            this.Backward.Size = new System.Drawing.Size(27, 20);
            this.Backward.Text = "<";
            this.Backward.ToolTipText = "Go Back";
            // 
            // Forward
            // 
            this.Forward.Enabled = false;
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(27, 20);
            this.Forward.Text = ">";
            this.Forward.ToolTipText = "Go Forward";
            // 
            // Bar
            // 
            this.Bar.Location = new System.Drawing.Point(67, 4);
            this.Bar.Name = "Bar";
            this.Bar.Size = new System.Drawing.Size(488, 20);
            this.Bar.TabIndex = 1;
            this.Bar.Text = "gopher://127.0.0.1/";
            this.Bar.WordWrap = false;
            this.Bar.TextChanged += new System.EventHandler(this.Bar_TextChanged);
            this.Bar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Bar_KeyDown);
            // 
            // Canvas
            // 
            this.Canvas.Location = new System.Drawing.Point(0, 27);
            this.Canvas.MinimumSize = new System.Drawing.Size(20, 20);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(555, 382);
            this.Canvas.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 409);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.Bar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Backward;
        private System.Windows.Forms.ToolStripMenuItem Forward;
        private System.Windows.Forms.TextBox Bar;
        private System.Windows.Forms.WebBrowser Canvas;

    }
}

