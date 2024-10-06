namespace NonBlocklingPrintNumbersMultiThreading
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
            btnDoTme = new Button();
            btnPrintNumbers = new Button();
            lbNumbers = new ListBox();
            lblTime = new Label();
            SuspendLayout();
            // 
            // btnDoTme
            // 
            btnDoTme.Font = new Font("Segoe UI", 10F);
            btnDoTme.Location = new Point(76, 23);
            btnDoTme.Name = "btnDoTme";
            btnDoTme.Size = new Size(236, 31);
            btnDoTme.TabIndex = 0;
            btnDoTme.Text = "Do Time Consuming Work";
            btnDoTme.UseVisualStyleBackColor = true;
            btnDoTme.Click += btnDoTme_Click;
            // 
            // btnPrintNumbers
            // 
            btnPrintNumbers.Font = new Font("Segoe UI", 10F);
            btnPrintNumbers.Location = new Point(76, 70);
            btnPrintNumbers.Name = "btnPrintNumbers";
            btnPrintNumbers.Size = new Size(236, 31);
            btnPrintNumbers.TabIndex = 1;
            btnPrintNumbers.Text = "Print Numbers";
            btnPrintNumbers.UseVisualStyleBackColor = true;
            btnPrintNumbers.Click += btnPrintNumbers_Click;
            // 
            // lbNumbers
            // 
            lbNumbers.FormattingEnabled = true;
            lbNumbers.ItemHeight = 15;
            lbNumbers.Location = new Point(76, 179);
            lbNumbers.Name = "lbNumbers";
            lbNumbers.Size = new Size(236, 154);
            lbNumbers.TabIndex = 3;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(76, 400);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(0, 15);
            lblTime.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(381, 516);
            Controls.Add(lblTime);
            Controls.Add(lbNumbers);
            Controls.Add(btnPrintNumbers);
            Controls.Add(btnDoTme);
            Name = "Form1";
            Text = "NonBlocking Print Numbers Multi-Threaded";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDoTme;
        private Button btnPrintNumbers;
        private ListBox lbNumbers;
        private Label lblTime;
    }
}
