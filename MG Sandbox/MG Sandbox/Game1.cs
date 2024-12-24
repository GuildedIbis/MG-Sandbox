using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using System.Collections.Generic;

namespace MG_Sandbox
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        List<Entity> entities;
        Player player;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            entities = new();
            // TODO: use this.Content to load your game content here
            Texture2D player_texture = Content.Load<Texture2D>("spr_gui_healthbar_radial_fill_yellow");
            Texture2D enemy_texture = Content.Load<Texture2D>("spr_gui_healthbar_radial_fill_health");
            entities.Add(new Entity(enemy_texture, new Vector2(100,100), Color.White));
            entities.Add(new Entity(enemy_texture, new Vector2(100,200), Color.White));
            entities.Add(new Entity(enemy_texture, new Vector2(200, 100), Color.White));
            player = new Player(player_texture, new Vector2(200, 200), Color.White);
            entities.Add(player);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            foreach (var sprite in entities)
            {
                sprite.Update(gameTime);
            }
            player.Update(gameTime, entities);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            foreach (var sprite in entities)
            {
                sprite.Draw(_spriteBatch);
            }
            player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
