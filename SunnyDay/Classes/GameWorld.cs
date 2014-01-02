using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class GameWorld
{
    protected Background bgHandle;

    private const int nButtons = 9;
    protected UnitButton[] unitButtons;
    protected int selectedButton;

    protected short nLane = 5;
    protected LaneHandler[] lanes;    
    protected List<BasicUnit> units;
    protected List<BasicUnit> enemyUnits;
    protected Texture2D meleeTex;

    protected ResourceManager resMan;

    private TheGuard tempGuard;

    public GameWorld(ContentManager content)
    {
        //bgHandle = new Background(content);
        resMan = new ResourceManager(content);

        string[] test = new string[2];
        test[0] = "melee";
        test[1] = "range";

        unitButtons = new UnitButton[nButtons];
        for (int i = 0; i < nButtons; i++)
            unitButtons[i] = new UnitButton(content, test[i % 2], new Vector2(22.0f, 33.0f) + new Vector2((i % 3) * 4 + (i % 3) * 56, (float)((int)(i / 3) * (5 + 56))));
        selectedButton = 4;
        unitButtons[selectedButton].IsSelected = true;

        units = new List<BasicUnit>();
        enemyUnits = new List<BasicUnit>();
        meleeTex = content.Load<Texture2D>("theGuard_sprite@6");//melee_sprite");

        lanes = new LaneHandler[nLane];
        Texture2D tempTexture = content.Load<Texture2D>("lane_pannel");
        Vector2 tempPos;
        for (short i = 0; i < nLane; i++)
        {
            tempPos = new Vector2(230.0f, 40f);
            tempPos.Y += (i * 5) + (100 * i);
            lanes[i] = new LaneHandler(tempTexture, tempPos, i);
        }

        //Vector2 tempVec = new Vector2(lanes[2].LanePosition.X + lanes[2].LaneSprite.Width - 80, lanes[2].LanePosition.Y);
        //tempGuard = new TheGuard(lanes[2]);//meleeTex, tempVec, lanes[2], true);
        enemyUnits.Add(tempGuard);
    }

    public void HandleInput(InputHelper inputHelper)
    {
        //TODO: add input handling method calls
        if (inputHelper.KeyPressed(Keys.Right))
        {
            this.MoveSelect(1);
            return;
        }
        if (inputHelper.KeyPressed(Keys.Left))
        {
            this.MoveSelect(-1);
            return;
        }
        if (inputHelper.KeyPressed(Keys.Up))
        {
            this.MoveSelect(-3);
            return;
        }
        if (inputHelper.KeyPressed(Keys.Down))
        {
            this.MoveSelect(3);
            return;
        }

        if (inputHelper.MouseLeftButtonPressed())
        {
            HandleMouse(inputHelper.MousePosition);
            return;
        }
    }

    /// <summary>
    /// Updates every item with update function
    /// </summary>
    /// <param name="gameTime"></param>
    public void Update(GameTime gameTime)
    {
        foreach (BasicUnit unit in units)
            unit.Update(gameTime);

        foreach (BasicUnit eneUnit in enemyUnits)
            eneUnit.Update(gameTime);

        //tempGuard.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)//, Matrix spriteScale)
    {
        //spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);   //start draw

        bgHandle.Draw(gameTime, spriteBatch);   //draw background

        for (int i = 0; i < nButtons; i++)      //draw buttons
            unitButtons[i].Draw(spriteBatch, resMan);

        foreach (LaneHandler lane in lanes)        //draw lane
            lane.Draw(spriteBatch);

        foreach (BasicUnit unit in units)       //draw units
            unit.Draw(gameTime, spriteBatch);

        foreach (BasicUnit eneUnit in enemyUnits)       //draw enemy units
            eneUnit.Draw(gameTime, spriteBatch);

        //tempGuard.Draw(gameTime, spriteBatch);

        //spriteBatch.End();      //end draw
    }

    private void MoveSelect(int step)
    {
        unitButtons[selectedButton].IsSelected = false;
        selectedButton += step;

        //make sure the new selected button is not out of bound, 0 to nButtons.
        if (selectedButton < 0)
            selectedButton = nButtons + selectedButton;
        if (selectedButton >= nButtons)
            selectedButton = selectedButton - nButtons;

        unitButtons[selectedButton].IsSelected = true;
    }

    /// <summary>
    /// Uses the mouse pos to determine if the click was inside a lan.
    /// </summary>
    /// <param name="mousePos"></param>
    public void HandleMouse(Vector2 mousePos)
    {
        for (int i = 0; i < nLane; i++)
        {
            if (lanes[i].isInside(mousePos))
            {
                Console.WriteLine("mouse click at x=" + mousePos.X + " y=" + mousePos.Y + " , in lane " + i);
                //units.Add(new TheGuard(lanes[i]));        //meleeTex, lanes[i].LanePosition, lanes[i]));
                //TODO: send new obj to opponent
            }
        }
    }

    public void updateEnemyUnits(BasicUnit newEneUnit)
    {
    }
}

