//GameManger.cs
//
//Use: Main Game Logic used in Game1
//
using System.Collections.Generic;


namespace MG_Sandbox.Managers
{
    internal class GameManager
    {
        List<Entity> entities = new();
        Player player;
        Texture2D spritesheet;

        public GameManager()
        {
            //Load Assets
            spritesheet = Globals.Content.Load<Texture2D>("spr_player_regaliare");
            player = new Player(spritesheet, new Vector2(0, 0), Color.White);
            //Debug.WriteLine(entities.GetType);
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
                //Debug.WriteLine(entity);
                entity.Update();
            }
        }
        //
        //
        public void Draw()
        {
            foreach (var entity in entities)
            {
                entity.Draw();
            }
        }
    }
}
