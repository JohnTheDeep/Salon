namespace ReportViewerProject
{
    partial class AllReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1 = new ReportViewerProject.Reports.DataSet1();
            this.dataTable6BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable6TableAdapter = new ReportViewerProject.Reports.DataSet1TableAdapters.DataTable6TableAdapter();
            this.dataTable7BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable7TableAdapter = new ReportViewerProject.Reports.DataSet1TableAdapters.DataTable7TableAdapter();
            this.dutyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dutyTTableAdapter = new ReportViewerProject.Reports.DataSet1TableAdapters.DutyTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable7BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dutyTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTable6BindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.dataTable7BindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.dutyTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportViewerProject.Reports.Report5.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTable6BindingSource
            // 
            this.dataTable6BindingSource.DataMember = "DataTable6";
            this.dataTable6BindingSource.DataSource = this.dataSet1;
            // 
            // dataTable6TableAdapter
            // 
            this.dataTable6TableAdapter.ClearBeforeFill = true;
            // 
            // dataTable7BindingSource
            // 
            this.dataTable7BindingSource.DataMember = "DataTable7";
            this.dataTable7BindingSource.DataSource = this.dataSet1;
            // 
            // dataTable7TableAdapter
            // 
            this.dataTable7TableAdapter.ClearBeforeFill = true;
            // 
            // dutyTBindingSource
            // 
            this.dutyTBindingSource.DataMember = "DutyT";
            this.dutyTBindingSource.DataSource = this.dataSet1;
            // 
            // dutyTTableAdapter
            // 
            this.dutyTTableAdapter.ClearBeforeFill = true;
            // 
            // AllReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "AllReport";
            this.Text = "Общий отчет";
            this.Load += new System.EventHandler(this.AllReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable7BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dutyTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reports.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataTable6BindingSource;
        private Reports.DataSet1TableAdapters.DataTable6TableAdapter dataTable6TableAdapter;
        private System.Windows.Forms.BindingSource dataTable7BindingSource;
        private Reports.DataSet1TableAdapters.DataTable7TableAdapter dataTable7TableAdapter;
        private System.Windows.Forms.BindingSource dutyTBindingSource;
        private Reports.DataSet1TableAdapters.DutyTTableAdapter dutyTTableAdapter;
    }
}