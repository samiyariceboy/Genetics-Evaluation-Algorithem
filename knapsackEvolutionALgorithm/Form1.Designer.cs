
namespace knapsackEvolutionALgorithm
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
            System.Windows.Forms.Label ExcutedTimeLabel;
            this.CapacityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EarlyPopulationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NumberOfGenerationRepetitionsTextBox = new System.Windows.Forms.TextBox();
            this.ItemsTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.NumberOfParentsTextBox = new System.Windows.Forms.TextBox();
            this.Run = new System.Windows.Forms.Button();
            this.ExcutedTimeTextBox = new System.Windows.Forms.TextBox();
            ExcutedTimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExcutedTimeLabel
            // 
            ExcutedTimeLabel.AutoSize = true;
            ExcutedTimeLabel.Location = new System.Drawing.Point(606, 402);
            ExcutedTimeLabel.Name = "ExcutedTimeLabel";
            ExcutedTimeLabel.Size = new System.Drawing.Size(37, 20);
            ExcutedTimeLabel.TabIndex = 12;
            ExcutedTimeLabel.Text = "زمان";
            ExcutedTimeLabel.Click += new System.EventHandler(this.ExcutedTimeTextBox_Click);
            // 
            // CapacityTextBox
            // 
            this.CapacityTextBox.Location = new System.Drawing.Point(4, 4);
            this.CapacityTextBox.Name = "CapacityTextBox";
            this.CapacityTextBox.Size = new System.Drawing.Size(125, 27);
            this.CapacityTextBox.TabIndex = 0;
            this.CapacityTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ظرفیت کوله پشتی";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "جمعیت اولیه";
            // 
            // EarlyPopulationTextBox
            // 
            this.EarlyPopulationTextBox.Location = new System.Drawing.Point(267, 8);
            this.EarlyPopulationTextBox.Name = "EarlyPopulationTextBox";
            this.EarlyPopulationTextBox.Size = new System.Drawing.Size(125, 27);
            this.EarlyPopulationTextBox.TabIndex = 2;
            this.EarlyPopulationTextBox.TextChanged += new System.EventHandler(this.EarlyPopulationTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "تعداد تکرار نسل";
            // 
            // NumberOfGenerationRepetitionsTextBox
            // 
            this.NumberOfGenerationRepetitionsTextBox.Location = new System.Drawing.Point(267, 57);
            this.NumberOfGenerationRepetitionsTextBox.Name = "NumberOfGenerationRepetitionsTextBox";
            this.NumberOfGenerationRepetitionsTextBox.Size = new System.Drawing.Size(125, 27);
            this.NumberOfGenerationRepetitionsTextBox.TabIndex = 4;
            // 
            // ItemsTextBox1
            // 
            this.ItemsTextBox1.Location = new System.Drawing.Point(12, 117);
            this.ItemsTextBox1.Name = "ItemsTextBox1";
            this.ItemsTextBox1.Size = new System.Drawing.Size(246, 311);
            this.ItemsTextBox1.TabIndex = 6;
            this.ItemsTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "اجناس و وزن ها";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "تعداد والدین";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // NumberOfParentsTextBox
            // 
            this.NumberOfParentsTextBox.Location = new System.Drawing.Point(4, 54);
            this.NumberOfParentsTextBox.Name = "NumberOfParentsTextBox";
            this.NumberOfParentsTextBox.Size = new System.Drawing.Size(125, 27);
            this.NumberOfParentsTextBox.TabIndex = 8;
            this.NumberOfParentsTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(284, 399);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(94, 29);
            this.Run.TabIndex = 10;
            this.Run.Text = "Train";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // ExcutedTimeTextBox
            // 
            this.ExcutedTimeTextBox.Location = new System.Drawing.Point(663, 399);
            this.ExcutedTimeTextBox.Name = "ExcutedTimeTextBox";
            this.ExcutedTimeTextBox.Size = new System.Drawing.Size(125, 27);
            this.ExcutedTimeTextBox.TabIndex = 13;
            this.ExcutedTimeTextBox.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExcutedTimeTextBox);
            this.Controls.Add(ExcutedTimeLabel);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NumberOfParentsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ItemsTextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumberOfGenerationRepetitionsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EarlyPopulationTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CapacityTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Knapsack";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CapacityTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EarlyPopulationTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumberOfGenerationRepetitionsTextBox;
        private System.Windows.Forms.RichTextBox ItemsTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NumberOfParentsTextBox;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.TextBox ExcutedTimeTextBox;
    }
}

