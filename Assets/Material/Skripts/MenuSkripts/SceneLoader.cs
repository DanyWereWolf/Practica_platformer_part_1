using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public MainMenuManager mainMenu;
    private ButtonNavigator buttonNavigator; // Ссылка на компонент GameState

    [System.Obsolete]
    private void Start()
    {
        buttonNavigator = FindObjectOfType<ButtonNavigator>();
    }
    public void LoadGame()
    {
        if (buttonNavigator != null)
        {
            buttonNavigator.Played = false;
            buttonNavigator.SaveVolume(); // Устанавливаем Played в true и сохраняем состояние
        }
        SceneManager.LoadScene(1);
        Invoke("OnDisable", 0.1f); // Вызываем OnDisable через 0.1 секунды после загрузки сцены
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Invoke("OnEnable", 0.1f); // Вызываем OnEnable через 0.1 секунды после загрузки сцены
        Time.timeScale = 1f;
    }
    public void Exit()
    {
        mainMenu.reloading = 0;
        Application.Quit();
    }
    //-------------------Блок для доработки главного меню
    //public void NewLoadGame()
    //{
    //    if (buttonNavigator != null)
    //    {
    //        buttonNavigator.Played = false;
    //        buttonNavigator.SaveVolume(); // Устанавливаем Played в false и сохраняем состояние
    //    }
    //    SceneManager.LoadScene(1);
    //    Invoke("OnDisable", 0.1f); // Вызываем OnDisable через 0.1 секунды после загрузки сцены
    // }
}