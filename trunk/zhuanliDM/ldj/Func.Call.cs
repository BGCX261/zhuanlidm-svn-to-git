using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Drawing;

namespace ldj
{
    public partial class Func
    {
        /// <summary>
        /// 专利运行
        /// </summary>
        public void ZhuanliMission()
        {

            Log("专利任务");
            int ret = 0, x, y;
            ret = FindPic(0, 0, clientW, clientH, p任务执行_状态_专利_完成描述, "222222", 0.9, 0, out x, out y);
            while (ret == 0)
            {
                Thread.Sleep(1000);
                if (0 == GetPicCenter(leftWindowStartX,leftWindowStartY,leftWindowEndX,leftWindowEndY,p任务执行_状态_专利_左中括号, 0.9, 0, 0, out x, out y))
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
                        Thread.Sleep(1000);

                        GetPicCenter(leftWindowStartX, leftWindowStartY, leftWindowEndX, leftWindowEndY, p任务执行_状态_专利_左中括号, 0.9, 0, 0, out x, out y);
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
                Log("判断专利有没结束" + p专利_提示_结束);
                if (1 == FindPic(0, 0, clientW, clientH, p专利_提示_结束, "222222", 0.9, 0, out x, out y))
                {
                    Thread.Sleep(100000);
                    CloseGame();
                    FuncEventHandler.Invoke(this, new FuncEventArgs("Finish", WorkStatus.Stop));
                    return;
                }
                ret = FindPic(0, 0, clientW, clientH, p任务执行_状态_专利_完成描述, "222222", 0.9, 0, out x, out y);
            }
            ResetWindowCount = 0;
        }
        /// <summary>
        /// 前往目标帮会属地(非驿站)
        /// 返回前Sleep 传送等待时间(csTime)
        /// </summary>
        /// <param name="xlPath">自动寻路列表NPC名称图片(帮会入口NPC名字)</param>
        /// <param name="xlNpcPath">NPC窗口名字图片(帮会入口NPC)</param>
        /// <param name="sdIndex">进入第几个帮会</param>
        /// <param name="s">相识度</param>
        /// <param name="dir">查找方向</param>
        public void GotoTargetBangHuiEx(string xlPath, string xlNpcPath, int sdIndex, double s, int dir)
        {
            int x, y, d;
            d = 23;//帮会列表的每个帮会y坐标距离22像素
            int ret = 0;
            int rework = 0;
            ResetWindowCount = 0;
            Wayfinding(xlPath, xlNpcPath, s, dir);
            Thread.Sleep(500);
            ret = 0;
            rework = 0;
            int y1 = 0;
            while (ret == 0)
            {
                if (rework > csReworkMax)
                {
                    ReSetWindow("前往:对方帮会属地");
                    rework = 0;
                }
                GetPicCenter(xlNpcPath, s, dir, 0, out x, out y);
                y1 = y + 81 + d * (sdIndex - 1);//NPC名字坐标和第一个帮会列表距离88像素//中心距離81px
                Thread.Sleep(500);
                dm.MoveTo(x, y1);
                Log(string.Format("GotoTargetBangHuiEx MoveTo x:{0};y:{1}", x, y1));
                Thread.Sleep(1000);
                dm.LeftClick();
                Thread.Sleep(csTime);
                int xx, yy;
                ret = FindPic(0, 0, clientW, clientH, "地图_天涯海角.bmp|地图_世外林源.bmp", "222222", 0.9, 2, out  xx, out  yy);
                rework++;
            }
            ResetWindowCount = 0;
        }
        /// <summary>
        /// 前往目标帮会属地(驿站)
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
                Thread.Sleep(2000);
                int xx, yy;
                if (1 == FindPic(0, 0, clientW, clientH, "驿站_提示_不加杀气.bmp", "222222", 0.9, 2, out  xx, out  yy))
                {
                    if (1 == MoveToPicCenter(p窗口_确定, 0.9, 0))
                    {
                        dm.LeftClick();
                    }
                }
                Thread.Sleep(csTime);

                ret = FindPic(0, 0, clientW, clientH, dtPath, "222222", 0.9, 2, out  xx, out  yy);
                rework++;
            }
            GotoTargetBangHuiEx(xlPath, xlNpcPath, sdIndex, s, dir);
        }
        public void DoZhuanliMissionEx()
        {
            Log("做专利Ex");
            Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter(p帮会_李逍_专利任务, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            int xx, yy;
            if (1 == FindPic(0, 0, clientW, clientH, p窗口_完成, "222222", 0.9, 1, out xx, out yy))
            {
                Thread.Sleep(500);
                dm.MoveTo(xx, yy);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(500);
                CloseSubWindows();
                Thread.Sleep(500);
                Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
                Thread.Sleep(showPageTime);
                MoveToPicCenter(p帮会_李逍_专利任务, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(showPageTime);
            }
            MoveToPicCenter(p窗口_接受, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            CloseSubWindows();
            Thread.Sleep(500);
            
            ResetWindowCount = 0;
          //點定位符 F1
            
            dm.KeyPress(112);//F1 
            Thread.Sleep(10000);
            Thread.Sleep(csTime);
            FindInPack(p道具_笔记本, 0.9, 3);
            Thread.Sleep(500);
            dm.RightClick();
            Thread.Sleep(showPageTime);
            ZhuanliMission();
            //點定位符回幫 F2
            dm.KeyPress(113);//F2
            Thread.Sleep(10000);
            Thread.Sleep(csTime);
           
            Thread.Sleep(5000);
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
            int xx, yy;
            if (1 == FindPic(0, 0, clientW, clientH, p窗口_完成, "222222", 0.9, 1, out xx, out yy))
            {
                Thread.Sleep(500);
                dm.MoveTo(xx, yy);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(500);
                CloseSubWindows();
                Thread.Sleep(500);
                Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
                Thread.Sleep(showPageTime);
                MoveToPicCenter(p帮会_李逍_专利任务, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(showPageTime);
            }
            MoveToPicCenter(p窗口_接受, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            CloseSubWindows();
            Thread.Sleep(500);
            Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
            Thread.Sleep(showPageTime);
            int ret = 0;

            int rework = 0;
            while (ret == 0)
            {
                if (rework > csReworkMax)
                {
                    ReSetWindow("传送到京师:" + rework.ToString());
                    rework = 0;
                    if (0 == FindPic(0, 0, clientW, clientH, p地图_京师, "222222", 0.9, 2, out  xx, out  yy))
                    {
                        Wayfinding(p自动寻路_帮会_李逍, p帮会_NPC_李逍, 0.9, 0);
                    }
                }
                MoveToPicCenter(p帮会_李逍_送我去京师, 0.9, 0);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(csTime);
                ret = FindPic(0, 0, clientW, clientH, p地图_京师, "222222", 0.9, 2, out  xx, out  yy);
                Log(string.Format("地图_京师,X:{0},Y{1},ret={2}", xx, yy, ret));
                rework++;
            }
            ResetWindowCount = 0;
            Log(p自动寻路_京师_邢千里);
            Wayfinding(p自动寻路_京师_邢千里, p京师_NPC_邢千里, 0.9, 0);
            Thread.Sleep(500);
            int x0 = 0, y0 = 0;
            FindPic(0, 0, clientW, clientH, p京师_NPC_邢千里, "222222", 0.9, 0, out x0, out y0);
            Thread.Sleep(500);
            ret = FindPic(0, 0, clientW, clientH, toPath, "222222", 0.9, 0, out xx, out yy);
            while (ret == 0)
            {
                Thread.Sleep(200);
                dm.MoveTo(10, 10);
                Thread.Sleep(1500);


                dm.MoveTo(x0 + 155, y0 + 402);
                Thread.Sleep(200);
                dm.LeftDoubleClick();
                Thread.Sleep(200);
                dm.LeftDoubleClick();
                Thread.Sleep(200);
                dm.LeftDoubleClick();
                ret = FindPic(0, 0, clientW, clientH, toPath, "222222", 0.9, 0, out xx, out yy);
            }
            //GotoTargetBangHui(p驿站_前往百花谷, p自动寻路_百花谷_于凯鑫, p百花谷_NPC_于凯鑫, 1, 0.9, 0);
            Log(string.Format("GotoTargetBangHui({0},{1},{2},{3})", toPath, xlPath, xlNpcPath, sdIndex));
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
                    ReSetWindow("传送到师门:" + rework.ToString());
                    rework = 0;
                }
                FindInPack(p道具_师门令, 0.9, 3);
                Thread.Sleep(500);
                dm.RightClick();
                Thread.Sleep(15000);
                ret = FindPic(0, 0, clientW, clientH, ProDtInfo.dtPath, "222222", 0.9, 2, out  xx, out  yy);
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
                ret = FindPic(0, 0, clientW, clientH, "地图_天涯海角.bmp|地图_世外林源.bmp", "222222", 0.9, 2, out  xx, out  yy);
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
        /// 自动打怪,~ &1
        /// </summary>
        /// <param name="str">是否为混合打怪</param>
        public void Attack(bool hh)
        {
            if (hh == false)
            {
                Thread.Sleep(500);
                dm.KeyPress(192);//~
                Thread.Sleep(500);
                dm.KeyPress(49);//1
            }
            else
            {
                int x = 0, y = 0;
                dm.KeyPress(192);//~
                Thread.Sleep(100);
                if (1 == FindPic(290, 0, 360, 35, "怪物_神秘黄蜂.bmp", "222222", 0.9, 0, out x, out y))
                {
                    dm.KeyPress(49);
                }
            }
        }
        /// <summary>
        /// 准备种地,调整朝北,滚轮到底,人最小
        /// </summary>
        /// <param name="x">调整后稻草人图片中心x坐标</param>
        /// <param name="y">调整后稻草人图片中心y坐标</param>
        public void ReadyToPlanting(ref int x, ref int y)
        {
            int xx = 0, yy = 0;
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
            /*
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
             * */
            int cX = clientW / 2;
            int cY = clientH / 2;
        plEx:
            int x1 = 0, y1 = 0;
            int rework = 0;
            while (0 == FindPic(cX - 200, cY - 250, cX + 200, cY + 150, "NPC_稻草人.bmp", "111111", 1, 0, out x1, out y1))
            {
                rework++;
                if (rework > picReworkMax)
                {
                    MessageBox.Show("找不到稻草人");
                    return;
                }
            }
            dm.MoveTo(x1 + 35, y1 + 85);
            Thread.Sleep(1000);
            dm.LeftClick();
            Thread.Sleep(3000);
            if (0 == GetPicCenter(p稻草人, 0.9, 0, 5, out xx, out yy))
            {
                goto plEx;
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
        /// 准备种树,调整朝北,滚轮到底,人最小
        /// </summary>
        /// <param name="x">调整后树苗图片中心x坐标</param>
        /// <param name="y">调整后树苗图片中心y坐标</param>
        public void ReadyToPlantTree(ref int x, ref int y)
        {
            
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
            CloseNotice();
            CloseSubWindows();
        }
         /// <summary>
        /// 自动种树
        /// </summary>
        /// <param name="index">种第几种作物</param>
        /// <param name="x">树苗图片中心的x坐标</param>
        /// <param name="y">树苗图片中心的y坐标</param>
        public void PlantTree(int index, int x, int y)
        {
            int xx = 0, yy = 0;
            int cX = clientW / 2;
            int cY = clientH / 2;
        plEx:
            int x1 = 0, y1 = 0;
            int rework = 0;
            
            while (0 == FindPic(cX - 200, cY - 250, cX + 200, cY + 150, "NPC_树苗.bmp", "111111", 1, 0, out x1, out y1))
            {
                Thread.Sleep(1000);
                rework++;
                if (rework > picReworkMax)
                {
                    MessageBox.Show("找不到树苗");
                    return;
                }
            }
            Thread.Sleep(1000);
            dm.MoveTo(x1 + 17, y1 + 47);
            Thread.Sleep(1000);
            dm.LeftClick();
            Thread.Sleep(3000);
            if (0 == GetPicCenter("树苗.bmp", 0.9, 0, 5, out xx, out yy))
            {
                goto plEx;
            }
            Thread.Sleep(500);
            if (xx != x || yy != y)
            {
                dm.MoveTo(xx, yy);
                Thread.Sleep(500);
                dm.LeftDown();
                Thread.Sleep(1000);
                dm.MoveTo(x, y);
                Thread.Sleep(2000);
                dm.LeftUp();
            }
            Thread.Sleep(2000);
            dm.MoveTo(106, y + 116);//点早产,树苗图片中心到早产中心116px
            Thread.Sleep(1000);
            dm.LeftClick();
            Thread.Sleep(3000);
            int yy1 = y + 15;
            yy1 = yy1 + 23 * index;
            dm.MoveTo(120, yy1);//要种第几个(总共8个)
            Thread.Sleep(1000);
            dm.LeftClick();
            Thread.Sleep(1000);
            dm.KeyPress(113);//F2 隐身
            Thread.Sleep(308000); //等5分钟
            
            if (1 == FindPic(cX - 200, cY - 250, cX + 200, cY + 150, "NPC_树苗.bmp", "111111", 1, 0, out x1, out y1))
            {
                Thread.Sleep(1000);
                dm.MoveTo(x1+30, y1-30);
                Thread.Sleep(500);
                dm.LeftClick(); //一次
                Thread.Sleep(10000);
                dm.LeftClick();//2次
                Thread.Sleep(10000);
                dm.LeftClick();//3
                Thread.Sleep(10000);
                dm.LeftClick();//4
                Thread.Sleep(10000);
                dm.MoveTo(10, 10);
                Thread.Sleep(1000);
            }
            CloseNotice();
            CloseSubWindows();
        }
        /// <summary>
        /// 自动种植
        /// </summary>
        /// <param name="index">种第几种作物</param>
        /// <param name="x">稻草人图片中心的x坐标</param>
        /// <param name="y">稻草人图片中心的y坐标</param>
        public void Planting(int index, int xx, int yy)
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

            dm.MoveTo(106, yy + 116);//点早产,稻草人图片中心到早产中心116px
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            int y = yy + 15;
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
        /// <summary>
        /// 自动种植
        /// </summary>
        /// <param name="index">种第几种作物</param>
        /// <param name="x">稻草人图片中心的x坐标</param>
        /// <param name="y">稻草人图片中心的y坐标</param>
        public void PlantingEx(int index, int xx, int yy)
        {
            CloseNotice();
            CloseSubWindows();
            Thread.Sleep(3000);
            int cX = clientW / 2;
            int cY = clientH / 2;
            plEx:
            int x1=0, y1=0;
            int rework = 0;
            while (0 == FindPic(cX - 200, cY - 250, cX + 200, cY + 150, "NPC_稻草人.bmp", "111111", 1, 0, out x1, out y1))
            {
                rework++;
                if (rework > picReworkMax)
                {
                    MessageBox.Show("找不到稻草人");
                    return;
                }
            }
            dm.MoveTo(x1 + 35, y1 + 85);
            Thread.Sleep(1000);
            dm.LeftClick();
            Thread.Sleep(3000);
            if (0 == GetPicCenter(p稻草人, 0.9, 0, 5, out xx, out yy))
            {
                goto plEx;
            }
            Thread.Sleep(1000);
            dm.MoveTo(106, yy + 116);//点早产,稻草人图片中心到早产中心116px
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(3000);
            int y = yy + 15;
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
        public void BBAutoXue(double p)
        {
            int x1 = 49;
            int y1 = 100;
            int x2 = 81;
            int y2 = 104;
            AutoXLByP(x1, y1, x2, y2, "ff0000-222222", p, p道具_珍兽血药);
        }
        private void AutoXLByP(int x1, int y1, int x2, int y2, string color, double p, string yPath)
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
        public void ReadyToXY(out string xlPath, out string npcPath)
        {
            int xx, yy;
            if (1 == FindPic(0, 0, clientW, clientH, "地图_明湖新村.bmp", "222222", 0.9, 2, out xx, out yy))
            {
                xlPath = "自动寻路_明湖新村_邹思.bmp";
                npcPath = "明湖新村_NPC_邹思.bmp";
            }
            else if (1 == FindPic(0, 0, clientW, clientH, "地图_平安城.bmp", "222222", 0.9, 2, out xx, out yy))
            {
                xlPath = "自动寻路_平安城_让叶.bmp";
                npcPath = "平安城_NPC_让叶.bmp";
            }
            else
            {
                throw new Exception("请将角色放到明湖新村或者平安城地图");
            }
        }
        public void XYTJ(int index, string xlPath, string npcPath)
        {
            int x, y;
            CloseNotice();
            if (0 == GetPicCenter(npcPath, 0.9, 0, 1, out x, out y))
            {
                Thread.Sleep(200);
                CloseSubWindows();
                Wayfinding(xlPath, npcPath, 0.9, 0);

                //GetPicCenter("平安城_NPC_让叶.bmp", 0.9, 0, 1, out x, out y);
            }
            Thread.Sleep(showPageTime);

            int ret = 0;
            while (ret == 0)
            {

                if (1 == GetPicCenter("平安城_让叶_提交.bmp", 0.9, 0, 1, out x, out y))
                {
                    Thread.Sleep(50);
                    dm.MoveTo(x, y);
                    Thread.Sleep(50);
                    dm.LeftClick();
                    Thread.Sleep(100);
                    dm.MoveTo(10, 10);
                    Thread.Sleep(100);
                    if (1 == GetPicCenter("星语_提示_待领取.bmp", 0.9, 1, 2, out x, out y))
                    {
                        Thread.Sleep(50);
                        XYLQ(index, xlPath, npcPath);
                        Thread.Sleep(50);
                    }
                    if (1 == GetPicCenter("星语_提示_分钟.bmp", 0.9, 1, 2, out x, out y))
                    {
                        Thread.Sleep(50);
                        XYLQ(index, xlPath, npcPath);
                        Thread.Sleep(50);
                    }
                    if (1 == GetPicCenter("星语_提示_已提交.bmp", 0.9, 1, 2, out x, out y))
                    {
                        Thread.Sleep(50);
                        XYLQ(index, xlPath, npcPath);
                        Thread.Sleep(50);
                    }
                    ret = GetPicCenter("星语_标题_尾.bmp", 0.9, 0, 1, out x, out y);
                    Thread.Sleep(50);
                    //Thread.Sleep(3000);
                }
                else
                {
                    CloseNotice();
                    if (0 == GetPicCenter(npcPath, 0.9, 0, 1, out x, out y))
                    {
                        Thread.Sleep(200);
                        CloseSubWindows();
                        Wayfinding(xlPath, npcPath, 0.9, 0);
                        //GetPicCenter("平安城_NPC_让叶.bmp", 0.9, 0, 1, out x, out y);
                    }
                    Thread.Sleep(showPageTime);
                }
            }
            int indexX, indexY;
            indexX = x;
            indexY = y + 7 + (index * 18);//间隔18px
            dm.MoveTo(indexX, indexY);
            Thread.Sleep(100);
            dm.LeftClick();
            Thread.Sleep(100);
            #region "选择 确定"
            if (1 == GetPicCenter("窗口_选择.bmp", 0.9, 0, 5, out x, out y))
            {
                Thread.Sleep(50);
                dm.MoveTo(x, y);
                Thread.Sleep(50);
                dm.LeftClick();
                Thread.Sleep(100);
                if (1 == GetPicCenter("窗口_确定.bmp", 0.9, 0, 5, out x, out y))
                {
                    Thread.Sleep(50);
                    dm.MoveTo(x, y);
                    Thread.Sleep(50);
                    dm.LeftClick();
                    Thread.Sleep(100);
                    if (1 == FindPic(0, 0, clientW, clientH, p窗口_确定, "222222", 0.9, 0, out x, out y))
                    {
                        Thread.Sleep(50);
                        dm.MoveTo(x + 5, y + 4);
                        Thread.Sleep(50);
                        dm.LeftClick();
                        Log(string.Format("按确定:X:{0},Y:{1};", x + 5, y + 4));
                        Thread.Sleep(50);
                    }
                    if (0 == GetPicCenter(npcPath, 0.9, 0, 1, out x, out y))
                    {
                        Thread.Sleep(50);
                        CloseNotice();
                        CloseSubWindows();
                        Wayfinding(xlPath, npcPath, 0.9, 0);
                    }
                    Thread.Sleep(showPageTime);
                }
            }
            #endregion
        }
        public void XYLQ(int index, string xlPath, string npcPath)
        {
            while (true)
            {
                int x, y;
                if (1 == FindPic(0, 0, clientW, clientH, p窗口_确定, "222222", 0.9, 0, out x, out y))
                {
                    Thread.Sleep(100);
                    dm.MoveTo(x + 5, y + 4);
                    Thread.Sleep(100);
                    dm.LeftClick();
                    Log(string.Format("按确定:X:{0},Y:{1};", x + 5, y + 4));
                    Thread.Sleep(100);
                }
                if (0 == GetPicCenter(npcPath, 0.9, 0, 1, out x, out y))
                {
                    Thread.Sleep(100);
                    CloseSubWindows();
                    Wayfinding(xlPath, npcPath, 0.9, 0);
                }
                Thread.Sleep(showPageTime);
                //Thread.Sleep(50);
                dm.MoveTo(10, 10);
                Thread.Sleep(50);
                if (1 == GetPicCenter("平安城_让叶_领取.bmp", 0.9, 0, 1, out x, out y))
                {
                    Thread.Sleep(100);
                    dm.MoveTo(x, y);
                    Thread.Sleep(100);
                    dm.LeftClick();
                    Thread.Sleep(100);
                    if (1 == GetPicCenter("星语_提示_完成.bmp", 0.9, 1, 2, out x, out y))
                    {
                        Log("星语完成");
                        break;
                    }
                    //Thread.Sleep(4000);
                    Thread.Sleep(100);
                    if (1 == GetPicCenter("星语_提示_没有提交.bmp", 0.9, 1, 2, out x, out y))
                    {
                        Log("星语,没有提交,重新开始");
                        break;
                    }
                }
                Thread.Sleep(100);
            }

        }
        public void XY(int index, string xlPath, string npcPath)
        {
            XYTJ(index, xlPath, npcPath);
            XYLQ(index, xlPath, npcPath);
        }
        public void DoBusiness(string str, string dtPath, string xlPath, string xlnpcPath, int sdIndex)
        {
            int x = 0; int y = 0; int ret = 0;
            Log("跑商");
            for (int i = 0; i < 3; i++)
            {
                dm.MoveTo(clientW - 74, 28);//调整朝向,北
                Thread.Sleep(200);
                dm.LeftClick();
                Thread.Sleep(2000);
                dm.WheelDown();
                Thread.Sleep(200);
            }

            CloseSubWindows();
            Wayfinding("自动寻路_帮会_沈富勤.bmp", "帮会_NPC_沈富勤.bmp", 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter("帮会_沈富勤_跑商.bmp", 1, 0);
            Thread.Sleep(1000);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            MoveToPicCenter("帮会_沈富勤_跑商_领取商票.bmp", 0.9, 0);
            Thread.Sleep(1000);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            if (1 == FindPic(0, 0, clientW, clientH, "跑商_提示_不是商人.bmp", "222222", 0.9, 0, out x, out y))
            {
                MessageBox.Show("不是商人不能跑商");
                return;
            }
            CloseSubWindows();
            Wayfinding("自动寻路_帮会_沈富勤.bmp", "帮会_NPC_沈富勤.bmp", 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter("帮会_沈富勤_商店.bmp", 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(5000);
            Answer(str);
            Thread.Sleep(500);
            ret = GetPicCenter("帮会_商店_商票购买.bmp", 0.9, 0, 3, out x, out y);
            while (ret == 0)
            {
                MoveToPicCenter("帮会_商店_箭头_右.bmp", 0.9, 0);
                dm.LeftClick();
                Thread.Sleep(500);
                ret = GetPicCenter("帮会_商店_商票购买.bmp", 0.9, 0, 3, out x, out y);
                Thread.Sleep(500);

            }
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            GetPicCenter("帮会_商店_购买.bmp", 0.9, 0, 3, out x, out y);
            Thread.Sleep(500);
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            GetPicCenter("帮会_商店_最大.bmp", 0.9, 0, 3, out x, out y);
            Thread.Sleep(500);
            dm.MoveTo(x - 70, y);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(1000);
            dm.KeyPress(49);//按2,购买11个,卖出66个,6个格子,2级物品
            Thread.Sleep(500);

            MoveToPicCenter(p窗口_确定, 0.9, 0);
            dm.LeftClick();
            Thread.Sleep(500);
            if (1 == MoveToPicCenter("跑商_提示_钱不够.bmp", 0.9, 0))
            {
                GetPicCenter("帮会_商店_购买.bmp", 0.9, 0, 3, out x, out y);
                Thread.Sleep(500);
                dm.MoveTo(x, y);
                Thread.Sleep(500);
                dm.LeftClick();
                Thread.Sleep(showPageTime);
                MoveToPicCenter("帮会_商店_最大.bmp", 0.9, 0);
                dm.LeftClick();
                Thread.Sleep(500);

                MoveToPicCenter(p窗口_确定, 0.9, 0);
                dm.LeftClick();
                Thread.Sleep(500);
            }
            Thread.Sleep(500);
            OutBangHui();
            if (1 != GetPicCenter("地图_"+mysdDt+".bmp", 0.9, 2, 3, out x, out y))
            {
                Thread.Sleep(500);
                OutBangHui();
            }
            WayfindingEx(mysdDt, dtPath, 0.9);
            CloseSubWindows();
            GotoTargetBangHuiEx(xlPath, xlnpcPath, sdIndex, 0.9, 0);
            Wayfinding("自动寻路_帮会_沈富勤.bmp", "帮会_NPC_沈富勤.bmp", 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter("帮会_沈富勤_商店.bmp", 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            Answer(str);
            Thread.Sleep(500);
            //ret = GetPicCenter("帮会_商店_物物交换.bmp", 0.9, 0, 3, out x, out y);
            int iY = 0;
        jiaohuan:
            ret = FindPic(0, iY, clientW, clientH, "帮会_商店_物物交换.bmp", "222222", 0.9, 0, out x, out y);
            iY = y;

            //string strRet=dm.FindPicEx(0, 0, clientW, clientH, "帮会_商店_物物交换.bmp", "222222", 0.9, 0);
            // MessageBox.Show(strRet);
            while (ret == 0)
            {
                MoveToPicCenter("帮会_商店_箭头_右.bmp", 0.9, 0);
                dm.LeftClick();
                Thread.Sleep(500);
                //ret = GetPicCenter("帮会_商店_物物交换.bmp", 0.9, 0, 3, out x, out y);
                ret = FindPic(0, iY, clientW, clientH, "帮会_商店_物物交换.bmp", "222222", 0.9, 0, out x, out y);
                Thread.Sleep(500);

            }
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            GetPicCenter("帮会_商店_购买.bmp", 0.9, 0, 3, out x, out y);
            Thread.Sleep(500);
            dm.MoveTo(x, y);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            MoveToPicCenter("帮会_商店_最大.bmp", 0.9, 0);
            dm.LeftClick();
            Thread.Sleep(500);
            MoveToPicCenter(p窗口_确定, 0.9, 0);
            dm.LeftClick();
            Thread.Sleep(500);
            if (1 == GetPicCenter("跑商_提示_不足.bmp", 0.9, 0, 5, out x, out y))
            {
                iY = iY + 30;
                int zX = 0, zY = 0;
                if (1 == FindPic(0, 0, clientW, clientH, "帮会_商店_最大.bmp", "222222", 0.9, 0, out zX, out zY))
                {
                    Thread.Sleep(200);
                    if (1 == FindPic(zX, zY - 60, zX + 100, zY, p窗口_关闭, "222222", 0.9, 2, out x, out y))
                    {
                        Thread.Sleep(200);
                        dm.MoveTo(x + 6, y + 6);
                        Thread.Sleep(500);
                        dm.LeftClick();
                        Thread.Sleep(500);
                    }
                }
                goto jiaohuan;
            }
            OutBangHui();
            if (1 != GetPicCenter("地图_" + dtPath + ".bmp", 0.9, 2, 3, out x, out y))
            {
                Thread.Sleep(500);
                OutBangHui();
            }

            WayfindingEx(dtPath, mysdDt, 0.9);
            GotoTargetBangHuiEx(myxlPath,myxlNpcPath, mysdIndex, 0.9, 0);
            Wayfinding("自动寻路_帮会_沈富勤.bmp", "帮会_NPC_沈富勤.bmp", 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter("帮会_沈富勤_商店.bmp", 0.9, 0);
            dm.LeftClick();
            Thread.Sleep(5000);
            Answer(str);
            Thread.Sleep(500);
            MoveToPicCenter("帮会_商店_全部卖出.bmp", 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            MoveToPicCenter(p窗口_确定, 0.9, 0);
            Thread.Sleep(500);
            dm.LeftClick();
            Thread.Sleep(500);
            CloseSubWindows();

            Wayfinding("自动寻路_帮会_沈富勤.bmp", "帮会_NPC_沈富勤.bmp", 0.9, 0);
            Thread.Sleep(showPageTime);
            MoveToPicCenter("帮会_沈富勤_跑商.bmp", 1, 0);
            dm.LeftClick();
            Thread.Sleep(showPageTime);
            MoveToPicCenter("帮会_沈富勤_跑商_交还商票.bmp", 0.9, 0);
            dm.LeftClick();
            Thread.Sleep(5000);
        }
        public void KJ()
        {
            int x = 0, y = 0, ret = 0;
        start:
            Thread.Sleep(200);
            CloseSubWindows();
            Thread.Sleep(200);
            Wayfinding("自动寻路_京师_崔翰林.bmp", "京师_NPC_崔翰林.bmp", 0.9, 3);
            Thread.Sleep(200);
            GetPicCenter(leftWindowStartX,leftWindowStartY,leftWindowEndX,leftWindowEndY,"京师_崔翰林_科举.bmp", 0.9, 0, 3, out x, out y);
            Thread.Sleep(200);
            dm.MoveTo(x, y);
            Thread.Sleep(200);
            dm.LeftClick();
            Thread.Sleep(200);
            if (1 == GetPicCenter("京师_崔翰林_科举_用准考证.bmp", 0.9, 0, 3, out x, out y))
            {
                Thread.Sleep(200);
                dm.MoveTo(x, y);
                Thread.Sleep(200);
                dm.LeftClick();
                Thread.Sleep(200);
                GetPicCenter("京师_崔翰林_科举_用准考证_确定.bmp", 0.9, 0, 3, out x, out y);
                Thread.Sleep(200);
                dm.MoveTo(x, y);
                Thread.Sleep(200);
                dm.LeftClick();
                Thread.Sleep(200);
            }
            if (1 == GetPicCenter("科举_提示_没有准考证.bmp", 0.9, 0, 3, out x, out y))
            {
                CloseSubWindows();
                Thread.Sleep(200);
                Wayfinding("自动寻路_京师_崔翰林.bmp", "京师_NPC_崔翰林.bmp", 0.9, 3);
                GetPicCenter("京师_崔翰林_领证.bmp", 0.9, 0, 3, out x, out y);
                Thread.Sleep(200);
                dm.MoveTo(x, y);
                Thread.Sleep(200);
                dm.LeftClick();
                Thread.Sleep(200);
                GetPicCenter("科举_提示_领准考证.bmp", 0.9, 0, 3, out x, out y);
                Thread.Sleep(200);
                dm.MoveTo(x, y);
                Thread.Sleep(200);
                dm.LeftClick();
                Thread.Sleep(200);
                goto start;
            }
        kj:
            ret = GetPicCenter("科举_答案.bmp", 0.9, 0, 3, out x, out y);
            while (ret == 1)
            {
                Thread.Sleep(100);
                dm.MoveTo(x, y);
                Thread.Sleep(100);
                dm.LeftClick();
                Thread.Sleep(400);
                dm.MoveTo(10, 10);
                Thread.Sleep(400);
                ret = GetPicCenter("科举_答案.bmp", 0.9, 0, 3, out x, out y);
            }
            if (0 == GetPicCenter(leftWindowStartX, leftWindowStartY, leftWindowEndX, leftWindowEndY, "科举_提示_左括号.bmp", 0.9, 0, 3, out x, out y))
            {
                if (1 == GetPicCenter("科举_提示_答完.bmp", 0.9, 0, 3, out x, out y))
                {
                    return;
                }
                if (1 == FindPic(0, 0, clientW, clientH, "科举_答题.bmp", "111111", 0.9, 0, out x, out y))
                {
                    Thread.Sleep(100);
                    dm.MoveTo(x, y);
                    Thread.Sleep(100);
                    dm.LeftClick();
                    Thread.Sleep(100);
                    goto kj;
                }
            }
            Thread.Sleep(100);
            dm.MoveTo(x, y);
            Thread.Sleep(100);
            dm.LeftClick();
            Thread.Sleep(100);

            ret = GetPicCenter("科举_继续答题.bmp", 0.9, 0, 3, out x, out y);
            while (ret == 0)
            {
                Thread.Sleep(100);
                ret = GetPicCenter("科举_继续答题.bmp", 0.9, 0, 3, out x, out y);
            }
            Thread.Sleep(100);
            dm.MoveTo(x, y);
            Thread.Sleep(100);
            dm.LeftClick();
            Thread.Sleep(100);
            goto kj;
        }
        public void Test()
        {
            ScanArea(new Rectangle(0, 0, clientW, clientH), 50);
        }
        public void ScanArea(Rectangle rect, int space)
        {
            for (int w = 10; w < rect.Width; w = w + space)
            {

                for (int h = 10; h < rect.Height; h = h + space)
                {
                    dm.MoveTo(w, h);
                    Thread.Sleep(100);
                    string cs = dm.GetCursorShape();
                    string log = string.Format("X:{0},Y:{1},CursorShape={2}", w, h, cs);
                    Log(log);
                    Console.WriteLine(log);
                    Thread.Sleep(400);
                }
            }
        }

        #region "旧版本星语"
        public void XY(int index, int dt)
        {

            int x, y;
            string xlPath = "", npcPath = "";
        xyStart:
            switch (dt)
            {
                case 1:
                    xlPath = "自动寻路_明湖新村_邹思.bmp";
                    npcPath = "明湖新村_NPC_邹思.bmp";
                    break;
                case 2:
                    xlPath = "自动寻路_平安城_让叶.bmp";
                    npcPath = "平安城_NPC_让叶.bmp";
                    break;
            }
            CloseNotice();
            if (0 == GetPicCenter(npcPath, 0.9, 0, 1, out x, out y))
            {
                Thread.Sleep(200);
                CloseSubWindows();
                Wayfinding(xlPath, npcPath, 0.9, 0);

                //GetPicCenter("平安城_NPC_让叶.bmp", 0.9, 0, 1, out x, out y);
            }
            Thread.Sleep(showPageTime);

            int ret = 0;
            while (ret == 0)
            {
                if (1 == GetPicCenter("平安城_让叶_提交.bmp", 0.9, 0, 1, out x, out y))
                {
                    Thread.Sleep(100);
                    dm.MoveTo(x, y);
                    Thread.Sleep(100);
                    dm.LeftClick();
                    Thread.Sleep(500);
                    dm.MoveTo(10, 10);
                    Thread.Sleep(100);
                    ret = GetPicCenter("星语_标题_尾.bmp", 0.9, 0, 1, out x, out y);
                    //Thread.Sleep(3000);
                    Thread.Sleep(200);
                }
                else
                {
                    goto xyStart;
                }
            }
            int indexX, indexY;
            indexX = x;
            indexY = y + 7 + (index * 18);//间隔18px
            dm.MoveTo(indexX, indexY);
            Thread.Sleep(200);
            dm.LeftClick();
            Thread.Sleep(200);
            if (1 == GetPicCenter("窗口_选择.bmp", 0.9, 0, 5, out x, out y))
            {
                Thread.Sleep(50);
                dm.MoveTo(x, y);
                Thread.Sleep(100);
                dm.LeftClick();
                Thread.Sleep(100);
                if (1 == GetPicCenter("窗口_确定.bmp", 0.9, 0, 5, out x, out y))
                {
                    Thread.Sleep(50);
                    dm.MoveTo(x, y);
                    Thread.Sleep(100);
                    dm.LeftClick();
                    Thread.Sleep(100);
                    if (0 == GetPicCenter(npcPath, 0.9, 0, 1, out x, out y))
                    {
                        Thread.Sleep(200);
                        CloseNotice();
                        CloseSubWindows();
                        Wayfinding(xlPath, npcPath, 0.9, 0);
                    }
                    Thread.Sleep(showPageTime);

                    while (true)
                    {
                        if (0 == GetPicCenter(npcPath, 0.9, 0, 1, out x, out y))
                        {
                            Thread.Sleep(200);
                            CloseSubWindows();
                            Wayfinding(xlPath, npcPath, 0.9, 0);
                        }
                        Thread.Sleep(showPageTime);
                        Thread.Sleep(50);
                        dm.MoveTo(10, 10);
                        Thread.Sleep(50);
                        if (1 == GetPicCenter("平安城_让叶_领取.bmp", 0.9, 0, 1, out x, out y))
                        {
                            Thread.Sleep(200);
                            dm.MoveTo(x, y);
                            Thread.Sleep(200);
                            dm.LeftClick();
                            Thread.Sleep(200);
                            if (1 == GetPicCenter("星语_提示_完成.bmp", 0.9, 1, 2, out x, out y))
                            {
                                Log("星语完成");
                                break;
                            }
                            if (1 == GetPicCenter("星语_提示_没有提交.bmp", 0.9, 1, 2, out x, out y))
                            {
                                Log("星语,没有提交,重新开始");
                                goto xyStart;
                            }
                        }
                        Thread.Sleep(200);
                        //Thread.Sleep(5000);
                    }
                }
            }

        }
        #endregion
    }
}
