using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoomFire;

public class FireData
{
    public int Cols { get; }
    public int Rows { get; }

    readonly int[] data;
    public FireWind Wind { get; set; } = FireWind.None;

    readonly Random random = new();

    public int this[int x, int y] => data[x * Cols + y];

    public FireData(int cols, int rows)
    {
        Cols = cols;
        Rows = rows;
        data = new int[Rows * Cols];

        DefineBaseState();
    }

    void DefineBaseState()
    {
        var max = ColorPalete.Colors.Length - 1;
        for (var j = 0; j < Cols; j++)
        {
            var overflowPixelIndex = Cols * Rows;
            var pixelIndex = (overflowPixelIndex - Cols) + j;
            data[pixelIndex] = max;
        }
    }

    public void Update()
    {
        for (var column = 0; column < Cols; column++)
        for (var row = 0; row < Rows; row++)
        {
            var pixelIndex = column + (Cols * row);
            UpdateFire(pixelIndex);
        }
    }

    void UpdateFire(int currentPixelIndex)
    {
        var belowPixelIndex = currentPixelIndex + Cols;

        if (belowPixelIndex >= Cols * Rows)
            return;

        var decay = random.Next(3 + 1);

        if (currentPixelIndex - decay < 0)
            return;

        var belowPixelFireIntensity = data[belowPixelIndex];
        var tempIntensity = belowPixelFireIntensity - (decay & 1);
        var newFireIntensity = tempIntensity >= 0 ? tempIntensity : 0;

        switch (Wind)
        {
            case FireWind.None:
                var rndNeg = (decay & 1) == 0 ? -decay : decay;
                data[currentPixelIndex + rndNeg] = newFireIntensity;
                break;
            case FireWind.Left:
                data[currentPixelIndex - decay] = newFireIntensity;
                break;
            case FireWind.Right:
                data[currentPixelIndex + decay] = newFireIntensity;
                break;
        }
    }

    Texture2D blankTexture;

    public void Draw(SpriteBatch spriteBatch)
    {
        blankTexture ??= spriteBatch.CreateBlankTexture();

        for (var row = 0; row < Rows; row++)
        for (var col = 0; col < Cols; col++)
        {
            Rectangle rect = new(col, row, 1, 1);
            var colorIndex = this[row, col];
            var color = ColorPalete.Colors[colorIndex];
            spriteBatch.Draw(blankTexture, rect, color);
        }
    }
}

public enum FireWind
{
    None,
    Left,
    Right,
}