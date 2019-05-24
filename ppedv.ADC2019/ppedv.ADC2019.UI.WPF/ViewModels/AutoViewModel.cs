using ppedv.ADC2019.Logic;
using ppedv.ADC2019.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.ADC2019.UI.WPF.ViewModels
{
    public class AutoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Auto> Autos { get; set; }

        public Auto SelectedAuto
        {
            get => selectedAuto;
            set
            {
                selectedAuto = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedAuto)));
            }
        }

        public ICommand SaveCommand { get; set; }

        Core core = new Core();
        private Auto selectedAuto;

        public event PropertyChangedEventHandler PropertyChanged;

        public AutoViewModel()
        {
            Autos = new ObservableCollection<Auto>(core.UnitOfWork.AutoRepository.GetAll());

            SaveCommand = new RelayCommand(o => core.UnitOfWork.SaveAll());
        }

    }
}
