using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
namespace ldj
{
    public class ThreadParam
    {
        public ThreadParam()
        {
        }
        public ThreadParam(string _toPath, string _xlPath, string _xlNpcPath, int _sdIndex)
        {
            toPath = _toPath;
            xlPath = _xlPath;
            xlNpcPath = _xlNpcPath;
            sdIndex = _sdIndex;
        }
        public string toPath;
        public string xlPath;
        public string xlNpcPath;
        public int sdIndex;
    }
    public enum Profession
    {
        贤士,
        剑客,
        药师,
        隐者,
        猛将,
        火枪手
    }
    public struct ProfessionDtInfo
    {
        public Profession pro;
        public string dtPath;
        public string xlPath;
        public string xlNpcPath;
    }
    public struct XLNPC
    {
        public string XlNpc;
        public string NPC;
        public XLNPC(string xlNpc, string Npc)
        {
            this.XlNpc = xlNpc;
            this.NPC = Npc;
        }
        public override string ToString()
        {
            return this.NPC;
        }
    }
    public class DTNPC
    {
        private string _DT;
        public string DT
        {
            get
            {
                return _DT;
            }
            set
            {
                _DT = value;
            }
        }
        private List<XLNPC> _NPC;
        public List<XLNPC> NPC
        {
            get
            {
                return _NPC;
            }
            set
            {
                _NPC = value;
            }
        }
        public DTNPC()
        {
        }
        public DTNPC(string dt, List<XLNPC> npc)
        {
            this._DT = dt;
            this._NPC = npc;
        }
        public override string ToString()
        {
            return this._DT;
        }
    }
    /*
    public delegate void FuncEventHandler(object sender,FuncEventArgs e);
    public enum WorkState
    {
        Suspend,
        Resume,
        Stop
    }

    public class FuncEventArgs : EventArgs
    {
        private WorkState _state;
        public FuncEventArgs(WorkState state)
        {
            this._state = state;
        }
        public WorkState State
        {
            get
            {
                return _state;
            }
        }
    }
     */

    public class Func
    {
        #region "图片变量"
        public const string p自动寻路_百花谷_白思维 = "自动寻路_百花谷_白思维.bmp";
        public const string p自动寻路_百花谷_赵林壁 = "自动寻路_百花谷_赵林壁.bmp";
        public const string p自动寻路_百花谷_于凯鑫 = "自动寻路_百花谷_于凯鑫.bmp";
        public const string p百花谷_NPC_白思维 = "百花谷_NPC_白思维.bmp";
        public const string p百花谷_NPC_赵林壁 = "百花谷_NPC_赵林壁.bmp";
        public const string p百花谷_NPC_于凯鑫 = "百花谷_NPC_于凯鑫.bmp";
        public const string p自动寻路_蓬莱_陈聚贤 = "自动寻路_蓬莱_陈聚贤.bmp";
        public const string p自动寻路_蓬莱_董听雨 = "自动寻路_蓬莱_董听雨.bmp";
        public const string p自动寻路_蓬莱_韦雪枫 = "自动寻路_蓬莱_韦雪枫.bmp";
        public const string p蓬莱_NPC_陈聚贤 = "蓬莱_NPC_陈聚贤.bmp";
        public const string p蓬莱_NPC_董听雨 = "蓬莱_NPC_董听雨.bmp";
        public const string p蓬莱_NPC_韦雪枫 = "蓬莱_NPC_韦雪枫.bmp";
        public const string p自动寻路_太子坡_田听风 = "自动寻路_太子坡_田听风.bmp";
        public const string p自动寻路_太子坡_夏昕 = "自动寻路_太子坡_夏昕.bmp";
        public const string p自动寻路_太子坡_张步笑 = "自动寻路_太子坡_张步笑.bmp";
        public const string p太子坡_NPC_田听风 = "太子坡_NPC_田听风.bmp";
        public const string p太子坡_NPC_夏昕 = "太子坡_NPC_夏昕.bmp";
        public const string p太子坡_NPC_张步笑 = "太子坡_NPC_张步笑.bmp";
        public const string p自动寻路_五台山_蔡玉双 = "自动寻路_五台山_蔡玉双.bmp";
        public const string p自动寻路_五台山_孟纪玉 = "自动寻路_五台山_孟纪玉.bmp";
        public const string p自动寻路_五台山_周诗懿 = "自动寻路_五台山_周诗懿.bmp";
        public const string p五台山_NPC_蔡玉双 = "五台山_NPC_蔡玉双.bmp";
        public const string p五台山_NPC_孟纪玉 = "五台山_NPC_孟纪玉.bmp";
        public const string p五台山_NPC_周诗懿 = "五台山_NPC_周诗懿.bmp";
        public const string p防挂机检测 = "防挂机检测.bmp";

        public const string p提示_帮会 = "提示_帮会.bmp";
        public const string p提示_龙诀 = "提示_龙诀.bmp";
        public const string p提示_活动 = "提示_活动.bmp";
        public const string p提示_对决 = "提示_对决.bmp";
        public const string p提示_组队 = "提示_组队.bmp";
        public const string p帮会_NPC_李逍 = "帮会_NPC_李逍.bmp";
        public const string p帮会_李逍_专利任务 = "帮会_李逍_专利任务.bmp";
        public const string p帮会_李逍_送我去京师 = "帮会_李逍_送我去京师.bmp";
        public const string p帮会_明珠_进入帮会属地 = "帮会_明珠_进入帮会属地.bmp";
        public const string p帮会_明珠_进入帮会属地_前往大总管处 = "帮会_明珠_进入帮会属地_前往大总管处.bmp";
        public const string p帮会属地_妖孽_极乐世界 = "帮会属地_妖孽_极乐世界.bmp";
        public const string p帮会属地_聚贤庄_聚宝园 = "帮会属地_聚贤庄_聚宝园.bmp";
        public const string p背包 = "背包.bmp";
        public const string p进度条 = "进度条.bmp";
        public const string p稻草人 = "稻草人.bmp";

        public const string p程海_NPC_杜四傲 = "程海_NPC_杜四傲.bmp";
        //public const string p百花谷_NPC_于凯鑫 = "百花谷_NPC_于凯鑫.bmp";
        public const string p窗口_关闭 = "窗口_关闭.bmp";
        public const string p窗口_再见 = "窗口_再见.bmp";
        public const string p窗口_接受 = "窗口_接受.bmp";
        public const string p窗口_完成 = "窗口_完成.bmp";
        public const string p道具_师门令 = "道具_师门令.bmp";
        public const string p道具_笔记本 = "道具_笔记本.bmp";
        public const string p道具_笔记本_选中 = "道具_笔记本_选中.bmp";
        public const string p道具_珍兽血药 = "道具_珍兽血药.bmp";
        public const string p道具_佣兵血药 = "道具_佣兵血药.bmp";
        public const string p道具_人物血药 = "道具_人物血药.bmp";
        public const string p道具_人物蓝药 = "道具_人物蓝药.bmp";
        public const string p道具_尾巴血药 = "道具_尾巴血药.bmp";
        public const string p地图_程海 = "地图_程海.bmp";
        public const string p地图_京师 = "地图_京师.bmp";
        public const string p地图_京燕山庄 = "地图_京燕山庄.bmp";
        public const string p地图_兵工厂 = "地图_兵工厂.bmp";
        public const string p地图_锁魂窟 = "地图_锁魂窟.bmp";
        public const string p地图_空仞山 = "地图_空仞山.bmp";
        public const string p地图_朝云珠海 = "地图_朝云珠海.bmp";
        public const string p地图_龙旗营 = "地图_龙旗营.bmp";
        public const string p京师_NPC_明珠 = "京师_NPC_明珠.bmp";
        public const string p京师_NPC_邢千里 = "京师_NPC_邢千里.bmp";
        public const string p京燕山庄_NPC_江程 = "京燕山庄_NPC_江程.bmp";
        public const string p空仞山_NPC_冷竹 = "空仞山_NPC_冷竹.bmp";
        public const string p朝云珠海_NPC_贾济世 = "朝云珠海_NPC_贾济世.bmp";
        public const string p兵工厂_NPC_萧隆 = "兵工厂_NPC_萧隆.bmp";
        public const string p龙旗营_NPC_杨立威 = "龙旗营_NPC_杨立威.bmp";
        public const string p锁魂窟_NPC_宋一成 = "锁魂窟_NPC_宋一成.bmp";

        public const string p驿站_京师 = "驿站_京师.bmp";
        public const string p驿站_前往程海 = "驿站_前往程海.bmp";
        public const string p驿站_前往嵩山 = "驿站_前往嵩山.bmp";
        public const string p驿站_前往百花谷 = "驿站_前往百花谷.bmp";
        public const string p自动寻路 = "自动寻路.bmp";
        public const string p自动寻路_帮会_李逍 = "自动寻路_帮会_李逍.bmp";
        public const string p自动寻路_程海_杜四傲 = "自动寻路_程海_杜四傲.bmp";
        //public const string p自动寻路_百花谷_于凯鑫 = "自动寻路_百花谷_于凯鑫.bmp";

        public const string p自动寻路_功能 = "自动寻路_功能.bmp";
        public const string p自动寻路_功能_选中 = "自动寻路_功能_选中.bmp";
        public const string p自动寻路_京师_明珠 = "自动寻路_京师_明珠.bmp";
        public const string p自动寻路_京师_邢千里 = "自动寻路_京师_邢千里.bmp";
        public const string p自动寻路_驿站老板 = "自动寻路_驿站老板.bmp";
        public const string p自动寻路_京燕山庄_江程 = "自动寻路_京燕山庄_江程.bmp";
        public const string p自动寻路_空仞山_冷竹 = "自动寻路_空仞山_冷竹.bmp";

        public const string p自动寻路_朝云珠海_贾济世 = "自动寻路_朝云珠海_贾济世.bmp";
        public const string p自动寻路_兵工厂_萧隆 = "自动寻路_兵工厂_萧隆.bmp";

        public const string p自动寻路_龙旗营_杨立威 = "自动寻路_龙旗营_杨立威.bmp";

        public const string p自动寻路_锁魂窟_宋一成 = "自动寻路_锁魂窟_宋一成.bmp";


        public const string p自动寻路_上箭头 = "自动寻路_上箭头.bmp";
        public const string p自动寻路_图标 = "自动寻路_图标.bmp";
        public const string p自动寻路_图标_选中 = "自动寻路_图标_选中.bmp";
        public const string p自动寻路_下箭头 = "自动寻路_下箭头.bmp";
        public const string p自动寻路_移动 = "自动寻路_移动.bmp";
        public const string p任务执行_状态_专利_左中括号 = "任务执行_状态_专利_左中括号.bmp";
        public const string p任务执行_状态_专利_完成描述 = "任务执行_状态_专利_完成描述.bmp";
        #endregion

        #region "引用"
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumThreadWindowsCallback callback, IntPtr extraData);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindow(HandleRef hWnd, int uCmd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(HandleRef hWnd);
        #endregion

        public Dm.dmsoft dm;
        public int clientW, clientH;//这两个在绑定时获取
        public const int picReworkMax = 10, csTime = 8000,csReworkMax=3; //找图默认10次,传送默认10秒
        public const int showPageTime = 1000;
        private Profession pro;
        public string DtImgPath = "dt/";
        public string ErrImgPath = "errImg/";
        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);
        private bool haveMainWindow = false;
        private IntPtr mainWindowHandle = IntPtr.Zero;
        private int processId = 0;
        public eyou.Reply ey;
        public string CurrentDir;
        private int hwnd;
        private int ResetWindowCount;
        private int ResetWindowMaxCount=10;
        private TimeSpan ReachTimeOut = TimeSpan.FromSeconds(100);
        private List<ProfessionDtInfo> ProDtInfoList;
        private ProfessionDtInfo ProDtInfo;
        public Func()
        {
            RunReg("RegDll.dll /s");
            RunReg("dm.dll /s");
            RunReg("eyou.dll /s");
            FillProDtInfoList();
            dm = new Dm.dmsoft();
            string a = dm.Ver();
            if (dm.Ver() == "")
            {
                throw new Exception("Can't Create Object dm.dmsoft");
            }
            ey = new eyou.Reply();
            if (false == Directory.Exists(DtImgPath))
            {
                Directory.CreateDirectory(DtImgPath);
            }
            if (false == Directory.Exists(ErrImgPath))
            {
                Directory.CreateDirectory(ErrImgPath);
            }
            CurrentDir = Directory.GetCurrentDirectory();
            ResetWindowCount = 0;
        }
        public static void Log(string str)
        {
            TraceLog.WriteToLogFile(str);
        }
        public void RunReg(string cmd)
        {
            Log(cmd);
            ProcessStartInfo pi = new ProcessStartInfo("regsvr32.exe");
            pi.Arguments = cmd;
            pi.CreateNoWindow = true;
            pi.RedirectStandardError = false;
            pi.RedirectStandardInput = false;
            pi.RedirectStandardOutput = false;
            pi.UseShellExecute = false;
            Process p = new Process();
            p.StartInfo = pi;

            p.Start();
            p.WaitForExit();
            p.Close();
        }
        /// <summary>
        /// 綁定窗口DM,获取客户端大小,启动提示消除Timer,获取人物职业
        /// </summary>
        /// <param name="className">類名</param>
        /// <returns>0失敗,1成功</returns>
        public int BindDM(string className, int pid, int handle)
        {
            Log("BindDM:" + className + ",pid:" + pid.ToString() + ",handle:" + handle.ToString());
            int ret = 0;
            IntPtr p = IntPtr.Zero;
            if (pid == 0 && handle == 0)
            {
                p = FindWindow(className, null);
                if (p == IntPtr.Zero)
                {
                    Log("BindDM:" + "找不到窗口,类名:" + className);
                    throw new Exception("找不到窗口,类名:" + className);
                }
            }
            else
            {
                if (handle != 0)
                    p = new IntPtr(handle);
                else
                {
                    p = GetMainWindowHandle(pid);
                }
            }
            hwnd = p.ToInt32();
            //dm.SetWindowState(p.ToInt32(), 1);//激活窗口
            Thread.Sleep(200);
            //ret = dm.BindWindow(p.ToInt32(), "normal", "windows", "windows", 0);
            ret = dm.BindWindow(hwnd, "dx2", "dx", "dx", 0);
            Log("BindWindow");
            if (ret == 0)
            {
                throw new Exception("绑定失败");
            }
            
            //ret = dm.LockInput(1);
            object w, h;
            ret = dm.GetClientSize(hwnd, out w, out h);
            if (ret == 0)
            {
                throw new Exception("获取窗口客户区失败");
            }
            clientH = (int)h;
            clientW = (int)w;
            Thread.Sleep(200);
            Log("客户区域,W:" + clientW.ToString() + ";H:" + clientH.ToString());
            pro = GetUserProfession();
            ProDtInfo = GetProfessionDtInfo(pro);
            Log("职业:" + pro.ToString());
            //CNoticeTimer.Start();
            return ret;
        }
        /// <summary>
        /// 解绑定DM,结束提示消除Timer
        /// </summary>
        public void UnBindDM()
        {
            //CNoticeTimer.Stop();
            dm.UnBindWindow();
            Log("UnBindWindow");
        }
        /// <summary>
        /// 設置DM默認資源路徑
        /// </summary>
        /// <param name="path">路徑</param>
        /// <returns>0失敗,1成功</returns>
        public int SetDMPath(string path)
        {
            Log("SetDMPath:" + path);
            return dm.SetPath(path);
        }
        /// <summary>
        /// 找图并返回图的坐标
        /// 返回前Sleep 100
        /// </summary>
        /// <param name="x">起点x坐标</param>
        /// <param name="y">起点y坐标</param>
        /// <param name="w">范围宽度</param>
        /// <param name="h">范围高度</param>
        /// <param name="picPath">图的路径</param>
        /// <param name="ps">色偏</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <param name="xx">图所在右上角的x坐标</param>
        /// <param name="yy">图所在右上角的y坐标</param>
        /// <returns>0失敗,1成功</returns>
        public int FindPic(int x, int y, int w, int h, string picPath, string ps, double s, int dir, out int xx, out int yy)
        {
            Log("FindPic:" + picPath);
            int ret = 0;
            object x1, y1;
            xx = 0;
            yy = 0;
            //FindPic
            if (-1 != dm.FindPic(x, y, w, h, picPath, ps, s, dir, out x1, out y1))
            {
                xx = (int)x1;
                yy = (int)y1;
                ret = 1;
                Log("FindPic:找到");
            }
            Thread.Sleep(100);
            //FindPicE
            //string[] strRet=dm.FindPicE(x, y, w, h, picPath, ps, s, dir).Split('|');
            //xx = int.Parse(strRet[1]);
            //yy = int.Parse(strRet[2]);
            return ret;
        }
        /// <summary>
        /// 找图获取图片中心坐标
        /// </summary>
        /// <param name="picPath">图片路径</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <param name="work">失败重复次数</param>
        /// <param name="x">图片中心x坐标</param>
        /// <param name="y">图片中心y坐标</param>
        /// <returns>0失敗,1成功</returns>
        public int GetPicCenter(string picPath, double s, int dir, int work, out int x, out int y)
        {
            Log("GetPicCenter:" + picPath);
            int ret = 0, rework = 0, ReworkMax = picReworkMax;
            if (work > 0)
            {
                ReworkMax = work;
            }
            int picW, picH;
            x = 0;
            y = 0;
            string[] strRet = dm.GetPicSize(picPath).Split(',');
            picW = int.Parse(strRet[0]);
            picH = int.Parse(strRet[1]);
            while (ret == 0)
            {
                if (rework > ReworkMax)
                    break;
                ret = FindPic(0, 0, clientW, clientH, picPath, "333333", s, dir, out x, out y);
                rework = rework + 1;
            }
            if (x > 0 || y > 0)
            {
                x = x + picW / 2;
                y = y + picH / 2;
                Log("GetPicCenter:找到");
            }
            return ret;
        }
        /// <summary>
        /// 关掉提示消息,然后把鼠标移动到找到图片的中心位置
        /// 返回前Sleep 500
        /// </summary>
        /// <param name="picPath">图片路径</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <returns>0失敗,1成功</returns>
        public int MoveToPicCenter(string picPath, double s, int dir)
        {
            CloseNotice();
            int ret = 0, x, y;
            ret = GetPicCenter(picPath, s, dir, 0, out x, out y);
            Thread.Sleep(500);
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            return ret;
        }
        /// <summary>
        /// 不断双击鼠标然后找图,,直到找到为止
        /// </summary>
        /// <param name="xlPath">自动寻路NPC图片</param>
        /// <param name="picPath">NPC窗口标题图片</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <returns>0失敗,1成功</returns>
        public int Reach(string xlPath,string picPath, double s, int dir)
        {
            Log("Reach:" + picPath);
            int ret = 0, x, y;
            DateTime dt1 = DateTime.Now;
            while (ret == 0)
            {
                dm.LeftDoubleClick();
                Thread.Sleep(5000);
                ret = FindPic(0, 0, clientW, clientH, picPath, "333333", s, dir, out x, out y);
                if (ret == 1)
                {
                    Log("Reach:到达");
                    if (y < 165)//150位置会出滚动条通知,会被遮挡
                    {
                        dm.MoveTo(x + 6, y + 6);
                        Thread.Sleep(200);
                        dm.LeftDown();
                        Thread.Sleep(200);
                        dm.MoveTo(x + 6, 190);
                        Thread.Sleep(1000);
                        dm.LeftUp();
                    }
                    break;
                }
                else
                {
                    DateTime dt2 = DateTime.Now;
                    if (dt2 - dt1 > ReachTimeOut) //超时,重新开始自动寻路
                    {
                        ReSetWindow("Reach Time Out");
                        Wayfinding(xlPath, picPath, s, dir);
                    }
                }
            }
            ResetWindowCount = 0;
            return ret;
        }
        /// <summary>
        /// 自动寻路
        /// </summary>
        /// <param name="xlPath">自动寻路列表中的截图(NPC名字)</param>
        /// <param name="npcPath">NPC对话框上面的截图</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <returns>0失敗,1成功</returns>
        public int Wayfinding(string xlPath, string npcPath, double s, int dir)
        {
            Log("Wayfinding:" + xlPath + npcPath);
            int ret = 0, x, y, reworkMax = 10, rework = 0;
            int x0, y0;
            if (0 == FindPic(0, 0, clientW, clientH, p自动寻路, "333333", s, dir, out x, out y))
            {
                if (1 == GetPicCenter(p自动寻路_图标, s, dir, 0, out x, out y))
                {
                    dm.MoveTo(x, y);
                    Thread.Sleep(500);
                    dm.LeftClick();
                    Thread.Sleep(showPageTime);
                }
                else
                {
                    dm.KeyDown(18);//Alt
                    Thread.Sleep(1000);
                    dm.KeyPress(192);//~
                    Thread.Sleep(1000);
                    dm.KeyUp(18);//Alt
                    Thread.Sleep(500);
                }
            }
            FindPic(0, 0, clientW, clientH, p自动寻路, "333333", s, dir, out x0, out y0);
            Thread.Sleep(500);

            ret = GetPicCenter(xlPath, s, dir, 2, out x, out y);
            while (ret == 0)
            {
                if (rework > reworkMax)
                {
                    //break;
                    ReSetWindow("自动寻路,找不到:" + xlPath);
                    Wayfinding(xlPath, npcPath, s, dir);
                    rework = 0;
                }
                Thread.Sleep(500);
                dm.MoveTo(10, 10);
                Thread.Sleep(1500);
                if (x0 + 130 < clientW && y0 + 227 < clientH)//相对"自动寻路"图片的坐标
                {
                    Thread.Sleep(500);
                    dm.MoveTo(x0 + 130, y0 + 227);
                    Thread.Sleep(500);
                    dm.LeftDoubleClick();
                }
                else
                {
                    Console.WriteLine("找下箭头");
                    Log("找下箭头");
                    if (1 == GetPicCenter(p自动寻路_下箭头, 0.8, dir, 0, out x, out y))
                    {
                        Console.WriteLine("找到下箭头");
                        Log("找到下箭头");
                        Thread.Sleep(500);
                        dm.MoveTo(x, y);
                        Thread.Sleep(500);
                        dm.LeftDoubleClick();
                    }
                }
                Thread.Sleep(1500);
                Console.WriteLine("自动寻路Rework" + rework.ToString());
                Log("自动寻路Rework" + rework.ToString());
                ret = GetPicCenter(xlPath, s, dir, 3, out x, out y);
                rework ++;

            }
            ResetWindowCount = 0;
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            dm.LeftDoubleClick();
            Thread.Sleep(500);
            ret = Reach(xlPath,npcPath, s, dir);
            return ret;
        }
        /// <summary>
        /// 在背包里查找物品,并将鼠标定位到物品图片的中心位置
        /// </summary>
        /// <param name="wpPath">物品截图</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <returns>0失敗,1成功</returns>
        public int FindInPack(string wpPath, double s, int dir)
        {
            Log("FindInPack:" + wpPath);
            int ret = 0, x, y;
            if (0 == FindPic(0, 0, clientW, clientH, p背包, "333333", s, dir, out x, out y))
            {
                Console.WriteLine("没找到背包,按B");
                Log("没找到背包,按B");
                dm.KeyPress(66);

            }
            Thread.Sleep(showPageTime);
            dm.MoveTo(10, 10);
            Thread.Sleep(500);
            ret = MoveToPicCenter(wpPath, s, dir);
            return ret;
        }
        /// <summary>
        /// 专利运行
        /// </summary>
        public void ZhuanliMission()
        {
            
            Log("专利任务");
            int ret = 0, x, y;
            ret = FindPic(0, 0, clientW, clientH, p任务执行_状态_专利_完成描述, "333333", 0.9, 0, out x, out y);
            while (ret == 0)
            {
                Thread.Sleep(1000);
                if (0 == GetPicCenter(p任务执行_状态_专利_左中括号, 0.9, 0, 0, out x, out y))
                {
                    //Log("找不到左中括号");
                    //ReSetWindow("专利任务,找不到:" + p任务执行_状态_专利_左中括号);
                    if (0 == FindInPack(p道具_笔记本, 0.9, 3))
                    {
                        Console.WriteLine("p道具_笔记本");
                        Thread.Sleep(500);
                        if (0 == FindInPack(p道具_笔记本_选中, 0.9, 3))
                        {
                            Console.WriteLine("p道具_笔记本_选中");
                            Log("找不到笔记本");
                            //throw new Exception("专利任务,找不到:" + p道具_笔记本);
                            ReSetWindow("专利任务,找不到:" + p道具_笔记本);
                        }
                        Thread.Sleep(200);
                        dm.RightClick();
                        Thread.Sleep(200);
                        GetPicCenter(p任务执行_状态_专利_左中括号, 0.9, 0, 0, out x, out y);
                        Thread.Sleep(500);
                    }
                }
                int x1, y1;
                x1 = x;
                y1 = y;
                if (y - 93 < 165)//150位置会出滚动条通知,会被遮挡 ,括号中心到标题中心是93px
                {

                    dm.MoveTo(x + 150, y - 93);
                    Thread.Sleep(200);
                    dm.LeftDown();
                    Thread.Sleep(200);
                    dm.MoveTo(x + 150, 190);
                    Thread.Sleep(1000);
                    dm.LeftUp();
                    Thread.Sleep(200);
                }
                dm.MoveTo(x1 + 20, y1);//左中括號靠右邊20px
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(25000);
                dm.MoveTo(10, 10);
                Thread.Sleep(500);

                if (0 == FindInPack(p道具_笔记本, 0.9, 3))
                {
                    Console.WriteLine("p道具_笔记本");
                    Thread.Sleep(500);
                    if (0 == FindInPack(p道具_笔记本_选中, 0.9, 3))
                    {
                        Console.WriteLine("p道具_笔记本_选中");
                        Log("找不到笔记本");
                        //throw new Exception("专利任务,找不到:" + p道具_笔记本);
                        ReSetWindow("专利任务,找不到:" + p道具_笔记本);
                    }
                }

                Thread.Sleep(500);
                dm.RightClick();
                Thread.Sleep(8000);
                if (1 == GetPicCenter(p进度条, 0.9, 1, 0, out x, out y))
                {
                    Thread.Sleep(12000);
                }
                //一次完成后再点一下右键更新坐标列表
                dm.MoveTo(10, 10);
                Thread.Sleep(500);

                if (0 == FindInPack(p道具_笔记本, 0.9, 3))
                {
                    Console.WriteLine("p道具_笔记本");
                    Thread.Sleep(500);
                    if (0 == FindInPack(p道具_笔记本_选中, 0.9, 3))
                    {
                        Console.WriteLine("p道具_笔记本_选中");
                        Log("找不到笔记本");
                        //throw new Exception("专利任务,找不到:" + p道具_笔记本);
                        ReSetWindow("专利任务,找不到:" + p道具_笔记本);
                    }
                }
                Thread.Sleep(500);
                dm.RightClick();
                Thread.Sleep(500);
                ret = FindPic(0, 0, clientW, clientH, p任务执行_状态_专利_完成描述, "333333", 0.9, 0, out x, out y);
            }
            ResetWindowCount = 0;
        }
        /// <summary>
        /// 关闭全部子窗口
        /// </summary>
        public void CloseSubWindows()
        {
            Log("CloseSubWindows");
            int ret = 1, x, y;
            while (ret == 1)
            {
                ret = FindPic(0, 0, clientW, clientH, p窗口_关闭, "333333", 0.9, 2, out x, out y);
                //ret = MoveToPicCenter(p窗口_关闭, 0.9, 2);
                if (ret == 1)
                {
                    dm.MoveTo(x, y);
                    Thread.Sleep(1000);
                    dm.LeftClick();
                }
            }
        }
        /// <summary>
        /// 关闭全部提示
        /// 返回前Sleep 50
        /// </summary>
        public void CloseNotice()
        {
            Log("CloseNotice");
            Thread.Sleep(50);
            int ret, x, y; ;
            //ret= MoveToPicCenter(p提示_对决, 0.9, 2);
            ret = FindPic(0, 0, clientW, clientH, p提示_对决, "333333", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(1000);
                dm.RightClick();
            }
            Thread.Sleep(50);
            //ret = MoveToPicCenter(p提示_活动, 0.9, 2);
            ret = FindPic(0, 0, clientW, clientH, p提示_活动, "333333", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(1000);
                dm.RightClick();
            }
            Thread.Sleep(50);
            ret = FindPic(0, 0, clientW, clientH, p提示_帮会, "333333", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(1000);
                dm.RightClick();
            }
            Thread.Sleep(50);
            ret = FindPic(0, 0, clientW, clientH, p提示_龙诀, "333333", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(1000);
                dm.RightClick();
            }
            Thread.Sleep(50);
            ret = FindPic(0, 0, clientW, clientH, p提示_组队, "333333", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(1000);
                dm.RightClick();
            }
            Thread.Sleep(50);
        }
        /// <summary>
        /// 前往目标帮会属地
        /// 返回前Sleep 传送等待时间(csTime)
        /// </summary>
        /// <param name="yzcsPath">驿站传送_前往xxx的截图</param>
        /// <param name="xlPath">自动寻路列表NPC名称图片(帮会入口NPC名字)</param>
        /// <param name="xlNpcPath">NPC窗口名字图片(帮会入口NPC)</param>
        /// <param name="sdIndex">进入第几个帮会</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        public void GotoTargetBangHui(string yzcsPath, string xlPath, string xlNpcPath, int sdIndex, double s, int dir)
        {
            Log("进入目标帮会");
            int x, y, d;
            d = 22;//帮会列表的每个帮会y坐标距离22像素
            string dtPath = "地图_" + yzcsPath.Replace("驿站_前往", "");
            int ret = 0;
            int rework = 0;
            while (ret == 0)
            {
                if (rework > csReworkMax)
                {
                    ReSetWindow("前往:" + dtPath);
                    rework = 0;
                }
                MoveToPicCenter(yzcsPath, s, dir);
                Thread.Sleep(200);
                dm.LeftClick();
                Thread.Sleep(csTime);
                int xx, yy;
                ret = FindPic(0, 0, clientW, clientH, dtPath, "333333", 0.9, 2, out  xx, out  yy);
                rework++;
            }
            ResetWindowCount = 0;
            Wayfinding(xlPath, xlNpcPath, s, dir);
            Thread.Sleep(500);
            ret = 0;
            rework = 0;
            while (ret == 0)
            {
                if (rework > csReworkMax)
                {
                    ReSetWindow("前往:对方帮会属地");
                    rework = 0;
                }
                GetPicCenter(xlNpcPath, s, dir, 0, out x, out y);
                y = y + 81 + d * (sdIndex - 1);//NPC名字坐标和第一个帮会列表距离88像素
                Thread.Sleep(500);
                dm.MoveTo(x, y);
                Thread.Sleep(1000);
                dm.LeftClick();
                Thread.Sleep(csTime);
                int xx, yy;
                ret = FindPic(0, 0, clientW, clientH, "地图_天涯海角.bmp|地图_世外林源.bmp", "333333", 0.9, 2, out  xx, out  yy);
                rework++;
            }
            ResetWindowCount = 0;
        }
        /// <summary>
        /// 做专利任务
        /// 返回前Sleep 500
        /// </summary>
        /// <param name="toPath">驿站传送_前往xxx的截图</param>
        /// <param name="xlPath">自动寻路列表NPC名称图片(帮会入口NPC名字)</param>
        /// <param name="xlNpcPath">NPC窗口名字图片(帮会入口NPC)</param>
        /// <param name="sdIndex">进入第几个帮会</param>
        public void DoZhuanliMission(string toPath, string xlPath, string xlNpcPath, int sdIndex)
        {
            //Wayfinding(p自动寻路_程海_杜四傲, p程海_NPC_杜四傲, 0.9, 0);
            //return;
            Log("做专利");
            Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter(p帮会_李逍_专利任务, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            MoveToPicCenter(p窗口_接受, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            CloseSubWindows();
            Thread.Sleep(500);
            Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
            Thread.Sleep(showPageTime);
            int ret = 0;
            int xx, yy;
            int rework = 0;
            while (ret == 0)
            {
                if (rework > csReworkMax)
                {
                    ReSetWindow("传送到京师:"+rework.ToString());
                    rework = 0;
                }
                MoveToPicCenter(p帮会_李逍_送我去京师, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(csTime);
                ret = FindPic(0, 0, clientW, clientH, p地图_京师, "333333", 0.9, 2, out  xx, out  yy);
                rework++;
            }
            ResetWindowCount = 0;
            Wayfinding(p自动寻路_京师_邢千里, p京师_NPC_邢千里, 0.9, 0);
            Thread.Sleep(500);
            //GotoTargetBangHui(p驿站_前往百花谷, p自动寻路_百花谷_于凯鑫, p百花谷_NPC_于凯鑫, 1, 0.9, 0);
            GotoTargetBangHui(toPath, xlPath, xlNpcPath, sdIndex, 0.9, 0);
            Thread.Sleep(showPageTime);
            FindInPack(p道具_笔记本, 0.9, 3);
            Thread.Sleep(500);
            dm.RightClick();
            Thread.Sleep(showPageTime);
            ZhuanliMission();
            Thread.Sleep(1000);
             ret = 0;
             rework = 0;
             while (ret == 0)
             {
                 if (rework > csReworkMax)
                {
                    ReSetWindow("传送到师门:"+rework.ToString());
                    rework = 0;
                }
                 FindInPack(p道具_师门令, 0.9, 3);
                 Thread.Sleep(500);
                 dm.RightClick();
                 Thread.Sleep(15000);
                 ret = FindPic(0, 0, clientW, clientH,ProDtInfo.dtPath , "333333", 0.9, 2, out  xx, out  yy);
                 rework++;
             }
             ResetWindowCount = 0;
            OutShimen();
            ret = 0;
            rework = 0;
            while (ret == 0)
            {
                if (rework > csReworkMax)
                {
                    ReSetWindow("传送到帮会属地:" + rework.ToString());
                    rework = 0;
                }
                Wayfinding(p自动寻路_京师_明珠, p京师_NPC_明珠, 0.9, 0);
                Thread.Sleep(showPageTime);
                MoveToPicCenter(p帮会_明珠_进入帮会属地, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(showPageTime);
                MoveToPicCenter(p帮会_明珠_进入帮会属地_前往大总管处, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(csTime);
                ret = FindPic(0, 0, clientW, clientH, "地图_天涯海角.bmp|地图_世外林源.bmp", "333333", 0.9, 2, out  xx, out  yy);
                rework++;
            }
            ResetWindowCount = 0;
            Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter(p帮会_李逍_专利任务, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            MoveToPicCenter(p窗口_完成, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            CloseSubWindows();
            Thread.Sleep(500);
        }
        /// <summary>
        /// 获取职业,并且关闭全部子窗口
        /// </summary>
        /// <returns>职业</returns>
        public Profession GetUserProfession()
        {
            CloseSubWindows();
            string picPath = "";
            int x, y, ret;
            dm.KeyPress(67);
            Thread.Sleep(500);
            Profession currentP = Profession.贤士;
            foreach (int code in Enum.GetValues(typeof(Profession)))
            {
                picPath = "职业_" + Enum.GetName(typeof(Profession), code) + ".bmp";
                ret = FindPic(0, 0, clientW, clientH, picPath, "333333", 0.9, 0, out x, out y);
                if (ret == 1)
                {
                    currentP = (Profession)code;
                    break;
                }
            }
            CloseSubWindows();
            return currentP;
        }
        /// <summary>
        /// 获取职业地图信息
        /// 必须先填充List ProfessionDtInfo
        /// </summary>
        /// <param name="pro">职业</param>
        /// <returns>职业地图信息</returns>
        public ProfessionDtInfo GetProfessionDtInfo(Profession pro)
        {
            //ProDtInfoList.Find(delegate(ProfessionDtInfo p) {return p.pro==pro; });
            return ProDtInfoList.Find(pInfo => pInfo.pro == pro);
        }
        /// <summary>
        /// 出师门
        /// 返回前Sleep 判断地图500;传送时间(csTime) 
        /// </summary>
        public void OutShimen()
        {
            Log("出师门");
            Wayfinding(ProDtInfo.xlPath, ProDtInfo.xlNpcPath, 0.9, 0);
            Thread.Sleep(showPageTime);
            int ret = 0;
            int rework = 0;
            while (ret == 0)
            {
                if (rework > csReworkMax)
                {
                    ReSetWindow("传送到京师:" + rework.ToString());
                    rework = 0;
                }
                MoveToPicCenter(p驿站_京师, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(csTime);
                int xx, yy;
                ret = FindPic(0, 0, clientW, clientH, p地图_京师, "333333", 0.9, 2, out  xx, out  yy);
                Thread.Sleep(500);
                rework++;
            }
            ResetWindowCount = 0;
        }
        public void GetEyouErrMsg(string ret,out string ErrMsg)
        {
            ErrMsg = "";
            switch (ret)
            {
                case "-1":
                    ErrMsg = "未知错误";
                    break;
                case "-2":
                    ErrMsg = "上传密码串格式错误";
                    break;
                case "-3":
                    ErrMsg = "找不到您填的上传密码串";
                    break;
                case "-4":
                    ErrMsg = "你的题分不足";
                    break;
                case "-5":
                    ErrMsg = "找不到游戏";
                    break;
                case "-6":
                    ErrMsg = "连接网络失败";
                    break;
                case "-7":
                    ErrMsg = "创建xml对象失败";
                    break;
                case "-8":
                    ErrMsg = "文件不存在";
                    break;
                case "-9":
                    ErrMsg = "压缩图片失败";
                    break;
                case "+4":
                    ErrMsg = "服务器维护或压力过大，暂停发送10分钟";
                    break;
                default:
                    ErrMsg = "未知";
                    break;
            }
        }
        /// <summary>
        /// 易游自动答题
        /// </summary>
        /// <param name="str">答题字串</param>
        public void Answer(string str)
        {
            int ret, x, y, picW = 240, picH = 300;
            DateTime dt1, dt2;
            string strImageName = "";
            if (1 == FindPic(0, 0, clientW, clientH, p防挂机检测, "333333", 0.9, 0, out x, out y))
            {
                if (str == "")
                {
                    dm.Beep(1000, 500);
                    dm.LockInput(0);
                }
                else
                {
                    dt1 = DateTime.Now;
                    strImageName = CurrentDir + "/" + DtImgPath + dt1.ToString("yyyy-MM-dd HHmmss") + ".jpg";

                    x = x - 88;
                    ret = 0;
                    while (ret == 0)
                    {
                        Log("截图:" + strImageName);
                        ret = dm.CaptureJpg(x, y, x + picW, y + picH, strImageName, 80);
                        Thread.Sleep(500);
                        dt2 = DateTime.Now;
                        if (dt2 - dt1 > TimeSpan.FromSeconds(40))
                        {
                            dm.Beep(1000, 500);
                        }
                    }
                    string dtID = "-1";
                    string dtDaAn = "-1";
                    while (dtID == "-1")
                    {
                        Log("发图:" + strImageName);
                        dtID = ey.SendFile(str, 1031, strImageName, 60).ToString();
                        Thread.Sleep(2000);
                    }
                    if (dtID.Length == 2)
                    {
                        string Err;
                        GetEyouErrMsg(dtID, out Err);
                        throw new Exception(Err);
                    }
                    while (dtDaAn == "-1")
                    {

                        dtDaAn = ey.GetAnswer(dtID).ToString();
                        Thread.Sleep(1000);
                    }
                    Log("获取答案:" + dtDaAn);
                    switch (dtDaAn)
                    {
                        case "1":
                            {
                                dm.MoveTo(x + 67, y + 165);
                                Thread.Sleep(200);
                                dm.LeftClick();
                                break;
                            }
                        case "2":
                            {
                                dm.MoveTo(x + 67, y + 190);
                                Thread.Sleep(200);
                                dm.LeftClick();
                                break;
                            }
                        case "3":
                            {
                                dm.MoveTo(x + 67, y + 215);
                                Thread.Sleep(200);
                                dm.LeftClick();
                                break;
                            }
                        case "4":
                            {
                                dm.MoveTo(x + 67, y + 240);
                                Thread.Sleep(200);
                                dm.LeftClick();
                                break;
                            }
                        default:
                            {
                                ey.Report(dtID, str);//发送错误报告
                                throw new Exception("eyou回答错误");
                            }
                    }
                    Thread.Sleep(1000);
                    dm.MoveTo(x + 200, y + 288);
                    Thread.Sleep(200);
                    dm.LeftClick();
                }
            }
            else
            {
                if (str == "")
                {
                    dm.LockInput(1);
                }
            }
        }
        /// <summary>
        /// 自动打怪,~ &1
        /// </summary>
        public void Attack()
        {
            Thread.Sleep(500);
            dm.KeyPress(192);//~
            Thread.Sleep(500);
            dm.KeyPress(49);//1
        }
        /// <summary>
        /// 准备种地,调整朝北,滚轮到底,人最小
        /// </summary>
        /// <param name="x">调整后稻草人图片中心x坐标</param>
        /// <param name="y">调整后稻草人图片中心y坐标</param>
        public void ReadyToPlanting(ref int x,ref int y)
        {
            int xx=0,yy=0;
            x = 160;
            y = 160;
            Thread.Sleep(2000);


            for (int i = 0; i < 3; i++)
            {
                dm.MoveTo(clientW - 74, 28);//调整朝向,北
                Thread.Sleep(200);
                dm.LeftClick();
                Thread.Sleep(2000);
                dm.WheelDown();
                Thread.Sleep(200);
            }
            dm.MoveTo(615, 324);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(4000);
            dm.MoveTo(750, 490);//稻草人
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            dm.MoveTo(530, 307);//点这个位置过来
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            if (0 == GetPicCenter(p稻草人, 0.9, 0, 5, out xx, out yy))
            {
                throw new Exception("找不到:" + p稻草人);
            }
            Thread.Sleep(500);
            dm.MoveTo(xx, yy);
            Thread.Sleep(500);
            dm.LeftDown();
            Thread.Sleep(1000);
            dm.MoveTo(x, y);
            Thread.Sleep(2000);
            dm.LeftUp();
        }
        /// <summary>
        /// 自动种植
        /// </summary>
        /// <param name="index">种第几种作物</param>
        /// <param name="x">稻草人图片中心的x坐标</param>
        /// <param name="y">稻草人图片中心的y坐标</param>
        public void Planting(int index,int xx,int yy)
        {
            CloseNotice();
            CloseSubWindows();
            Thread.Sleep(3000);
            dm.MoveTo(615, 324);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(4000);
            dm.MoveTo(750, 490);//稻草人
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            dm.MoveTo(530, 307);//点这个位置过来
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            
            dm.MoveTo(106, yy+116);//点早产,稻草人图片中心到早产中心116px
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            int y = yy+15;
            y = y + 23 * index;
            dm.MoveTo(120, y);//要种第几个(总共8个)
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            dm.KeyPress(113);//F2 隐身
            Thread.Sleep(308000); //等5分钟
            dm.MoveTo(543, 313); //收割左上角
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(10000);
            dm.KeyPress(86);
            Thread.Sleep(500);
            dm.MoveTo(735, 365);//收割右上
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(10000);
            dm.KeyPress(86);
            Thread.Sleep(500);
            dm.MoveTo(615, 503);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(10000);
            dm.KeyPress(86);
            Thread.Sleep(500);
            dm.MoveTo(770, 419);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(10000);
            dm.KeyPress(86);
            Thread.Sleep(500);
            dm.MoveTo(833, 480);//点这个地方重新定位开始
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            dm.MoveTo(533, 289);//点草人
            Thread.Sleep(500);
            dm.LeftClick();
        }
        public IntPtr GetMainWindowHandle(int processId)
        {
            if (!this.haveMainWindow)
            {
                this.mainWindowHandle = IntPtr.Zero;
                this.processId = processId;
                EnumThreadWindowsCallback callback = new EnumThreadWindowsCallback(this.EnumWindowsCallback); EnumWindows(callback, IntPtr.Zero);
                GC.KeepAlive(callback);
                this.haveMainWindow = true;
            }
            return this.mainWindowHandle;
        }
        private bool EnumWindowsCallback(IntPtr handle, IntPtr extraParameter)
        {
            int num;
            GetWindowThreadProcessId(new HandleRef(this, handle), out num);
            if ((num == this.processId) && this.IsMainWindow(handle))
            {
                this.mainWindowHandle = handle;
                return false;
            }
            return true;
        }
        private bool IsMainWindow(IntPtr handle)
        {
            return (!(GetWindow(new HandleRef(this, handle), 4) != IntPtr.Zero) && IsWindowVisible(new HandleRef(this, handle)));
        }
        /// <summary>
        /// 重置窗口
        /// 返回前Sleep 5000
        /// </summary>
        public void ReSetWindow(string err)
        {
            if (hwnd != 0)
            {
                Log("ReSetWindow:"+ResetWindowCount.ToString());
                string errImg=CurrentDir + "/" + ErrImgPath + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".PNG";
                Log(errImg);
                dm.CapturePng(0, 0, clientW, clientH, errImg);
                if (ResetWindowCount < ResetWindowMaxCount)
                {
                    dm.SetWindowState(hwnd, 2);//最小化窗口,不激活
                    Thread.Sleep(2000);
                    dm.SetWindowState(hwnd, 5);//恢复窗口,不激活
                    Thread.Sleep(5000);
                    dm.SetClientSize(hwnd, clientW, clientH);//设置窗口大小为原来的
                    Thread.Sleep(5000);
                    object w, h;
                    dm.GetClientSize(hwnd, out w, out h);//重新获取
                    clientW = (int)w;
                    clientH = (int)h;
                    ResetWindowCount++;
                }
                else
                {
                    Log("ReSetWindow Reach Max Count,Thread Abort,ErrMsg:"+err);
                    throw new Exception(err);
                }
            }
        }
        private void FillProDtInfoList()
        {
            ProDtInfoList=new List<ProfessionDtInfo>();
            foreach (Profession pro in Enum.GetValues(typeof(Profession)))
            {
                ProfessionDtInfo p = new ProfessionDtInfo();
                p.pro = pro;
                switch (pro)
                {
                    case Profession.贤士:
                        {
                            p.dtPath = p地图_京燕山庄;
                            p.xlPath = p自动寻路_京燕山庄_江程;
                            p.xlNpcPath = p京燕山庄_NPC_江程;
                            break;
                        };
                    case Profession.剑客:
                        {
                            p.dtPath = p地图_空仞山;
                            p.xlPath = p自动寻路_空仞山_冷竹;
                            p.xlNpcPath = p空仞山_NPC_冷竹;
                            break;
                        };
                    case Profession.药师:
                        {
                            p.dtPath = p地图_朝云珠海;
                            p.xlPath = p自动寻路_朝云珠海_贾济世;
                            p.xlNpcPath = p朝云珠海_NPC_贾济世;
                            break;
                        };
                    case Profession.火枪手:
                        {
                            p.dtPath = p地图_兵工厂;
                            p.xlPath = p自动寻路_兵工厂_萧隆;
                            p.xlNpcPath = p兵工厂_NPC_萧隆;
                            break;
                        };
                    case Profession.猛将:
                        {
                            p.dtPath = p地图_龙旗营;
                            p.xlPath = p自动寻路_龙旗营_杨立威;
                            p.xlNpcPath = p龙旗营_NPC_杨立威;
                            break;
                        };
                    case Profession.隐者:
                        {
                            p.dtPath = p地图_锁魂窟;
                            p.xlPath = p自动寻路_锁魂窟_宋一成;
                            p.xlNpcPath = p锁魂窟_NPC_宋一成;
                            break;
                        };
                    default:
                        {
                            throw new Exception("未知职业");
                        }
                }
                ProDtInfoList.Add(p);
            }
        }
        public void BBAutoXue(double p)
        {
            int x1 = 49;
            int y1 = 100;
            int x2 = 81;
            int y2 = 104;
            AutoXLByP(x1, y1, x2, y2, "ff0000-222222", p, p道具_珍兽血药);
        }
        private void AutoXLByP(int x1, int y1, int x2, int y2,string color, double p, string yPath)
        {
            int xx, yy;
            object xx1, yy1;
            if (1 == dm.FindColor(x1, y1, x2, y2, color, 0.9, 2, out xx1, out yy1))
            {
                xx = (int)xx1;
                yy = (int)yy1;
                if (p > (double)(xx - x1) / (double)(x2 - x1))
                {
                    if (1 == GetPicCenter(yPath, 0.9, 3, 1, out xx, out yy))
                    {
                        Thread.Sleep(50);
                        dm.MoveTo(xx, yy);
                        Thread.Sleep(50);
                        dm.RightClick();
                        Thread.Sleep(50);
                    }
                }
            }
            
        }
        public void YBAutoXue(double p)
        {
            int x1 = 136;
            int y1 = 100;
            int x2 = 168;
            int y2 = 104;
            AutoXLByP(x1, y1, x2, y2, "ff0000-222222", p, p道具_佣兵血药);
        }
        public void WAutoXue(double p)
        {
            int x1 = 225;
            int y1 = 100;
            int x2 = 257;
            int y2 = 104;
            AutoXLByP(x1, y1, x2, y2, "ff0000-222222", p, p道具_尾巴血药);
        }
        public void UserXue(double p)
        {
            int x1 = 63;
            int y1 = 31;
            int x2 = 164;
            int y2 = 36;
            AutoXLByP(x1, y1, x2, y2, "ff0000-222222", p, p道具_人物血药);
        }
        public void UserLan(double p)
        {
            int x1 = 72;
            int y1 = 40;
            int x2 = 164;
            int y2 = 45;
            AutoXLByP(x1, y1, x2, y2, "1311ce-222222", p, p道具_人物蓝药);
        }
        public void AutoTeam()
        {
            int xx, yy;
            if (1 == GetPicCenter("提示_组队.bmp", 0.9, 3, 1, out xx, out yy))       
            {
                Thread.Sleep(50);
                dm.MoveTo(xx, yy);
                Thread.Sleep(50);
                dm.LeftClick();
                Thread.Sleep(showPageTime);
                if (1 == GetPicCenter("窗口_确认.bmp", 0.9, 3, 1, out xx, out yy))
                {
                    Thread.Sleep(50);
                    dm.MoveTo(xx, yy);
                    Thread.Sleep(50);
                    dm.LeftClick();
                    Thread.Sleep(50);
                    CloseSubWindows();
                }
            }
        }
    }
}
