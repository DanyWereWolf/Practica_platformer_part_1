using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public static GameManager instance;
    public Text textScore;
    public Text FinalScore;
    public Text LoseScore;
    public int score;

    public GameObject pausePanel; // Панель паузы
    public GameObject optionPannel;
    private bool isPaused = false; // Состояние паузы

    private int levelComplete;
    private int sceneIndex;

    public PlayerInput playerInput;
    public PlayerMovment playerMovment;

    private EventInstance musicEventOnClick;

    private void Awake()
    {
        // Создаем одиночный экземпляр GameManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Не уничтожать при загрузке новой сцены
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicEventOnClick = RuntimeManager.CreateInstance("event:/Click");
        Vector3 position = transform.position;
        musicEventOnClick.set3DAttributes(RuntimeUtils.To3DAttributes(position));

        pausePanel.SetActive(false);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete", 0); // 0 - значение по умолчанию
        UpdateScoreText();
    }

    public void EndGame()
    {
        if (sceneIndex == 5)
        {
            Invoke("MainMenu", 1f);
        }
        else
        {
            if (levelComplete < sceneIndex)
            {
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            }
            Invoke("NextLevel", 1f);
        }
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Continue()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
        Time.timeScale = 1f;
    }

    public void Repeat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText(); // Обновляем текст счета после изменения
    }

    private void UpdateScoreText()
    {
        LoseScore.text = "Очков: " + score.ToString();
        textScore.text = score.ToString();
        FinalScore.text = "Очков: " + score.ToString();
    }

    private void Update()
    {
        // Проверяем, нажата ли клавиша Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovment.StopSoundMove();
            TogglePause();
        }
        UpdateScoreText();
    }
    private void TogglePause()
    {
        isPaused = !isPaused; // Меняем состояние паузы

        // Активируем или деактивируем панель паузы
        pausePanel.SetActive(isPaused);
        
        // Приостанавливаем или возобновляем игру
        if (isPaused)
        {
            Time.timeScale = 0f; // Приостанавливаем игру
        }
        else
        {
            optionPannel.SetActive(false);
            Time.timeScale = 1f; // Возобновляем игру
        }
    }
    public void EnableControls()
    {
        playerMovment.enabled = true;
        playerInput.enabled = true;
    }
    public void DisableControls()
    {
        playerMovment.enabled = false;
        playerInput.enabled = false;
    }
    public void OnClick()
    {
        musicEventOnClick.start();
    }
}
