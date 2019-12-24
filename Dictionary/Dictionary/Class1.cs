using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    public class Class1
    {
        public void Main()
        {
            //创建计数，初始值为0 
            int count = 0;
            //创建数据词典 
            IDictionary<string, int> dic1 = new Dictionary<string, int>();
            //单词数组 
            string[] strs = "apler blue hit hit blue".Split(' ');

            //循环数组，统计每个单词的数量 
            for (int i = 0; i < strs.Length; i++)
            {
                if (dic1.TryGetValue(strs[i], out count))
                {
                    dic1[strs[i]] = count + 1;  //存在，在基数上加1 
                }
                else
                {
                    dic1.Add(strs[i], 1);   //不存在，添加一个新键值对 
                }
                //输出统计结果 
                foreach (string key in dic1.Keys)
                {
                    Console.WriteLine(string.Format("这个单词{0}, 共{1}。", key, dic1[key]));
                }
            }
        }
    }
}



