using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using purr_mission.Content;
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
        //window dimensions
        private int windowWidth;
        private int windowHeight;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private Bullets bullet;
        private Alien alien;
        private List<Alien> list_aliens;

        private Texture2D tex_cat;
        private Texture2D tex_alien;
        private Texture2D tex_bullet;
        private Vector2 vec_cat;
        private Vector2 vec_alien;
        private Random rng;

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

        //keyboard input for all the classes to get this data
        public KeyboardState prevKb;
        public KeyboardState currentKb;

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
            list_aliens = new List<Alien>();

            //saves window dimensions for other classes to use
            windowHeight = _graphics.GraphicsDevice.Viewport.Height;
            windowWidth = _graphics.GraphicsDevice.Viewport.Width;

            //to use this in randomizing enemies' position
            rng = new Random();
          
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tex_cat = Content.Load<Texture2D>("cat");
            tex_bullet = Content.Load<Texture2D>("bullet");

            //so that we can use 5 aliens at the same time
            for(int i=0; i< 5; i++)
            {
                tex_alien = Content.Load<Texture2D>("small alien");
                //tex2dList_aliens.Add(tex_alien);
                vec_alien = new Vector2(rng.Next(0,                         //lower limit
                                        windowWidth - tex_alien.Width),     //upper limit
                                        
                                         rng.Next(0,                        //lower limit
                                         windowHeight - tex_alien.Height)); //upper limit
                vecList_aliens.Add(vec_alien);

                //saves the data into alien list
                alien = new Alien(tex_alien, vec_alien, windowHeight, windowWidth);
                list_aliens.Add(alien);
            }

            player = new Player(tex_cat, vec_cat, windowWidth, windowHeight, 0);
            bullet = new Bullets(tex_bullet, player.Position);
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

            player.Update(gameTime);
            
            //to make all the aliens move
            for(int i=0; i< list_aliens.Count; i++)
            {
                list_aliens[i].Update(gameTime);
            }

            // BUG/// To ensure that this action happens once the ENTER key is pressed AND released
            if( //prevKb.IsKeyUp(Keys.Enter) && 
               currentKb.IsKeyDown(Keys.Enter))
            {
                //to ensure that bullet comes from player's position 
                bullet.Position = player.Position;
                bullet.Update(gameTime);
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
            player.Draw(_spriteBatch);

            for(int i=0; i < list_aliens.Count; i++)
            {
                list_aliens[i].Draw(_spriteBatch);
            }

            //how to make an object shoot from itself?
            if (currentKb.IsKeyDown(Keys.Enter))
            {
                bullet.Draw(_spriteBatch);
            }
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