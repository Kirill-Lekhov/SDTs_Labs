using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Runtime.ConstrainedExecution;

namespace Ducks_vs_Drakes
{
    public partial class ColoredBoxes : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D sprTexture;
        protected Rectangle sprRectangle;
        protected Vector2 sprPosition;
        protected Rectangle scrBounds;

        protected Random randNum;
        protected Game1 MyGame;
        protected int stepNum;
        protected Color sprColor;
        protected Vector2 speed;

        MouseState mouse;
        public ColoredBoxes(Game1 game, ref Texture2D newTexture, Rectangle newRectangle, int Speed) : base(game)
        {
            sprTexture = newTexture;
            sprRectangle = newRectangle;
            MyGame = game;

            randNum = new Random(Speed);
            scrBounds = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Width);

            setSpriteToStart();
            while (howManyCollides() > 0)
            {
                setSpriteToStart();
            }

            sprColor = new Color((byte)randNum.Next(0, 255), (byte)randNum.Next(0, 255), (byte)randNum.Next(0, 255));
            speed = new Vector2((float)randNum.Next(-5, 5), (float)randNum.Next(-5, 5));
        }

        bool MouseCollide()
        {
            return ((mouse.X > sprPosition.X) &&
                    (mouse.X < sprPosition.X + sprRectangle.Width) &&
                    (mouse.Y > sprPosition.Y) &&
                    (mouse.Y < sprPosition.Y + sprRectangle.Height));
        }

        int howManyCollides()
        {
            int howMany = 0;

            foreach (ColoredBoxes spr in MyGame.Components)
            {
                if (this != spr)
                {
                    if (this.sprCollide(spr))
                    {
                        howMany++;
                    }
                }
            }

            return howMany;
        }

        void setSpriteToStart()
        {
            sprPosition.X = (float)randNum.NextDouble() * (scrBounds.Width - sprRectangle.Width);
            sprPosition.Y = (float)randNum.NextDouble() * (scrBounds.Height - sprRectangle.Height);
        }

        public virtual void Move()
        {
            sprPosition += speed;
        }

        void Check()
        {
            if (sprPosition.X < scrBounds.Left)
            {
                sprPosition.X = scrBounds.Left;
                this.speed.X *= -1;
            }
            if (sprPosition.X > scrBounds.Width - sprRectangle.Width)
            {
                sprPosition.X = scrBounds.Width - sprRectangle.Width;
                this.speed.X *= -1;
            }
            if (sprPosition.Y < scrBounds.Top)
            {
                sprPosition.Y = scrBounds.Top;
                this.speed.Y *= -1;
            }
            if (sprPosition.Y > scrBounds.Height - sprRectangle.Height)
            {
                sprPosition.Y = scrBounds.Height - sprRectangle.Height;
                this.speed.Y *= -1;
            }
        }

        public bool sprCollide(ColoredBoxes spr)
        {
            Rectangle R1 = new Rectangle((int)this.sprPosition.X, (int)this.sprPosition.Y, this.sprRectangle.Width, this.sprRectangle.Height);
            Rectangle R2 = new Rectangle((int)spr.sprPosition.X, (int)spr.sprPosition.Y, spr.sprRectangle.Width, spr.sprRectangle.Height);

            return R1.Intersects(R2);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
            {
                if (MouseCollide())
                {
                    MyGame.Score++;
                    MyGame.Components.Remove(this);
                }
            }

            Move();
            Check();
            IsSpriteCollide();

            while (howManyCollides() > 0)
            {
                IsSpriteCollide();
            }

            base.Update(gameTime);
        }

        void IsSpriteCollide()
        {
            foreach (ColoredBoxes spr in MyGame.Components)
            {
                if (this != spr)
                {
                    if (this.sprCollide(spr))
                    {
                        this.speed *= -1;
                        this.sprPosition += this.speed;
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBacth = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBacth.Draw(sprTexture, sprPosition, sprRectangle, sprColor);

            base.Draw(gameTime);
        }
    }
}
