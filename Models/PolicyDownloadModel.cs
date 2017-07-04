using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainApp
{
    public class PolicyDownloadModel
    {
        public string policyNo { get; set; }
        public string distribution { get; set; }
        public bool compareWithPrevious { get; set; }
        public string status { get; set; }
        public string additional_Comments { get; set; }
        public string alpha { get; set; }
        public string DOB { get; set; }
        public string OlderVersionFileName { get; set; }
        public string NewVersionFileName { get; set; }
        public string ComparisonReportFileName { get; set; }


        public PolicyDownloadModel()
        {

        }
        public PolicyDownloadModel(string policy_no, string distrib, string compWithPrev,string alpha, string DOB,string status, string addnt_comm , string old_pdf_path , string new_pdf_path , string comp_report_path)
        {
            if (policy_no.Length != 13)

            {
                policy_no =  policy_no.PadRight(13, ' ');
            }
                this.policyNo = policy_no;
            this.distribution = distrib;
            this.compareWithPrevious = compWithPrev == "YES" ? true : false;
            this.status = status;
            this.additional_Comments = addnt_comm;
            this.alpha = alpha;
            this.DOB = DOB;
            this.NewVersionFileName = new_pdf_path;
            this.OlderVersionFileName = old_pdf_path;
            this.ComparisonReportFileName = comp_report_path;

            
        }
    }
}
