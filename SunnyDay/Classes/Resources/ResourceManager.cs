using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class ResourceManager
{
    public enum sprType {unitSprite, unitButtonNorm, unitButtonSele, background};

    Dictionary<string, Texture2D> sprDictionary;
    ContentManager content;

    public ResourceManager(ContentManager content)
    {
        sprDictionary = new Dictionary<string, Texture2D>();
        this.content = content;
    }

    /// <summary>
    /// This function uses the sprType to add the appropriate affix to the wanted sprite,
    /// then try to load the texture from the map, is null is returned (the sprite is not in the map)
    /// uses LoadTexture to load the texture and add it to the map.
    /// </summary>
    /// <param name="sprName">wanted sprite</param>
    /// <param name="spriteType">sprite type (use enum)</param>
    /// <returns>Texture2D of the wanted sprite</returns>
    public Texture2D GetTexture(string sprName, sprType spriteType)
    {
        string sprKey = sprName;
        switch (spriteType)
        {
            case sprType.unitSprite:
                sprKey += "_sprite";
                break;
            case sprType.unitButtonNorm:
                sprKey += "_norm";
                break;
            case sprType.unitButtonSele:
                sprKey += "_sel";
                break;
            case sprType.background:
                sprKey += "_pannel";
                break;
            default:
                return null;
        }

        Texture2D sprTex;
        sprDictionary.TryGetValue(sprKey, out sprTex);

        if (sprTex == null)
            sprTex = LoadTexture(sprKey);

        return sprTex;
    }

    private Texture2D LoadTexture(string sprName)
    {
        Texture2D tempTex = content.Load<Texture2D>(sprName);
        sprDictionary.Add(sprName, tempTex);
        return tempTex;
    }
}

