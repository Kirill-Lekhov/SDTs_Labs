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
        private Texture2D Circle;
        private Vector2 position = new Vector2(150, 30);
        MouseState mouse;
        Vector2 center;
        
        //spriteComp PlayerOneBoard, PlayerTwoBoard, Ball;
        //Texture2D GameShapes, BackGround;

        //Random randNum;

        public int Score;
        //bool is_win = false;

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
            center.X = position.X + 250 + 8;
            center.Y = position.Y + 250 + 8;
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
            Circle = Content.Load<Texture2D>("Circle");

            //GameShapes = Content.Load<Texture2D>("Shapes");

            //randNum = new Random();
            
            //CreateNewObject();

            //BackGround = Content.Load<Texture2D>("background");
            // TODO: use this.Content to load your game content here
        }

        protected void CreateNewObject()
        {
            //PlayerOneBoard = new spriteComp(this, ref GameShapes, new Rectangle(0, 0, 20, 100), new Vector2(100, 150));
            //PlayerTwoBoard = new spriteComp(this, ref GameShapes, new Rectangle(26, 0, 20, 100), new Vector2(600, 150));
            //Ball = new spriteComp(this, ref GameShapes, new Rectangle(51, 0, 20, 20), new Vector2(400, 150));

            //Components.Add(PlayerOneBoard);
            //Components.Add(PlayerTwoBoard);
            //Components.Add(Ball);

            //for (int i = 0; i < 10; i++)
            //{
            //    Components.Add(new ColoredBoxes(this, ref GameShapes, new Rectangle(51, 0, 20, 100), i));
            //}
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

            mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
                if (IsPointInCircle()) Window.Title = "Вы попали в мишень!";
                else Window.Title = "Вы не попали в мишень!";


            //if (is_win == false)
            //{
            //    Window.Title = "Уничтожено " + Score.ToString() + " за " + gameTime.TotalGameTime.Seconds + " с."; 
            //}

            //if (Score == 10 && is_win == false)
            //{
            //    Window.Title = "Вы уничтожили всех за: " + gameTime.TotalGameTime.Seconds + " с.";
            //}
            // Keyboard controller
            //KeyboardState kbState = Keyboard.GetState();
            //Rectangle Current_Rect = PlayerOneBoard.GetRectangle();
            //float X_change = 0, Y_change = 0, change = 1;

            //if (kbState.IsKeyDown(Keys.Up))
            //    Y_change -= change;
            //if (kbState.IsKeyDown(Keys.Down))
            //    Y_change += change;
            //if (kbState.IsKeyDown(Keys.Left))
            //    X_change -= change;
            //if (kbState.IsKeyDown(Keys.Right))
            //    X_change += change;

            //PlayerOneBoard.set_position(X_change, Y_change);

            //if (!PlayerOneBoard.check_all_elements_collision())
            //    PlayerOneBoard.set_position(-X_change, -Y_change);

            //PlayerOneBoard.Check();

            //X_change = 0;
            //Y_change = 0;

            //if (kbState.IsKeyDown(Keys.W))
            //    Y_change -= change;
            //if (kbState.IsKeyDown(Keys.S))
            //    Y_change += change;
            //if (kbState.IsKeyDown(Keys.A))
            //    X_change -= change;
            //if (kbState.IsKeyDown(Keys.D))
            //    X_change += change;

            //PlayerTwoBoard.set_position(X_change, Y_change);

            //if (!PlayerTwoBoard.check_all_elements_collision())
            //    PlayerTwoBoard.set_position(-X_change, -Y_change);

            //PlayerTwoBoard.Check();



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

        bool IsPointInCircle()
        {
            double length = Math.Pow((Math.Pow((mouse.X - center.X), 2) + Math.Pow((mouse.Y - center.Y), 2)), 0.5);
            if (length <= 251) return true;
            else return false;
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(Circle, position, Color.White);
            spriteBatch.End();

            //spriteBatch.Draw(BackGround, new Rectangle(0, 0, 800, 480), Color.White);
            // TODO: Add your drawing code here
            base.Draw(gameTime);
            //spriteBatch.End();
        }
    }
}
