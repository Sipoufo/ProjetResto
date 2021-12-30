using System;
using System.Collections.Generic;
using System.Text;

namespace Pacman.Core
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    class GameObject
    {
        public Vector2 Position; //position de l'objet
        public Texture2D Texture; //image à afficher

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
