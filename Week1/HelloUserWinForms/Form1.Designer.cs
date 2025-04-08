namespace HelloUserWinForms
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
            this.label1 = new System.Windows.Forms.Label();
            this.helloUserTextBox = new System.Windows.Forms.TextBox();
            this.HelloUserButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // helloUserTextBox
            // 
            this.helloUserTextBox.Location = new System.Drawing.Point(272, 32);
            this.helloUserTextBox.Name = "helloUserTextBox";
            this.helloUserTextBox.Size = new System.Drawing.Size(158, 22);
            this.helloUserTextBox.TabIndex = 1;
            // 
            // HelloUserButton
            // 
            this.HelloUserButton.Location = new System.Drawing.Point(447, 35);
            this.HelloUserButton.Name = "HelloUserButton";
            this.HelloUserButton.Size = new System.Drawing.Size(150, 23);
            this.HelloUserButton.TabIndex = 2;
            this.HelloUserButton.Text = "Sai Hi";
            this.HelloUserButton.UseVisualStyleBackColor = true;
            this.HelloUserButton.Click += new System.EventHandler(this.helloUserButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.HelloUserButton);
            this.Controls.Add(this.helloUserTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox helloUserTextBox;
        private System.Windows.Forms.Button HelloUserButton;
    }
}

