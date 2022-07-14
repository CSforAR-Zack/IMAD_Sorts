namespace IMAD_Sorts;

public class InsertionSorter : Sorter
{
    public InsertionSorter(Values values, int delay) : base(values, delay)
    {
    }

    public override async void Sort()
    {
        ColorPicker.SetColor(this.values.Labels[0], "sorted");

        for (int j = 1; j < this.values.Labels.Count; j++)
        {
            ColorPicker.SetColor(this.values.Labels[j], "lookingAt");
            await this.Pause(delay);
            int k = j - 1;

            while ((k >= 0) && (Convert.ToInt32(this.values.Labels[k].Text) > Convert.ToInt32(this.values.Labels[k + 1].Text)))
            {
                ColorPicker.SetColor(this.values.Labels[k + 1], "current");
                ColorPicker.SetColor(this.values.Labels[k], "lookingAt");
                await this.Pause(delay);
                this.Swap(k, k + 1);
                ColorPicker.SetColor(this.values.Labels[k + 1], "sorted");
                k--;
            }
            ColorPicker.SetColor(this.values.Labels[k + 1], "sorted");
        }
        await this.Pause(delay);
    }
}
