using ppedv.ADC2019.Logic;
using ppedv.ADC2019.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.ADC2019.UI.WPF.ViewModels
{
    public class AutoViewModel
    {
        public ObservableCollection<Auto> Autos { get; set; }
        Core core = new Core();

        public AutoViewModel()
        {
            Autos = new ObservableCollection<Auto>(core.UnitOfWork.AutoRepository.GetAll());
        }
        
    }
}
