namespace IMAD_Sorts;

public partial class MainPage : ContentPage
{
	Random random = new Random();
	int numValues = 20;
    int delay = 100;
	List<Label> labels = new List<Label>();

	public MainPage()
	{
		InitializeComponent();
	}

	public void GenerateValues(object sender, EventArgs args)
    {
		labels.Clear();
        for (int i = 0; i < numValues; i++)
        {
			Label label = new Label();
			int newValue = random.Next(1, 20);
			label.Text = newValue.ToString();
			label.HeightRequest = newValue * 10;
			labels.Add(label);

        }

		horizSL.Children.Clear();
        foreach (var label in labels)
        {
			horizSL.Add(label);
        }
    }

    public async void BubbleSort(object sender, EventArgs args)
    {
        ToggleButtons(false);
        bool done = false;
        int sorted = 0;

        while (!done)
        {
            done = true;
            for (int k = 0; k < labels.Count - sorted - 1; k++)
            {
                labels[k].BackgroundColor = ColorPicker.current;
                labels[k + 1].BackgroundColor = ColorPicker.lookingAt;
                await NextStep(delay);

                if (Convert.ToInt32(labels[k].Text) > Convert.ToInt32(labels[k + 1].Text))
                {
                    Swap(labels, k, k + 1);
                    await NextStep(delay);
                    labels[k].BackgroundColor = ColorPicker.unsorted;
                    done = false;
                }
                else
                {
                    await NextStep(delay);
                    labels[k].BackgroundColor = ColorPicker.unsorted;
                }
            }
            sorted++;
            labels[labels.Count - sorted].BackgroundColor = ColorPicker.sorted;
        }
        if (sorted < labels.Count)
        {
            await NextStep(delay);
            for (int i = 0; i < labels.Count - sorted; i++)
            {
                labels[i].BackgroundColor = ColorPicker.sorted;
            }
        }
        await NextStep(delay);
        ToggleButtons(true);
    }

    public async void SelectionSort(object sender, EventArgs args)
    {
        ToggleButtons(false);
        for (int i = 0; i < labels.Count; i++)
        {
            int best = i;

            labels[i].BackgroundColor = ColorPicker.current;
            await NextStep(delay);

            for (int j = i + 1; j < labels.Count; j++)
            {
                labels[j].BackgroundColor = ColorPicker.lookingAt;  
                await NextStep(delay);

                if (Convert.ToInt32(labels[j].Text) < Convert.ToInt32(labels[best].Text))
                {
                    if (best == i)
                    {
                        labels[i].BackgroundColor = ColorPicker.current;
                    }
                    else
                    {
                        labels[best].BackgroundColor = ColorPicker.unsorted;
                    }
                    best = j;
                    labels[best].BackgroundColor = ColorPicker.best;
                    await NextStep(delay);
                }
                else
                {
                    await NextStep(delay);
                    labels[j].BackgroundColor = ColorPicker.unsorted;
                }
            }

            if (best != i)
            {
                Swap(labels, i, best);
            }
            await NextStep(delay);
            labels[best].BackgroundColor = ColorPicker.unsorted;
            labels[i].BackgroundColor = ColorPicker.sorted;
        }
        await NextStep(delay);
        ToggleButtons(true);
    }

    public async void InsertionSort(object sender, EventArgs args)
    {
        ToggleButtons(false);

        labels[0].BackgroundColor = ColorPicker.sorted;

        for (int j = 1; j < labels.Count; j++)
        {
            labels[j].BackgroundColor = ColorPicker.lookingAt;
            await NextStep(delay);
            int k = j - 1;

            while ((k >= 0) && (Convert.ToInt32(labels[k].Text) > Convert.ToInt32(labels[k + 1].Text)))
            {
                labels[k + 1].BackgroundColor = ColorPicker.current;
                labels[k].BackgroundColor = ColorPicker.lookingAt;
                await NextStep(delay);
                Swap(labels, k, k + 1);
                labels[k + 1].BackgroundColor = ColorPicker.sorted;
                k--;
            }
            labels[k + 1].BackgroundColor = ColorPicker.sorted;
        }
        await NextStep(delay);
        ToggleButtons(true);
    }

    async Task NextStep(int time)
    {
        horizSL.Children.Clear();
        foreach (var label in labels)
        {
            horizSL.Add(label);
        }
        await Task.Delay(time);
    }

    void Swap(List<Label> list, int i, int j)
    {
        Label temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    void ToggleButtons(bool state)
    {
        genValueBtn.IsEnabled = state;
        bubbleBtn.IsEnabled = state;
        selectBtn.IsEnabled = state;
        insertBtn.IsEnabled = state;
    }

    static class ColorPicker
    {
        public static Color sorted = Color.FromArgb("#77FF77");
        public static Color lookingAt = Colors.Cyan;
        public static Color unsorted = Colors.Grey;
        public static Color current = Colors.Yellow;
        public static Color best = Colors.Red;
    }
}

