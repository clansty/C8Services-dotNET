using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using ServiceStack.Redis;
using Spire.Doc;

namespace QYPlugin
{
    public static class PluginInfo //插件的相关信息
    {
        public const string name = "c8bot"; //名称
        public const string appid = "c8bot"; //标识
        public const string version = "1.0"; //版本
        public const int versionId = 1; //版本ID
        public const string author = "凌莞"; //作者
        public const string description = "凌莞优化重制版 C# SDK"; // 简介
    }

    public static class QYEvents
    {
        private static System.Timers.Timer t;

        public static void FriendMsg(FriendMsgArgs e)
        {
            // 这里处理好友消息
            //e.Reply("你发了好友消息 " + e.Msg);
        }

        public static void GroupTmpMsg(GroupTmpMsgArgs e)
        {
            // 这里处理群临时消息
            //e.Reply("你发了群临时消息 " + e.Msg);
        }

        public static void GroupMsg(GroupMsgArgs e)
        {
            // 处理群消息
            //e.Reply(e.Msg, true);
            //e.Recall(); //撤回
        }

        public static void GroupAdminAdded(GroupAdminChangedArgs e)
        {
            Robot.Log($"{e.Group} 的 {e.QQ} 被设为管理员");
        }

        public static void GroupAdminRemoved(GroupAdminChangedArgs e)
        {
            Robot.Log($"{e.Group} 的 {e.QQ} 被取消管理员");
        }

        public static void RequestAddFriend(RequestAddFriendArgs e)
        {
            //别人加你好友

            //e.Accept(e.Msg);//同意
            //e.Reject("你不好看");//拒绝
        }

        public static void RequestAddGroup(RequestGroupArgs e)
        {
            //别人申请加入你管理的群

            //e.Accept();
        }

        public static void RequestInviteGroup(RequestGroupArgs e)
        {
            //别人邀请你加群
        }

        //好友申请，加群申请，群文件等事件尚未完成，敬请期待
        public static void Start()
        {
            t = new System.Timers.Timer(1000 * 60 * 10);
            t.Elapsed += (_, __) => { SendEng(); };
            t.AutoReset = true;
            t.Enabled = true;
        }

        public static void SendEng()
        {
            var d = DateTime.Now;
            var m = d.Month - 1;
            var month = "err";
            switch (m)
            {
                case 0:
                    month = "Jan";
                    break;
                case 1:
                    month = "Feb";
                    break;
                case 2:
                    month = "Mar";
                    break;
                case 3:
                    month = "Apr";
                    break;
                case 4:
                    month = "May";
                    break;
                case 5:
                    month = "Jun";
                    break;
                case 6:
                    month = "Jul";
                    break;
                case 7:
                    month = "Aug";
                    break;
                case 8:
                    month = "Sept";
                    break;
                case 9:
                    month = "Oct";
                    break;
                case 10:
                    month = "Nov";
                    break;
                case 11:
                    month = "Dec";
                    break;
            }

            var dt = $"{d.Month}.{d.Day}";
            var loc = @"C:\Users\baban\Desktop\英语\" + month + @"\" + dt;
            if (Directory.Exists(loc))
            {
                if (File.Exists(loc + @"\uploaded"))
                {
                    return;
                }

                var processList = System.Diagnostics.Process.GetProcesses();
                foreach (var process in processList)
                {
                    if (process.ProcessName.ToUpper().StartsWith("WINWORD"))
                    {
                        return;
                    }
                }

                var z = new Process();
                z.StartInfo.FileName = @"C:\Program Files\7-Zip\7z.exe";
                z.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                z.StartInfo.Arguments = "a " + loc + ".7z " + loc;
                z.Start();
                z.WaitForExit();
                z.Close();
                z.Dispose();

                File.Create(loc + @"\uploaded").Close();
                Robot.Group.UploadFile("117076933", loc + ".7z");
                
                Document doc = new Document();
                doc.LoadFromFile(loc + @"\homework.docx");
                string s = doc.GetText().Trim('\n', '\t', ' ');
                doc.Dispose();
                Robot.Send.Group("117076933", "英语作业：\n" + s);
                using (var rds = new RedisClient("101.132.178.136", 6379, "qVAo9C1tCbD2PEiR"))
                {
                    var date = DateTime.Now.ToShortDateString();
                    rds.SetEntryInHash("zy" + date, "e", s);
                }
    
                if (File.Exists(loc + @"\quiz.docx"))
                    using (var rds = new RedisClient("101.132.178.136", 6379, "qVAo9C1tCbD2PEiR"))
                    {
                        rds.SetEntryInHash("loc", "quiz", loc + @"\quiz.docx");
                    }
            }
        }
    }
}