using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Ducks_vs_Drakes
{
    public partial class CircleComp : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D circleTexture;
        protected Vector2 circlePosition;
        protected Vector2 center;
        public CircleComp(Game game, ref Texture2D newTexture, Vector2 newPosition, Vector2 newCenter) : base(game)
        {
            circleTexture = newTexture;
            circlePosition = newPosition;
            center = newCenter;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public bool IsPointInCircle(MouseState mouse)
        {
            double length = Math.Pow((Math.Pow((mouse.X - center.X), 2) + Math.Pow((mouse.Y - center.Y), 2)), 0.5);

            if (length <= 251)
                return true;
            else
                return false;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBacth = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBacth.Draw(circleTexture, circlePosition, Color.White);

            base.Draw(gameTime);
        }
    }
}
