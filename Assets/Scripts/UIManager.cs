using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]GameObject _gameUI;
    [SerializeField]GameObject _gameMenu;
    [SerializeField]GameObject _winScreen;
    // Start is called before the first frame update
    void Start()
    {
        GamescreenReady();
    }
    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("escape")))
        {
            OpenCloseMenu();
        }
    }

    #region Functions
    #region surface level UI Functions
    public void OpenCloseMenu()
    {
        if (!_gameUI.activeSelf && _gameMenu.activeSelf)
        {
            ZaWarudo(false);
            UIChange(_gameMenu, _gameUI);
        }
        else
        {
            if (_gameUI.activeSelf)
            {
                ZaWarudo(true);
                UIChange(_gameUI, _gameMenu);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);//i am reloading scene instead of calling first map, in case something can went wrong
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void WinScreen()
    {
        GamescreenReady();//i am making sure player didnt somehow have menu ui open when winning
        ZaWarudo(true);
        UIChange(_gameUI, _winScreen);
    }
    #endregion
    #region Inside Functions
    public void GamescreenReady()
    {
        ZaWarudo(false);
        _gameUI.SetActive(true);
        _winScreen.SetActive(false);
        _gameMenu.SetActive(false);
    }
    public void UIChange(GameObject obj1, GameObject obj2)
    {
        if (obj1.activeSelf)
        {
            obj1.SetActive(false);
            obj2.SetActive(true);
        }
    }
    public void ZaWarudo(bool time)// this function stops the time, a jojo reference, https://www.youtube.com/watch?v=VtzvlXL9gXk&ab_channel=Sour
    {
        Time.timeScale = time? 0:1;
    }
    #endregion
    #endregion
}
