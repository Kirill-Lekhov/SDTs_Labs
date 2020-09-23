using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Ducks_vs_Drakes
{
    public partial class ColoredBoxes : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D sprTexture;
        protected Rectangle sprRectangle;
        protected Vector2 sprPosition;
        protected Rectangle scrBounds;

        protected Random randNum;
        protected int stepNum;
        protected Vector2 newPosition;
        protected Color sprColor;
        protected Vector2 speed;
        public ColoredBoxes(Game game, ref Texture2D newTexture, Rectangle newRectangle, int Speed) : base(game)
        {
            sprTexture = newTexture;
            sprRectangle = newRectangle;

            randNum = new Random(Speed);
            scrBounds = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Width);

            sprPosition.X = (float)randNum.NextDouble() * (scrBounds.Width - sprRectangle.Width);
            sprPosition.Y = (float)randNum.NextDouble() * (scrBounds.Height - sprRectangle.Height);

            stepNum = 0;

            sprColor = new Color((byte)randNum.Next(0, 255), (byte)randNum.Next(0, 255), (byte)randNum.Next(0, 255));

            speed = new Vector2();
        }

        public virtual void Move()
        {
            if (stepNum > 0)
            {
                stepNum--;

                if (sprPosition.X < newPosition.X)
                    sprPosition.X += speed.X;
                if (sprPosition.X > newPosition.X)
                    sprPosition.X -= speed.X;
                if (sprPosition.Y < newPosition.Y)
                    sprPosition.Y += speed.Y;
                if (sprPosition.Y > newPosition.Y)
                    sprPosition.Y -= speed.Y;
            }

            if (stepNum == 0)
            {
                stepNum = randNum.Next(50, 200);
                newPosition.X = (float)randNum.NextDouble() * (scrBounds.Width - sprRectangle.Width);
                newPosition.Y = (float)randNum.NextDouble() * (scrBounds.Height - sprRectangle.Height);

                speed.X = randNum.Next(1, 5);
                speed.Y = randNum.Next(1, 5);

                sprColor = new Color((byte)randNum.Next(0, 255), (byte)randNum.Next(0, 255), (byte)randNum.Next(0, 255));
            }

            Check();
        }

        void Check()
        {
            if (sprPosition.X < scrBounds.Left)
            {
                sprPosition.X = scrBounds.Left;
            }
            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;
            }
            if (sprPosition.Y < scrBounds.Top)
            {
                sprPosition.Y = scrBounds.Top;
            }
            if (sprPosition.Y > scrBounds.Height - sprRectangle.Height)
            {
                sprPosition.Y = scrBounds.Height - sprRectangle.Height;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            Move();
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBacth = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBacth.Draw(sprTexture, sprPosition, sprRectangle, sprColor);

            base.Draw(gameTime);
        }
    }
}
