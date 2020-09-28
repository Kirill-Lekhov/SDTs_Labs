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

        MouseState mouse;
        private Texture2D Buttons;
        Texture2D BackGround;
        bool BackGroundEnable = false;

        // Кнопки
        public short STATE = 3;
        public button Button1;
        public button Button2;
        public button Button3;
        public bool clicked = false;

        // Для проверки попадания в окружность
        private Texture2D CircleTexture;
        Vector2 CircleCenter;
        private Vector2 CirclePosition = new Vector2(150, 30);
        CircleComp Circle;

        //Для игры в понг
        spriteComp PlayerOneBoard, PlayerTwoBoard, Ball;
        Texture2D GameShapes;
        KeyboardState kbState;
        Rectangle Current_Rect;
        float X_change, Y_change, change = 5;

        //Для "стрельбы" по кубикам
        Random randNum;
        public int Score;
        bool is_win = false;
        int time = 0;

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

            //Для проверки попадания в окружность
            CircleCenter.X = CirclePosition.X + 250 + 8;
            CircleCenter.Y = CirclePosition.Y + 250 + 8;

            //Делает видимым курсор
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

            CircleTexture = Content.Load<Texture2D>("Circle");
            GameShapes = Content.Load<Texture2D>("Shapes");
            Buttons = Content.Load<Texture2D>("Buttons");
            BackGround = Content.Load<Texture2D>("background");

            randNum = new Random();

            LoadGame(STATE);
            // TODO: use this.Content to load your game content here
        }

        protected void LoadGame(short type_objects)
        {
            Components.Clear();
            BackGroundEnable = false;

            switch (type_objects)
            {
                case 0:
                    PlayerOneBoard = new spriteComp(this, ref GameShapes, new Rectangle(0, 0, 20, 100), new Vector2(100, 150));
                    PlayerTwoBoard = new spriteComp(this, ref GameShapes, new Rectangle(26, 0, 20, 100), new Vector2(600, 150));
                    Ball = new spriteComp(this, ref GameShapes, new Rectangle(51, 0, 20, 20), new Vector2(400, 150));

                    Components.Add(PlayerOneBoard);
                    Components.Add(PlayerTwoBoard);
                    Components.Add(Ball);
                    BackGroundEnable = true;

                    break;

                case 1:
                    for (int i = 0; i < 10; i++)
                        Components.Add(new ColoredBoxes(this, ref GameShapes, new Rectangle(51, 0, 20, 20), i));

                    break;

                case 2:
                    Circle = new CircleComp(this, ref CircleTexture, CirclePosition, CircleCenter);
                    Components.Add(Circle);
                    break;

                case 3:
                    Button1 = new button(this, ref Buttons, new Rectangle(0, 100, 100, 50), new Vector2(350, 100));
                    Button2 = new button(this, ref Buttons, new Rectangle(0, 50, 100, 50), new Vector2(350, 175));
                    Button3 = new button(this, ref Buttons, new Rectangle(0, 0, 100, 50), new Vector2(350, 250));
                    Components.Add(Button1);
                    Components.Add(Button2);
                    Components.Add(Button3);
                    break;
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

            mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed)
                clicked = true;

                switch (STATE)
                {
                    case 0:
                        kbState = Keyboard.GetState();
                        Current_Rect = PlayerOneBoard.GetRectangle();
                        X_change = 0;
                        Y_change = 0;

                        if (kbState.IsKeyDown(Keys.Up))
                            Y_change -= change;
                        if (kbState.IsKeyDown(Keys.Down))
                            Y_change += change;
                        if (kbState.IsKeyDown(Keys.Left))
                            X_change -= change;
                        if (kbState.IsKeyDown(Keys.Right))
                            X_change += change;

                        PlayerOneBoard.set_position(X_change, Y_change);

                        if (!PlayerOneBoard.check_all_elements_collision())
                            PlayerOneBoard.set_position(-X_change, -Y_change);

                        PlayerOneBoard.Check();

                        X_change = 0;
                        Y_change = 0;

                        if (kbState.IsKeyDown(Keys.W))
                            Y_change -= change;
                        if (kbState.IsKeyDown(Keys.S))
                            Y_change += change;
                        if (kbState.IsKeyDown(Keys.A))
                            X_change -= change;
                        if (kbState.IsKeyDown(Keys.D))
                            X_change += change;

                        PlayerTwoBoard.set_position(X_change, Y_change);

                        if (!PlayerTwoBoard.check_all_elements_collision())
                            PlayerTwoBoard.set_position(-X_change, -Y_change);

                        PlayerTwoBoard.Check();
                        break;

                    case 1:
                        if (is_win == false)
                        {
                            Window.Title = "Уничтожено " + Score.ToString() + " за " + time + " с.";
                            time = gameTime.TotalGameTime.Seconds;
                        }

                        if (Score == 10 && is_win == false)
                        {
                            Window.Title = "Вы уничтожили всех за: " + time + " с.";
                            is_win = true;
                        }
                        break;

                    case 2:
                        if ((mouse.LeftButton == ButtonState.Released) && (clicked == true))
                        {
                            Console.WriteLine(Circle.IsPointInCircle(mouse));

                            if (Circle.IsPointInCircle(mouse))
                                Window.Title = "Вы попали в мишень!";
                            else
                                Window.Title = "Вы не попали в мишень!";

                            clicked = false;
                        }

                        break;

                    case 3:
                        if ((mouse.LeftButton == ButtonState.Released) && (clicked == true))
                        {
                            if (Button1.Check(mouse))
                                STATE = 0;

                            if (Button2.Check(mouse))
                                STATE = 1;

                            if (Button3.Check(mouse))
                                STATE = 2;

                            clicked = false;
                            LoadGame(STATE);
                        }
                    
                        break;
                }

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

            if (BackGroundEnable)
            {
                spriteBatch.Draw(BackGround, new Rectangle(0, 0, 800, 480), Color.White);
            }
            
            // TODO: Add your drawing code here
            base.Draw(gameTime);
            spriteBatch.End();
            //spriteBatch.End();
        }
    }
}
