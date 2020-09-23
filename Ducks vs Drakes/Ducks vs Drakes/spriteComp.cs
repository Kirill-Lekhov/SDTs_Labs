using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Ducks_vs_Drakes
{
    public partial class spriteComp : Microsoft.Xna.Framework.DrawableGameComponent
    {
        protected Texture2D sprTexture;
        protected Rectangle sprRectangle;
        protected Vector2 sprPosition;
        protected Rectangle scrBounds;

        public spriteComp(Game game, ref Texture2D newTexture, Rectangle newRectangle, Vector2 newPosition) : base(game)
        {
            sprTexture = newTexture;
            sprRectangle = newRectangle;
            sprPosition = newPosition;
            scrBounds = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Width);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Check()
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

        public Vector2 GetPosition()
        {
            return sprPosition;
        }

        public Rectangle GetRectangle()
        {
            return sprRectangle;
        }

        public int GetWidth()
        {
            return sprRectangle.Width;
        }

        public int GetHeight()
        {
            return sprRectangle.Height;
        }

        public void set_position(float x, float y)
        {
            sprPosition.X += x;
            sprPosition.Y += y;
        }

        public bool check_all_elements_collision()
        {
            foreach (spriteComp spr in base.Game.Components)
            {
                if (this != spr)
                {
                    Rectangle Rec1 = new Rectangle((int)this.GetPosition().X, (int)this.GetPosition().Y, this.GetWidth(), this.GetHeight());
                    Rectangle Rec2 = new Rectangle((int)spr.GetPosition().X, (int)spr.GetPosition().Y, spr.GetWidth(), spr.GetHeight());

                    if (Rec1.Intersects(Rec2))
                        return false;
                }
            }

            return true;
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBacth = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBacth.Draw(sprTexture, sprPosition, sprRectangle, Color.White);
            
            base.Draw(gameTime);
        }
    }
}
