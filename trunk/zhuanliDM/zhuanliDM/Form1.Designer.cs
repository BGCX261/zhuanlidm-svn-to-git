namespace ldj
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxDT = new System.Windows.Forms.ComboBox();
            this.cbxNPC = new System.Windows.Forms.ComboBox();
            this.cbxSDIndex = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHandle = new System.Windows.Forms.TextBox();
            this.btnStartFishing = new System.Windows.Forms.Button();
            this.btnStopFishing = new System.Windows.Forms.Button();
            this.btnStartAttack = new System.Windows.Forms.Button();
            this.btnStopAttack = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDtStr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAttackWaitTime = new System.Windows.Forms.TextBox();
            this.cbxAutoPick = new System.Windows.Forms.CheckBox();
            this.btnStartPlanting = new System.Windows.Forms.Button();
            this.btnStopPlanting = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxPlantIndex = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标帮会地图:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "自动寻路NPC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "第几个属地:";
            // 
            // cbxDT
            // 
            this.cbxDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDT.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxDT.FormattingEnabled = true;
            this.cbxDT.Location = new System.Drawing.Point(99, 18);
            this.cbxDT.Name = "cbxDT";
            this.cbxDT.Size = new System.Drawing.Size(192, 25);
            this.cbxDT.TabIndex = 1;
            this.cbxDT.SelectedIndexChanged += new System.EventHandler(this.cbxDT_SelectedIndexChanged);
            // 
            // cbxNPC
            // 
            this.cbxNPC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNPC.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxNPC.FormattingEnabled = true;
            this.cbxNPC.Location = new System.Drawing.Point(99, 46);
            this.cbxNPC.Name = "cbxNPC";
            this.cbxNPC.Size = new System.Drawing.Size(192, 25);
            this.cbxNPC.TabIndex = 1;
            // 
            // cbxSDIndex
            // 
            this.cbxSDIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSDIndex.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSDIndex.FormattingEnabled = true;
            this.cbxSDIndex.Location = new System.Drawing.Point(99, 74);
            this.cbxSDIndex.Name = "cbxSDIndex";
            this.cbxSDIndex.Size = new System.Drawing.Size(192, 25);
            this.cbxSDIndex.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(61, 219);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStop.Location = new System.Drawing.Point(200, 248);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Enabled = false;
            this.btnContinue.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnContinue.Location = new System.Drawing.Point(61, 248);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "继续";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPause.Location = new System.Drawing.Point(200, 219);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtPID
            // 
            this.txtPID.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPID.Location = new System.Drawing.Point(99, 103);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(86, 23);
            this.txtPID.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(13, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "进程ID:";
            // 
            // txtHandle
            // 
            this.txtHandle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHandle.Location = new System.Drawing.Point(205, 103);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(86, 23);
            this.txtHandle.TabIndex = 3;
            // 
            // btnStartFishing
            // 
            this.btnStartFishing.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartFishing.Location = new System.Drawing.Point(61, 277);
            this.btnStartFishing.Name = "btnStartFishing";
            this.btnStartFishing.Size = new System.Drawing.Size(75, 23);
            this.btnStartFishing.TabIndex = 4;
            this.btnStartFishing.Text = "开始钓鱼";
            this.btnStartFishing.UseVisualStyleBackColor = true;
            this.btnStartFishing.Click += new System.EventHandler(this.btnStartFishing_Click);
            // 
            // btnStopFishing
            // 
            this.btnStopFishing.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopFishing.Location = new System.Drawing.Point(200, 277);
            this.btnStopFishing.Name = "btnStopFishing";
            this.btnStopFishing.Size = new System.Drawing.Size(75, 23);
            this.btnStopFishing.TabIndex = 4;
            this.btnStopFishing.Text = "停止钓鱼";
            this.btnStopFishing.UseVisualStyleBackColor = true;
            this.btnStopFishing.Click += new System.EventHandler(this.btnStopFishing_Click);
            // 
            // btnStartAttack
            // 
            this.btnStartAttack.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartAttack.Location = new System.Drawing.Point(61, 306);
            this.btnStartAttack.Name = "btnStartAttack";
            this.btnStartAttack.Size = new System.Drawing.Size(75, 23);
            this.btnStartAttack.TabIndex = 4;
            this.btnStartAttack.Text = "开始打怪";
            this.btnStartAttack.UseVisualStyleBackColor = true;
            this.btnStartAttack.Click += new System.EventHandler(this.btnStartAttack_Click);
            // 
            // btnStopAttack
            // 
            this.btnStopAttack.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopAttack.Location = new System.Drawing.Point(200, 306);
            this.btnStopAttack.Name = "btnStopAttack";
            this.btnStopAttack.Size = new System.Drawing.Size(75, 23);
            this.btnStopAttack.TabIndex = 4;
            this.btnStopAttack.Text = "停止打怪";
            this.btnStopAttack.UseVisualStyleBackColor = true;
            this.btnStopAttack.Click += new System.EventHandler(this.btnStopAttack_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(13, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "易游答题字串:";
            // 
            // txtDtStr
            // 
            this.txtDtStr.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDtStr.Location = new System.Drawing.Point(99, 132);
            this.txtDtStr.Name = "txtDtStr";
            this.txtDtStr.Size = new System.Drawing.Size(192, 23);
            this.txtDtStr.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(13, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "打怪间隔:";
            // 
            // txtAttackWaitTime
            // 
            this.txtAttackWaitTime.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAttackWaitTime.Location = new System.Drawing.Point(99, 161);
            this.txtAttackWaitTime.Name = "txtAttackWaitTime";
            this.txtAttackWaitTime.Size = new System.Drawing.Size(86, 23);
            this.txtAttackWaitTime.TabIndex = 3;
            this.txtAttackWaitTime.Text = "1000";
            // 
            // cbxAutoPick
            // 
            this.cbxAutoPick.AutoSize = true;
            this.cbxAutoPick.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxAutoPick.Location = new System.Drawing.Point(205, 161);
            this.cbxAutoPick.Name = "cbxAutoPick";
            this.cbxAutoPick.Size = new System.Drawing.Size(75, 21);
            this.cbxAutoPick.TabIndex = 5;
            this.cbxAutoPick.Text = "自动捡取";
            this.cbxAutoPick.UseVisualStyleBackColor = true;
            // 
            // btnStartPlanting
            // 
            this.btnStartPlanting.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartPlanting.Location = new System.Drawing.Point(61, 336);
            this.btnStartPlanting.Name = "btnStartPlanting";
            this.btnStartPlanting.Size = new System.Drawing.Size(75, 23);
            this.btnStartPlanting.TabIndex = 6;
            this.btnStartPlanting.Text = "开始种植";
            this.btnStartPlanting.UseVisualStyleBackColor = true;
            this.btnStartPlanting.Click += new System.EventHandler(this.btnStartPlanting_Click);
            // 
            // btnStopPlanting
            // 
            this.btnStopPlanting.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopPlanting.Location = new System.Drawing.Point(200, 336);
            this.btnStopPlanting.Name = "btnStopPlanting";
            this.btnStopPlanting.Size = new System.Drawing.Size(75, 23);
            this.btnStopPlanting.TabIndex = 6;
            this.btnStopPlanting.Text = "停止种植";
            this.btnStopPlanting.UseVisualStyleBackColor = true;
            this.btnStopPlanting.Click += new System.EventHandler(this.btnStopPlanting_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(13, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "第几种作物:";
            // 
            // cbxPlantIndex
            // 
            this.cbxPlantIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPlantIndex.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxPlantIndex.FormattingEnabled = true;
            this.cbxPlantIndex.Location = new System.Drawing.Point(99, 188);
            this.cbxPlantIndex.Name = "cbxPlantIndex";
            this.cbxPlantIndex.Size = new System.Drawing.Size(192, 25);
            this.cbxPlantIndex.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 375);
            this.Controls.Add(this.btnStopPlanting);
            this.Controls.Add(this.btnStartPlanting);
            this.Controls.Add(this.cbxAutoPick);
            this.Controls.Add(this.btnStopAttack);
            this.Controls.Add(this.btnStartAttack);
            this.Controls.Add(this.btnStopFishing);
            this.Controls.Add(this.btnStartFishing);
            this.Controls.Add(this.txtHandle);
            this.Controls.Add(this.txtAttackWaitTime);
            this.Controls.Add(this.txtDtStr);
            this.Controls.Add(this.txtPID);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cbxPlantIndex);
            this.Controls.Add(this.cbxSDIndex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxNPC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxDT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxDT;
        private System.Windows.Forms.ComboBox cbxNPC;
        private System.Windows.Forms.ComboBox cbxSDIndex;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TextBox txtPID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHandle;
        private System.Windows.Forms.Button btnStartFishing;
        private System.Windows.Forms.Button btnStopFishing;
        private System.Windows.Forms.Button btnStartAttack;
        private System.Windows.Forms.Button btnStopAttack;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDtStr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAttackWaitTime;
        private System.Windows.Forms.CheckBox cbxAutoPick;
        private System.Windows.Forms.Button btnStartPlanting;
        private System.Windows.Forms.Button btnStopPlanting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxPlantIndex;
    }
}

