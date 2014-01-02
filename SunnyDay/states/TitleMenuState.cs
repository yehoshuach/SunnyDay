using Microsoft.Xna.Framework;

class TitleMenuState : GameObjectList
{
    protected Button playButton;

    public TitleMenuState()
    {
        //load title screen
        SpriteGameObject titleScreen = new SpriteGameObject("Backgrounds/spr_title", 0, "background");
        this.Add(titleScreen);

        //add play button
        playButton = new Button("Buttons/spr_button_play", 1);
        playButton.Position = new Vector2((GameEnvironment.Screen.X - playButton.Width) / 2, 540);
        this.Add(playButton);

        //TODO: add more buttons (options, exit, friends, etc.)
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (playButton.Pressed)
            GameEnvironment.GameStateManager.SwitchTo("playingState");
    }
}
