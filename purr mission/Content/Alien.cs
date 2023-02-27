using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*GOALS
 *      dies if shot by bullet
 *      damages players health if touches
 *      random movement
 */
namespace purr_mission.Content
{
    public class Alien : Game_Object
    {
        private int windowHeight;
        private int windowWidth;

        //to calculate amount of distance covered per gametime
        private int xDelta;             
        private int yDelta;
        public Alien(Texture2D asset, Vector2 position, int windowHeight, int windowWidth) : base(asset, position)
        {
            this.asset = asset;
            this.position = position;
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
        }

        //BOUNCE ISSUE not happening
        public override void Update(GameTime gameTime)
        {
            //basic idea
            //moves goes right when x=0 till x= is the windows width
            //now that it has reached window width- we want it to reverse its direction 

            if(position.X < windowWidth- asset.Width && 
               position.X >=0)
            {
                xDelta = 10;
            }
            else if(position.X < 0 &&
                    position.X > windowWidth - windowWidth)
            {
                xDelta = -10;
            }
            position.X += xDelta;

            
        }

        /// <summary>
        /// Draws aliens onto the screen
        /// </summary>
        /// <param name="sb"></param>
        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(
                asset,
                Position,
                Color.White);
            //base.Draw(sb);
        }
    }
}
