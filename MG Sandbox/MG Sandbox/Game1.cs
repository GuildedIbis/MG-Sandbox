using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace MG_Sandbox
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        List<Entity> entities = new();
        Player player;
        Texture2D spritesheet;
        
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize(); 
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Load Assets
            spritesheet = Content.Load<Texture2D>("spr_player_regaliare");
            player = new Player(spritesheet, new Vector2(0, 0), Color.White);
            //Debug.WriteLine(entities.GetType);
            entities.Add(player);
            player.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            //Close Game Window
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
                
            //Main Loop
            foreach (var entity in entities)
            {
                //Debug.WriteLine(entity);
                entity.Update(gameTime);
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Window Base Color
            GraphicsDevice.Clear(Color.DarkGreen);

            //Main Render
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var entity in entities)
            {
                entity.Draw(gameTime, _spriteBatch);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
