using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class BattleRow : GameEnvironment
{
    static void Main()
    {
        BattleRow game = new BattleRow();
        game.Run();
    }

    public BattleRow()
    {
        Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        screen = new Point(1440, 825);
        this.SetFullScreen(false);

        gameStateManager.AddGameState("titleMenu", new TitleMenuState());
        gameStateManager.AddGameState("playingState", new PlayingState(Content));
        gameStateManager.SwitchTo("titleMenu");
    }
}
