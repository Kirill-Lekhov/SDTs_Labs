using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ducks_vs_Drakes
{
    class spriteClass
    {
        public Texture2D spTexture;
        public Vector2 spPosition;

        public spriteClass(Texture2D newSpTexture, Vector2 newSpPosition)
        {
            spTexture = newSpTexture;
            spPosition = newSpPosition;
        }
    }
}
