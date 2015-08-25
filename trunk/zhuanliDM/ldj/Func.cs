using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Drawing;
using Microsoft.Win32;

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
    public class MyProcess
    {
        public MyProcess(Process p)
        {
            _P = p;
        }
        private Process _P;
        public Process P
        {
            get
            {
                return _P;
            }
            set
            {
                _P = value;
            }
        }
        public override string ToString()
        {
            if (_P != null)
            {
                return _P.ProcessName + " - " + _P.Id;
            }
            return "";
        }
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
    public enum WorkStatus
    {
        ReStart,
        Start,
        Stop,
        Continue,
    }
    public class Regedit
    {
        const string regRoot="Software\\";
        public static string GetAppRegKey(string registryDirName, string key)
        {
            string value = "";
            RegistryKey rsg = null;
            try
            {
                rsg = Registry.CurrentUser.OpenSubKey(regRoot + registryDirName, false);
                if (rsg == null)
                {
                    rsg = Registry.CurrentUser.CreateSubKey(regRoot + registryDirName);
                }
                value = rsg.GetValue(key, "").ToString();
            }
            catch
            {
            }
            finally
            {
                if (rsg != null)
                {
                    rsg.Close();
                }
            }
            return value;
        }
        public static bool SetAppRegKeyValue(string registryDirName, string key, string value)
        {
            bool ret = false;
            RegistryKey rsg = null;
            try
            {
                rsg = Registry.CurrentUser.OpenSubKey(regRoot + registryDirName, true);
                if (rsg == null)
                {
                    rsg = Registry.CurrentUser.CreateSubKey(regRoot + registryDirName);
                }
                rsg.SetValue(key, value);
                ret = true;
            }
            catch { }
            finally
            {
                if (rsg != null)
                {
                    rsg.Close();
                }
            }
            return ret;
        }
    }
    public class FuncEventArgs : EventArgs
    {
        private string _msg;
        private WorkStatus _ws;
        public FuncEventArgs(string msg, WorkStatus ws)
        {
            _msg = msg;
            _ws = ws;
        }
        public string Msg
        {
            get
            {
                return _msg;
            }
        }
        public WorkStatus WorkStatus
        {
            get
            {
                return _ws;
            }
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
    public delegate void EventHandler(object sender, FuncEventArgs e);

   
    public partial class Func
    {
        [DllImport("Kernel32.dll")]
        public static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("Kernel32.dll")]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("Kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        delegate long Invoker();
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
        public const string p窗口_确定 = "窗口_确定.bmp";
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
        public const string p专利_提示_结束 = "专利_提示_结束.bmp";
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

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "SetActiveWindow")]
        public static extern bool SetActiveWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hWnd,int cmdShow);
        // 0:隐藏   1：正常   2：最小化   3：最大化 
        #endregion
        public event EventHandler FuncEventHandler;
        public Dm.dmsoft dm;
        public int clientW, clientH;//这两个在绑定时获取
        public const int picReworkMax = 10, csTime = 12000, csReworkMax = 3; //找图默认10次,传送默认10秒
        public const int showPageTime = 1000;
        private Profession pro;
        public const string DtImgPath = "dt/";
        public const string ErrImgPath = "errImg/";
        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);
        private bool haveMainWindow = false;
        private IntPtr mainWindowHandle = IntPtr.Zero;
        private int processId = 0;
        public eyou.Reply ey;
        public string CurrentDir;
        private int hwnd;
        private int ResetWindowCount;
        private int ResetWindowMaxCount = 3;
        private TimeSpan ReachTimeOut = TimeSpan.FromSeconds(200);
        private List<ProfessionDtInfo> ProDtInfoList;
        private ProfessionDtInfo ProDtInfo;
        private static List<ILine> lst_lines;
        private const string myxlPath = "自动寻路_蓬莱_董听雨.bmp";
        private const string myxlNpcPath = "蓬莱_NPC_董听雨.bmp";
        private const string mysdDt = "蓬莱";
        private const int mysdIndex = 5;
        private const int leftWindowX = 170;
        private const int leftWindowY = 190;
        private const int leftWindowStartX = 20;
        private const int leftWindowStartY = 180;
        private const int leftWindowEndX = 318;
        private const int leftWindowEndY = 400;
        public Func()
        {
            //RunReg("RegDll.dll /s");
            //RunReg("dm.dll /s");
            //RunReg("eyou.dll /s");
            dm = new Dm.dmsoft();
            try
            {
                ey = new eyou.Reply();
            }
            catch
            {
                RegCom("eyou.dll");
                ey = new eyou.Reply();
            }
            FillProDtInfoList();//职业场景
            FillDtInfoList();//野外地图
           
            string a = dm.Ver();
            if (dm.Ver() == "")
            {
                throw new Exception("Can't Create Object dm.dmsoft");
            }
            
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
        ~Func()
        {
            if (dm != null)
            {
                UnBindDM();
                dm = null;
            }
            if (ey != null)
            {
                ey = null;
            }
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
        public static void RegCom(string dllName)
        {
            IntPtr hModule = LoadLibrary(dllName);
            if (hModule != IntPtr.Zero)
            {
                IntPtr FuncAddr = GetProcAddress(hModule, "DllRegisterServer");
                if (FuncAddr != IntPtr.Zero)
                {
                    Invoker invoker = Marshal.GetDelegateForFunctionPointer(FuncAddr, typeof(Invoker)) as Invoker;
                    invoker();
                    FreeLibrary(hModule);
                }
                else
                {
                    throw new Exception(string.Format("LoadLibrary:{0} Successful but can not find the interface:DllRegisterServer", dllName));
                }
            }
            else
            {
                throw new Exception(string.Format("LoadLibrary:{0} Failed",dllName));
            }
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
            if (1==dm.IsBind(hwnd))
            {
                if (DialogResult.Yes == MessageBox.Show("窗口已被绑定,是否重新绑定", "提示", MessageBoxButtons.YesNo))
                {
                    dm.UnBindWindow();
                }
                else
                {
                    throw new Exception("不能重复绑定窗口");
                }
            }
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
            return GetPicCenter(0, 0, clientW, clientH, picPath, s, dir, work, out x, out y);
        }

        /// <summary>
        /// 找图获取图片中心坐标
        /// </summary>
        /// <param name="sx">查找範圍起點x座標</param>
        /// <param name="sy">查找範圍起點y座標</param>
        /// <param name="tw">查找範圍結束x座標</param>
        /// <param name="th">查找範圍結束y座標</param>
        /// <param name="picPath">图片路径</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <param name="work">失败重复次数</param>
        /// <param name="x">图片中心x坐标</param>
        /// <param name="y">图片中心y坐标</param>
        /// <returns>0失敗,1成功</returns>
        public int GetPicCenter(int sx,int sy,int tw,int th,string picPath, double s, int dir, int work, out int x, out int y)
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
                {
                    Log(string.Format("Rework={0},ReworkMax={1}", rework, ReworkMax));
                    break;
                }
                ret = FindPic(sx, sy, tw, th, picPath, "222222", s, dir, out x, out y);
                rework = rework + 1;
                Log(string.Format("X:{0},Y:{1};Ret={2}", x, y, ret));
            }
            if (x > 0 || y > 0)
            {
                x = x + picW / 2;
                y = y + picH / 2;
                Log(string.Format("GetPicCenter:找到X:{0},Y:{1}", x, y));
            }
            else
            {
                Log("GetPicCenter:找不到");
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
        /// 不断双击鼠标然后找图,,直到找到为止,找到后等待1秒
        /// </summary>
        /// <param name="xlPath">自动寻路NPC图片</param>
        /// <param name="picPath">NPC窗口标题图片</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        /// <returns>0失敗,1成功</returns>
        public int Reach(string xlPath, string picPath, double s, int dir)
        {
            Log("Reach:" + picPath);
            int ret = 0, x, y;
            DateTime dt1 = DateTime.Now;
            while (ret == 0)
            {
                Thread.Sleep(4000);
                //ret = FindPic(0, 0, clientW, clientH, picPath, "222222", s, dir, out x, out y);
                ret = GetPicCenter(picPath, s, dir,3, out x, out y);
                if (ret == 1)
                {
                    Log("Reach:到达");
                    if ((y < 165 || x > 200) && -1 == picPath.IndexOf("地图"))//150位置会出滚动条通知,会被遮挡
                    {
                        //dm.MoveTo(x + 6, y + 6);
                        dm.MoveTo(x, y);
                        Thread.Sleep(200);
                        dm.LeftDown();
                        Thread.Sleep(200);
                        dm.MoveTo(leftWindowX, leftWindowY);
                        Thread.Sleep(1000);
                        dm.LeftUp();
                    }
                    return ret;
                }
                else
                {
                    dm.LeftDoubleClick();
                    DateTime dt2 = DateTime.Now;
                    if (dt2 - dt1 > ReachTimeOut) //超时,重新开始自动寻路
                    {
                        Log("Reach TimeOut");
                        ReSetWindow("Reach Time Out");
                        dm.MoveTo(clientW / 2 + 100, clientH / 2 + 100); //防止人物与NPC重叠导致NPC界面打不开而超时
                        Thread.Sleep(500);
                        dm.LeftClick();
                        Thread.Sleep(5000);
                        Wayfinding(xlPath, picPath, s, dir);
                    }
                    if (-1 != picPath.IndexOf("地图"))//目标为地图时,检查传送提示
                    {
                        if (1 == FindPic(0, 0, clientW, clientH, "驿站_提示_不加杀气.bmp", "222222", 0.9, 2, out x, out  y))
                        {
                            if (1 == MoveToPicCenter(p窗口_确定, 0.9, 0))
                            {
                                dm.LeftClick();
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
            ResetWindowCount = 0;
            return ret;
        }
        /// <summary>
        /// 自动寻路(全地图跑,非传送模式) 例如,from 程海 to 蓬莱
        /// </summary>
        /// <param name="from">从xx地图</param>
        /// <param name="to">到yy地图</param>
        /// <param name="s">图片相似度</param>
        /// <returns></returns>
        public int WayfindingEx(string from, string to, double s)
        {
            //string dtPrefix="地图_";
            //string from = "", to = "";
            //if (0 == dt1Path.IndexOf(dtPrefix) || 0 == dt2Path.IndexOf(dtPrefix))
            //{
            //    throw new Exception("地图图片名称要以:"+dtPrefix+"开头");
            //}
            //from = dt1Path.ToUpper().Replace("地图_", "").Replace(".BMP","");
            //to = dt2Path.ToUpper().Replace("地图_", "").Replace(".BMP", "");

            List<ILine> lst_result;
            RoadFinder finder = new RoadFinder();
            if (finder.FindRoad(from, to, lst_lines, out lst_result))
            {
                for (int i = 0; i < lst_result.Count; i++)
                {
                    TestLine tl = (TestLine)lst_result[i];
                    CloseSubWindows();
                    Thread.Sleep(1000);
                    try
                    {
                        Wayfinding("自动寻路_通往" + tl.DstId + ".bmp", "地图_" + tl.DstId + ".bmp", s, 2);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.IndexOf("自动寻路_通往" + tl.DstId) != -1)
                        {
                            int x,y;
                            if (1 == GetPicCenter("地图_" + tl.DstId + ".bmp", 0.9, 2, 3, out x, out y))
                            {
                                continue;
                            }
                            else
                            {
                                if(i>0)
                                    i--;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception("找不到可行路径:" + from + "-" + to);
            }
            return 0;
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
            int ret = 0, x, y, reworkMax = 20, rework = 0;
            int x0 = 0, y0 = 0;
            CloseNotice();
            while (ret == 0)
            {
                if (0 == FindPic(0, 0, clientW, clientH, p自动寻路, "222222", s, dir, out x, out y))
                {
                    Log("没打开自动寻路窗口");
                    Thread.Sleep(500);
                    if (1 == GetPicCenter(p自动寻路_图标, s, dir, 0, out x, out y))
                    {
                        Log("点击自动寻路图标");
                        Thread.Sleep(100);
                        dm.MoveTo(x, y);
                        Thread.Sleep(500);
                        dm.LeftClick();
                        Thread.Sleep(showPageTime);
                    }
                    else
                    {
                        Log("按自动寻路快捷键");
                        dm.KeyDown(18);//Alt
                        Thread.Sleep(1000);
                        dm.KeyPress(192);//~
                        Thread.Sleep(1000);
                        dm.KeyUp(18);//Alt
                        Thread.Sleep(500);
                    }
                }
                ret = FindPic(0, 0, clientW, clientH, p自动寻路, "222222", s, dir, out x0, out y0);
                rework++;
                if (rework > reworkMax)
                {
                    //break;
                    ReSetWindow("自动寻路,找不到:" + xlPath);
                    Wayfinding(xlPath, npcPath, s, dir);
                    rework = 0;
                }
            }
            Log(string.Format("X:{0},Y:{1}", x0, y0));
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
                Thread.Sleep(200);
                dm.MoveTo(10, 10);
                Thread.Sleep(1500);
                if (x0 + 130 < clientW && y0 + 227 < clientH)//相对"自动寻路"图片的坐标
                {
                    Thread.Sleep(500);
                    dm.MoveTo(x0 + 130, y0 + 227);
                    Thread.Sleep(200);
                    dm.LeftDoubleClick();
                    Thread.Sleep(200);
                    dm.LeftDoubleClick();
                    Thread.Sleep(200);
                    dm.LeftDoubleClick();
                }
                #region "//"
                /*
                else
                {
                    Console.WriteLine("找下箭头");
                    Log("找下箭头");
                    if (1 == GetPicCenter(p自动寻路_下箭头, 0.8, dir, 0, out x, out y))
                    {
                        Console.WriteLine("找到下箭头");
                        Log("找到下箭头");
                        Thread.Sleep(200);
                        dm.MoveTo(x, y);
                        Thread.Sleep(200);
                        dm.LeftDoubleClick();
                        Thread.Sleep(200);
                        dm.LeftDoubleClick();
                        Thread.Sleep(200);
                        dm.LeftDoubleClick();
                    }
                }
                     */
                #endregion
                Thread.Sleep(1000);
                // Console.WriteLine("自动寻路Rework" + rework.ToString());
                Log("自动寻路Rework" + rework.ToString());
                ret = GetPicCenter(xlPath, s, dir, 3, out x, out y);
                rework++;

            }
            ResetWindowCount = 0;
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            dm.LeftDoubleClick();
            Thread.Sleep(500);
            dm.LeftDoubleClick();
            Thread.Sleep(500);
            ret = Reach(xlPath, npcPath, s, dir);
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
            if (0 == FindPic(0, 0, clientW, clientH, p背包, "222222", s, dir, out x, out y))
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
        /// 关闭全部子窗口
        /// </summary>
        public void CloseSubWindows()
        {
            Log("CloseSubWindows");
            int ret = 1, x, y;
            int count = 0;
            while (ret == 1)
            {
                Thread.Sleep(100);
                dm.MoveTo(1, 1);
                Thread.Sleep(500);
                ret = FindPic(0, 0, clientW, clientH, p窗口_关闭, "222222", 0.9, 2, out x, out y);
                //ret = MoveToPicCenter(p窗口_关闭, 0.9, 2);
                if (ret == 1)
                {
                    Thread.Sleep(100);
                    dm.MoveTo(x + 5, y + 5);
                    Thread.Sleep(600);
                    dm.LeftClick();
                    count++;
                }
                if (count > 5)
                {
                    if (1 == FindPic(0, 0, clientW, clientH, p窗口_确定, "222222", 0.9, 1, out x, out y))
                    {
                        dm.MoveTo(x + 5, y + 4);
                        Thread.Sleep(1000);
                        dm.LeftClick();
                    }
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
            ret = FindPic(0, 0, clientW, clientH, p提示_对决, "222222", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(500);
                dm.RightClick();
            }
            Thread.Sleep(50);
            //ret = MoveToPicCenter(p提示_活动, 0.9, 2);
            ret = FindPic(0, 0, clientW, clientH, p提示_活动, "222222", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(1000);
                dm.RightClick();
            }
            Thread.Sleep(50);
            ret = FindPic(0, 0, clientW, clientH, p提示_帮会, "222222", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(500);
                dm.RightClick();
            }
            Thread.Sleep(50);
            ret = FindPic(0, 0, clientW, clientH, p提示_龙诀, "222222", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(500);
                dm.RightClick();
            }
            Thread.Sleep(50);
            ret = FindPic(0, 0, clientW, clientH, p提示_组队, "222222", 0.9, 2, out x, out y);
            if (ret == 1)
            {
                dm.MoveTo(x, y);
                Thread.Sleep(500);
                dm.RightClick();
            }
            Thread.Sleep(50);
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
                ret = FindPic(0, 0, clientW, clientH, picPath, "222222", 0.9, 0, out x, out y);
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
                    Wayfinding(ProDtInfo.xlPath, ProDtInfo.xlNpcPath, 0.9, 0);
                }
                MoveToPicCenter(p驿站_京师, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(csTime);
                int xx, yy;
                ret = FindPic(0, 0, clientW, clientH, p地图_京师, "222222", 0.9, 2, out  xx, out  yy);
                Thread.Sleep(500);
                rework++;
            }
            ResetWindowCount = 0;
        }
        public void GetEyouErrMsg(string ret, out string ErrMsg)
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
            if (1 == FindPic(0, 0, clientW, clientH, p防挂机检测, "222222", 0.9, 0, out x, out y))
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
                Log("ReSetWindow:" + ResetWindowCount.ToString());
                string errImg = CurrentDir + "/" + ErrImgPath + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + err.Replace(":", "") + ".PNG";
                Log(errImg);
                dm.CapturePng(0, 0, clientW, clientH, errImg);
                if (ResetWindowCount < ResetWindowMaxCount)
                {
                    dm.SetWindowState(hwnd, 2);//最小化窗口,不激活
                    Thread.Sleep(2000);
                    dm.SetWindowState(hwnd, 5);//恢复窗口,不激活
                    Thread.Sleep(5000);
                    //dm.SetClientSize(hwnd, clientW, clientH);//设置窗口大小为原来的
                    //Thread.Sleep(5000);
                    object w, h;
                    dm.GetClientSize(hwnd, out w, out h);//重新获取
                    clientW = (int)w;
                    clientH = (int)h;
                    CloseNotice();
                    CloseSubWindows();
                    ResetWindowCount++;
                }
                else
                {
                    Log("ReSetWindow Reach Max Count,Thread Abort,ErrMsg:" + err);
                    throw new Exception(err);
                }
            }
        }
        private void FillProDtInfoList()
        {
            ProDtInfoList = new List<ProfessionDtInfo>();
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

        public void FillDtInfoList()
        {
            lst_lines = new List<ILine>();
            //A - B
            lst_lines.Add(new TestLine("京师", "太子坡", 1));
            //B - C
            lst_lines.Add(new TestLine("京师", "蓬莱", 10));
            //C - D
            lst_lines.Add(new TestLine("蓬莱", "长白山", 2));
            lst_lines.Add(new TestLine("长白山", "神龙岛", 2));
            lst_lines.Add(new TestLine("神龙岛", "泰山", 2));
            lst_lines.Add(new TestLine("泰山", "百花谷", 2));
            lst_lines.Add(new TestLine("太子坡", "五台山", 1));
            lst_lines.Add(new TestLine("太子坡", "嘉峪关", 2));
            lst_lines.Add(new TestLine("嘉峪关", "木兰草原", 2));
            lst_lines.Add(new TestLine("木兰草原", "辽西", 2));
            lst_lines.Add(new TestLine("木兰草原", "长白山", 2));
            lst_lines.Add(new TestLine("嘉峪关", "华山", 2));
            lst_lines.Add(new TestLine("五台山", "嵩山", 1));
            lst_lines.Add(new TestLine("蓬莱", "王屋山", 1));
            lst_lines.Add(new TestLine("王屋山", "百花谷", 1));
            lst_lines.Add(new TestLine("华山", "玉龙雪山", 3));
            lst_lines.Add(new TestLine("玉龙雪山", "丽江", 2));
            lst_lines.Add(new TestLine("丽江", "昆仑山口", 2));
            lst_lines.Add(new TestLine("昆仑山口", "天池", 2));
            lst_lines.Add(new TestLine("玉龙雪山", "嵩山", 3));
            lst_lines.Add(new TestLine("丽江", "南岭", 2));
            lst_lines.Add(new TestLine("南岭", "程海", 2));
            lst_lines.Add(new TestLine("程海", "昆明", 1));
            lst_lines.Add(new TestLine("嵩山", "昆明", 1));
            lst_lines.Add(new TestLine("程海", "哀牢山", 1));
            lst_lines.Add(new TestLine("哀牢山", "白龙潭", 1));
            lst_lines.Add(new TestLine("哀牢山", "黑龙潭", 3));
            lst_lines.Add(new TestLine("白龙潭", "扬州", 1));
            lst_lines.Add(new TestLine("黑龙潭", "扬州", 3));
            lst_lines.Add(new TestLine("白龙潭", "隐龙江", 2));
            lst_lines.Add(new TestLine("黑龙潭", "隐龙江", 3));
            lst_lines.Add(new TestLine("隐龙江", "武夷山", 2));
            lst_lines.Add(new TestLine("武夷山", "南岭", 2));
            lst_lines.Add(new TestLine("隐龙江", "龙虎山", 2));
            lst_lines.Add(new TestLine("龙虎山", "泰山", 2));
            lst_lines.Add(new TestLine("百花谷", "扬州", 1));
            lst_lines.Add(new TestLine("百花谷", "古域丛林", 1));
            lst_lines.Add(new TestLine("古域丛林", "古域海底", 1));
            lst_lines.Add(new TestLine("古域海底", "古域矿洞", 1));
            lst_lines.Add(new TestLine("古域矿洞", "古域东宫", 1));
            lst_lines.Add(new TestLine("古域东宫", "古域西宫", 1));
        }
        /// <summary>
        /// 退出游戏,Sleep 100
        /// </summary>
        public void CloseGame()
        {
            int x, y;
            if (1 == GetPicCenter("Esc.bmp", 0.9, 3, 2, out x, out y))
            {
                Thread.Sleep(100);
                dm.MoveTo(x, y);
                Thread.Sleep(100);
                dm.LeftClick();
                Thread.Sleep(showPageTime);
                if (1 == GetPicCenter("菜单_退出游戏.bmp", 0.9, 3, 2, out x, out y))
                {
                    Thread.Sleep(100);
                    dm.MoveTo(x, y);
                    Thread.Sleep(100);
                    dm.LeftClick();
                    Thread.Sleep(showPageTime);
                    if (1 == GetPicCenter("窗口_退出游戏.bmp", 0.9, 3, 2, out x, out y))
                    {
                        Thread.Sleep(100);
                        dm.MoveTo(x, y);
                        Thread.Sleep(100);
                        dm.LeftClick();
                        Thread.Sleep(100);
                    }
                }
            }
        }
        /// <summary>
        /// 出帮会属地,Sleep csTime
        /// </summary>
        public void OutBangHui()
        {
            int ret = 0;
            int x = 0, y = 0;
            //Thread.Sleep(1000);
            //if (0 == FindPic(0, 0, clientW, clientH, "地图_天涯海角.bmp|地图_世外林源.bmp", "222222", 0.9, 2, out  x, out  y))
            //{
            //    MessageBox.Show("没在帮会中");
            //}
            CloseSubWindows();
            Wayfinding("自动寻路_帮会_李晓生.bmp", "帮会_NPC_李晓生.bmp", 0.9, 0);
            CloseSubWindows();
            Thread.Sleep(500);
            if (0 == GetPicCenter("帮会_地图_传送.bmp", 0.9, 3, 3, out x, out y))
            {
                Thread.Sleep(500);
                GetPicCenter("帮会_地图_传送1.bmp", 0.9, 3, 3, out x, out y);
            }
            Thread.Sleep(500);
            dm.MoveTo(x, y);
            dm.LeftClick();

            Thread.Sleep(3000);

            //73b2d6 8ce7f7-050505|c6ffff-050505
            //ret = dm.FindColor(0, 0, clientW, clientH, "73b2d6-050505|c6ffff-050505", 1.0, 4, out objx, out objy);
            //x = (int)objx;
            //y = (int)objy;
            ret = FindPic(0, 0, clientW, clientH, "帮会_出口_传送.bmp", "111111", 1, 0, out x, out y);
            while (ret == 0)
            {
                //Thread.Sleep(1000);
                //ret = dm.FindColor(0, 0, clientW, clientH, "73b2d6-050505|c6ffff-050505", 1.0, 4, out objx, out objy);
                //x = (int)objx;
                //y = (int)objy;
                Thread.Sleep(200);
                ret = FindPic(0, 0, clientW, clientH, "帮会_出口_传送.bmp", "111111", 1, 0, out x, out y);//GetPicCenter("帮会_出口_传送.bmp", 1, 0, 5, out x, out y);

            }
            Log(string.Format("X:{0},Y:{1}", x, y));
            Thread.Sleep(500);
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(csTime);
        }
       
        public string GetCurrentDT()
        {
            string[] dtList = Directory.GetFiles(Form1.PicPath, "地图_*.bmp");
            int x = 0, y = 0;
            foreach (string dt in dtList)
            {
                if (1 == FindPic(0, 0, clientW, clientH, dt.Replace(Form1.PicPath, ""), "222222", 0.9, 2, out x, out y))
                {
                    return dt.Replace(Form1.PicPath, "").Replace("地图_", "").Replace(".bmp", "");
                }
            }
            return "";
        }
       
    }
}
