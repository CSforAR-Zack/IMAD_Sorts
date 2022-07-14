using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace IMAD_Sorts;

public class BubbleSorter : Sorter
{
    public BubbleSorter(Values values, int delay) : base(values, delay)
    {    
    }

    public override async void Sort()
    {
        bool done = false;
        int sorted = 0;

        while (!done)
        {
            done = true;
            for (int k = 0; k < this.values.Labels.Count - sorted - 1; k++)
            {
                ColorPicker.SetColor(this.values.Labels[k], "current");
                ColorPicker.SetColor(this.values.Labels[k + 1], "lookingAt");
                await this.Pause(delay);

                if (Convert.ToInt32(this.values.Labels[k].Text) > Convert.ToInt32(this.values.Labels[k + 1].Text))
                {
                    this.Swap(k, k + 1);
                    await this.Pause(delay);
                    ColorPicker.SetColor(this.values.Labels[k], "unsorted");
                    done = false;
                }
                else
                {
                    await this.Pause(delay);
                    ColorPicker.SetColor(this.values.Labels[k], "unsorted");
                }
            }
            sorted++;
            ColorPicker.SetColor(this.values.Labels[this.values.Labels.Count - sorted], "sorted");
        }
        if (sorted < this.values.Labels.Count)
        {
            await this.Pause(delay);
            for (int i = 0; i < this.values.Labels.Count - sorted; i++)
            {
                ColorPicker.SetColor(this.values.Labels[i], "sorted");
            }
        }
        await this.Pause(delay);
    }
}
