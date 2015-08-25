using System;
using System.Collections.Generic;
using System.Text;

namespace ldj
{
    /// <summary>
    /// 接口：点间连线
    /// </summary>
    public interface ILine
    {
        /// <summary>
        /// 开始节点ID
        /// </summary>
        string SrcId { get; set; }
        /// <summary>
        /// 结束节点ID
        /// </summary>
        string DstId { get; set; }
        /// <summary>
        /// 连线的权重。必需大于0
        /// </summary>
        int Weight { get; set; }
    }
    /// <summary>
    /// 测试类：点间连线
    /// </summary>
    public class TestLine : ILine
    {
        private string _src_id;
        private string _dst_id;
        private int _weight;
        public TestLine(string src_id, string dst_id, int weight)
        {
            _src_id = src_id;
            _dst_id = dst_id;
            _weight = weight;
        }
        /// <summary>
        /// 出发点
        /// </summary>
        public string SrcId
        {
            get { return _src_id; }
            set { _src_id = value; }
        }
        /// <summary>
        /// 目标点
        /// </summary>
        public string DstId
        {
            get { return _dst_id; }
            set { _dst_id = value; }
        }
        /// <summary>
        /// 权重
        /// </summary>
        public int Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        /// <summary>
        /// 转换为字符串
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} - {1}", _src_id, _dst_id);
        }
    }
    /// <summary>
    /// 实现点间最小权重路径算法
    /// </summary>
    public class RoadFinder
    {
        /// <summary>
        /// 已知路线的查找表。key：src_id.dst_id, value: ILine
        /// </summary>
        private Dictionary<string, ILine> dct_lines = new Dictionary<string, ILine>();
        /// <summary>
        /// 邻接节点
        /// </summary>
        private Dictionary<string, List<string>> dct_relate = new Dictionary<string, List<string>>();
        /// <summary>
        /// 查找两点间的最短路径（路径权重和最小）
        /// </summary>
        /// <param name="src_id">出发点ID</param>
        /// <param name="dst_id">目标点ID</param>
        /// <param name="lines">已知的所有连接线</param>
        /// <returns>最短路径的连接线</returns>
        public bool FindRoad(string src_id, string dst_id, IEnumerable<ILine> enu_lines, out List<ILine> lst_result)
        {
            //初始化缓存
            this.dct_lines.Clear();
            this.dct_relate.Clear();
            foreach (ILine item in enu_lines)
            {
                this.dct_lines[string.Format("{0}.{1}", item.SrcId, item.DstId)] = item;
                ILine item1 = new TestLine(item.DstId, item.SrcId, item.Weight); //反向
                this.dct_lines[string.Format("{1}.{0}", item.SrcId, item.DstId)] = item1;
                _PutRelatingPoint(item.SrcId, item.DstId);
                _PutRelatingPoint(item.DstId, item.SrcId);
            }
            List<string> lst_visited = new List<string>();
            return _Find(src_id, dst_id, lst_visited, out lst_result);
        }
        /// <summary>
        /// 添加关联节点
        /// </summary>
        /// <param name="point_id">起始点ID</param>
        /// <param name="related_id">关联点ID</param>
        void _PutRelatingPoint(string point_id, string related_id)
        {
            List<string> lst;
            if (this.dct_relate.TryGetValue(point_id, out lst))
            {
                lst.Add(related_id);
            }
            else
            {
                lst = new List<string>();
                lst.Add(related_id);
                this.dct_relate[point_id] = lst;
            }
        }
        /// <summary>
        /// 递归查找点间最小权重的路径
        /// </summary>
        /// <param name="src_id">出发点ID</param>
        /// <param name="dst_id">目标点ID</param>
        /// <param name="lst_visited">已访问的节点列表</param>
        /// <param name="enu_lines">返回连线</param>
        /// <returns>如果找到，返回true</returns>
        bool _Find(string src_id, string dst_id, List<string> lst_visited, out List<ILine> lst_result)
        {
            lst_result = null;
            lst_visited.Add(src_id);
            //记录最小权重
            int weight = -1;
            ILine line;
            if (_HasDirectLine(src_id, dst_id, out line))
            {
                //存在直接连线
                lst_result = new List<ILine>();
                lst_result.Add(line);
                weight = line.Weight;
            }
            //递归遍历邻接点是否存在最短路径
            {
                int count = lst_visited.Count;
                bool found_relate = false;
                List<string> lst_relate;
                if (this.dct_relate.TryGetValue(src_id, out lst_relate))
                {
                    foreach (string point_id in lst_relate)
                    {
                        if (lst_visited.Contains(point_id))
                            continue;
                        List<ILine> lst_temp;
                        if (_Find(point_id, dst_id, lst_visited, out lst_temp))
                        {
                            lst_temp.Insert(0, this.dct_lines[string.Format("{0}.{1}", src_id, point_id)]);
                            int w = _GetWeight(lst_temp);
                            if (weight == -1 || w < weight)
                            {
                                weight = w;
                                lst_result = lst_temp;
                                found_relate = true;
                            }
                        }
                    }
                }
                lst_visited.RemoveRange(count, lst_visited.Count - count);
                if (found_relate)
                    return true;
            }
            return lst_result != null;
        }
        /// <summary>
        /// 判断两点间是否存在直接连线
        /// </summary>
        /// <param name="src_id">出发点ID</param>
        /// <param name="dst_id">目标点ID</param>
        /// <param name="line">连接线</param>
        /// <returns>如果存在直接连线，返回true</returns>
        bool _HasDirectLine(string src_id, string dst_id, out ILine line)
        {
            return this.dct_lines.TryGetValue(string.Format("{0}.{1}", src_id, dst_id), out line);
        }
        /// <summary>
        /// 计算路径的权重和
        /// </summary>
        /// <param name="enu_lines">连接线</param>
        /// <returns>权重和</returns>
        int _GetWeight(IEnumerable<ILine> enu_lines)
        {
            int total = 0;
            foreach (ILine item in enu_lines)
                total += item.Weight;
            return total;
        }
        /// <summary>
        /// 测试方法
        /// </summary>
        public static void Test()
        {
            List<ILine> lst_lines = new List<ILine>();
            //A - B
            lst_lines.Add(new TestLine("京师", "太子坡", 1));
            //B - C
            lst_lines.Add(new TestLine("京师", "蓬莱", 1));
            //C - D
            lst_lines.Add(new TestLine("蓬莱", "长白山", 1));
            lst_lines.Add(new TestLine("长白山", "神龙岛", 1));
            lst_lines.Add(new TestLine("神龙岛", "泰山", 1));
            lst_lines.Add(new TestLine("泰山", "百花谷", 1));
            lst_lines.Add(new TestLine("太子坡", "五台山", 1));
            lst_lines.Add(new TestLine("太子坡", "嘉峪关", 1));
            lst_lines.Add(new TestLine("嘉峪关", "木兰草原", 1));
            lst_lines.Add(new TestLine("木兰草原", "辽西", 1));
            lst_lines.Add(new TestLine("木兰草原", "长白山", 1));
            lst_lines.Add(new TestLine("嘉峪关", "华山", 1));
            lst_lines.Add(new TestLine("五台山", "嵩山", 1));
            lst_lines.Add(new TestLine("蓬莱", "王屋山", 1));
            lst_lines.Add(new TestLine("王屋山", "百花谷", 1));
            lst_lines.Add(new TestLine("华山", "玉龙雪山", 1));
            lst_lines.Add(new TestLine("玉龙雪山", "丽江", 1));
            lst_lines.Add(new TestLine("丽江", "昆仑山口", 1));
            lst_lines.Add(new TestLine("昆仑山口", "天池", 1));
            lst_lines.Add(new TestLine("玉龙雪山", "嵩山", 1));
            lst_lines.Add(new TestLine("丽江", "南岭", 1));
            lst_lines.Add(new TestLine("南岭", "程海", 1));
            lst_lines.Add(new TestLine("程海", "昆明", 1));
            lst_lines.Add(new TestLine("嵩山", "昆明", 1));
            lst_lines.Add(new TestLine("程海", "哀牢山", 1));
            lst_lines.Add(new TestLine("哀牢山", "白龙潭", 1));
            lst_lines.Add(new TestLine("哀牢山", "黑龙潭", 1));
            lst_lines.Add(new TestLine("白龙潭", "扬州", 1));
            lst_lines.Add(new TestLine("黑龙潭", "扬州", 1));
            lst_lines.Add(new TestLine("白龙潭", "隐龙江", 1));
            lst_lines.Add(new TestLine("黑龙潭", "隐龙江", 1));
            lst_lines.Add(new TestLine("隐龙江", "武夷山", 1));
            lst_lines.Add(new TestLine("武夷山", "南岭", 1));
            lst_lines.Add(new TestLine("隐龙江", "龙虎山", 1));
            lst_lines.Add(new TestLine("龙虎山", "泰山", 1));
            lst_lines.Add(new TestLine("百花谷", "扬州", 1));
            lst_lines.Add(new TestLine("百花谷", "古域丛林", 1));
            lst_lines.Add(new TestLine("古域丛林", "古域海底", 1));
            lst_lines.Add(new TestLine("古域海底", "古域矿洞", 1));
            lst_lines.Add(new TestLine("古域矿洞", "古域东宫", 1));
            lst_lines.Add(new TestLine("古域东宫", "古域西宫", 1));
            //B - D
            //lst_lines.Add(new TestLine("B", "D", 1));
            List<ILine> lst_result;
            RoadFinder finder = new RoadFinder();
            if (finder.FindRoad("蓬莱", "程海", lst_lines, out lst_result))
            {
                foreach (ILine line in lst_result)
                    Console.WriteLine(line);
            }
        }
    }
}
