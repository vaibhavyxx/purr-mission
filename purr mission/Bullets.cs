using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using purr_mission.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//GOALS
/*      When ENTER --> gives out bullet
 *      Checks if it collides with the enemy
 */

namespace purr_mission
{
    public class Bullets : Game_Object
    {
        //not sure about fields

        public Bullets(Texture2D asset, Vector2 position) : base(asset, position)
        {
            this.asset = asset;
            this.position = position;
        }

        /// <summary>
        /// To ensure bullet moves at a constant speed.
        /// </summary>
        /// <param name="gameTime">Takes time parameter</param>
        public override void Update(GameTime gameTime)
        {
            //KeyboardState currentKb = Keyboard.GetState();
            position.X += 10;
            //throw new NotImplementedException();
        }

        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(asset,
                    Position,
                    Color.White);
        }
    }
}
