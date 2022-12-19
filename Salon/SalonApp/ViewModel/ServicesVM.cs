using Microsoft.EntityFrameworkCore;
using Salon;
using Salon.Models.Data;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using SalonApp.View.AddJournal;
using SalonApp.ViewModel.MainWindowViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Serv = SalonApp.Models.Data;

namespace SalonApp.ViewModel
{
    public class ServicesVM : PropertyChangedBase
    {
        private protected MainVM VM;
        private BitmapImage img;
        public BitmapImage Img
        {
            get => img;
            set => Set(ref img, value);
        }
        private Users _dutyAdmin;
        public Users dutyAdmin
        {
            get => _dutyAdmin;
            set => Set(ref _dutyAdmin, value);
        }
        private SalonApp.Models.Data.Services _selServ;
        public SalonApp.Models.Data.Services selServ
        {
            get => _selServ;
            set => Set(ref _selServ, value);
        }
        private Salons _selSalon;
        public Salons selSalon
        {
            get => _selSalon;
            set => Set(ref _selSalon, value);
        }

        private Employees _selectedEmployee;
        public Employees SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {

                Set(ref _selectedEmployee, value);
                try
                {
                    using (var db = new ApplDbContext())
                    {
                        Lasy item = db.LasyT.Include(el => el.Employee).FirstOrDefault(el => el.Employee.Salon_Id == selSalon.Id && el.Employee_id == SelectedEmployee.Id && el.Service_Id == Service.Id);
                        if (item is null)
                        {
                            db.LasyT.Add(new Lasy { Employee_id = SelectedEmployee.Id, IsSelected = true, Service_Id = Service.Id });
                            db.SaveChanges();
                        }
                        else
                        {
                            item.IsSelected = true;
     
                            foreach(var item2 in db.LasyT)
                            {
                                if(item2.Employee_id != SelectedEmployee.Id && item2.Service_Id == selServ.Id)
                                {
                                    item2.IsSelected = false;
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private Serv.Services _service;
        public Serv.Services Service
        {
            get => _service;
            set => Set(ref _service, value);
        }
        private List<Employees> _employees;
        public List<Employees> Employees
        {
            get => _employees;
            set => Set(ref _employees, value);
        }

        private void CheckedServices(ApplDbContext db)
        {

            try
            {
                Lasy list = db.LasyT.Include(el => el.Employee).FirstOrDefault(el => el.Employee.Salon_Id == selSalon.Id && el.Service_Id == selServ.Id && el.IsSelected == true);
                if (list != null)
                {
                    foreach (Employees v in Employees)
                    {
                        if (v.Id == list.Employee_id)
                        {
                            SelectedEmployee = v;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private RelayCommand _openWindowCommand;
        public RelayCommand OpenWindowCommand
        {
            get
            {
                return _openWindowCommand ?? (_openWindowCommand = new RelayCommand(obj => 
                {
                    OpenServiceWindow(this, new EventArgs());
                }));
            }
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void OpenServiceWindow(object sender, EventArgs e)
        {
            if (SelectedEmployee != null)
            {
                AddJournalWindow wind = new AddJournalWindow(selSalon, selServ, SelectedEmployee, dutyAdmin);
                SetCenterPositionAndOpen(wind);
                if (VM != null) VM.Upp2();
            }
            else MessageBox.Show("Выберите сотрудника!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public ServicesVM() { }
        public ServicesVM(Salons salon,Serv.Services serv,  Users dutyAdmin,MainVM vm)
        {
            this.selSalon = salon;
            this.selServ = serv;
            this.dutyAdmin = dutyAdmin;
            Service = serv;
            VM = vm; 
            Employees = new List<Employees>();
            using (var db = new ApplDbContext())
            {
                foreach(var item in db.Enrollments.Include(empa => empa.Employee).Include(el => el.Service).Where(el => el.Employee.Salon_Id == salon.Id && el.Employee.IsActive == true))
                {
                    if(item.ServiceId == serv.Id)
                    {
                        Employees.Add(item.Employee);
                    }
                }
                CheckedServices(db);
            }

            if (selServ.ServiceImage != null)
            {
                BitmapImage ima = new BitmapImage();
                using (MemoryStream memStream = new MemoryStream(selServ.ServiceImage))
                {
                    ima.BeginInit();
                    ima.CacheOption = BitmapCacheOption.OnLoad;
                    ima.StreamSource = memStream;
                    ima.EndInit();
                    ima.Freeze();
                }
                Img = ima;
            }

        }
    }
}
