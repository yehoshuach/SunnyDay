using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

/// <summary>
/// This class takes care of the background.
/// It loads the textures and set their position.
/// </summary>
class Background : GameObjectList
{
    //protected static Vector2 LEFT_PAN_POS, RIGHT_PAN_POS;
    //protected static Texture2D leftPan, rightPan;

    public Background()//ContentManager Content)
    {
        SpriteGameObject leftPan = new SpriteGameObject("Backgrounds/left_pannel", 0, "leftpannel");
        leftPan.Position = new Vector2((float)GameEnvironment.Screen.X * 0.0025f, (float)GameEnvironment.Screen.Y * 0.04f);    //(36.0f, 33.0f);
        this.Add(leftPan);

        SpriteGameObject rightPan = new SpriteGameObject("Backgrounds/right_pannel", 0, "rightpannel");
        rightPan.Position = new Vector2(((float)GameEnvironment.Screen.X * 0.0075f) + leftPan.Sprite.Width + 49, (float)GameEnvironment.Screen.Y * 0.04f);
        this.Add(rightPan);

        //set posiotions
        //LEFT_PAN_POS = new Vector2(20.0f, 30.0f);
        //RIGHT_PAN_POS = new Vector2(220.0f, 30.0f);
        //load the textures
        /*leftPan = Content.Load<Texture2D>("Backgrounds/left_pannel");
        rightPan = Content.Load<Texture2D>("Backgrounds/right_pannel");*/
    }

    /*public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        //spriteBatch.Draw(leftPan, LEFT_PAN_POS, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
        //spriteBatch.Draw(rightPan, RIGHT_PAN_POS, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.0f);
    }*/
}