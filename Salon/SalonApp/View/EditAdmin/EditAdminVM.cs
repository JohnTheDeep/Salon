using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.EditAdmin
{
    public class EditAdminVM : PropertyChangedBase
    {
        private Window window;
        private Users _selectedAdmin;
        public Users SelectedAdmin
        {
            get => _selectedAdmin;
            set => Set(ref _selectedAdmin, value);
        }
        public EditAdminVM(Users selectedUser,Window wind)
        {
            SelectedAdmin = selectedUser;
            window = wind;
        }

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(obj => 
                {
                    using(var db = new ApplDbContext())
                    {
                        try
                        {
                            Users user = db.UsersT.FirstOrDefault(el => el.Id == SelectedAdmin.Id);
                            user.Ppackage = SelectedAdmin.Ppackage;
                            user.Paddit = SelectedAdmin.Paddit;
                            user.Psertificate = SelectedAdmin.Psertificate;
                            user.VirtualAdminBid = SelectedAdmin.VirtualAdminBid;
                            db.SaveChanges();
                            window.Close();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }));
            }
        }
    }
}
