using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//GOALS:
/*      WASD movement
 *      Enter bullet shooting
 *      Potential animation
 *      Take Damage if alien touches them
 */
namespace purr_mission.Content
{
    public class Player : Game_Object
    {
        //dimensions
        private int windowWidth;
        private int windowHeight;
        //here, score can be num of aliens killed?
        private int score;

        public Player(Texture2D asset,  Vector2 position,int windowWidth, int windowHeight, int score):
            base(asset, position)
        {
            this.asset = asset;
            this.position = position;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.score = score;
        }

        /// <summary>
        /// Supports WASD movement with oncreen wrapping
        /// </summary>
        /// <param name="gameTime">Takes in time param to update each frame</param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState currentKb = Keyboard.GetState();

            //to support oncreen wrapping of the sprite
            if ((position.Y + asset.Height) < 0)
            {
                //brings sprite from bottom
                position.Y = windowHeight;
            }
            else if (position.Y > windowHeight)
            {
                //brings sprite from top
                position.Y = -asset.Height;
            }

            if ((position.X + asset.Width) < 0)
            {
                //brings sprite from right
                position.X = windowWidth;
            }
            else if (position.X > windowWidth)
            {
                //brings sprite from left
                position.X = 0 - asset.Width;
            }

            //WASD controls and movement
            if (currentKb.IsKeyDown(Keys.W))
            {
                position.Y -= 3;
            }
            if (currentKb.IsKeyDown(Keys.D))
            {
                position.X += 3;
            }
            if (currentKb.IsKeyDown(Keys.S))
            {
                position.Y += 3;
            }
            if (currentKb.IsKeyDown(Keys.A))
            {
                position.X -= 3;
            }
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(
                asset,
                position,
                Color.White);
        }

    }
}
