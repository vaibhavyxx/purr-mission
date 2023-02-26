using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace purr_mission
{
    enum States
    {
        Title,
        Game,
        GameOver
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D tex_cat;
        private Texture2D tex_alien;
        private Vector2 vec_cat;
        private Vector2 vec_alien;

        //to store for n amount of aliens
        private List<Vector2> vecList_aliens;
        private List<Texture2D> tex2dList_aliens;

        #region
        //for animation
        private double fps;
        private double secondsPerFrame;
        private double timer;
        private int playersCurrentFrame;
        private int numSprites;
        private double widthSingleSprite;
        #endregion

        //keyboard input
        private KeyboardState prevKb;
        private KeyboardState currentKb;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            prevKb = Keyboard.GetState();
            vecList_aliens = new List<Vector2>();
            tex2dList_aliens = new List<Texture2D>();
          
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tex_cat = Content.Load<Texture2D>("cat");

            //so that we can use 5 aliens at the same time
            for(int i=0; i< 5; i++)
            {
                tex_alien = Content.Load<Texture2D>("alien");
                tex2dList_aliens.Add(tex_alien);
            }

            #region
            //ISSUE W ANIMATION
            //Loading sprite sheet and filling in sprite data
            /*tex_player = Content.Load<Texture2D>("MarioSpriteSheet");
            numSprites = 4;
            widthSingleSprite = tex_player.Width / numSprites;

            //decides where will the player be placed into the game window
            vect_playerPos = new Vector2(200,200);

            //animation data
            fps = 8.0;
            secondsPerFrame = 1.0 / fps;
            timer = 0;
            playersCurrentFrame = 1;*/
            #endregion
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            currentKb = Keyboard.GetState();

            // BUG/// To ensure that this action happens once the ENTER key is pressed AND released
            if(//prevKb.IsKeyUp(Keys.Enter) && 
               currentKb.IsKeyDown(Keys.Enter))
            {
                //add the animation
                //UpdateAnimation(gameTime);
            }

            base.Update(gameTime);

            //ensures its a single frame
            prevKb = currentKb;
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            //DrawPlayer(SpriteEffects.FlipVertically);
            _spriteBatch.End();
            base.Draw(gameTime);
        }

        #region
        /*/// <summary>
		/// Helper for updating player's animation based on time
		/// </summary>
		/// <param name="gameTime">Info about time from MonoGame</param>
        private void UpdateAnimation(GameTime gameTime)
        {
            //to ensure smooth
            timer += gameTime.ElapsedGameTime.TotalSeconds;

            if(timer >= secondsPerFrame)
            {
                playersCurrentFrame++;

                //to loop the animation
                if(playersCurrentFrame >= 4)
                {
                    playersCurrentFrame = 1;
                }
            }
            //reset the timer
            timer -= secondsPerFrame;
        }

        private void DrawPlayer(SpriteEffects flip)
        {
            _spriteBatch.Draw(
                tex_player,
                vect_playerPos,
                new Rectangle(
                    (int)(playersCurrentFrame * widthSingleSprite),
                    0,
                    (int)widthSingleSprite,
                    tex_player.Height),
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    1.0f,
                    flip,
                    0.0f);
        }*/
        #endregion
    }
}