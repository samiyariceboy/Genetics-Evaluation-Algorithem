
namespace knapsackEvolutionALgorithm.Presentation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.KnapsakProblem = new System.Windows.Forms.Button();
            this.MinimumPointFunctionsProblem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // KnapsakProblem
            // 
            resources.ApplyResources(this.KnapsakProblem, "KnapsakProblem");
            this.KnapsakProblem.Name = "KnapsakProblem";
            this.KnapsakProblem.UseVisualStyleBackColor = true;
            this.KnapsakProblem.Click += new System.EventHandler(this.KnapsakProblem_Click);
            // 
            // MinimumPointFunctionsProblem
            // 
            resources.ApplyResources(this.MinimumPointFunctionsProblem, "MinimumPointFunctionsProblem");
            this.MinimumPointFunctionsProblem.Name = "MinimumPointFunctionsProblem";
            this.MinimumPointFunctionsProblem.UseVisualStyleBackColor = true;
            this.MinimumPointFunctionsProblem.Click += new System.EventHandler(this.MinimumPointFunctionsProblem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MinimumPointFunctionsProblem);
            this.Controls.Add(this.KnapsakProblem);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button KnapsakProblem;
        private System.Windows.Forms.Button MinimumPointFunctionsProblem;
    }
}