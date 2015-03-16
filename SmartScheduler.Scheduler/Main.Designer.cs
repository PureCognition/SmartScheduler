using System.ComponentModel;
using System.Windows.Forms;

namespace SmartScheduler.SchedulerApplication
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.Schedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Schedule
            // 
            this.Schedule.Location = new System.Drawing.Point(218, 40);
            this.Schedule.Name = "Schedule";
            this.Schedule.Size = new System.Drawing.Size(75, 23);
            this.Schedule.TabIndex = 0;
            this.Schedule.Text = "Schedule";
            this.Schedule.UseVisualStyleBackColor = true;
            this.Schedule.Click += new System.EventHandler(this.Schedule_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 96);
            this.Controls.Add(this.Schedule);
            this.Name = "Main";
            this.Text = "Smart Scheduler";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Schedule;
    }
}

