namespace IMAD_Sorts;

public class Values
{
    int numValues = 0;
    HorizontalStackLayout hsl = null;
    Random random = new Random();
    List<Label> labels = new List<Label>();

    public List<Label> Labels { get { return labels; } }

    public Values(int numValues, HorizontalStackLayout hsl)
    {
        this.numValues = numValues;
        this.hsl = hsl;
    }

    public void GenerateValues()
    {
        this.labels.Clear();
        for (int i = 0; i < numValues; i++)
        {
            Label label = new Label();
            int newValue = this.random.Next(1, 20);
            label.Text = newValue.ToString();
            label.HeightRequest = newValue * 10;
            this.labels.Add(label);
        }
        this.Draw();
    }

    public void Draw()
    {
        this.hsl.Children.Clear();
        foreach (var label in this.Labels)
        {
            this.hsl.Add(label);
        }
    }
}
