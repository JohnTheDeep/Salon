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

namespace SalonApp.View.EditRank
{
    public class EditRankVM : PropertyChangedBase
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
        public EditRankVM(Window wind,Ranks selected)
        {
            window = wind;
            SelectedRanks = selected;
            FillList();
            RankName = SelectedRanks.RankName;
            RankDescription = SelectedRanks.Description;
        }
        private Ranks _selectedRank;
        public Ranks SelectedRanks
        {
            get => _selectedRank;
            set => Set(ref _selectedRank, value);
        }
        private void FillList()
        {
            using(var db = new ApplDbContext())
            {
                Ranks = db.RanksT.ToList();
            }
        }
        private RelayCommand _editRankCommand;
        public RelayCommand EditRankCommand
        {
            get 
            {
                return _editRankCommand ?? (_editRankCommand = new RelayCommand(obj => 
                {
                    try
                    {
                        using (var db = new ApplDbContext())
                        {
                            if (RankName != "" && RankName != null)
                            {
                                Ranks rank = db.RanksT.FirstOrDefault(el => el.Id == SelectedRanks.Id);
                                rank.RankName = RankName;
                                rank.Description = RankDescription;
                                db.SaveChanges();
                                window.Close();
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
