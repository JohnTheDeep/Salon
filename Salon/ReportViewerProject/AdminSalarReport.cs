using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportViewerProject
{
    public partial class AdminSalarReport : Form
    {
        public int Emplid, ServId;
        string DateIn, DateOut;
        public AdminSalarReport(int emplId, string DateIn, string DateOut)
        {
            InitializeComponent(); 
            this.Emplid = emplId;
            this.DateIn = DateIn;
            this.DateOut = DateOut;
        }
        
        private void AdminSalarReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("");
            conn.Open();
            SqlCommand comm = new SqlCommand($"UPDATE DutyT Set newCol = CONVERT(datetime2, DutyDate, 103)", conn);
            comm.ExecuteNonQuery();
            SqlDataAdapter sql = new SqlDataAdapter("SELECT " +
                "D.DutyDate, D.CashPerDay, D.NonCashPerDay, D.TransfersPerDay, D.TotalSertificates, D.Income, " +
                "EMP.FullName, usr.NickName, " +
                "STAT.BaseBid, STAT.IsAdmin, STAT.VirtualAdminBid, STAT.Total " +
                "FROM StatisticT STAT " +
                "INNER JOIN DutyT D ON D.Id = STAT.Duty_Id " +
                "INNER JOIN EmployeesT EMP ON EMP.Id = STAT.Employee_Id  " +
                "LEFT JOIN UsersT usr ON usr.Employee_Id = EMP.Id " +
                "WHERE Stat.IsAdmin = 1 " +
                $"AND Emp.Id = {Emplid} AND D.newCol BETWEEN '{DateIn}' AND '{DateOut}' ", conn);
            sql.Fill(this.dataSet1.DataTable3);
            SqlCommand comm2 = new SqlCommand($"UPDATE AvanciesT Set DateIn2 = CONVERT(datetime2, DateIn, 103)\r\nUPDATE AvanciesT Set DateOut2 = CONVERT(datetime2, DateOut, 103)", conn);
            comm2.ExecuteNonQuery();
            SqlDataAdapter sq2l = new SqlDataAdapter("SELECT Datein,Dateout,Fine,A.Total FROM AvanciesT A INNER JOIN EmployeesT E ON E.Id = A.Employee_Id " +
               $"WHERE E.Id = {Emplid} AND DateOut2 BETWEEN '{DateIn}' AND '{DateOut}'", conn);
            sq2l.Fill(this.dataSet1.AvanciesT);
            conn.Close();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.AvanciesT". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dataSet1.DataTable3". При необходимости она может быть перемещена или удалена.

            this.reportViewer1.RefreshReport();
        }
    }
}
