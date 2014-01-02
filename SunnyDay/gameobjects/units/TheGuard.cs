using Microsoft.Xna.Framework;

class TheGuard: BasicUnit
{
    /// <summary>
    /// The Guard Constractor.
    /// Gets the info needed and sets it to the appropriate property
    /// </summary>
    /// <param name="id"></param>
    /// <param name="layer"></param>
    public TheGuard(bool isPlayer = true, string id = "", int layer = 0)
        : base(isPlayer, id, layer)
    {
        this.LoadAnimation("Units/theGuard_sprite@6", "guardWalk", true, 0.2f);
        this.PlayAnimation("guardWalk");
        
        Reset();

        //TODO: Improve state values
        this.name = "theGuard";
        this.Health = 30;
        this.Attack = 5;
        this.Defence = 4;
        this.Range = new Vector2(30.0f, 0.0f);
        SetVelocity();    //base.Velocity = new Vector2(20.0f, 0.0f);
        this.Visible = true;
    }

    public override void Reset()
    {
        this.Visible = false;
        this.velocity = Vector2.Zero;
    }

    public override bool inRange(BasicUnit otherObj)
    {
        return base.inRange(otherObj);
    }

    public override void SetVelocity()
    {
        base.Velocity = new Vector2(20.0f, 0.0f);
    }
}

