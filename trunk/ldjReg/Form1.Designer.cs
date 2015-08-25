namespace ldjReg
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
            this.txtMCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegCode = new System.Windows.Forms.TextBox();
            this.btnCreateRegCode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "机器码:";
            // 
            // txtMCode
            // 
            this.txtMCode.Location = new System.Drawing.Point(68, 34);
            this.txtMCode.Name = "txtMCode";
            this.txtMCode.Size = new System.Drawing.Size(235, 23);
            this.txtMCode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "注册码:";
            // 
            // txtRegCode
            // 
            this.txtRegCode.Location = new System.Drawing.Point(68, 119);
            this.txtRegCode.Multiline = true;
            this.txtRegCode.Name = "txtRegCode";
            this.txtRegCode.Size = new System.Drawing.Size(235, 86);
            this.txtRegCode.TabIndex = 1;
            // 
            // btnCreateRegCode
            // 
            this.btnCreateRegCode.Location = new System.Drawing.Point(228, 63);
            this.btnCreateRegCode.Name = "btnCreateRegCode";
            this.btnCreateRegCode.Size = new System.Drawing.Size(75, 23);
            this.btnCreateRegCode.TabIndex = 2;
            this.btnCreateRegCode.Text = "产生";
            this.btnCreateRegCode.UseVisualStyleBackColor = true;
            this.btnCreateRegCode.Click += new System.EventHandler(this.btnCreateRegCode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 247);
            this.Controls.Add(this.btnCreateRegCode);
            this.Controls.Add(this.txtRegCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMCode);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegCode;
        private System.Windows.Forms.Button btnCreateRegCode;
    }
}

