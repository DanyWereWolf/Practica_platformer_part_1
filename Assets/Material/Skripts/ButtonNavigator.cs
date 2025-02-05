using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonNavigator : MonoBehaviour
{
    public Button[] buttons; 
    private int selectedButtonIndex = -1;
    [Header("Кнопки")]
    public GameObject selectPlay;
    public GameObject newPlayButton;
    public GameObject selectNewPlay;
    public GameObject selectOptions;
    public GameObject selectExit;
    [Header("Панели")]
    public GameObject panelOptions;
    public GameObject panelButtons;
    [Header("Слайдер")]
    public Slider volumeSlider; 
    private const string VolumeKey = "VolumeLevel"; 
    private const string PlayedKey = "Played";
    [Header("Если игрок играл")]
    public Text PlayedText;
    public bool Played;
    void Start()
    {
        LoadVolume();
        Cursor.visible = false;
        SelectButton(0);
        selectPlay.SetActive(true);
    }
    void Update()
    {
        played();
        // Обработка ввода клавиш
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // Выбор кнопки 1
        {
            SelectButton(0);
            selectPlay.SetActive(true);
            selectOptions.SetActive(false);
            selectExit.SetActive(false);
            selectNewPlay.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // Выбор кнопки 2
        {
            SelectButton(2);
            selectPlay.SetActive(false);
            selectOptions.SetActive(false);
            selectExit.SetActive(true);
            selectNewPlay.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // Выбор кнопки 3
        {
            SelectButton(1);
            selectPlay.SetActive(false);
            selectOptions.SetActive(true);
            selectExit.SetActive(false);
            selectNewPlay.SetActive(false);
        }
        //-------------------Блок для доработки главного меню
        // else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // Выбор кнопки 4
        // {
        //    SelectButton(3);
        //     selectPlay.SetActive(false);
        //     selectOptions.SetActive(false);
        //     selectExit.SetActive(false);
        //     selectNewPlay.SetActive(true);
        //  }
       
        // Обработка нажатий клавиш Enter и Space
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedButtonIndex >= 0)
            {
                buttons[selectedButtonIndex].onClick.Invoke(); // Активируем выбранную кнопку
            }
        }
        // Обработка нажатий клавиш Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelOptions.SetActive(false);
            panelButtons.SetActive(true);
            SaveVolume(); // Сохраняем уровень громкости перед закрытием панели
        }
        if (panelOptions != null)
        {
            EventSystem.current.SetSelectedGameObject(volumeSlider.gameObject);
        }
        // Отключение мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Игнорируем нажатие мыши
        }
    }
    public void SelectButton(int index)
    {
        // Убираем выделение со старой кнопки
        if (selectedButtonIndex >= 0)
        {
            ColorBlock colors = buttons[selectedButtonIndex].colors;
            colors.normalColor = Color.gray; // Сбрасываем цвет
            buttons[selectedButtonIndex].colors = colors;
        }

        // Устанавливаем новую выбранную кнопку
        selectedButtonIndex = index;
        ColorBlock newColors = buttons[selectedButtonIndex].colors;
        newColors.normalColor = Color.white; // Изменяем цвет выделенной кнопки
        buttons[selectedButtonIndex].colors = newColors;
    }
    public void LoadVolume()
    {
        // Проверяем, существует ли сохранённое значение
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            float volume = PlayerPrefs.GetFloat(VolumeKey);
            volumeSlider.value = volume; // Устанавливаем значение слайдера
        }
        else
        {
            volumeSlider.value = 1.0f; // Устанавливаем значение по умолчанию, если нет сохранённого значения
        }

        // Проверяем, существует ли сохранённое значение
        if (PlayerPrefs.HasKey(PlayedKey))
        {
            Played = PlayerPrefs.GetInt(PlayedKey) == 1; // Загружаем значение и преобразуем в bool
        }
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(VolumeKey, volumeSlider.value); // Сохраняем текущее значение слайдера
        PlayerPrefs.SetInt(PlayedKey, Played ? 1 : 0); // Сохраняем значение как int (1 для true, 0 для false)
        PlayerPrefs.Save(); // Сохраняем изменения
    }
    public void played()
    {
        if (Played == false)
        {
            PlayedText.text = "Новая игра";
            newPlayButton.SetActive(false);
        }
        else if (Played == true)
        {
            PlayedText.text = "Продолжить";
            newPlayButton.SetActive(true);
        }
    }

}
