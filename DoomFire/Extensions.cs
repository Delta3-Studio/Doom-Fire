using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DoomFire;

public static class Extensions
{
    public static FireWind Toggle(this FireWind wind) =>
        (FireWind)(((int)wind + 1) % Enum.GetValues<FireWind>().Length);

    public static Texture2D CreateBlankTexture(this SpriteBatch s)
    {
        Texture2D blankTexture = new(s.GraphicsDevice, 1, 1);
        blankTexture.SetData([Color.White]);
        return blankTexture;
    }
}