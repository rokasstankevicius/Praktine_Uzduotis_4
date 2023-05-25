namespace ReceverGUI
{
    partial class ReceverGUI
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
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            richTextBox3 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 440);
            button1.Name = "button1";
            button1.Size = new Size(198, 31);
            button1.TabIndex = 15;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 347);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 21;
            label3.Text = "PUBLIC KEY:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(318, 12);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 20;
            label2.Text = "SIGNATURE:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 19;
            label1.Text = "TEXT:";
            // 
            // richTextBox3
            // 
            richTextBox3.Location = new Point(318, 35);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.Size = new Size(300, 294);
            richTextBox3.TabIndex = 18;
            richTextBox3.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(12, 370);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(606, 64);
            richTextBox2.TabIndex = 17;
            richTextBox2.Text = "";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 35);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(300, 294);
            richTextBox1.TabIndex = 16;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(420, 440);
            button2.Name = "button2";
            button2.Size = new Size(198, 31);
            button2.TabIndex = 22;
            button2.Text = "Verify";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ReceverGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 515);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox3);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Name = "ReceverGUI";
            Text = "Recever";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private RichTextBox richTextBox3;
        private RichTextBox richTextBox2;
        private RichTextBox richTextBox1;
        private Button button2;
    }
}