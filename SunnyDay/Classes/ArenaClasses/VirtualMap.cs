using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

class VirtualMap
{
    Vector2 size;
    Vector2 stepSize = Vector2.Zero;

    /// <summary>
    /// Constructor - 
    /// Throws "Size error" exception
    /// </summary>
    /// <param name="PicSize">A vector to the </param>
    public VirtualMap(Vector2 PicSize)
    {
        if (PicSize.X <= 0 || PicSize.Y <= 0)
            throw new Exception("Size Error, cannot be: " + PicSize.X.ToString() + ", " + PicSize.Y.ToString()); 
        size = PicSize;
    }

    //Methods
    public void CreateScale(Vector2 screenSize)
    {
        if (size.X == 0 || size.Y == 0)
            throw new Exception("Odd size error");
        
        float x = screenSize.X / size.X;
        float y = screenSize.Y / size.Y;
        stepSize = new Vector2(x, y);
    }

    public float DistanceToLaneEnd(Vector2 position)
    {
        return Math.Abs(position.X - size.X);
    }

    public Vector2 PositionToScreen(Vector2 position)
    {
        return Vector2.Zero;
    }

    //Calculate different vector distances
    public static double DistanceVecTVec(Vector2 vec1, Vector2 vec2)
    {
        return Math.Sqrt(Math.Pow(vec1.X - vec2.X, 2) + Math.Pow(vec1.Y - vec2.Y, 2));
    }
    public static double DistanceVecTVecX(Vector2 vec1, Vector2 vec2)
    {
        return Math.Abs(vec1.X - vec2.X);
    }
    public static double DistanceVecTVecY(Vector2 vec1, Vector2 vec2)
    {
        return Math.Abs(vec1.Y - vec2.Y);
    }
}
