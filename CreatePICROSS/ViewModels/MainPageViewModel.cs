using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePICROSS.ViewModels
{
    internal class MainPageViewModel : PICROSSCommon.ViewModelBase
    {
        public int Size { get; set; } = 15;

        public PICROSSPage Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value;
                OnPropertyChanged(nameof(Page));
            }
        }
        private PICROSSPage _page;

        public MainPageViewModel() 
        {
            Page = new PICROSSPage(Size);
        }
    }
}
