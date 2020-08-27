using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Model.Model
{
    public class ReportsModel
    {
    }

    public class PatientHistory
    {

        public string FROMDATE { get; set; }
        public string TODATE { get; set; }
        public string DOCTORNAME { get; set; }
        public string SPECIALITY { get; set; }
        public string Doctorreport { get; set; }

        public string Visitdate { get; set; }

        public string OrgDisplayAddress { get; set; }
        public string email_address { get; set; }
        public string DMOBILENO { get; set; }
        public string Current_address { get; set; }
        public string PMobileno { get; set; }
        public string PatientName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string BP_systolic { get; set; }
        public string BP_Diastolic { get; set; }
        public string DrugName { get; set; }
        public string Dose_qty { get; set; }
        public string PatientVisitID { get; set; }
        public string OrgID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }
        public string ModifyBy { get; set; }
        public string ModiyDate { get; set; }

        public string P_KEY { get; set; }
    }
}
