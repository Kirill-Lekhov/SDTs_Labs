using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Ducks_vs_Drakes
{
    public partial class gameObj2 : spriteComp
    {
        public gameObj2(Game game, ref Texture2D newTexture, Rectangle newRectangle, Vector2 newPosition) : base(game, ref newTexture, newRectangle, newPosition)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
