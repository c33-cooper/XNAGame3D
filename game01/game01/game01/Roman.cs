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
    class Roman : GameObject
    {
        // Class constructor
        public Roman(string fileName, ContentManager content)
            : base(fileName, content)
        {
            // appropriate values
            scale = 100.0f;
            pitch = 0.0f;
            yaw = 0.0f;
            roll = 0.0f;
            position = new Vector3(0.0f, 1.0f, 90.0f);
            worldMatrix = Matrix.Identity;
        }
    }
}
