namespace IMAD_Sorts;

public abstract class Sorter
{
    protected Values values = null;
    protected int delay = 0;

    public Sorter(Values values, int delay)
    {
        this.values = values;
        this.delay = delay;
    }

    public abstract void Sort();

    public void Swap(int i, int j)
    {
        Label temp = values.Labels[i];
        values.Labels[i] = values.Labels[j];
        values.Labels[j] = temp;
    }

    public async Task Pause(int time)
    {
        values.Draw();
        await Task.Delay(time);
    }
}
