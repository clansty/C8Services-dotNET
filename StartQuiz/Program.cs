using System;
using System.Diagnostics;
using ServiceStack.Redis;

namespace StartQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            string l;
            using (RedisClient rds = new RedisClient("101.132.178.136"))
            {
                l = rds.GetValueFromHash("loc", "quiz");
            }

            Process p = new Process();
            p.StartInfo.FileName = @"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE";
            p.StartInfo.Arguments = l;
            p.Start();
        }
    }
}