﻿namespace SideBar
{
    partial class LeftForm
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
            this.Left_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Left_timer
            // 
            this.Left_timer.Tick += new System.EventHandler(this.Left_Tick);
            // 
            // Left_Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(52, 474);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Left_Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Left Form";
            this.Load += new System.EventHandler(this.Left_Form_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Left_Form_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Left_Form_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Left_timer;
    }
}