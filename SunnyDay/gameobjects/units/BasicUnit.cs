using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class BasicUnit : AnimatedGameObject
{       
    //Units stats
    protected string name;
    protected int hp;
    protected int att, def;
    protected Vector2 range;

    protected bool isPlayer = true;

    public BasicUnit(bool isPlayer = true, string id = "", int layer = 0)
        : base(id, layer)
    {
        this.name = "";
        this.isPlayer = isPlayer;
        range = Vector2.Zero;
    }

    //Protected properties
    protected string Name
    {
        get { return name; }
    }
    public int Health
    {
        get
        {
            System.Console.Out.WriteLine("dying!!");
            return hp; }
        set { hp = value; }
    }
    public int Attack
    {
        get 
        { 
            System.Console.Out.WriteLine("Attacking!!");
            return att;
        }
        set { att = value; }
    }
    public int Defence
    {
        get { return def; }
        set { def = value; }
    }

    public Vector2 Range
    {
        get { return range; }
        set { range = value; }
    }

    //check if obj is dead
    public bool isDead()
    {
        if (hp <= 0)
            return true;
        return false;
    }

    public bool IsPlayer
    {
        get { return isPlayer; }
    }

    private Vector2 GetDistance(float totalSecs)
    {
        return (Velocity * totalSecs);
    }

    public virtual bool inRange(BasicUnit otherObj)
    {
        if (this.RangeBox.Y != otherObj.MyBoundingBox.Y && otherObj.MyBoundingBox.Y != -1.0f)
            return false;
        if (this.Mirror)
        {
            if (this.RangeBox.X <= otherObj.MyBoundingBox.X && this.GlobalPosition.X >= otherObj.GlobalPosition.X)
                return true;
        }
        else
        {
            if (this.RangeBox.X >= otherObj.MyBoundingBox.X && this.GlobalPosition.X <= otherObj.GlobalPosition.X)
                return true;
        }

        return false;
    }
    public virtual void SetVelocity() { }

    public virtual Vector2 MyBoundingBox
    {
        get
        {
            Vector2 temp;
            if (this.Mirror)
                temp = new Vector2(this.GlobalPosition.X, this.GlobalPosition.Y + this.Height);
            else
                temp = new Vector2(this.GlobalPosition.X + Width, this.GlobalPosition.Y + this.Height);
            return temp;

            /*int left = (int)(GlobalPosition.X + origin.X);
            if (!this.Mirror)
                left += (int)(origin.X / 2);
            else
                left -= (int)(origin.X / 2);
            int top = (int)(GlobalPosition.Y - origin.Y);
            return new Rectangle(left, top, (int)(origin.X / 2), Height);*/
        }
    }

    public Vector2 RangeBox
    {
        get
        {
            Vector2 temp;
            if (this.Mirror)
            {
                temp = new Vector2(this.GlobalPosition.X, this.GlobalPosition.Y + this.Height);
                temp -= this.Range;
            }
            else
            {
                temp = new Vector2(this.GlobalPosition.X + Width, this.GlobalPosition.Y + this.Height);
                temp += this.Range;
            }
            return temp;


            //--**--**--**--
            /*int left;
            if (!this.Mirror)
                left = (int)(GlobalPosition.X - origin.X) + (int)this.Range.X;
            else
                left = (int)(GlobalPosition.X + origin.X) - (int)this.Range.X;
            int top = (int)(GlobalPosition.Y - origin.Y) + (int)this.Range.Y;
            return new Rectangle(left, top, (int)((float)Width * 0.05f), Height);*/
        }
    }
}

