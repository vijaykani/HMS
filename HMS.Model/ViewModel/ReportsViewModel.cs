using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Model.Model;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data;
using HMS.DAO;
using HMS.UTILITY;
using System.Web;

namespace HMS.Model.ViewModel
{
   public class ReportsViewModel
    {
        #region Properties
        public List<PatientHistory> lipatienthistory { get; set; }
        #endregion

        #region PatientHistory

        public static List<PatientHistory> Patienthistory(PatientHistory PatientHistory)
        {
            DataValue dv = new DataValue();

            dv.Add("@FROMDATE", PatientHistory.FROMDATE, EnumCommand.DataType.Varchar);
            dv.Add("@TODATE", PatientHistory.TODATE, EnumCommand.DataType.Varchar);
            dv.Add("@OrgID", PatientHistory.OrgID, EnumCommand.DataType.Varchar);
            dv.Add("@P_KEY", PatientHistory.P_KEY, EnumCommand.DataType.Varchar);
            var Patienthistory = (List<PatientHistory>)SQLHelper.FetchData<PatientHistory>(Common.Queries.SP_PatientHistory, EnumCommand.DataSource.list, dv).DataSource.Data;
            return Patienthistory;
        }
        #endregion
    }
}
