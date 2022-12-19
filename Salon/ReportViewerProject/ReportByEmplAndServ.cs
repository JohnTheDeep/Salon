using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.AxHost;
using System.Reflection;
using System.Web.Services.Description;
using System.Windows.Controls.Primitives;

namespace ReportViewerProject
{
    public partial class ReportByEmplAndServ : Form
    {
        public int EmplId;
        string servType;
        string DateIn, DateOut;
        public ReportByEmplAndServ(int EmplId, string ServType, string DateIn, string DateOut)
        {
            InitializeComponent();
            this.EmplId = EmplId;
            this.servType = ServType;
            this.DateIn = DateIn;
            this.DateOut = DateOut;
        }

        private void ReportByEmplAndServ_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DataTable5' table. You can move, or remove it, as needed.

            SqlConnection conn = new SqlConnection("Dont look");
            conn.Open();
            SqlCommand comm = new SqlCommand($"UPDATE DutyT Set newCol = CONVERT(datetime2, DutyDate, 103)", conn) ;
            comm.ExecuteNonQuery();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT  STAT.Salary,STAT.BaseBid, STAT.VirtualAdminBid, D.DutyDate, D.CashPerDay, D.NonCashPerDay, D.Total, S.ServiceName, E.FullName, R.RankName, E.EntryTreshold, E.Bid, E.Paddit, E.Pfictive, E.Phandjob, E.Ppackage, J.UserTotal, J.ClientName, " +
                "J.Cash, J.NonCash, J.Transfer, J.Fictive, J.AdditCash, J.AdditNonCash, J.HandJobCash, J.HandJobNonCash, J.PackageCash, J.PackageNonCash, J.Sertificate, ENR.[Percent] AS per, J.Package AS PACK, S.ServiceType " +
                "FROM     JournalT AS J " +

                "INNER JOIN DutyT AS D ON D.Id = J.DutyId " +

                "INNER JOIN ServicesT AS S ON S.Id = J.Service_Id " +

                "INNER JOIN EmployeesT AS E ON E.Id = J.Employee_id " +

                "INNER JOIN RanksT AS R ON R.Id = E.Rank_Id " +

                "INNER JOIN Enrollments AS ENR ON ENR.EmployeeId = E.Id AND ENR.ServiceId = S.Id " +
                 
                "INNER JOIN  StatisticT AS STAT ON STAT.Employee_Id = E.Id AND STAT.Duty_Id = D.Id " +
                $"WHERE E.Id = { EmplId } AND S.ServiceType = N'{servType}' AND D.newCol BETWEEN '{DateIn}' AND '{DateOut}' ", conn);
            SqlCommand comm2 = new SqlCommand($"UPDATE AvanciesT Set DateIn2 = CONVERT(datetime2, DateIn, 103)\r\nUPDATE AvanciesT Set DateOut2 = CONVERT(datetime2, DateOut, 103)",conn);
            comm2.ExecuteNonQuery();
            SqlDataAdapter sq2l = new SqlDataAdapter("SELECT Datein,Dateout,Fine,Total FROM AvanciesT A INNER JOIN EmployeesT E ON E.Id = A.Employee_Id " +
               $"WHERE E.Id = {EmplId} AND DateOut2 BETWEEN '{DateIn}' AND '{DateOut}'", conn);
            sq2l.Fill(this.dataSet1.AvanciesT);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable1". При необходимости она может быть перемещена или удалена.
            sql.Fill(this.dataSet1.DataTable1);
            SqlDataAdapter sql3 = new SqlDataAdapter($"SELECT T.Id, T.Duty_Id, T.Employee_Id, T.IsAdmin, T.Total, T.IsVirtualAdmin, T.isArrivedVirtualAdminBid, T.BaseBid, " +
                $"T.VirtualAdminBid, T.Salary, D.Id AS Expr1, D.DutyDate, D.Salon_Id, D.User_Id, D.IsVirtualAdmin AS Expr2, D.CashPerDay," +
                $"D.NonCashPerDay, D.TransfersPerDay, D.Total AS Expr3, D.TotalSertificates, D.IsArrived, D.Taken, D.Income, D.newcol " +
                $"FROM StatisticT AS T INNER JOIN DutyT AS D ON D.Id = T.Duty_Id WHERE T.Employee_Id = {EmplId} AND D.newcol BETWEEN '{DateIn}' AND '{DateOut}' ",conn);
            sql3.Fill(this.dataSet1.DataTable5);
            conn.Close();
            this.reportViewer1.RefreshReport();
        }
    }
}
