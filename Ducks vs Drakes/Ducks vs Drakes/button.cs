using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Ducks_vs_Drakes
{
    public partial class button : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D buttonTexture;
        protected Rectangle buttonRectangle;
        protected Vector2 buttonPosition;

        public button(Game game, ref Texture2D newTexture, Rectangle newRectangle, Vector2 newPosition) : base(game)
        {
            buttonTexture = newTexture;
            buttonRectangle = newRectangle;
            buttonPosition = newPosition;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public bool Check(MouseState mouse)
        {
            return ((mouse.X > buttonPosition.X) &&
                    (mouse.X < buttonPosition.X + buttonRectangle.Width) &&
                    (mouse.Y > buttonPosition.Y) &&
                    (mouse.Y < buttonPosition.Y + buttonRectangle.Height));
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBacth = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBacth.Draw(buttonTexture, buttonPosition, buttonRectangle, Color.White);

            base.Draw(gameTime);
        }
    }
}
