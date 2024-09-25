using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _quitPanel;

    private void OnValidate()
    {
        if (_mainMenuPanel == null)
            throw new ArgumentNullException(nameof(_mainMenuPanel));

        if (_quitPanel == null)
            throw new ArgumentNullException(nameof(_quitPanel));
    }

    public void ToNewGameButton() => SceneManager.LoadScene(GameSceneNames.Game);

    public void ToRecordButton() => SceneManager.LoadScene(GameSceneNames.Records);

    public void ToAboutButton() => SceneManager.LoadScene(GameSceneNames.About);

    public void ToQuitGameButton() => Application.Quit();

    public void ToQuitPanelButton()
    {
        _mainMenuPanel.SetActive(false);
        _quitPanel.SetActive(true);
    }

    public void ToMainMenuPanel()
    {
        _mainMenuPanel.SetActive(true);
        _quitPanel.SetActive(false);
    }
}
