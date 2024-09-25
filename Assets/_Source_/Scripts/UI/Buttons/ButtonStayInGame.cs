using Reflex.Attributes;

public class ButtonStayInGame : ButtonView
{
    [Inject] private StateMashineUI _stateMashine;

    protected override void OnClick()
    {
        _stateMashine.EnterIn<GameSceneUIState>();
    }
}
