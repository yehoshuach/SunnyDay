using Microsoft.Xna.Framework;

class Player : BasicUnit
{

    public Player(bool isPlayer, string id = "", int layer = 0)
        : base(isPlayer, id, layer)
    {
        this.LoadAnimation("Backgrounds/player_pannel", "player", false);
        this.PlayAnimation("player");

        this.Health = 1000;
        this.Attack = 0;
        this.Defence = 0;
        this.Range = new Vector2(0.0f, 0.0f);
        this.Visible = true;
    }

    public override Vector2 MyBoundingBox
    {
        get
        {
            Vector2 temp;
            if (this.Mirror)
                temp = new Vector2(this.GlobalPosition.X, -1.0f);
            else
                temp = new Vector2(this.GlobalPosition.X + Width, -1.0f);
            return temp;
        }
    }
}
