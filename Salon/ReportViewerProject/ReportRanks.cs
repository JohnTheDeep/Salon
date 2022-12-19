using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace ReportViewerProject
{
    public partial class ReportRanks : Form
    {
        public int RankId;
        string DateIn, DateOut;
        public ReportRanks(int rankId, string DateIn, string DateOut)
        {
            InitializeComponent(); this.RankId = rankId;
            this.DateIn = DateIn;
            this.DateOut = DateOut;
        }

        private void ReportRanks_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable2". При необходимости она может быть перемещена или удалена.
            SqlConnection conn = new SqlConnection("");
            conn.Open();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT " +
                "STAT.BaseBid,STAT.VirtualAdminBid,\r\n\t" +
                "D.DutyDate,D.CashPerDay,D.NonCashPerDay,D.Total,\r\n\t" +
                "S.ServiceName,\r\n\t" +
                "E.FullName, R.RankName,E.EntryTreshold,E.Bid,E.Paddit,E.Pfictive,E.Phandjob,E.Ppackage,\r\n\t" +
                "J.UserTotal,J.ClientName,J.Cash,J.NonCash,J.Transfer,J.Fictive,J.AdditCash,J.AdditNonCash,J.HandJobCash,j.HandJobNonCash,j.PackageCash,j.PackageNonCash,j.Sertificate,ENR.[Percent] as per, J.Total AS tOtaL2 \r\n\tFROM JournalT J\r\n\tINNER JOIN SalonDbTest.dbo.DutyT D ON D.Id = J.DutyId\r\n\tINNER JOIN SalonDbTest.dbo.ServicesT S ON S.Id = J.Service_Id\r\n\tINNER JOIN SalonDbTest.dbo.EmployeesT E ON E.Id = J.Employee_id\r\n\tINNER JOIN SalonDbTest.dbo.RanksT R ON R.Id = E.Rank_Id\r\n\tINNER JOIN SalonDbTest.dbo.Enrollments ENR ON ENR.EmployeeId = E.Id AND ENR.ServiceId = S.Id\r\n\tINNER JOIN SalonDbTest.dbo.StatisticT " +
            $"STAT ON STAT.Employee_Id = E.Id AND STAT.Duty_Id = D.Id " +
                $"WHERE R.Id = {RankId} AND D.DutyDate BETWEEN '{DateIn}' AND '{DateOut}'", conn);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable1". При необходимости она может быть перемещена или удалена.
            sql.Fill(this.dataSet1.DataTable2);
            conn.Close();
            this.reportViewer1.RefreshReport();
        }
    }
}
