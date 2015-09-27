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
    class GameObject
    {
        #region Attributes

        // Create the model attribute
        Model model;

        // Attributes for the world transform of the object
        public float scale { get; set; }

        public float yaw { get; set; }
        public float pitch { get; set; }
        public float roll { get; set; }

        public Vector3 position { get; set; }

        // World matrix & fudge matrix object declaration
        public Matrix worldMatrix { get; protected set; }
        public Matrix fudgeMatrix { get; set; }

        #endregion

        // Class constructor
        public GameObject(string fileName = "", ContentManager content = null,
            GameObject parent = null)
        {
            // load required model
            if (content != null)
            {
                model = content.Load<Model>(fileName);
            }

            // Approprioate starting values for world transform data
            scale = 0.0f;
            pitch = 0;
            yaw = 0;
            roll = 0;

            // Setting Fudge matrix
            fudgeMatrix = Matrix.Identity;

        }

        // Update method
        public virtual void update(GameTime gameTime)
        {
            // Create component matrices for world transform
            Matrix rotMat = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll);
            Matrix scaleMat = Matrix.CreateScale(scale);
            Matrix transMat = Matrix.CreateTranslation(position);

            // multiply to create world transform
            worldMatrix = fudgeMatrix * scaleMat * rotMat * transMat;
        }

        // Draw method
        public virtual void draw(Camera cam)
        {
            if (model != null)
            {
                foreach(ModelMesh mesh in model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();
                        effect.PreferPerPixelLighting = true;

                        effect.World = worldMatrix;
                        effect.Projection = cam.projMat;
                        effect.View = cam.viewMat;
                    }
                    mesh.Draw();
                }
            }
        }
    }
}
