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
        private Texture2D sprTexture;
        private Rectangle sprRecrangle;
        private Vector2 sprPosition;
        public spriteComp(Game game, ref Texture2D newTexture, Rectangle newRectangle, Vector2 newPosition) : base(game)
        {
            sprTexture = newTexture;
            sprRecrangle = newRectangle;
            sprPosition = newPosition;
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
            SpriteBatch sprBacth = (SpriteBatch)Game.Services.GetService(typeof(SpriteBatch));
            sprBacth.Draw(sprTexture, sprPosition, sprRecrangle, Color.White);
            
            base.Draw(gameTime);
        }
    }
}
