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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.btnStartXY = new System.Windows.Forms.Button();
            this.btnStopXY = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxXYIndex = new System.Windows.Forms.ComboBox();
            this.btnStartPS = new System.Windows.Forms.Button();
            this.btnStopPS = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnStopRun = new System.Windows.Forms.Button();
            this.cbxHH = new System.Windows.Forms.CheckBox();
            this.btnKJ = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.chkLog = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxProcesses = new System.Windows.Forms.ComboBox();
            this.btnActive = new System.Windows.Forms.Button();
            this.gbSetting = new System.Windows.Forms.GroupBox();
            this.gbStart = new System.Windows.Forms.GroupBox();
            this.btnStartPrintTree = new System.Windows.Forms.Button();
            this.gbStop = new System.Windows.Forms.GroupBox();
            this.btnStopPrintTree = new System.Windows.Forms.Button();
            this.cbZLDW = new System.Windows.Forms.CheckBox();
            this.gbSetting.SuspendLayout();
            this.gbStart.SuspendLayout();
            this.gbStop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标帮会地图:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "自动寻路NPC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 89);
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
            this.cbxDT.Location = new System.Drawing.Point(92, 29);
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
            this.cbxNPC.Location = new System.Drawing.Point(92, 57);
            this.cbxNPC.Name = "cbxNPC";
            this.cbxNPC.Size = new System.Drawing.Size(192, 25);
            this.cbxNPC.TabIndex = 1;
            // 
            // cbxSDIndex
            // 
            this.cbxSDIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSDIndex.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSDIndex.FormattingEnabled = true;
            this.cbxSDIndex.Location = new System.Drawing.Point(92, 85);
            this.cbxSDIndex.Name = "cbxSDIndex";
            this.cbxSDIndex.Size = new System.Drawing.Size(192, 25);
            this.cbxSDIndex.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(6, 22);
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
            this.btnStop.Location = new System.Drawing.Point(6, 50);
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
            this.btnContinue.Location = new System.Drawing.Point(6, 50);
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
            this.btnPause.Location = new System.Drawing.Point(6, 22);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // txtPID
            // 
            this.txtPID.Enabled = false;
            this.txtPID.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPID.Location = new System.Drawing.Point(92, 143);
            this.txtPID.Name = "txtPID";
            this.txtPID.Size = new System.Drawing.Size(59, 23);
            this.txtPID.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "进程ID:";
            // 
            // txtHandle
            // 
            this.txtHandle.Enabled = false;
            this.txtHandle.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHandle.Location = new System.Drawing.Point(154, 143);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(59, 23);
            this.txtHandle.TabIndex = 3;
            // 
            // btnStartFishing
            // 
            this.btnStartFishing.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartFishing.Location = new System.Drawing.Point(6, 78);
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
            this.btnStopFishing.Location = new System.Drawing.Point(6, 78);
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
            this.btnStartAttack.Location = new System.Drawing.Point(6, 105);
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
            this.btnStopAttack.Location = new System.Drawing.Point(6, 105);
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
            this.label5.Location = new System.Drawing.Point(6, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "易游答题字串:";
            // 
            // txtDtStr
            // 
            this.txtDtStr.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDtStr.Location = new System.Drawing.Point(92, 172);
            this.txtDtStr.Name = "txtDtStr";
            this.txtDtStr.Size = new System.Drawing.Size(192, 23);
            this.txtDtStr.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "打怪间隔:";
            // 
            // txtAttackWaitTime
            // 
            this.txtAttackWaitTime.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAttackWaitTime.Location = new System.Drawing.Point(92, 201);
            this.txtAttackWaitTime.Name = "txtAttackWaitTime";
            this.txtAttackWaitTime.Size = new System.Drawing.Size(40, 23);
            this.txtAttackWaitTime.TabIndex = 3;
            this.txtAttackWaitTime.Text = "1000";
            // 
            // cbxAutoPick
            // 
            this.cbxAutoPick.AutoSize = true;
            this.cbxAutoPick.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxAutoPick.Location = new System.Drawing.Point(189, 202);
            this.cbxAutoPick.Name = "cbxAutoPick";
            this.cbxAutoPick.Size = new System.Drawing.Size(51, 21);
            this.cbxAutoPick.TabIndex = 5;
            this.cbxAutoPick.Text = "捡取";
            this.cbxAutoPick.UseVisualStyleBackColor = true;
            // 
            // btnStartPlanting
            // 
            this.btnStartPlanting.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartPlanting.Location = new System.Drawing.Point(6, 135);
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
            this.btnStopPlanting.Location = new System.Drawing.Point(6, 135);
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
            this.label7.Location = new System.Drawing.Point(6, 232);
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
            this.cbxPlantIndex.Location = new System.Drawing.Point(92, 228);
            this.cbxPlantIndex.Name = "cbxPlantIndex";
            this.cbxPlantIndex.Size = new System.Drawing.Size(192, 25);
            this.cbxPlantIndex.TabIndex = 1;
            // 
            // btnStartXY
            // 
            this.btnStartXY.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartXY.Location = new System.Drawing.Point(6, 164);
            this.btnStartXY.Name = "btnStartXY";
            this.btnStartXY.Size = new System.Drawing.Size(75, 23);
            this.btnStartXY.TabIndex = 6;
            this.btnStartXY.Text = "开始星语";
            this.btnStartXY.UseVisualStyleBackColor = true;
            this.btnStartXY.Click += new System.EventHandler(this.btnStartXY_Click);
            // 
            // btnStopXY
            // 
            this.btnStopXY.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopXY.Location = new System.Drawing.Point(6, 164);
            this.btnStopXY.Name = "btnStopXY";
            this.btnStopXY.Size = new System.Drawing.Size(75, 23);
            this.btnStopXY.TabIndex = 6;
            this.btnStopXY.Text = "停止星语";
            this.btnStopXY.UseVisualStyleBackColor = true;
            this.btnStopXY.Click += new System.EventHandler(this.btnStopXY_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "第几个尾巴:";
            // 
            // cbxXYIndex
            // 
            this.cbxXYIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxXYIndex.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxXYIndex.FormattingEnabled = true;
            this.cbxXYIndex.Location = new System.Drawing.Point(92, 256);
            this.cbxXYIndex.Name = "cbxXYIndex";
            this.cbxXYIndex.Size = new System.Drawing.Size(192, 25);
            this.cbxXYIndex.TabIndex = 1;
            // 
            // btnStartPS
            // 
            this.btnStartPS.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartPS.Location = new System.Drawing.Point(6, 193);
            this.btnStartPS.Name = "btnStartPS";
            this.btnStartPS.Size = new System.Drawing.Size(75, 23);
            this.btnStartPS.TabIndex = 6;
            this.btnStartPS.Text = "开始跑商";
            this.btnStartPS.UseVisualStyleBackColor = true;
            this.btnStartPS.Click += new System.EventHandler(this.btnStartPS_Click);
            // 
            // btnStopPS
            // 
            this.btnStopPS.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopPS.Location = new System.Drawing.Point(6, 193);
            this.btnStopPS.Name = "btnStopPS";
            this.btnStopPS.Size = new System.Drawing.Size(75, 23);
            this.btnStopPS.TabIndex = 6;
            this.btnStopPS.Text = "停止跑商";
            this.btnStopPS.UseVisualStyleBackColor = true;
            this.btnStopPS.Click += new System.EventHandler(this.btnStopPS_Click);
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnRun.Location = new System.Drawing.Point(6, 221);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "跑";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStopRun
            // 
            this.btnStopRun.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnStopRun.Location = new System.Drawing.Point(6, 221);
            this.btnStopRun.Name = "btnStopRun";
            this.btnStopRun.Size = new System.Drawing.Size(75, 23);
            this.btnStopRun.TabIndex = 7;
            this.btnStopRun.Text = "停";
            this.btnStopRun.UseVisualStyleBackColor = true;
            this.btnStopRun.Click += new System.EventHandler(this.btnStopRun_Click);
            // 
            // cbxHH
            // 
            this.cbxHH.AutoSize = true;
            this.cbxHH.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxHH.Location = new System.Drawing.Point(241, 202);
            this.cbxHH.Name = "cbxHH";
            this.cbxHH.Size = new System.Drawing.Size(51, 21);
            this.cbxHH.TabIndex = 5;
            this.cbxHH.Text = "黄蜂";
            this.cbxHH.UseVisualStyleBackColor = true;
            // 
            // btnKJ
            // 
            this.btnKJ.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnKJ.Location = new System.Drawing.Point(6, 249);
            this.btnKJ.Name = "btnKJ";
            this.btnKJ.Size = new System.Drawing.Size(75, 23);
            this.btnKJ.TabIndex = 7;
            this.btnKJ.Text = "科举";
            this.btnKJ.UseVisualStyleBackColor = true;
            this.btnKJ.Click += new System.EventHandler(this.btnKJ_Click);
            // 
            // btnTest
            // 
            this.btnTest.Enabled = false;
            this.btnTest.Font = new System.Drawing.Font("Microsoft YaHei", 9F);
            this.btnTest.Location = new System.Drawing.Point(6, 249);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // chkLog
            // 
            this.chkLog.AutoSize = true;
            this.chkLog.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkLog.Location = new System.Drawing.Point(135, 202);
            this.chkLog.Margin = new System.Windows.Forms.Padding(0);
            this.chkLog.Name = "chkLog";
            this.chkLog.Size = new System.Drawing.Size(51, 21);
            this.chkLog.TabIndex = 5;
            this.chkLog.Text = "日志";
            this.chkLog.UseVisualStyleBackColor = true;
            this.chkLog.CheckedChanged += new System.EventHandler(this.chkLog_CheckedChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRefresh.Location = new System.Drawing.Point(219, 113);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "刷新进程";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(6, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "进程:";
            // 
            // cbxProcesses
            // 
            this.cbxProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProcesses.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxProcesses.FormattingEnabled = true;
            this.cbxProcesses.Location = new System.Drawing.Point(92, 112);
            this.cbxProcesses.Name = "cbxProcesses";
            this.cbxProcesses.Size = new System.Drawing.Size(121, 25);
            this.cbxProcesses.TabIndex = 1;
            this.cbxProcesses.SelectedIndexChanged += new System.EventHandler(this.cbxProcesses_SelectedIndexChanged);
            // 
            // btnActive
            // 
            this.btnActive.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnActive.Location = new System.Drawing.Point(219, 143);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(65, 23);
            this.btnActive.TabIndex = 2;
            this.btnActive.Text = "激活窗口";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.btnActive_Click);
            // 
            // gbSetting
            // 
            this.gbSetting.Controls.Add(this.cbZLDW);
            this.gbSetting.Controls.Add(this.txtPID);
            this.gbSetting.Controls.Add(this.label1);
            this.gbSetting.Controls.Add(this.label2);
            this.gbSetting.Controls.Add(this.label3);
            this.gbSetting.Controls.Add(this.label4);
            this.gbSetting.Controls.Add(this.label9);
            this.gbSetting.Controls.Add(this.label7);
            this.gbSetting.Controls.Add(this.cbxDT);
            this.gbSetting.Controls.Add(this.label8);
            this.gbSetting.Controls.Add(this.label5);
            this.gbSetting.Controls.Add(this.cbxNPC);
            this.gbSetting.Controls.Add(this.label6);
            this.gbSetting.Controls.Add(this.cbxHH);
            this.gbSetting.Controls.Add(this.cbxSDIndex);
            this.gbSetting.Controls.Add(this.chkLog);
            this.gbSetting.Controls.Add(this.cbxProcesses);
            this.gbSetting.Controls.Add(this.cbxAutoPick);
            this.gbSetting.Controls.Add(this.cbxPlantIndex);
            this.gbSetting.Controls.Add(this.cbxXYIndex);
            this.gbSetting.Controls.Add(this.btnRefresh);
            this.gbSetting.Controls.Add(this.btnActive);
            this.gbSetting.Controls.Add(this.txtDtStr);
            this.gbSetting.Controls.Add(this.txtHandle);
            this.gbSetting.Controls.Add(this.txtAttackWaitTime);
            this.gbSetting.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSetting.Location = new System.Drawing.Point(12, 12);
            this.gbSetting.Name = "gbSetting";
            this.gbSetting.Size = new System.Drawing.Size(298, 313);
            this.gbSetting.TabIndex = 8;
            this.gbSetting.TabStop = false;
            this.gbSetting.Text = "设置";
            // 
            // gbStart
            // 
            this.gbStart.Controls.Add(this.btnStartPrintTree);
            this.gbStart.Controls.Add(this.btnStartPlanting);
            this.gbStart.Controls.Add(this.btnStart);
            this.gbStart.Controls.Add(this.btnContinue);
            this.gbStart.Controls.Add(this.btnStartFishing);
            this.gbStart.Controls.Add(this.btnKJ);
            this.gbStart.Controls.Add(this.btnStartAttack);
            this.gbStart.Controls.Add(this.btnRun);
            this.gbStart.Controls.Add(this.btnStartXY);
            this.gbStart.Controls.Add(this.btnStartPS);
            this.gbStart.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbStart.Location = new System.Drawing.Point(310, 12);
            this.gbStart.Name = "gbStart";
            this.gbStart.Size = new System.Drawing.Size(88, 313);
            this.gbStart.TabIndex = 8;
            this.gbStart.TabStop = false;
            this.gbStart.Text = "开始";
            // 
            // btnStartPrintTree
            // 
            this.btnStartPrintTree.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartPrintTree.Location = new System.Drawing.Point(6, 278);
            this.btnStartPrintTree.Name = "btnStartPrintTree";
            this.btnStartPrintTree.Size = new System.Drawing.Size(75, 23);
            this.btnStartPrintTree.TabIndex = 6;
            this.btnStartPrintTree.Text = "开始种树";
            this.btnStartPrintTree.UseVisualStyleBackColor = true;
            this.btnStartPrintTree.Click += new System.EventHandler(this.btnStartPrintTree_Click);
            // 
            // gbStop
            // 
            this.gbStop.Controls.Add(this.btnStop);
            this.gbStop.Controls.Add(this.btnPause);
            this.gbStop.Controls.Add(this.btnStopFishing);
            this.gbStop.Controls.Add(this.btnStopRun);
            this.gbStop.Controls.Add(this.btnStopAttack);
            this.gbStop.Controls.Add(this.btnTest);
            this.gbStop.Controls.Add(this.btnStopPrintTree);
            this.gbStop.Controls.Add(this.btnStopPlanting);
            this.gbStop.Controls.Add(this.btnStopPS);
            this.gbStop.Controls.Add(this.btnStopXY);
            this.gbStop.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbStop.Location = new System.Drawing.Point(404, 12);
            this.gbStop.Name = "gbStop";
            this.gbStop.Size = new System.Drawing.Size(90, 313);
            this.gbStop.TabIndex = 9;
            this.gbStop.TabStop = false;
            this.gbStop.Text = "结束";
            // 
            // btnStopPrintTree
            // 
            this.btnStopPrintTree.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStopPrintTree.Location = new System.Drawing.Point(6, 278);
            this.btnStopPrintTree.Name = "btnStopPrintTree";
            this.btnStopPrintTree.Size = new System.Drawing.Size(75, 23);
            this.btnStopPrintTree.TabIndex = 6;
            this.btnStopPrintTree.Text = "停止种树";
            this.btnStopPrintTree.UseVisualStyleBackColor = true;
            this.btnStopPrintTree.Click += new System.EventHandler(this.btnStopPrintTree_Click);
            // 
            // cbZLDW
            // 
            this.cbZLDW.AutoSize = true;
            this.cbZLDW.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbZLDW.Location = new System.Drawing.Point(92, 288);
            this.cbZLDW.Margin = new System.Windows.Forms.Padding(0);
            this.cbZLDW.Name = "cbZLDW";
            this.cbZLDW.Size = new System.Drawing.Size(184, 21);
            this.cbZLDW.TabIndex = 10;
            this.cbZLDW.Text = "专利定位(F1目标帮,F2自己帮)";
            this.cbZLDW.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(505, 330);
            this.Controls.Add(this.gbStop);
            this.Controls.Add(this.gbStart);
            this.Controls.Add(this.gbSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbSetting.ResumeLayout(false);
            this.gbSetting.PerformLayout();
            this.gbStart.ResumeLayout(false);
            this.gbStop.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnStartXY;
        private System.Windows.Forms.Button btnStopXY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxXYIndex;
        private System.Windows.Forms.Button btnStartPS;
        private System.Windows.Forms.Button btnStopPS;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnStopRun;
        private System.Windows.Forms.CheckBox cbxHH;
        private System.Windows.Forms.Button btnKJ;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chkLog;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxProcesses;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.GroupBox gbSetting;
        private System.Windows.Forms.GroupBox gbStart;
        private System.Windows.Forms.GroupBox gbStop;
        private System.Windows.Forms.Button btnStartPrintTree;
        private System.Windows.Forms.Button btnStopPrintTree;
        private System.Windows.Forms.CheckBox cbZLDW;
    }
}

