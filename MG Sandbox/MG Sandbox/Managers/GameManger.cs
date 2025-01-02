//GameManger.cs
//
//Use: Main Game Logic used in Game1
//
using System.Collections.Generic;
using MG_Sandbox.Entities;


namespace MG_Sandbox.Managers
{
    internal class GameManager
    {
        List<Entity> entities = new();
        Player player;
        Texture2D spritesheet;
        Texture2D background;

        public GameManager()
        {
            //Load Assets
            background = Globals.Content.Load<Texture2D>("spr_simple_480x270"); 
            spritesheet = Globals.Content.Load<Texture2D>("spr_player_regaliare");
            player = new Player(spritesheet, new Vector2(0, 0), Color.White);
            entities.Add(player);
            player.LoadContent();
        }
        //
        //
        public void Update()
        {
            InputManager.Update();
            foreach (var entity in entities)
            {
                entity.Update();
            }
        }
        //
        //
        public void Draw()
        {
            Globals.SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            foreach (var entity in entities)
            {
                entity.Draw();
            }
            
        }
    }
}
