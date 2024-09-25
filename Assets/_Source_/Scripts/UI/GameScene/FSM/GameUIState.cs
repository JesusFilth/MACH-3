using System;

public abstract class GameUIState
{
    private IGameView _view;

    public GameUIState(IGameView view)
    {
        if (view == null)
            throw new ArgumentNullException(nameof(view));

        _view = view;
    }

    public virtual void Open() => _view.Show();

    public virtual void Close() => _view.Hide();
}
