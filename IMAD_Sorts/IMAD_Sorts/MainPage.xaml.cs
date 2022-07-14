namespace IMAD_Sorts;

public partial class MainPage : ContentPage
{
    Values values = null;
    BubbleSorter bSort = null;
    SelectionSorter sSort = null;
    InsertionSorter iSort = null;

    public MainPage()
	{
		InitializeComponent();
        values = new Values(20, horizSL);
        bSort = new BubbleSorter(values, 100);
        sSort = new SelectionSorter(values, 100);
        iSort = new InsertionSorter(values, 100);
    }

	public void GenerateValues(object sender, EventArgs args)
    {
        values.GenerateValues();
    }

    public void BubbleSort(object sender, EventArgs args)
    {
        this.ToggleButtons(false);
        bSort.Sort();
        this.ToggleButtons(true);
    }

    public void SelectionSort(object sender, EventArgs args)
    {
        this.ToggleButtons(false);
        sSort.Sort();
        this.ToggleButtons(true);
    }

    public void InsertionSort(object sender, EventArgs args)
    {
        this.ToggleButtons(false);
        iSort.Sort();
        this.ToggleButtons(true);
    }

    void ToggleButtons(bool state)
    {
        genValueBtn.IsEnabled = state;
        bubbleBtn.IsEnabled = state;
        selectBtn.IsEnabled = state;
        insertBtn.IsEnabled = state;
    }
}

