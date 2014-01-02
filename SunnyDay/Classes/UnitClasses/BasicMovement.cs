using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
/// <summary>
/// No need?
/// </summary>
class BasicMovement
{
    protected Vector2 Velocity;
    
    public BasicMovement(float stepX, float stepY)
    {
        Velocity = new Vector2(stepX, stepY);
    }

    /// <summary>
    /// This function uses the original position to calculate the new position and return the new position vector.
    /// </summary>
    /// <param name="origPos">Original Position</param>
    /// <returns>a new vector</returns>
    public virtual Vector2 GetDistance(float totalSecs)
    {
        return (Velocity * totalSecs);
    }
}
