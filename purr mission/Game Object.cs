using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace purr_mission
{
    public abstract class Game_Object
    {
        //fields for players and NPCs
        protected Texture2D asset;
        protected Vector2 position;

        public Vector2 Position
        {
            set { position = value; }
            get { return position; }
        }

        public Game_Object(Texture2D asset, Vector2 position)
        {
            this.asset = asset;
            this.position = position;
        }

        /// <summary>
        /// Draws sb onscreen
        /// </summary>
        /// <param name="sb">Takes the sprite</param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(
                asset,              //texture
                Position,           //vector
                Color.White);       //color
        }
        /// <summary>
        /// Useful for player movements
        /// </summary>
        /// <param name="gameTime">To update info each frame</param>
        public abstract void Update(GameTime gameTime);
    }
}
