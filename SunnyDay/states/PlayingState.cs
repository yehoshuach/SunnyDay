using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

class PlayingState : GameObjectList
{
    protected ContentManager content;
    protected Background bgHandle;

    protected short nLane = 5;
    protected int unitsCounter;
    protected int lastMiliSec;
    protected int battleSlower;

    protected BasicUnit player, opponent;

    public PlayingState(ContentManager content)
    {
        this.content = content;
        LoadArena();
    }

    public void LoadArena()
    {
        battleSlower = 300;
        lastMiliSec = 0;
        bgHandle = new Background();
        this.Add(bgHandle);
        SpriteGameObject rp = (SpriteGameObject)bgHandle.Find("rightpannel");
        float x = rp.Position.X + 4.0f;

        for (short i = 0; i < nLane; i++)
        {
            string id = "lane_" + i;
            Button lane = new Button("Backgrounds/lane_pannel", 1, id);
            float y = rp.Position.Y + (4.0f * (i + 1)) + (147.0f * i);
            lane.Position = new Vector2(x, y);
            this.Add(lane);
        }

        BasicUnit enemy = new TheGuard(false, "eguard", 2);
        SpriteGameObject laneX = (SpriteGameObject)Find("lane_1");
        enemy.Position = laneX.GlobalPosition + new Vector2(laneX.Width - 800 - (enemy.Sprite.Width / 2), 80);
        enemy.Mirror = true;
        this.Add(enemy);

        player = new Player(true, "player", 3);
        opponent = new Player(false, "opponent", 3);
        opponent.Mirror = true;
        SpriteGameObject lp = (SpriteGameObject)bgHandle.Find("leftpannel");
        player.Position = new Vector2(lp.GlobalPosition.X + (float)lp.Width + (float)GameEnvironment.Screen.X * 0.0025f + player.Origin.X, lp.Position.Y + lp.Height);
        opponent.Position = new Vector2(rp.GlobalPosition.X + rp.Width + (float)GameEnvironment.Screen.X * 0.0025f + player.Origin.X, lp.Position.Y + lp.Height);
        this.Add(player);
        this.Add(opponent);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);

        if (inputHelper.MouseLeftButtonPressed())
        {
            for (short i = 0; i < nLane; i++)
            {
                Button ln = (Button)Find("lane_" + i);
                if (ln.Pressed)
                {
                    System.Console.Out.WriteLine("lane no: " + i + " was pressed");
                    ++unitsCounter;
                    BasicUnit newUnit = new TheGuard(true, "theguard" + unitsCounter, ln.Layer + 1);
                    newUnit.Position = new Vector2(ln.GlobalPosition.X + (newUnit.Sprite.Width / 2), ln.GlobalPosition.Y + newUnit.Sprite.Height);
                    this.Add(newUnit);
                }
            }
        }
    }

    public override void Update(GameTime gameTime)
    {
        List<GameObject> toDel = new List<GameObject>();
        if (Math.Abs(gameTime.TotalGameTime.Milliseconds - lastMiliSec) >= battleSlower)
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj is BasicUnit)
                {
                    BasicUnit thisUnit = (BasicUnit)obj;
                    if (thisUnit.isDead())
                    {
                        toDel.Add(obj);
                        continue;
                    }
                    thisUnit.SetVelocity();
                    foreach (GameObject otherObj in gameObjects)
                    {
                        if (otherObj is BasicUnit && obj != otherObj)// && (obj as BasicUnit).IsPlayer != (otherObj as BasicUnit).IsPlayer)
                        {
                            BasicUnit otherUnit = (BasicUnit)otherObj;
                            if (thisUnit.inRange(otherUnit) && thisUnit.IsPlayer != otherUnit.IsPlayer)
                            {
                                thisUnit.Velocity = Vector2.Zero;

                                //if (thisUnit.IsPlayer != otherUnit.IsPlayer)
                                (otherObj as BasicUnit).Health -= (obj as BasicUnit).Attack;

                                /*if ((otherObj as BasicUnit).isDead())
                                    toDel.Add(otherObj);*/
                            }
                        }
                    }
                }
            }
            foreach (GameObject obj in toDel)
                this.Remove(obj);
            lastMiliSec = gameTime.TotalGameTime.Milliseconds;

            this.PC(gameTime);
        }        
        base.Update(gameTime);
    }

    private void PC(GameTime gameTime)
    {
        int spawnTime = GameEnvironment.Random.Next(1133);
        int spawnTime2 = GameEnvironment.Random.Next(1133);

        if ((spawnTime < gameTime.TotalGameTime.TotalMilliseconds % 1133) && (spawnTime2 > gameTime.TotalGameTime.TotalMilliseconds % 1133))
        {
            BasicUnit enemy = new TheGuard(false, "eguard", 2);
            string ln = "lane_";
            ln += GameEnvironment.Random.Next(5);
            SpriteGameObject laneX = (SpriteGameObject)Find(ln);
            enemy.Position = laneX.GlobalPosition + new Vector2(laneX.Width - (enemy.Sprite.Width / 2), 80);
            enemy.Mirror = true;
            this.Add(enemy);
        }
    }
}