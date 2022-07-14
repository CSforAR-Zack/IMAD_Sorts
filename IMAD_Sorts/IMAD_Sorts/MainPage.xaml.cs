namespace IMAD_Sorts;

public partial class MainPage : ContentPage
{
    int numValues = 50;
    int delay = 50;
    Values values = null;
    BubbleSorter bSort = null;
    SelectionSorter sSort = null;
    InsertionSorter iSort = null;

    public MainPage()
	{
		InitializeComponent();
        values = new Values(numValues, horizSL);
        bSort = new BubbleSorter(values, delay);
        sSort = new SelectionSorter(values, delay);
        iSort = new InsertionSorter(values, delay);
    }

	public void GenerateValues(object sender, EventArgs args)
    {
        values.GenerateValues();
    }

    public void BubbleSort(object sender, EventArgs args)
    {
        bSort.Sort();
    }

    public void SelectionSort(object sender, EventArgs args)
    {
        sSort.Sort();
    }

    public void InsertionSort(object sender, EventArgs args)
    {
        iSort.Sort();
    }
}

