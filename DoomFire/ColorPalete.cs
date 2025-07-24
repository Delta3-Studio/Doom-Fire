using Microsoft.Xna.Framework;

namespace DoomFire;

public static class ColorPalete
{
    static Color Rgb(int r, int g, int b) => new(r, g, b, byte.MaxValue);

    public static readonly Color[] Colors =
    [
        Rgb(7, 7, 7),
        Rgb(31, 7, 7),
        Rgb(47, 15, 7),
        Rgb(71, 15, 7),
        Rgb(87, 23, 7),
        Rgb(103, 31, 7),
        Rgb(119, 31, 7),
        Rgb(143, 39, 7),
        Rgb(159, 47, 7),
        Rgb(175, 63, 7),
        Rgb(191, 71, 7),
        Rgb(199, 71, 7),
        Rgb(223, 79, 7),
        Rgb(223, 87, 7),
        Rgb(223, 87, 7),
        Rgb(215, 95, 7),
        Rgb(215, 95, 7),
        Rgb(215, 103, 15),
        Rgb(207, 111, 15),
        Rgb(207, 119, 15),
        Rgb(207, 127, 15),
        Rgb(207, 135, 23),
        Rgb(199, 135, 23),
        Rgb(199, 143, 23),
        Rgb(199, 151, 31),
        Rgb(191, 159, 31),
        Rgb(191, 159, 31),
        Rgb(191, 167, 39),
        Rgb(191, 167, 39),
        Rgb(191, 175, 47),
        Rgb(183, 175, 47),
        Rgb(183, 183, 47),
        Rgb(183, 183, 55),
        Rgb(207, 207, 111),
        Rgb(223, 223, 159),
        Rgb(239, 239, 199),
        Rgb(255, 255, 255)
    ];
}