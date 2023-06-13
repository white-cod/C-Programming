using System.Drawing;

Func<string, Color> getRainbowColor = (colorOfRainbow) =>
{
    switch (colorOfRainbow.ToLower())
    {
        case "красный":
            return Color.FromArgb(255, 0, 0);
        case "оранжевый":
            return Color.FromArgb(255, 165, 0);
        case "желтый":
            return Color.FromArgb(255, 255, 0);
        case "зеленый":
            return Color.FromArgb(0, 128, 0);
        case "синий":
            return Color.FromArgb(0, 0, 255);
        case "розовый":
            return Color.FromArgb(75, 0, 130);
        case "фиолетовый":
            return Color.FromArgb(238, 130, 238);
        default:
            throw new ArgumentException("Указан неверный цвет радуги");
    }
};

string colorOfRainbow = "синий";
Color rainbowColor = getRainbowColor(colorOfRainbow);
Console.WriteLine($"Значение RGB для {colorOfRainbow} в радуге - это ({rainbowColor.R}, {rainbowColor.G}, {rainbowColor.B}).");