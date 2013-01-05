namespace Gopherd
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
            this.button1 = new System.Windows.Forms.Button();
            this.RunningIndicator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Stop = new System.Windows.Forms.Button();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TSR = new System.Windows.Forms.CheckBox();
            this.Logging = new System.Windows.Forms.CheckBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.FancyIndexes = new System.Windows.Forms.CheckBox();
            this.Indexes = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.Debugging = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 240);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RunningIndicator
            // 
            this.RunningIndicator.AutoSize = true;
            this.RunningIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningIndicator.ForeColor = System.Drawing.Color.Lime;
            this.RunningIndicator.Location = new System.Drawing.Point(231, 222);
            this.RunningIndicator.Name = "RunningIndicator";
            this.RunningIndicator.Size = new System.Drawing.Size(49, 13);
            this.RunningIndicator.TabIndex = 1;
            this.RunningIndicator.Text = "running";
            this.RunningIndicator.Visible = false;
            this.RunningIndicator.Click += new System.EventHandler(this.RunningIndicator_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ServerName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "DocumentRoot";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(205, 149);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "DirectoryIndex";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "LogFile";
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(124, 240);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 14;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Gopherd.Form1);
            // 
            // TSR
            // 
            this.TSR.AutoSize = true;
            this.TSR.Checked = global::Gopherd.Properties.Settings.Default.TSR;
            this.TSR.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Gopherd.Properties.Settings.Default, "TSR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TSR.Location = new System.Drawing.Point(16, 196);
            this.TSR.Name = "TSR";
            this.TSR.Size = new System.Drawing.Size(48, 17);
            this.TSR.TabIndex = 15;
            this.TSR.Text = "TSR";
            this.TSR.UseVisualStyleBackColor = true;
            this.TSR.Visible = false;
            this.TSR.CheckedChanged += new System.EventHandler(this.TSR_CheckedChanged);
            // 
            // Logging
            // 
            this.Logging.AutoSize = true;
            this.Logging.Checked = global::Gopherd.Properties.Settings.Default.Logging;
            this.Logging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Logging.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Gopherd.Properties.Settings.Default, "Logging", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Logging.Location = new System.Drawing.Point(124, 149);
            this.Logging.Name = "Logging";
            this.Logging.Size = new System.Drawing.Size(64, 17);
            this.Logging.TabIndex = 13;
            this.Logging.Text = "Logging";
            this.Logging.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Gopherd.Properties.Settings.Default, "LogFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox5.Location = new System.Drawing.Point(100, 121);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(180, 20);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = global::Gopherd.Properties.Settings.Default.LogFile;
            // 
            // FancyIndexes
            // 
            this.FancyIndexes.AutoSize = true;
            this.FancyIndexes.Checked = global::Gopherd.Properties.Settings.Default.FancyIndexes;
            this.FancyIndexes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FancyIndexes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Gopherd.Properties.Settings.Default, "FancyIndexes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FancyIndexes.Location = new System.Drawing.Point(15, 172);
            this.FancyIndexes.Name = "FancyIndexes";
            this.FancyIndexes.Size = new System.Drawing.Size(92, 17);
            this.FancyIndexes.TabIndex = 10;
            this.FancyIndexes.Text = "FancyIndexes";
            this.FancyIndexes.UseVisualStyleBackColor = true;
            // 
            // Indexes
            // 
            this.Indexes.AutoSize = true;
            this.Indexes.Checked = global::Gopherd.Properties.Settings.Default.Indexes;
            this.Indexes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Indexes.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Gopherd.Properties.Settings.Default, "Indexes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Indexes.Location = new System.Drawing.Point(16, 149);
            this.Indexes.Name = "Indexes";
            this.Indexes.Size = new System.Drawing.Size(63, 17);
            this.Indexes.TabIndex = 9;
            this.Indexes.Text = "Indexes";
            this.Indexes.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Gopherd.Properties.Settings.Default, "DirectoryIndex", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox4.Location = new System.Drawing.Point(100, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(180, 20);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = global::Gopherd.Properties.Settings.Default.DirectoryIndex;
            // 
            // Debugging
            // 
            this.Debugging.AutoSize = true;
            this.Debugging.Checked = global::Gopherd.Properties.Settings.Default.Debugging;
            this.Debugging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Debugging.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Gopherd.Properties.Settings.Default, "Debugging", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Debugging.Location = new System.Drawing.Point(124, 172);
            this.Debugging.Name = "Debugging";
            this.Debugging.Size = new System.Drawing.Size(58, 17);
            this.Debugging.TabIndex = 7;
            this.Debugging.Text = "Debug";
            this.Debugging.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Gopherd.Properties.Settings.Default, "DocumentRoot", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Location = new System.Drawing.Point(100, 67);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(180, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = global::Gopherd.Properties.Settings.Default.DocumentRoot;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Gopherd.Properties.Settings.Default, "Port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox2.Location = new System.Drawing.Point(100, 40);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = global::Gopherd.Properties.Settings.Default.Port;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Gopherd.Properties.Settings.Default, "ServerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox1.Location = new System.Drawing.Point(100, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = global::Gopherd.Properties.Settings.Default.ServerName;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.TSR);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Logging);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.FancyIndexes);
            this.Controls.Add(this.Indexes);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.Debugging);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RunningIndicator);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Gopherd";
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.Label RunningIndicator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox Debugging;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Indexes;
        private System.Windows.Forms.CheckBox FancyIndexes;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox Logging;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.CheckBox TSR;
    }
}