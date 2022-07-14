using System.Linq;

namespace IMAD_Sorts;

public class SelectionSorter : Sorter
{
    public SelectionSorter(Values values, int delay) : base(values, delay)
    {
    }

    public override async void Sort()
    {
        for (int i = 0; i < this.values.Labels.Count; i++)
        {
            int best = i;

            ColorPicker.SetColor(this.values.Labels[i], "current");
            await this.Pause(delay);

            for (int j = i + 1; j < this.values.Labels.Count; j++)
            {
                ColorPicker.SetColor(this.values.Labels[j], "lookintAt");  
                await this.Pause(delay);

                if (Convert.ToInt32(this.values.Labels[j].Text) < Convert.ToInt32(this.values.Labels[best].Text))
                {
                    if (best == i)
                    {
                        ColorPicker.SetColor(this.values.Labels[i], "current");
                    }
                    else
                    {
                        ColorPicker.SetColor(this.values.Labels[best], "unsorted");
                    }
                    best = j;
                    ColorPicker.SetColor(this.values.Labels[best], "best");
                    await this.Pause(delay);
                }
                else
                {
                    await this.Pause(delay);
                    ColorPicker.SetColor(this.values.Labels[j], "unsorted");
                }
            }

            if (best != i)
            {
                this.Swap(i, best);
            }
            await this.Pause(delay);
            ColorPicker.SetColor(this.values.Labels[best], "unsorted");
            ColorPicker.SetColor(this.values.Labels[i], "sorted");
        }
        await Pause(delay);
    }
}
