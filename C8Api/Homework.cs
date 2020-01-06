using System;
using ServiceStack.Redis;

namespace C8Api
{
    public class Homework
    {
        public Homework()
        {
            using (var rds=new RedisClient("101.132.178.136", 6379, "qVAo9C1tCbD2PEiR"))
            {
                var date = DateTime.Now.ToShortDateString();
                C = rds.GetValueFromHash("zy" + date, "c");
                M = rds.GetValueFromHash("zy" + date, "m");
                E = rds.GetValueFromHash("zy" + date, "e");
                P = rds.GetValueFromHash("zy" + date, "p");
                B = rds.GetValueFromHash("zy" + date, "b");
            }
        }

        public override string ToString()
        {
            var a = "语文：\n";
                a += C;
                a += "\n";
                a += "数学：\n";
                a += M;
                a += "\n";
                a += "英语：\n";
                a += E;
                a += "\n";
                a += "物理：\n";
                a += P;
                a += "\n";
                a += "生物：\n";
                a += B;
                return a;
        }

        

        public string B { get; }

        public string P { get; }

        public string E { get; }

        public string M { get; }

        public string C { get; }
    }
}