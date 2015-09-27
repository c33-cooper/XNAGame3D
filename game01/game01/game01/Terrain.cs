using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace game01
{
    class Terrain : GameObject
    {
        // Class Constructor
        public Terrain(string fileName = "", ContentManager content = null)
            : base(fileName, content)
        {
            // Initialise terrain attributes
            scale = 9.0f;
            pitch = 0.0f;
            yaw = 0.0f;
            roll = 0.0f;
        }
    }
}
