namespace IMAD_Sorts;

public static class ColorPicker
{
    static Dictionary<string, Color> colors = new Dictionary<string, Color>
    {
        { "sorted", Color.FromArgb("#77FF77") },
        { "lookingAt", Colors.Cyan },
        { "unsorted", Colors.Grey },
        { "current", Colors.Yellow },
        { "best", Colors.Red }
    };

    public static void SetColor(Label label, string key)
    {
        label.BackgroundColor = colors[key];
    }
}
