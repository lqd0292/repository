using System;
using System.Collections.Generic;
using System.Linq;
using CDS000.Common;

namespace Properties
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var totalDays = 0;  // 所有人员的全部天数
            var now = DateTime.Now;
            foreach (var item in PersonRepository.InitialPersonCollection())
            {
                totalDays = totalDays + Math.Abs(((TimeSpan)(now - item.Birthday)).Days);
            }

            var avgTotaldays = totalDays / PersonRepository.InitialPersonCollection().Count();
            var avgYears = avgTotaldays / 365;
            var avgDays = avgTotaldays - avgYears * 365;
            Console.WriteLine("平均年龄：" + avgYears + "周岁" + " - " + avgDays + "天");
            Console.ReadKey();



            NameCount(PersonRepository.InitialPersonCollection());

        }

        public static void NameCount(List<Person> people)
        {

            var v = from i in people
                    where !i.Name.Contains("欧阳")
                    group i by i.Name.Substring(0, 1) into c
                    select new { c.Key, cc = c.Count() };
            var s = from i in people
                    where i.Name.Contains("欧阳")
                    group i by i.Name.Substring(0, 2) into c
                    select new { c.Key, cc = c.Count() };
            foreach (var item in v)
            {
                Console.WriteLine("姓氏：{0}   {1}", item.Key, item.cc);
            }
            foreach (var item in s)
            {
                Console.WriteLine("姓氏：{0}   {1}", item.Key, item.cc);
            }
        }
    }
}
