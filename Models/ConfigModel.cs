using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class ConfigModel
    {
        public string policyIllustratedPath_New { get; set; }
        public string policyIllustratedPath_Old { get; set; }
        public string policyCompare_with_Prev_and_Current_Path { get; set; }

        public string Brighthouse_username { get; set; }
        public string Brighthouse_password { get; set; }

        public string GenAm_username { get; set; }
        public string GenAm_password { get; set; }

        public string MLFS_username { get; set; }
        public string MLFS_password { get; set; }

        public string NEF_username { get; set; }
        public string NEF_password { get; set; }

        public string prev_Winlegacy_installer_path { get; set; }
        public string curr_Winlegacy_installer_path { get; set; }

        public static bool iscurrentRun { get; set; }

        public static string  log_path { get; set; }
        public static string ExcelReport_path { get; set; }

    }
}
