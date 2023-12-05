using PICROSSCommon;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CreatePICROSS.ViewModels
{
    public class PICROSSPageViewModel : ViewModelBase
    {
        public ObservableCollection<PanelButtonBase> PanelButtons { get; set; } = new ObservableCollection<PanelButtonBase>();

        public ObservableCollection<RowNumber> RowNumbers { get; set; } = new ObservableCollection<RowNumber>();

        public ObservableCollection<ColumnNumber> ColumnNumbers { get; set; } = new ObservableCollection<ColumnNumber>();

        public ICommand ButtonClick { get; set; }


        public PICROSSPageViewModel(int size)
        {
            if (size < 1) { throw new ArgumentOutOfRangeException(nameof(size)); }
            for (int i = 0; i < size * size; i++)
            {
                PanelButtons.Add(new DefaultPanelButton(i, size));
            }

            for (int i = 0; i < size; i++)
            {
                RowNumbers.Add(new RowNumber(i, PanelButtons.Where(x => x.Row == i)));
            }

            for (int i = 0; i < size; i++)
            {
                ColumnNumbers.Add(new ColumnNumber(i, PanelButtons.Where(x => x.Column == i)));
            }


            ButtonClick = new Command(
                execute: (sender) =>
                {
                    var panelButton = sender as PanelButtonBase;
                    if (panelButton == null) { return; }
                    var index = PanelButtons.IndexOf(panelButton);
                    if (panelButton is DefaultPanelButton)
                    {
                        PanelButtons[index] = new CheckedPanelButton(index, size);
                    }
                    else if (panelButton is CheckedPanelButton)
                    {
                        PanelButtons[index] = new DefaultPanelButton(index, size);
                    }

                    RowNumbers[panelButton.Row] = new RowNumber(panelButton.Row, PanelButtons.Where(x => x.Row == panelButton.Row));
                    ColumnNumbers[panelButton.Column] = new ColumnNumber(panelButton.Column, PanelButtons.Where(x => x.Column ==  panelButton.Column));
                });
        }
    }
}
