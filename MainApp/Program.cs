using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadPolicyXML;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.Office.Interop;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using MainApp;
using Models;
using Microsoft.Win32;
using System.Threading;
using DownloadPolicies;
using DownloadXML_Beta;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Initialization
            Utlities util = new Utlities();

            //Moving the Archieve Files
            util.move(@"D:\IllustratedPolicies\", @"D:\IllustratedPolicies\Status Archieve\", "PolicyDownloadReport");
            //NEW
            util.move(@"D:\IllustratedPolicies\NEW\", @"D:\IllustratedPolicies\NEW\Archieve\", null);
            //OLD
            util.move(@"D:\IllustratedPolicies\OLD\", @"D:\IllustratedPolicies\OLD\Archieve\", null);
            //Comparison Logs
            util.move(@"D:\IllustratedPolicies\ComparisonSummaryReport\", @"D:\IllustratedPolicies\ComparisonSummaryReport\Archieve\", null);
            //LOGS
            util.move(@"D:\IllustratedPolicies\", @"D:\IllustratedPolicies\Log Archieve\", "PolicyDownloadLog");

            //Creating the Log File
            util.CreateLog(@"D:\IllustratedPolicies\");
            util.WriteLog("`````````````````````````PROCESS STARTED`````````````````````````");
            util.WriteLog("Batch Download Started at " + DateTime.Now.ToString());

            string path_1 = @"D:\Arvind\Illustration\RegressionTool\SourceSheetforBatchDowload\PolicyDetails_for_BatchDownload_V_0.1.xlsx";
            string path_2 = @"D:\IllustratedPolicies\PolicyDownloadReport_" + DateTime.Now.ToString().Replace('/', '_').Replace(':', ' ').Replace(" ", "") + "." + "xlsx";
            ConfigModel.ExcelReport_path = path_2;
            util.Copy(path_1, path_2);

            util.WriteLog("Input file Copied to Status Location at " + DateTime.Now.ToString());

            ConfigModel config = util.Getconfig();
            BrighthousePolicyDownload policy = new BrighthousePolicyDownload();
            IllustratePDF illustrate = new IllustratePDF();


           

            util.WriteLog("Previous Log files and report files moved to their respective Archieve Folders at  " + DateTime.Now.ToString());

            try
            {

                //Installing Old Version 
                util.winlegacy_uninstallation();
                util.WriteLog("Exisiting Version of WinLegacy Unistalled successfully at " + DateTime.Now.ToString());
                Thread.Sleep(5000);
                util.winlegacy_installation(config.prev_Winlegacy_installer_path);
                util.WriteLog("OLD/PREVIOUS version of WinLegacy installed successfully at " + DateTime.Now.ToString());
                Thread.Sleep(3000);
                ConfigModel.iscurrentRun = false;


                Playback.Initialize();
                util.WriteLog("Policy download started  ( OLD/PREVIOUS version ) at " + DateTime.Now.ToString());
                policy.BrighthousePolicyDownload_method();
                util.WriteLog("Policy download ended  ( OLD/PREVIOUS version )  at " + DateTime.Now.ToString());
                Playback.Cleanup();

                Playback.Initialize();
                util.WriteLog("Policy Illustration and Save ( OLD/PREVIOUS version ) started  at " + DateTime.Now.ToString());
                illustrate.IllustratePDF_method();
                util.WriteLog("Policy Illustration and Save ( OLD/PREVIOUS version ) ended  at " + DateTime.Now.ToString());
                Playback.Cleanup();


                //Installing NEW Version 
                util.winlegacy_uninstallation();
                util.WriteLog("PREVIOUS Version of WinLegacy Unistalled successfully at " + DateTime.Now.ToString());
                Thread.Sleep(5000);
                util.winlegacy_installation(config.curr_Winlegacy_installer_path);
                util.WriteLog("NEW version of WinLegacy installed successfully at " + DateTime.Now.ToString());
                Thread.Sleep(3000);

                ConfigModel.iscurrentRun = true;

                Playback.Initialize();
                util.WriteLog("Policy download started  (NEW version) at " + DateTime.Now.ToString());
                policy.BrighthousePolicyDownload_method();
                util.WriteLog("Policy download ended  (NEW version) at " + DateTime.Now.ToString());
                Playback.Cleanup();

                Playback.Initialize();
                util.WriteLog("Policy Illustration and Save ( NEW version ) started  at " + DateTime.Now.ToString());
                illustrate.IllustratePDF_method();
                util.WriteLog("Policy Illustration and Save ( NEW version ) ended  at " + DateTime.Now.ToString());
                Playback.Cleanup();

                util.WriteLog("Policy compare started  at " + DateTime.Now.ToString());
                util.ComparePDF();
                util.WriteLog("Policy compare ended  at " + DateTime.Now.ToString());
            }
            catch (Exception e)
            {
                util.WriteLog("ALERT!! Execution Stopped due to a runtime error. Here is the Error Message :   " + e.Message + " ..... Time Stamp - " + DateTime.Now.ToString());

                util.WriteLog("`````````````````````````PROCESS STARTED`````````````````````````");
            }






        }


    }
}
