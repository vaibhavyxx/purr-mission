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
        public Alien(Texture2D asset, Vector2 position, int windowHeight, int windowWidth) : base(asset, position)
        {
            this.asset = asset;
            this.position = position;
            this.windowHeight = windowHeight;
            this.windowWidth = windowWidth;
        }

        public override void Update(GameTime gameTime)
        {
            //decides the speed of aliens movements
            position.X += 20;
            position.Y += 25;

            //TODO: Add movement here to ensure that they are still in the room and not going out- like boucing
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
            //throw new NotImplementedException();
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
