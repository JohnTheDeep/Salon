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
    public partial class AllReport : Form
    {
        private string _DateIn, _DateOut;
        private int _SalonID;
        public AllReport(string DateIn,string DateOut,int SalonId)
        {
            InitializeComponent();
            _DateIn = DateIn;
            _DateOut = DateOut;
            _SalonID = SalonId;
        }

        private void AllReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server = 94.124.78.213; Database=SalonDbTest; Integrated Security=false; User Id=sa; Password=LoveIsMSSQLDb_2022;");
            conn.Open();
            SqlCommand comm = new SqlCommand($"UPDATE DutyT Set newCol = CONVERT(datetime2, DutyDate, 103)", conn);
            comm.ExecuteNonQuery();
            SqlCommand comm2 = new SqlCommand($"UPDATE AvanciesT Set DateIn2 = CONVERT(datetime2, DateIn, 103)\r\nUPDATE AvanciesT Set DateOut2 = CONVERT(datetime2, DateOut, 103)", conn);
            comm2.ExecuteNonQuery();
            SqlDataAdapter data1 = new SqlDataAdapter($"SELECT EMP.FullName,R.RankName, " +
                $"(SELECT IsNull(SUM(Salary),0) FROM StatisticT T WHERE T.Employee_Id = Emp.Id AND T.Duty_Id " +
                    $"IN (SELECT Id FROM DutyT D WHERE D.newcol BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeSalary, " +

                $"(SELECT IsNull(SUM(A.Total),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.Id " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeAvancies, " +

                $"(SELECT IsNull(SUM(A.Fine),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.ID " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeAvanciesFine, " +

                $"(SELECT IsNull(SUM(A.Total),0) - IsNull(SUM(A.Fine),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.Id " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeAvanciesTotal, " +

                $"((SELECT IsNull(SUM(Salary),0) FROM StatisticT T WHERE T.Employee_Id = Emp.Id AND T.Duty_Id " +
                    $"IN (SELECT Id FROM DutyT D WHERE D.newcol BETWEEN '{_DateIn}' AND '{_DateOut}')) - " +
                    $"(SELECT IsNull(SUM(A.Total),0) - IsNull(SUM(A.Fine),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.Id " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}'))) " +
                $"AS Give FROM EmployeesT EMP " +
                $"INNER JOIN RanksT R ON R.Id = EMP.Rank_Id WHERE EMP.IsAdmin = 0 AND EMP.Salon_Id = {_SalonID}",conn);
            data1.Fill(this.dataSet1.DataTable6);
            SqlDataAdapter data2 = new SqlDataAdapter($"SELECT EMP.FullName,R.RankName, " +
                $"(SELECT IsNull(SUM(BaseBid),0) + IsNull(SUM(VirtualAdminBid),0) + IsNull(SUM(Total),0) FROM StatisticT T WHERE T.Employee_Id = Emp.Id AND T.Duty_Id " +
                    $"IN (SELECT Id FROM DutyT D WHERE D.newcol BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeSalary, " +

                $"(SELECT IsNull(SUM(A.Total),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.Id " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeAvancies, " +

                $"(SELECT IsNull(SUM(A.Fine),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.ID " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeAvanciesFine, " +

                $"(SELECT IsNull(SUM(A.Total),0) - IsNull(SUM(A.Fine),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.ID " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}')) AS EmployeeAvanciesTotal, " +

                $"((SELECT IsNull(SUM(BaseBid),0) + IsNull(SUM(VirtualAdminBid),0) + IsNull(SUM(Total),0) FROM StatisticT T WHERE T.Employee_Id = Emp.Id AND T.Duty_Id " +
                    $"IN (SELECT Id FROM DutyT D WHERE D.newcol BETWEEN '{_DateIn}' AND '{_DateOut}')) - " +
                    $"(SELECT IsNull(SUM(A.Total),0) - IsNull(SUM(A.Fine),0) FROM AvanciesT A WHERE A.Employee_Id = EMP.Id AND A.ID " +
                    $"IN (SELECT Id FROM AvanciesT AV WHERE AV.DateOut2 BETWEEN '{_DateIn}' AND '{_DateOut}'))) AS Give " +
                $"FROM EmployeesT EMP INNER JOIN RanksT R ON R.Id = EMP.Rank_Id WHERE EMP.IsAdmin = 1 AND EMP.Salon_Id = {_SalonID}", conn);
            data2.Fill(this.dataSet1.DataTable7);
            SqlDataAdapter data3 = new SqlDataAdapter($"SELECT Id,newcol FROM DutyT WHERE newcol BETWEEN '{_DateIn}' AND '{_DateOut}'", conn);
            data3.Fill(this.dataSet1.DutyT);
            conn.Close();
            this.reportViewer1.RefreshReport();
        }
    }
}
