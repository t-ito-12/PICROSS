using CreatePICROSS.ViewModels;

namespace CreatePICROSS;

public partial class PICROSSPage : StackLayout
{
    public PICROSSPageViewModel ViewModel { get; }

    public PICROSSPage(int size)
    {
        InitializeComponent();
        ViewModel = new PICROSSPageViewModel(size);
        this.BindingContext = ViewModel;
        for (int i = 0; i < size; i++)
        {
            this.PanelButtonsGrid.RowDefinitions.Add(new RowDefinition());
            this.PanelButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }
    }

}