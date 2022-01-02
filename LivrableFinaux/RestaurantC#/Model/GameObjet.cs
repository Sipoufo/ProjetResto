using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectResto.Models
{
    [NotMapped]
    class GameObjet
    {
        public GameObjet()
        {
            this.Position = new Vector2(0,0);
            this.Color = Color.White;
        }

        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
