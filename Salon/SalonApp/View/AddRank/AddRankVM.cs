using Salon;
using SalonApp.Models.Data;
using SalonApp.Services.Commands;
using SalonApp.Services.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalonApp.View.AddRank
{
    public class AddRankVM : PropertyChangedBase
    {
        private string _rankName;
        public string RankName
        {
            get => _rankName;
            set => Set(ref _rankName, value);
        }
        private string _rankDescription;
        public string RankDescription
        {
            get => _rankDescription;
            set => Set(ref _rankDescription, value);
        }
        private Window window;
        public AddRankVM(Window wind)
        {
            window = wind;
            FillList();
        }
        private void FillList()
        {
            using (var db = new ApplDbContext())
            {
                Ranks = db.RanksT.ToList();
            }
        }
        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    using (var db = new ApplDbContext())
                    {
                        try
                        {
                            if (RankName != "" && RankName != null)
                            {
                                if (!db.RanksT.Any(el => el.RankName == RankName))
                                {
                                    db.RanksT.Add(new Ranks { RankName = RankName, Description = RankDescription });
                                    db.SaveChanges();
                                    window.Close();
                                }
                                else MessageBox.Show("Должность с таким именем уже существует!");

                            }
                            else MessageBox.Show("Заполните все данные!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }));
            }
        }
        private List<Ranks> _ranks;
        public List<Ranks> Ranks
        {
            get => _ranks;
            set => Set(ref _ranks, value);
        }
    }
}

