using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ReportViewerProject
{
    public partial class ReportByEmplAndServ2 : Form
    {
        public int EmplId;
        string servType;
        string DateIn, DateOut;
        public ReportByEmplAndServ2(int EmplId, string ServType, string DateIn, string DateOut)
        {
            InitializeComponent();
            this.EmplId = EmplId;
            this.servType = ServType;
            this.DateIn = DateIn;
            this.DateOut = DateOut;
        }

        private void ReportByEmplAndServ2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DataTable4' table. You can move, or remove it, as needed
            SqlConnection conn = new SqlConnection("");
            conn.Open();
            SqlCommand comm = new SqlCommand($"UPDATE DutyT Set newCol = CONVERT(datetime2, DutyDate, 103)", conn);
            comm.ExecuteNonQuery();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT DISTINCT STAT.Salary, STAT.Id, STAT.Total AS UserTotal, Stat.BaseBid, Stat.VirtualAdminBid, D.DutyDate, D.CashPerDay, D.NonCashPerDay, D.Total, E.FullName, R.RankName, E.EntryTreshold, E.Bid, E.Paddit, E.Pfictive, E.Phandjob, E.Ppackage, S.ServiceType " +
                "FROM     StatisticT AS Stat INNER JOIN " +
                "DutyT AS D ON D.Id = Stat.Duty_Id INNER JOIN " +
                "EmployeesT AS E ON E.Id = Stat.Employee_Id INNER JOIN " +
                "RanksT AS R ON R.Id = E.Rank_Id INNER JOIN " +
                "Enrollments AS ENR ON ENR.EmployeeId = E.Id INNER JOIN " +
                "ServicesT AS S ON S.Id = ENR.ServiceId " +
                $"WHERE E.Id = {EmplId} AND S.ServiceType = N'{servType}' AND D.newCol BETWEEN '{DateIn}' AND '{DateOut}' ", conn);
            SqlCommand comm2 = new SqlCommand($"UPDATE AvanciesT Set DateIn2 = CONVERT(datetime2, DateIn, 103)\r\nUPDATE AvanciesT Set DateOut2 = CONVERT(datetime2, DateOut, 103)", conn);
            comm2.ExecuteNonQuery();
            SqlDataAdapter sq2l = new SqlDataAdapter("SELECT Datein,Dateout,Fine,A.Total FROM AvanciesT A  INNER JOIN EmployeesT E ON E.Id = A.Employee_Id " +
               $"WHERE E.Id = {EmplId} AND DateOut2 BETWEEN '{DateIn}' AND '{DateOut}'", conn);
            sq2l.Fill(this.dataSet1.AvanciesT);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable1". При необходимости она может быть перемещена или удалена.
            sql.Fill(this.dataSet1.DataTable4);
            conn.Close();
            this.reportViewer1.RefreshReport();
        }
    }
}
