using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


class LaneHandler
{
    protected short serialNum;
    protected string laneName;
    protected Texture2D laneSprite;
    protected Vector2 lanePos;

    protected List<BasicUnit> playerUnits;
    protected List<BasicUnit> enemyUnits;

    public LaneHandler(Texture2D sprite, Vector2 pos, short laneNum)
    {
        laneSprite = sprite;
        lanePos = pos;
        serialNum = laneNum;

        playerUnits = new List<BasicUnit>();
        enemyUnits = new List<BasicUnit>();

        laneName = "lane";
    }

    public short SerialNum
    {
        get { return serialNum; }
        set { serialNum = value; }
    }
    public bool isInside(Vector2 vec)
    {
        if (vec.X <= lanePos.X + laneSprite.Width && vec.X >= lanePos.X && vec.Y <= lanePos.Y + laneSprite.Height && vec.Y >= lanePos.Y)
            return true;
        return false;
    }

    public Texture2D LaneSprite
    {
        get { return laneSprite; }
    }

    public Vector2 LanePosition
    {
        get { return lanePos; }
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        //TODO: hard values
        spriteBatch.Draw(laneSprite, lanePos, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.1f);
    }
}

