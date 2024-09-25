using UnityEngine.SceneManagement;

public class ButtonToMainMenu : ButtonView
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(GameSceneNames.MainMenu);
    }
}
