using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.Mime;

namespace Ducks_vs_Drakes
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        spriteComp PlayerOneBoard, PlayerTwoBoard, Ball;
        Texture2D GameShapes, BackGround;

        Random randNum;

        //mouse click controller
        //bool is_MouseLB_Pressed = false;
        //Vector2 new_position = new Vector2();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            //mouse click controller
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            GameShapes = Content.Load<Texture2D>("Shapes");
            randNum = new Random();
            CreateNewObject();

            BackGround = Content.Load<Texture2D>("background");
            // TODO: use this.Content to load your game content here
        }

        protected void CreateNewObject()
        {
            //PlayerOneBoard = new gameObj1(this, ref GameShapes, new Rectangle(0, 0, 20, 100), new Vector2(100, 150));
            //PlayerTwoBoard = new gameObj2(this, ref GameShapes, new Rectangle(26, 0, 20, 100), new Vector2(600, 150));
            //Ball = new spriteComp(this, ref GameShapes, new Rectangle(51, 0, 20, 100), new Vector2(400, 150));

            //Components.Add(PlayerOneBoard);
            //Components.Add(PlayerTwoBoard);
            //Components.Add(Ball);

            for (int i = 0; i < randNum.Next(50, 200); i++)
            {
                Components.Add(new ColoredBoxes(this, ref GameShapes, new Rectangle(51, 0, 20, 100), i));
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Keyboard controller
            //KeyboardState kbState = Keyboard.GetState();

            //if (kbState.IsKeyDown(Keys.Up))
            //    Ball.sprPosition.Y -= 1;
            //if (kbState.IsKeyDown(Keys.Down))
            //    Ball.sprPosition.Y += 1;
            //if (kbState.IsKeyDown(Keys.Left))
            //    Ball.sprPosition.X -= 1;
            //if (kbState.IsKeyDown(Keys.Right))
            //    Ball.sprPosition.X += 1;


            //mouse move controller
            //MouseState mState = Mouse.GetState();
            //Ball.sprPosition.Y = mState.Y;
            //Ball.sprPosition.X = mState.X;

            //Mouse Click Controller
            //MouseState mState = Mouse.GetState();

            //if (mState.LeftButton == ButtonState.Pressed)
            //{
            //    is_MouseLB_Pressed = true;
            //    new_position.X = mState.X;
            //    new_position.Y = mState.Y;
            //}

            //if (is_MouseLB_Pressed)
            //{
            //    if (new_position.X - Ball.sprPosition.X > 0)
            //    {
            //        Ball.sprPosition.X += 1;
            //    }
            //    else 
            //    {
            //        Ball.sprPosition.X -= 1;
            //    }

            //    if (new_position.Y - Ball.sprPosition.Y > 0)
            //    {
            //        Ball.sprPosition.Y += 1;
            //    }
            //    else
            //    {
            //        Ball.sprPosition.Y -= 1;
            //    }

            //    if (Ball.sprPosition == new_position)
            //    {
            //        is_MouseLB_Pressed = false;
            //    }
            //}


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(BackGround, new Rectangle(0, 0, 800, 480), Color.White);
            // TODO: Add your drawing code here
            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
