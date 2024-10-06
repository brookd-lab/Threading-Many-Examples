namespace NonBlockingCountCharacters
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
            btnGetCount = new Button();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // btnGetCount
            // 
            btnGetCount.Location = new Point(230, 142);
            btnGetCount.Name = "btnGetCount";
            btnGetCount.Size = new Size(137, 23);
            btnGetCount.TabIndex = 0;
            btnGetCount.Text = "Get Count Async";
            btnGetCount.UseVisualStyleBackColor = true;
            btnGetCount.Click += btnGetCount_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(233, 189);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 15);
            lblMessage.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMessage);
            Controls.Add(btnGetCount);
            Name = "Form1";
            Text = "Counting Characters - Non Blocking";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetCount;
        private Label lblMessage;
    }
}
