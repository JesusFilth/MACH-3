using Reflex.Attributes;

public class ButtonToGameMenu : ButtonView
{
    [Inject] private StateMashineUI _stateMashine;

    protected override void OnClick()
    {
        _stateMashine.EnterIn<GameMenuUIState>();
    }
}
