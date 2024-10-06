namespace WinformDeadlock
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbTest = new TextBox();
            btnTest = new Button();
            lblTest = new Label();
            SuspendLayout();
            // 
            // tbTest
            // 
            tbTest.Location = new Point(141, 124);
            tbTest.Multiline = true;
            tbTest.Name = "tbTest";
            tbTest.Size = new Size(241, 58);
            tbTest.TabIndex = 0;
            // 
            // btnTest
            // 
            btnTest.Font = new Font("Segoe UI", 10F);
            btnTest.Location = new Point(141, 29);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(104, 35);
            btnTest.TabIndex = 1;
            btnTest.Text = "Test Deadlock";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // lblTest
            // 
            lblTest.AutoSize = true;
            lblTest.Location = new Point(141, 77);
            lblTest.Name = "lblTest";
            lblTest.Size = new Size(0, 15);
            lblTest.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 211);
            Controls.Add(lblTest);
            Controls.Add(btnTest);
            Controls.Add(tbTest);
            Name = "Form1";
            Text = "Test Deadlock";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbTest;
        private Button btnTest;
        private Label lblTest;
    }
}
