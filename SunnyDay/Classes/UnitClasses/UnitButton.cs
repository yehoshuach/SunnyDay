using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class UnitButton
{
    Texture2D normImg, selectImg;   //The button images are constent throughout the game. They will never change once the game started.
    bool isSelected = false;        //Is this button selected
    string unitName;                //The name of the obj, not sure if needed
    Vector2 loc;                    //The location of the button

    public UnitButton(ContentManager Content, string unitName, Vector2 location)
    {
        this.unitName = unitName;
        /*string normImgName = this.unitName + "_norm";
        string selImgName = this.unitName + "_sel";
        normImg = Content.Load<Texture2D>(normImgName);
        selectImg = Content.Load<Texture2D>(selImgName);*/
        loc.X = location.X;
        loc.Y = location.Y;
    }

    public Vector2 Loc
    {
        get { return loc; }
        set { loc = value; }
    }

    public bool IsSelected
    {
        get { return isSelected; }
        set { isSelected = value; }
    }

    /// <summary>
    /// This function will return a Texture2D based on the bool.
    /// If the bool is true, the selected Image is needed and returned.
    /// Else the normal Image is returned.
    /// </summary>
    /// <param name="selImg">true = Selected, false = Normal</param>
    /// <returns>Texture2D</returns>
    protected Texture2D GetImage(ResourceManager resMan)
    {
        if (isSelected)
            return resMan.GetTexture(unitName, ResourceManager.sprType.unitButtonSele);

        return resMan.GetTexture(unitName, ResourceManager.sprType.unitButtonNorm);
    }

    public virtual void Draw(SpriteBatch spriteBatch, ResourceManager resMan)
    {
        //TODO: hard values
        spriteBatch.Draw(GetImage(resMan), Loc, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0.6f);
    }

}

