using MainApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Management;
using Microsoft.Win32;
using System.IO;

namespace Models
{
    public class Utlities
    {


        public bool SaveLog(List<PolicyDownloadModel> Policies)
        {
            Excel.Application excel = new Excel.Application();

            Excel.Workbook workbook = excel.Workbooks.Open(ConfigModel.ExcelReport_path, ReadOnly: false, Editable: true);

            Excel.Worksheet worksheet = workbook.Worksheets.Item["BatchPolicyDownload"] as Excel.Worksheet;
            if (worksheet == null)
                return false;

            foreach (PolicyDownloadModel policy in Policies)
            {

                Excel.Range range = worksheet.Columns.Find(policy.policyNo.Trim());
                while (range.Columns[1].Cells.Value != policy.policyNo.Trim())
                {
                    range = worksheet.Columns.Find(policy.policyNo.Trim(), range.Cells);
                }
                range.Columns[6].Cells.Value = policy.status;
                range.Columns[7].Cells.Value = policy.additional_Comments;
                range.Columns[8].Cells.Value = policy.OlderVersionFileName;
                range.Columns[9].Cells.Value = policy.NewVersionFileName;
                range.Columns[10].Cells.Value = policy.ComparisonReportFileName;

            }

            excel.Application.ActiveWorkbook.Save();
            excel.Application.Quit();
            excel.Quit();

            return true;
        }

        public ConfigModel Getconfig()
        {
            ConfigModel config = new ConfigModel();

            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;
                string inputExcel_Location;

                inputExcel_Location = ConfigModel.ExcelReport_path;


                xlApp = new Excel.Application();

                xlWorkBook = xlApp.Workbooks.Open(inputExcel_Location, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = xlWorkBook.Worksheets.Item["CONFIG"] as Excel.Worksheet;

                range = xlWorkSheet.UsedRange;

                config.policyIllustratedPath_New = Convert.ToString((range.Cells[1, 2] as Excel.Range).Value2);
                config.policyIllustratedPath_Old = Convert.ToString((range.Cells[2, 2] as Excel.Range).Value2);
                config.policyCompare_with_Prev_and_Current_Path = Convert.ToString((range.Cells[3, 2] as Excel.Range).Value2);

                config.Brighthouse_username = Convert.ToString((range.Cells[5, 2] as Excel.Range).Value2);
                config.Brighthouse_password = Convert.ToString((range.Cells[6, 2] as Excel.Range).Value2);

                config.GenAm_username = Convert.ToString((range.Cells[8, 2] as Excel.Range).Value2);
                config.GenAm_password = Convert.ToString((range.Cells[9, 2] as Excel.Range).Value2);

                config.NEF_username = Convert.ToString((range.Cells[11, 2] as Excel.Range).Value2);
                config.NEF_password = Convert.ToString((range.Cells[12, 2] as Excel.Range).Value2);

                config.MLFS_username = Convert.ToString((range.Cells[14, 2] as Excel.Range).Value2);
                config.MLFS_password = Convert.ToString((range.Cells[15, 2] as Excel.Range).Value2);

                config.curr_Winlegacy_installer_path = Convert.ToString((range.Cells[18, 2] as Excel.Range).Value2);
                config.prev_Winlegacy_installer_path = Convert.ToString((range.Cells[17, 2] as Excel.Range).Value2);


                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

            }
            catch (Exception e)
            {

            }


            return config;

        }

        public bool UninstallProgram(string ProgramName)
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher(
                  "SELECT * FROM Win32_Product WHERE Name = '" + ProgramName + "'");
                foreach (ManagementObject mo in mos.Get())
                {
                    try
                    {
                        if (mo["Name"].ToString() == ProgramName)
                        {
                            object hr = mo.InvokeMethod("Uninstall", null);
                            return (bool)hr;
                        }
                    }
                    catch (Exception ex)
                    {
                        //this program may not have a name property, so an exception will be thrown
                    }
                }

                //was not found...
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<PolicyDownloadModel> fetchPolicyNo_FromInput()
        {
            List<PolicyDownloadModel> Policies = new List<PolicyDownloadModel>();

            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;
                string inputExcel_Location;
                int rCnt;
                int rw = 0;
                int cl = 0;
                inputExcel_Location = ConfigModel.ExcelReport_path;
                xlApp = new Excel.Application();

                xlWorkBook = xlApp.Workbooks.Open(inputExcel_Location, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = xlWorkBook.Worksheets.Item["BatchPolicyDownload"] as Excel.Worksheet;

                range = xlWorkSheet.UsedRange;
                rw = range.Rows.Count;
                cl = range.Columns.Count;

                for (rCnt = 2; rCnt <= rw; rCnt++)

                {
                    if (Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Value2) != null)
                    {
                        string tmp_policy_number = "";
                        string tmp_distribution = "";
                        string tmp_comparewithPrev = "";
                        string tmp_apha = "";
                        string tmp_DOB = "";
                        string tmp_status = "";
                        string tmp_addtn_comm = "";
                        string tmp_old_path = "";
                        string tmp_new_path = "";
                        string tmp_compare_report_path = "";


                        tmp_policy_number = Convert.ToString((range.Cells[rCnt, 1] as Excel.Range).Value2);
                        tmp_apha = Convert.ToString((range.Cells[rCnt, 2] as Excel.Range).Value2);
                        tmp_DOB = Convert.ToString((range.Cells[rCnt, 3] as Excel.Range).Value2);
                        tmp_distribution = Convert.ToString((range.Cells[rCnt, 4] as Excel.Range).Value2);
                        tmp_comparewithPrev = Convert.ToString((range.Cells[rCnt, 5] as Excel.Range).Value2);

                        tmp_addtn_comm = Convert.ToString((range.Cells[rCnt, 7] as Excel.Range).Value2);
                        tmp_status = Convert.ToString((range.Cells[rCnt, 6] as Excel.Range).Value2);
                        tmp_old_path = Convert.ToString((range.Cells[rCnt, 8] as Excel.Range).Value2);
                        tmp_new_path = Convert.ToString((range.Cells[rCnt, 9] as Excel.Range).Value2);
                        tmp_compare_report_path = Convert.ToString((range.Cells[rCnt, 10] as Excel.Range).Value2);



                        PolicyDownloadModel policy = new PolicyDownloadModel(tmp_policy_number, tmp_distribution, tmp_comparewithPrev, tmp_apha, tmp_DOB, tmp_status, tmp_addtn_comm, tmp_old_path, tmp_new_path, tmp_compare_report_path);
                        Policies.Add(policy);
                    }

                }

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);

            }
            catch (Exception e)
            {

            }

            return Policies;
        }
        public void ComparePDF()
        {
            List<PolicyDownloadModel> policies = new List<PolicyDownloadModel>();
            policies = fetchPolicyNo_FromInput();
            ConfigModel config = new ConfigModel();
            config = Getconfig();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            foreach (PolicyDownloadModel policy in policies)
            {

                if (policy.NewVersionFileName != null && policy.OlderVersionFileName != null)
                {

                    startInfo.FileName = "cmd.exe";

                    //build the path 
                    string cmd = "/C diffpdfc -Hc -r ";
                    string comparisonReportname = policy.policyNo.Trim() + "_ComparisonReport_" + DateTime.Now.ToString().Replace('/', ' ').Replace(':', ' ').Replace(" ", "") + ".pdf";
                    cmd = cmd + config.policyCompare_with_Prev_and_Current_Path + comparisonReportname + " " + config.policyIllustratedPath_New + policy.NewVersionFileName + " " + config.policyIllustratedPath_Old + policy.OlderVersionFileName;


                    //startInfo.Arguments = "/C diffpdfc -Hc -r D:\\IllustratedPolicies\\report.pdf D:\\IllustratedPolicies\\11.pdf D:\\IllustratedPolicies\\22.pdf";
                    policy.ComparisonReportFileName = comparisonReportname;


                    startInfo.Arguments = cmd;
                    p.StartInfo = startInfo;
                    startInfo.Verb = "runas";
                    p.Start();
                    p.WaitForExit();
                }

            }
            SaveLog(policies);
        }
        public void winlegacy_uninstallation()
        {
            RegistryKey regkey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall", false);
            string s1;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            foreach (String s in regkey.GetSubKeyNames())

            {
                RegistryKey key = regkey.OpenSubKey(s);
                try
                {
                    s1 = key.GetValue("DisplayName").ToString();

                    if (s1 == "WinLegacy")
                    {
                        string uninstall_string = key.GetValue("QuietUninstallString").ToString();


                        //actual code
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c " + uninstall_string;
                        process.StartInfo = startInfo;
                        startInfo.Verb = "runas";
                        process.Start();
                        process.WaitForExit();
                        break;
                    }

                }
                catch (Exception e)
                {
                    continue;
                }



            }

        }

        public void winlegacy_installation(string exe_path)
        {

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/c " + exe_path + " /q";
            process.StartInfo = startInfo;
            startInfo.Verb = "runas";
            process.Start();
            process.WaitForExit();

        }

        public bool CreateLog(string file_path)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = file_path;
            logFilePath = logFilePath + "PolicyDownloadLog-" + DateTime.Now.ToString().Replace('/', '_').Replace(':', ' ').Replace(" ", "") + "." + "txt";
            ConfigModel.log_path = logFilePath;
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
                
            }
            fileStream.Close();
            
            return true;
        }


        public  void Copy(string source_path, string Dest_path)
        {
            File.Copy(source_path, Dest_path, true);
        }
        public void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;            

            fileStream = new FileStream(ConfigModel.log_path, FileMode.Append);
         
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }


        public  void move(string source, string destination, string fileName)
        {
            DirectoryInfo targetName = new DirectoryInfo(destination);
            if (!Directory.Exists(targetName.FullName))
            {
                Directory.CreateDirectory(targetName.FullName);
            }
            string FolderPath = source;
            DirectoryInfo dir = new DirectoryInfo(FolderPath);
            if (fileName != null)
            {
                FileInfo[] files = dir.GetFiles(fileName + "*", SearchOption.TopDirectoryOnly);
                if (files.Length != 0)
                {
                    foreach (var item in files)
                    {
                        File.Move(FolderPath + item.Name, targetName + item.Name);
                    }
                }                    
            }
           
            else
            {
                FileInfo[] Allfiles = dir.GetFiles();
                foreach (var file in Allfiles)
                {
                    File.Move(FolderPath + file.Name, targetName + file.Name);
                }
            }
        }
    }
}
