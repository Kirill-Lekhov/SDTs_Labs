using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Ducks_vs_Drakes
{
    public partial class gameObj1 : spriteComp
    {
        public gameObj1(Game game, ref Texture2D newTexture, Rectangle newRectangle, Vector2 newPosition) : base(game, ref newTexture, newRectangle, newPosition)
        {
            
        }

        public override void Move()
        {
            KeyboardState kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.Up))
                sprPosition.Y -= 5;
                // base.SetPositionY(base.GetPositionY() - 5);
            if (kbState.IsKeyDown(Keys.Down))
                sprPosition.Y += 5;
            if (kbState.IsKeyDown(Keys.Left))
                sprPosition.X -= 5;
            if (kbState.IsKeyDown(Keys.Right))
                sprPosition.X += 5;

            base.Move();
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
