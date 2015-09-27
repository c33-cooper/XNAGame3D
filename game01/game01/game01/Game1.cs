using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace game01
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region GameAttributes

        // Game Attributes
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Create a list of game objects
        List<GameObject> gameObjects = new List<GameObject>();

        // List of gameObjects instances
        Terrain terrain;
        Camera cam;
        Roman roman;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Initialise the camera
            cam = new Camera(MathHelper.ToRadians(45.0f),
                (float)graphics.GraphicsDevice.Viewport.Width /
                (float)graphics.GraphicsDevice.Viewport.Height,
                1.0f, 10000.0f, Vector3.Zero, Vector3.Up);
            cam.position = new Vector3(0.0f, 0.0f, 0.0f);

            // Initialise the roman
            roman = new Roman("Models/Characters/roman", Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Load the terrain object
            terrain = new Terrain("Models/Terrain/terrain", Content);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // used to set up camera
            cam = new Camera(MathHelper.ToRadians(45.0f), // field of view
                (float)graphics.GraphicsDevice.Viewport.Width /
                (float)graphics.GraphicsDevice.Viewport.Height, // aspect ratio
                1.0f, 10000.0f, Vector3.Zero, Vector3.Up);
            cam.position = new Vector3(0.0f, 30.0f, 160.0f); // sets up cameras position

            // roman position
            roman.position = new Vector3(cam.position.X - 5.0f, cam.position.Y - 10.0f,
                cam.position.Z - 5.0f);

            // Add objects to the game objects list
            gameObjects.Add(cam);
            gameObjects.Add(terrain);
            gameObjects.Add(roman);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Update the game objects
            foreach (GameObject go in gameObjects)
            {
                go.update(gameTime);
            }

            cam.target = new Vector3(roman.position.X, roman.position.Y,
                roman.position.Z);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw the gameObjects
            foreach (GameObject go in gameObjects)
            {
                go.draw(cam);
            }

            base.Draw(gameTime);
        }
    }
}
