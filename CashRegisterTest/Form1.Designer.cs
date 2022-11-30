namespace CashRegisterTest
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
            this.ivTestButton = new System.Windows.Forms.Button();
            this.ivListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ivTestButton
            // 
            this.ivTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ivTestButton.Location = new System.Drawing.Point(12, 339);
            this.ivTestButton.Name = "ivTestButton";
            this.ivTestButton.Size = new System.Drawing.Size(75, 23);
            this.ivTestButton.TabIndex = 0;
            this.ivTestButton.Text = "Test";
            this.ivTestButton.UseVisualStyleBackColor = true;
            this.ivTestButton.Click += new System.EventHandler(this.ivTestButton_Click);
            // 
            // ivListBox
            // 
            this.ivListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ivListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivListBox.FormattingEnabled = true;
            this.ivListBox.ItemHeight = 14;
            this.ivListBox.Location = new System.Drawing.Point(12, 12);
            this.ivListBox.Name = "ivListBox";
            this.ivListBox.Size = new System.Drawing.Size(322, 312);
            this.ivListBox.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 374);
            this.Controls.Add(this.ivListBox);
            this.Controls.Add(this.ivTestButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button ivTestButton;
        private System.Windows.Forms.ListBox ivListBox;
    }
}

