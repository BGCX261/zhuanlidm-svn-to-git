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
        private const string PicPath = "Pic/";
        private List<string> DTList;
        private Thread worker;
        private static Func f;
        private const string ClassName = "LuDingJi WndClass";//"Photo_Lightweight_Viewer";
        System.Timers.Timer Attimer;
        System.Timers.Timer Antimer;
        System.Timers.Timer Aytimer;
        System.Timers.Timer Amtimer;
        public Form1()
        {
            InitializeComponent();
            Func.Log("InitializeComponent");
            DTNPC d1 = new DTNPC();
            DTList = new List<string>();
            dtNpcList = new List<DTNPC>();
            DTList.Add("百花谷");//
            DTList.Add("程海");
            DTList.Add("哀牢山");
            DTList.Add("蓬莱");//
            DTList.Add("嵩山");
            DTList.Add("太子坡");//
            DTList.Add("王屋山");
            DTList.Add("五台山");//
            for (int i = 1; i < 7; i++)
            {
                this.cbxSDIndex.Items.Add(i);
            }
            for (int i = 1; i < 9; i++)
            {
                this.cbxPlantIndex.Items.Add(i);
            }
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
                    this.cbxDT.Items.Add(dt);
                }
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
                this.cbxDT.Enabled = false;
                this.cbxNPC.Enabled = false;
                this.cbxSDIndex.Enabled = false;
                this.btnStop.Enabled = true;

                string toPath = "驿站_前往" + cbxDT.Text + ".bmp";
                string xlPath = ((XLNPC)this.cbxNPC.SelectedItem).XlNpc;
                string xlNpcPath = ((XLNPC)this.cbxNPC.SelectedItem).NPC;
                int sdIndex = int.Parse(this.cbxSDIndex.Text);
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
                //this.btnStart.Enabled = false;
                //this.btnPause.Enabled = true;
                //this.btnContinue.Enabled = true;
                this.Invoke(DelegateSetControl, new object[] { btnStart, false });
                this.Invoke(DelegateSetControl, new object[] { btnPause, true });
                this.Invoke(DelegateSetControl, new object[] { btnContinue, true });
                this.Invoke(DelegateSetControl, new object[] { txtPID, false });
                this.Invoke(DelegateSetControl, new object[] { txtHandle, false });

                this.Invoke(DelegateSetControl, new object[] { btnStartFishing, false });
                this.Invoke(DelegateSetControl, new object[] { btnStartAttack, false });
                this.Invoke(DelegateSetControl, new object[] { btnStartPlanting, false });
                for (int i = 1; i < 30; i++)
                {
                    f.DoZhuanliMission(toPath, xlPath, xlNpcPath, sdIndex);
                    //f.ZhuanliMission();
                    Thread.Sleep(10000);
                }
            }
            catch (Exception ex)
            {
                this.Invoke(delegateShowMsg, new object[] { ex.Message });
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
                    worker.Abort();
                    worker = null;
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                    this.btnStartAttack.Enabled = true;
                    this.btnStartFishing.Enabled = true;
                    this.btnStartPlanting.Enabled = true;
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

        private void btnStartFishing_Click(object sender, EventArgs e)
        {
            Func.Log("Start Fishing");
            try
            {
                worker = new Thread(new ThreadStart(Fishing));
                worker.Start();
                this.btnStart.Enabled = false;
                this.btnStartAttack.Enabled = false;
                this.btnStartFishing.Enabled = false;
                this.txtHandle.Enabled = false;
                this.btnStartPlanting.Enabled = false;
                this.txtPID.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        private void Attack(bool a)
        {

            Attimer = new System.Timers.Timer();

            Attimer.Interval = int.Parse(this.txtAttackWaitTime.Text.Trim());
            Attimer.Elapsed += new System.Timers.ElapsedEventHandler(Attimer_Elapsed);
            Attimer.Start();
            //if (a)
            //{
            Antimer = new System.Timers.Timer();
            Antimer.Interval = 3000;
            Antimer.Elapsed += new System.Timers.ElapsedEventHandler(Antimer_Elapsed);
            Antimer.Start();
            Aytimer = new System.Timers.Timer();
            Aytimer.Interval = 10000;
            Aytimer.Elapsed += new System.Timers.ElapsedEventHandler(Aytimer_Elapsed);
            Aytimer.Start();
            Amtimer = new System.Timers.Timer();
            Amtimer.Interval = 10000;
            Amtimer.Elapsed += new System.Timers.ElapsedEventHandler(Amtimer_Elapsed);
            Amtimer.Start();
            //}
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
            f.BBAutoXue(0.6);
            f.WAutoXue(0.6);
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
            f.Attack();
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
                bool autoAnswer = true;
                if (txtDtStr.Text.Trim() == "")
                {
                    autoAnswer = false;
                    if (DialogResult.No == MessageBox.Show("你没有填写答题账号,无法自动答题,是否继续?","提示",MessageBoxButtons.YesNo))
                    {
                        return;
                    }
                }
                worker = new Thread(new ParameterizedThreadStart(AttackThread));
                worker.Start(autoAnswer);
                this.btnStart.Enabled = false;
                this.btnStartAttack.Enabled = false;
                this.btnStartFishing.Enabled = false;
                this.btnStartPlanting.Enabled = false;
                this.txtAttackWaitTime.Enabled = false;
                this.txtDtStr.Enabled = false;
                this.txtHandle.Enabled = false;
                this.txtPID.Enabled = false;
                this.cbxAutoPick.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AttackThread(object a)
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

                Attack((bool)a);
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
                this.btnStartAttack.Enabled = true;
                this.btnStart.Enabled = true;
                this.btnStartFishing.Enabled = true;
                this.btnStartPlanting.Enabled = true;
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
                this.btnStartAttack.Enabled = true;
                this.btnStart.Enabled = true;
                this.btnStartFishing.Enabled = true;
                this.btnStartPlanting.Enabled = true;
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
                this.btnStart.Enabled = false;
                this.btnStartAttack.Enabled = false;
                this.btnStartFishing.Enabled = false;
                this.txtAttackWaitTime.Enabled = false;
                this.txtDtStr.Enabled = false;
                this.txtHandle.Enabled = false;
                this.txtPID.Enabled = false;
                this.cbxAutoPick.Enabled = false;
                this.cbxPlantIndex.Enabled = false;
                this.btnStartPlanting.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                this.btnStartAttack.Enabled = true;
                this.btnStart.Enabled = true;
                this.btnStartFishing.Enabled = true;
                this.btnStartPlanting.Enabled = true;
                this.cbxPlantIndex.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }

}
