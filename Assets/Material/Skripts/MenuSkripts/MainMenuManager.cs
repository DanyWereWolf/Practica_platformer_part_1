using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public ButtonNavigator buttonNavigator;
    public SceneLoader sceneLoader;
    [Header("�� ���� � ����")]
    public Animator startGame;
    public GameObject startGamePanel;
    [Header("��������� �������� ����")]
    public Animator loadMainMenu;
    public GameObject loadPanel;
    [Header(" �������� ���� �� ����")]
    public GameObject loadPanelGame;

    public int reloading = 0;

    void Start()
    {
        // ������������ �� ����
        if (reloading == 0)
        {
            loadPanelGame.SetActive(false);
            loadPanel.SetActive(true);
            loadMainMenu.Play("LoadMainMenu");
        }
        else if (reloading == 1)
        {
            loadPanel.SetActive(false);
            loadPanelGame.SetActive(true);
        }
        startGamePanel.SetActive(false);
    }
    void Update()
    {
        // ���������, ��������� �� �������� �������� �������� ����
        if (loadMainMenu.GetCurrentAnimatorStateInfo(0).IsName("LoadMainMenu") &&
            loadMainMenu.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            reloading = 1; // ������������� reloading � 1 ����� ��������� �����
        }
        // ���������, ��������� �� �������� ������ ����
        if (startGame.GetCurrentAnimatorStateInfo(0).IsName("StartGamePannel") &&
            startGame.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            sceneLoader.LoadGame();
        }
    }
    private void OnDisable()
    {
        // ��������� �������� reloading ��� ���������� �����
        PlayerPrefs.SetInt("Reloading", reloading);
    }

    private void OnEnable()
    {
        // ��������� �������� reloading ��� �������� �����
        reloading = PlayerPrefs.GetInt("Reloading", 0);
    }
    public void LoadGameAnim()
    {
        startGamePanel.SetActive(true);
        startGame.Play("StartGamePannel");
    }
}
