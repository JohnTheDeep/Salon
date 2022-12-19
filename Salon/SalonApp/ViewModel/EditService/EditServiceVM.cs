using Microsoft.Win32;
using Salon;
using SalonApp.Services.Commands;
using SalonApp.Services.DbCommands;
using SalonApp.Services.PropertyChanged;
using SalonApp.ViewModel.MainWindowViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using static System.Net.WebRequestMethods;
using Data = SalonApp.Models.Data;
using File = System.IO.File;

namespace SalonApp.ViewModel.EditService
{
    internal class EditServiceVM : PropertyChangedBase
    {
        private Window window;
        public EditServiceVM(Window wind,Data.Services selected)
        {
            window = wind;
            SelectedService = selected;
            BitmapImage ima = new BitmapImage();
            if (SelectedService != null)
            {
                if (SelectedService.ServiceImage != null)
                {
                    using (MemoryStream memStream = new MemoryStream(SelectedService.ServiceImage))
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
        private Data.Services _selectedService;
        public Data.Services SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService,value);
        }
        private string _serviceName;
        public string ServiceName
        {
            get => _serviceName;
            set => Set(ref _serviceName, value);
        }
        private BitmapImage img;
        public BitmapImage Img
        {
            get => img;
            set => Set(ref img, value);
        }
        private RelayCommand _addImage;
        public RelayCommand AddImage
        {
            get
            {
                return _addImage ?? (_addImage = new RelayCommand(obj =>
                {
                    try
                    {
                        OpenFileDialog file = new OpenFileDialog();
                        file.ShowDialog();
                        if (file.FileName != null)
                        {
                            using (var db = new ApplDbContext())
                            {
                                var us = db.ServicesT.FirstOrDefault(el => el.Id == SelectedService.Id);
                                if (us != null)
                                {
                                    us.ServiceImage = File.ReadAllBytes(file.FileName);
                                    db.SaveChanges();
                                    BitmapImage ima = new BitmapImage();
                                    using (MemoryStream memStream = new MemoryStream(File.ReadAllBytes(file.FileName)))
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
                            //window?.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }));
            }
        }
        private RelayCommand _editServiceCommand;
        public RelayCommand EditServiceCommand
        {
            get
            {
                return _editServiceCommand ?? (_editServiceCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        Controller.EditService(SelectedService, new Data.Services { ServiceName = SelectedService.ServiceName , TitleService = SelectedService.TitleService, TitleHandJob = SelectedService.TitleHandJob, ServiceType = SelectedService.ServiceType});
                        window?.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }));
            }
        }
    }
}
