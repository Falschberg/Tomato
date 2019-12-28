namespace Tomatoes
{
    partial class TomatoesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TomatoesForm));
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTotalTime = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelTime
            // 
            this.labelTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTime.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.Color.Maroon;
            this.labelTime.Location = new System.Drawing.Point(5, 5);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(130, 40);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "00:00:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotalTime
            // 
            this.labelTotalTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTotalTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotalTime.ForeColor = System.Drawing.Color.Black;
            this.labelTotalTime.Location = new System.Drawing.Point(5, 50);
            this.labelTotalTime.Name = "labelTotalTime";
            this.labelTotalTime.Size = new System.Drawing.Size(130, 20);
            this.labelTotalTime.TabIndex = 1;
            this.labelTotalTime.Text = "TotalTime: 00:00:00";
            this.labelTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTotal.ForeColor = System.Drawing.Color.Black;
            this.labelTotal.Location = new System.Drawing.Point(140, 50);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(116, 20);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "yyyy:MM:dd - 0 t";
            this.labelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStart.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(140, 5);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(116, 42);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer
            // 
            this.timer.Interval = 99;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // TomatoesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 75);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelTotalTime);
            this.Controls.Add(this.labelTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TomatoesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "0 Tomatoes";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TomatoesForm_FormClosing);
            this.Load += new System.EventHandler(this.TomatoesForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTotalTime;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer;
    }
}

