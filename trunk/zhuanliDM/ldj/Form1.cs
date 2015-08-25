using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace ldj
{
    
    public partial class Form1 : Form
    {
        private List<DTNPC> dtNpcList;
        public const string PicPath = "Pic/";
        public const string RegistryDirName = "ldjtool";
        private const string GameProcessName = "LDJGame";//"devenv";//
        private List<string> DTList;
        private Thread worker;
        private static Func f;
        public const string GameName = "LuDingJi";
        private const string ClassName = "LuDingJi WndClass";//"Photo_Lightweight_Viewer";
        private static List<string> DTListEx;
        private string mCode="";
        private string regCode="";
        /// <summary>
        /// 打怪timer
        /// </summary>
        System.Timers.Timer Attimer;
        /// <summary>
        /// 答题timer
        /// </summary>
        System.Timers.Timer Antimer;
        /// <summary>
        /// 加血timer
        /// </summary>
        System.Timers.Timer Aytimer;
        /// <summary>
        /// 组队timer
        /// </summary>
        System.Timers.Timer Amtimer;
        public Form1()
        {
            InitializeComponent();
            Func.Log("InitializeComponent");
            FillDTListEx();
            BindCbxProcesses();
            DTNPC d1 = new DTNPC();
            DTList = new List<string>();
            string[] dtList = Directory.GetFiles(PicPath, "地图_*.bmp");
            foreach (string dt in dtList)
            {
                DTList.Add(dt.Replace(PicPath, "").Replace("地图_","").Replace(".bmp",""));
            }
            dtNpcList = new List<DTNPC>();
            //DTList.Add("百花谷");//
            //DTList.Add("程海");
            //DTList.Add("哀牢山");
            //DTList.Add("蓬莱");//
            //DTList.Add("嵩山");
            //DTList.Add("太子坡");//
            //DTList.Add("王屋山");
            //DTList.Add("五台山");//
            //DTList.Add("隐龙江");//
            for (int i = 1; i < 7; i++)
            {
                this.cbxSDIndex.Items.Add(i);
            }
            for (int i = 1; i < 9; i++)
            {
                this.cbxPlantIndex.Items.Add(i);
            }
            for (int i = 1; i < 7; i++)
            {
                this.cbxXYIndex.Items.Add(i);
            }
        }
        private void FillDTListEx()
        {
            DTListEx = new List<string>();
            DTListEx.Add("兵工厂");
            DTListEx.Add("京燕山庄");
            DTListEx.Add("空仞山");
            DTListEx.Add("朝云珠海");
            DTListEx.Add("龙旗营");
            DTListEx.Add("锁魂窟");
            DTListEx.Add("平安城");
            DTListEx.Add("明湖新村");
            DTListEx.Add("世外桃源");
            DTListEx.Add("天涯海角");
        }
        public delegate void SetControlEnable(Control c, bool eb);
        public delegate string GetControlText(Control c);
        public SetControlEnable DelegateSetControl = new SetControlEnable(DoSetControl);
        public delegate void DShowMsg(string msg);
        public DShowMsg delegateShowMsg = new DShowMsg(ShowMsg);
        public static void DoSetControl(Control c, bool eb)
        {
            c.Enabled = eb;
        }
        public static void ShowMsg(string msg)
        {
            Func.Log(msg);
            MessageBox.Show(msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                   Dm.dmsoft dm = new Dm.dmsoft();
                }
                catch
                {
                    Func.RegCom("dm.dll");
                }
                mCode = new Dm.dmsoft().GetMachineCode();
                regCode = Regedit.GetAppRegKey(RegistryDirName, "RegCode");
                if (string.IsNullOrEmpty(regCode) || !HardwareInfo.CheckCode(mCode, regCode, Form1.GameName))
                {
                    FrmReg r = new FrmReg();
                    if (DialogResult.OK != r.ShowDialog())
                    {
                        this.Close();
                        return;
                    }
                }
                
                foreach (string s in DTList)
                {
                    string[] xlNpcs = Directory.GetFiles(PicPath, "自动寻路_" + s + "_*.bmp");
                    List<XLNPC> xlNpcList = new List<XLNPC>();
                    foreach (string xl in xlNpcs)
                    {
                        XLNPC xlnpc = new XLNPC(xl.Replace(PicPath, ""), s + "_NPC_" + xl.Replace(PicPath + "自动寻路_" + s + "_", ""));
                        xlNpcList.Add(xlnpc);
                    }
                    if (xlNpcList.Count > 0)
                    {
                        DTNPC d = new DTNPC(s, xlNpcList);
                        dtNpcList.Add(d);
                    }
                }
                
                foreach (DTNPC dt in dtNpcList)
                {
                    if (!DTListEx.Contains(dt.DT))
                    {
                        this.cbxDT.Items.Add(dt);
                    }
                }
                this.txtDtStr.Text = Regedit.GetAppRegKey(RegistryDirName, "eyouMiMa");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbxNPC.Items.Clear();
            DTNPC dtNpc = dtNpcList.Find(delegate(DTNPC dlist) { return dlist.DT == this.cbxDT.Text; });
            if (dtNpc == null)
                return;
            foreach (XLNPC d in dtNpc.NPC)
            {
                this.cbxNPC.Items.Add(d);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cbZLDW.Checked == false)
            {
                if (this.cbxDT.Text == "")
                {
                    MessageBox.Show("目标帮会地图还没选");
                    return;
                }
                if (this.cbxNPC.Text == "")
                {
                    MessageBox.Show("自动寻路NPC还没选");
                    return;
                }
                if (this.cbxSDIndex.Text == "")
                {
                    MessageBox.Show("第几个属地还没选");
                    return;
                }
            }
            
            try
            {
                this.cbxDT.Enabled = false;
                this.cbxNPC.Enabled = false;
                this.cbxSDIndex.Enabled = false;
                this.btnStop.Enabled = true;
                string toPath = "";
                string xlPath="";
                string xlNpcPath = "";
                int sdIndex = 0;
                if (cbZLDW.Checked == false)
                {
                    toPath = "驿站_前往" + cbxDT.Text + ".bmp";
                    xlPath = ((XLNPC)this.cbxNPC.SelectedItem).XlNpc;
                    xlNpcPath = ((XLNPC)this.cbxNPC.SelectedItem).NPC;
                    sdIndex = int.Parse(this.cbxSDIndex.Text);
                }
                ThreadParam p = new ThreadParam(toPath, xlPath, xlNpcPath, sdIndex);
                //DoWork(p);
                ParameterizedThreadStart ps = new ParameterizedThreadStart(DoWork);
                worker = new Thread(ps);
                worker.Start(p);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "专利";
        }
        public void DoWork(object obj)
        {
            try
            {
                ThreadParam p = (ThreadParam)obj;

                string toPath = p.toPath;
                string xlPath = p.xlPath;
                string xlNpcPath = p.xlNpcPath;
                int sdIndex = p.sdIndex;
                f = new Func();
                f.FuncEventHandler += new EventHandler(f_FuncEventHandler);
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                Thread.Sleep(1000);
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
                if (cbZLDW.Checked == false)
                {
                    for (int i = 0; i < 30; i++)
                    {

                        f.DoZhuanliMission(toPath, xlPath, xlNpcPath, sdIndex);
                        //f.ZhuanliMission();
                        Thread.Sleep(10000);

                    }
                }
                else
                {
                    for (int i = 0; i < 20; i++)
                    {
                        f.DoZhuanliMissionEx();
                        Thread.Sleep(2000);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
            }
        }

        void f_FuncEventHandler(object sender, FuncEventArgs e)
        {
            if (e.WorkStatus == WorkStatus.Stop)
            {
                btnStop_Click(sender, e);
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            Func.Log("Stop 专利");
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                    this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                    //worker.Join(50000);                    
                    worker.Abort();
                    worker = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            Func.Log("Pause 专利");
            try
            {
                if (worker != null)
                {
                    if (worker.ThreadState != System.Threading.ThreadState.Suspended)
                    {
                        worker.Suspend();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Func.Log("Continue 专利");
            try
            {
                if (worker != null)
                {
                    if (worker.ThreadState == System.Threading.ThreadState.Suspended)
                    {
                        worker.Resume();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void PSThread(object obj)
        {
            try
            {
                ThreadParam p = obj as ThreadParam;

                string toPath = p.toPath;
                string xlPath = p.xlPath;
                string xlNpcPath = p.xlNpcPath;
                int sdIndex = p.sdIndex;
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                for (int i = 0; i < 9; i++)
                {
                    f.DoBusiness(txtDtStr.Text.Trim(), toPath,xlPath,xlNpcPath,sdIndex);
                }
                f.UnBindDM();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
                return;
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
            }
        }
        private void btnStartPS_Click(object sender, EventArgs e)
        {
            Func.Log("StartPS");
            if (this.cbxDT.Text == "")
            {
                MessageBox.Show("目标帮会地图还没选");
                return;
            }
            if (this.cbxNPC.Text == "")
            {
                MessageBox.Show("自动寻路NPC还没选");
                return;
            }
            if (this.cbxSDIndex.Text == "")
            {
                MessageBox.Show("第几个属地还没选");
                return;
            }
            try
            {
                if (txtDtStr.Text.Trim() == "")
                {
                    MessageBox.Show("你没有填写答题账号,无法自动答题,不能跑商");
                    return;
                }
                string toPath = cbxDT.Text ;
                string xlPath = ((XLNPC)this.cbxNPC.SelectedItem).XlNpc;
                string xlNpcPath = ((XLNPC)this.cbxNPC.SelectedItem).NPC;
                int sdIndex = int.Parse(this.cbxSDIndex.Text);
                ThreadParam p = new ThreadParam(toPath, xlPath, xlNpcPath, sdIndex);
                //DoWork(p);
                ParameterizedThreadStart ps = new ParameterizedThreadStart(PSThread);
                worker = new Thread(ps);
                worker.Start(p);
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "跑商";
        }

        private void btnStopPS_Click(object sender, EventArgs e)
        {
            Func.Log("StopPS");
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                    this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                    this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartFishing_Click(object sender, EventArgs e)
        {
            Func.Log("Start Fishing");
            try
            {
                worker = new Thread(new ThreadStart(Fishing));
                worker.Start();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "钓鱼";
        }

        private void Fishing()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                for (int i = 0; i < 500; i++)
                {
                    Thread.Sleep(1000);
                    f.dm.MoveTo(399, 260);
                    Thread.Sleep(1000);
                    f.dm.LeftClick();
                    Thread.Sleep(13000);
                    f.dm.KeyDown(18);
                    Thread.Sleep(1000);
                    f.dm.KeyPress(32);
                    Thread.Sleep(1000);
                    f.dm.KeyUp(18);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
            }
        }
        /// <summary>
        /// 普通自动打怪
        /// </summary>
        private void Attack()
        {

            Attimer = new System.Timers.Timer();

            Attimer.Interval = int.Parse(this.txtAttackWaitTime.Text.Trim());
            Attimer.Elapsed += new System.Timers.ElapsedEventHandler(Attimer_Elapsed);
            Attimer.Start();
            Antimer = new System.Timers.Timer();
            Antimer.Interval = 3000;
            Antimer.Elapsed += new System.Timers.ElapsedEventHandler(Antimer_Elapsed);
            Antimer.Start();
            if (cbxHH.Checked == false)
            {
                Aytimer = new System.Timers.Timer();
                Aytimer.Interval = 10000;
                Aytimer.Elapsed += new System.Timers.ElapsedEventHandler(Aytimer_Elapsed);
                Aytimer.Start();
                Amtimer = new System.Timers.Timer();
                Amtimer.Interval = 5000;
                Amtimer.Elapsed += new System.Timers.ElapsedEventHandler(Amtimer_Elapsed);
                Amtimer.Start();
            }
        }

        void Amtimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Amtimer.Enabled == false)
                return;
            Amtimer.Stop();
            f.AutoTeam();
            Amtimer.Start();
        }

        void Aytimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Aytimer.Enabled == false)
                return;
            Aytimer.Stop();
            f.BBAutoXue(0.7);
            f.WAutoXue(0.7);
            f.YBAutoXue(0.6);
            f.UserXue(0.7);
            f.UserLan(0.2);
            Aytimer.Start();
        }

        void Attimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Attimer.Enabled == false)
                return;
            Attimer.Stop();
            f.Attack(this.cbxHH.Checked);
            if (this.cbxAutoPick.Checked == true)
            {
                f.dm.KeyPress(86);
            }
            Attimer.Start();
        }

        void Antimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Antimer.Enabled == false)
                return;
            Antimer.Stop();
            f.Answer(this.txtDtStr.Text.Trim());
            Antimer.Start();
        }
        private void btnStartAttack_Click(object sender, EventArgs e)
        {
            Func.Log("StartAutoAttack");
            try
            {
                if (txtDtStr.Text.Trim() == "")
                {
                    if (DialogResult.No == MessageBox.Show("你没有填写答题账号,无法自动答题,是否继续?", "提示", MessageBoxButtons.YesNo))
                    {
                        return;
                    }
                }
                else
                {
                    Regedit.SetAppRegKeyValue(RegistryDirName, "eyouMiMa", txtDtStr.Text.Trim());

                }
                worker = new Thread(new ThreadStart(AttackThread));
                worker.Start();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "打怪";
        }
        private void AttackThread()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);

                Attack();
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
            }
        }

        private void PlantingThread()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
               // int plantIndex=this.Invoke(delegate(){return int.Parse(this.cbxPlantIndex.Text.Trim());});
               int plantIndex= int.Parse(this.Invoke(new GetControlText(delegate(Control c) { return c.Text; }),new object[]{this.cbxPlantIndex}).ToString());
                
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                Thread.Sleep(3000);
                int x=0, y=0;
                f.ReadyToPlanting(ref x, ref y);//调整稻草人窗口到,x,y
                while (true)
                {
                    f.Planting(plantIndex,x,y);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
            }
        }
        private void PlantTreeThread()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                // int plantIndex=this.Invoke(delegate(){return int.Parse(this.cbxPlantIndex.Text.Trim());});
                int plantIndex = int.Parse(this.Invoke(new GetControlText(delegate(Control c) { return c.Text; }), new object[] { this.cbxPlantIndex }).ToString());

                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                Thread.Sleep(3000);
                int x = 0, y = 0;
                f.ReadyToPlantTree(ref x, ref y);//调整稻草人窗口到,x,y
                while (true)
                {
                    f.PlantTree(plantIndex, x, y);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
            }
        }
        private void btnStopFishing_Click(object sender, EventArgs e)
        {
            Func.Log("StopFishing");
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                }
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopAttack_Click(object sender, EventArgs e)
        {
            Func.Log("StopAutoAttack");
            try
            {
                if (Antimer != null)
                {
                    Antimer.Enabled = false;
                    Antimer = null;
                }
                if (Attimer != null)
                {
                    Attimer.Enabled = false;
                    Antimer = null;
                }
                if (Amtimer != null)
                {
                    Amtimer.Enabled = false;
                    Amtimer = null;
                }
                if (Aytimer != null)
                {
                    Aytimer.Enabled = false;
                    Aytimer = null;
                }
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                }
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartPlanting_Click(object sender, EventArgs e)
        {
            Func.Log("StartPlanting");
            try
            {
                if (this.cbxPlantIndex.Text.Trim() == "")
                {
                    MessageBox.Show("请选择种植第几种作物");
                    return;
                }
                worker = new Thread(new ThreadStart(PlantingThread));
                worker.Start();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "种植";
        }
        void XYThread()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                // int plantIndex=this.Invoke(delegate(){return int.Parse(this.cbxPlantIndex.Text.Trim());});
                int xyIndex = int.Parse(this.Invoke(new GetControlText(delegate(Control c) { return c.Text; }), new object[] { this.cbxXYIndex }).ToString());

                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                Thread.Sleep(3000);
                string xlPath, npcPath;
                f.ReadyToXY(out xlPath,out npcPath);
                while (true)
                {
                    f.XY(xyIndex, xlPath,npcPath);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
            }
        }
        private void btnStopPlanting_Click(object sender, EventArgs e)
        {
            Func.Log("StopPlanting");
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                }
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStartXY_Click(object sender, EventArgs e)
        {
             Func.Log("StartXY");
             try
             {
                 if (this.cbxXYIndex.Text == "")
                 {
                     MessageBox.Show("请选择第几个尾进行星语");
                     return;
                 }
                 worker = new Thread(new ThreadStart(XYThread));
                 worker.Start();
                 this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                 this.Invoke(DelegateSetControl, new object[] { gbStart, false });
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
             this.Text = "星语";
        }

        private void btnStopXY_Click(object sender, EventArgs e)
        {
            Func.Log("StopXY");
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                }
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public void RunThread()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                string currentDT = f.GetCurrentDT();
                if (currentDT == "")
                {
                    throw new Exception("获取当前地图失败");
                }
                string dtTo = this.Invoke(new GetControlText(delegate(Control c) { return c.Text; }), new object[] { this.cbxDT }).ToString().Trim();
                string npc = this.Invoke(new GetControlText(delegate(Control c) { return c.Text; }), new object[] { this.cbxNPC }).ToString().Trim();
                string strIndex = this.Invoke(new GetControlText(delegate(Control c) { return c.Text; }), new object[] { this.cbxSDIndex }).ToString();
                if (currentDT != dtTo)
                {
                    f.WayfindingEx(currentDT, dtTo, 0.9);
                }
                Thread.Sleep(500);
                f.CloseSubWindows();
                if (npc != "")
                {
                    Thread.Sleep(500);
                    string xl = npc.Replace(PicPath, "").Replace(dtTo,"自动寻路").Replace("NPC", dtTo);
                    f.Wayfinding(xl, npc, 0.9, 2);
                    if (strIndex != "")
                    {
                        int sdIndex = int.Parse(strIndex);
                        int x = 0, y = 0;
                        f.GetPicCenter(npc, 0.9, 2, 0, out x, out y);
                        y = y + 81 + 22 * (sdIndex - 1);//NPC名字坐标和第一个帮会列表距离88像素
                        Thread.Sleep(500);
                        f.dm.MoveTo(x, y);
                        Thread.Sleep(1000);
                        f.dm.LeftClick();
                        Thread.Sleep(10000);
                        f.UnBindDM();
                        this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                        this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                    }
                }
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
                if (f != null)
                {
                    f.UnBindDM();
                    this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                    this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                }
            }
        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            Func.Log("StartRun");
            try
            {
                worker = new Thread(new ThreadStart(RunThread));
                worker.Start();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "跑";
        }

        private void btnStopRun_Click(object sender, EventArgs e)
        {
            Func.Log("StopRun");
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                    this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                    this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnKJ_Click(object sender, EventArgs e)
        {
            Func.Log("StartKJ");
            try
            {
                worker = new Thread(new ThreadStart(KJThread));
                worker.Start();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "科举";
        }
        public void KJThread()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                string currentDT = f.GetCurrentDT();
                if (currentDT != "京师")
                {
                    throw new Exception("当前不在京师");
                }

                f.KJ();
                f.UnBindDM();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                return;

            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
                if (f != null)
                {
                    f.UnBindDM();
                    this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                    this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                }
            }
        }
        public void TestThread()
        {
            try
            {
                f = new Func();
                f.SetDMPath(PicPath);
                Thread.Sleep(500);
                int pid = 0, handle = 0;
                if (this.txtPID.Text.Trim() != "")
                {
                    pid = int.Parse(txtPID.Text.Trim());
                }
                if (this.txtHandle.Text.Trim() != "")
                {
                    handle = int.Parse(txtHandle.Text.Trim());
                }
                f.BindDM(ClassName, pid, handle);
                f.Test();
                f.UnBindDM();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });

            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
                if (f != null)
                {
                    f.UnBindDM();
                    this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                    this.Invoke(DelegateSetControl, new object[] { gbStart, true });
                }
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            Func.Log("StartTest");
            try
            {
                worker = new Thread(new ThreadStart(TestThread));
                worker.Start();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
                //this.btnTest.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkLog_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.bLog = chkLog.Checked;
        }

        private void cbxProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyProcess p = this.cbxProcesses.SelectedItem as MyProcess;
            if (p.P != null)
            {
                this.txtPID.Text = p.P.Id.ToString();
                this.txtHandle.Text = p.P.MainWindowHandle.ToString();
                Func.SetForegroundWindow(p.P.MainWindowHandle);
            }
            else
            {
                this.txtPID.Text = "";
                this.txtHandle.Text = "";
            }
        }
        private void BindCbxProcesses()
        {
            Process[] ps = Process.GetProcessesByName(GameProcessName);
            List<MyProcess> mps = new List<MyProcess>();
            mps.Add(new MyProcess(null));
            for (int i = 0; i < ps.Length; i++)
            {
                mps.Add(new MyProcess(ps[i]));
            }
            cbxProcesses.DataSource = mps;
            //cbxProcesses.DisplayMember = "ProcessName";

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (cbxProcesses.Enabled == true)
            {
                BindCbxProcesses();
            }
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
            if (cbxProcesses.Enabled == true && this.txtHandle.Text.Trim()!="")
            {
                IntPtr p=new IntPtr(int.Parse(this.txtHandle.Text.Trim()));
                Func.ShowWindow(p ,1);
                Func.SetForegroundWindow(p);
                Func.SetActiveWindow(p);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                }
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });
            }
            catch 
            {
               
            }
        }

        private void btnStartPrintTree_Click(object sender, EventArgs e)
        {
            Func.Log("StartPlantTree");
            try
            {
                if (this.cbxPlantIndex.Text.Trim() == "")
                {
                    MessageBox.Show("请选择种植第几种树苗");
                    return;
                }
                worker = new Thread(new ThreadStart(PlantTreeThread));
                worker.Start();
                this.Invoke(DelegateSetControl, new object[] { gbSetting, false });
                this.Invoke(DelegateSetControl, new object[] { gbStart, false });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Text = "种树";
        }

        private void btnStopPrintTree_Click(object sender, EventArgs e)
        {
            Func.Log("StopPlantTree");
            try
            {
                if (worker != null && f != null)
                {
                    f.UnBindDM();
                    worker.Abort();
                    worker = null;
                }
                this.Invoke(DelegateSetControl, new object[] { gbSetting, true });
                this.Invoke(DelegateSetControl, new object[] { gbStart, true });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
