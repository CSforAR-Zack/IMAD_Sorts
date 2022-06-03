﻿namespace IMAD_Sorts;

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

    public async void InsertionSort(object sender, EventArgs args)
    {
        ToggleButtons(false);

        labels[0].BackgroundColor = ColorPicker.sorted;
        await NextStep(delay);

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
                await NextStep(delay);
                k--;
            }
            labels[k + 1].BackgroundColor = ColorPicker.sorted;
        }
        horizSL.Children.Clear();
        foreach (var label in labels)
        {
            horizSL.Add(label);
        }
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
        insertBtn.IsEnabled = state;
    }

    static class ColorPicker
    {
        public static Color sorted = Color.FromArgb("#77FF77");
        public static Color lookingAt = Colors.Cyan;
        public static Color unsorted = Colors.Grey;
        public static Color current = Colors.Yellow;
    }
}
