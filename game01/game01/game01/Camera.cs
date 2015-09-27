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
    class Camera : GameObject
    {
        #region
        // Camera attributes
        public Matrix projMat { get; private set; }
        public Matrix viewMat { get; set; }

        public float fieldOfView { get; set; }
        public float aspectRatio { get; set; }
        public float nearPlaneDistance { get; set; }
        public float farPlaneDistance { get; set; }

        public Vector3 target { get; set; }
        public Vector3 up { get; set; }

        // cam positions
        float x, y, z;

        // keyboard state
        KeyboardState prevKeyboardState;
        KeyboardState currKeyboardState;

        #endregion

        // Class constructor
        public Camera(float fieldOfView, float aspectRatio, float nearPlaneDistance,
            float farPlaneDistance, Vector3 target, Vector3 up, GameObject parent = null)
        {
            // Initialise attributes
            this.fieldOfView = fieldOfView;
            this.aspectRatio = aspectRatio;
            this.nearPlaneDistance = nearPlaneDistance;
            this.farPlaneDistance = farPlaneDistance;

            this.target = target;
            this.up = up;

            // init positions
            x = 0.0f;
            y = 30.0f;
            z = 160.0f;
        }

        // Update the camera
        public override void update(GameTime gameTime)
        {
            // set the camera projection and view matrices
            projMat = Matrix.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio,
                nearPlaneDistance, farPlaneDistance);
            viewMat = Matrix.CreateLookAt(position, target, up);

            // Initialize current keyboard state
            currKeyboardState = Keyboard.GetState();

            if (currKeyboardState.IsKeyDown(Keys.S))
              position = new Vector3(x, y, z++);
               // target = new Vector3(x, y, z++);
            if (currKeyboardState.IsKeyDown(Keys.W))
                position = new Vector3(x, y, z--);
              //  target = new Vector3(x, y, z--);


            // get new keyboard state
            currKeyboardState = Keyboard.GetState();

            base.update(gameTime);
        }
    }
}
