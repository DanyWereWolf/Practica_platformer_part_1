using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonNavigator : MonoBehaviour
{
    public Button[] buttons; 
    private int selectedButtonIndex = -1;
    [Header("������")]
    public GameObject selectPlay;
    public GameObject newPlayButton;
    public GameObject selectNewPlay;
    public GameObject selectOptions;
    public GameObject selectExit;
    [Header("������")]
    public GameObject panelOptions;
    public GameObject panelButtons;
    [Header("�������")]
    public Slider volumeSlider; 
    private const string VolumeKey = "VolumeLevel"; 
    private const string PlayedKey = "Played";
    [Header("���� ����� �����")]
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
        // ��������� ����� ������
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) // ����� ������ 1
        {
            SelectButton(0);
            selectPlay.SetActive(true);
            selectOptions.SetActive(false);
            selectExit.SetActive(false);
            selectNewPlay.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // ����� ������ 2
        {
            SelectButton(2);
            selectPlay.SetActive(false);
            selectOptions.SetActive(false);
            selectExit.SetActive(true);
            selectNewPlay.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) // ����� ������ 3
        {
            SelectButton(1);
            selectPlay.SetActive(false);
            selectOptions.SetActive(true);
            selectExit.SetActive(false);
            selectNewPlay.SetActive(false);
        }
        //-------------------���� ��� ��������� �������� ����
        // else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) // ����� ������ 4
        // {
        //    SelectButton(3);
        //     selectPlay.SetActive(false);
        //     selectOptions.SetActive(false);
        //     selectExit.SetActive(false);
        //     selectNewPlay.SetActive(true);
        //  }
       
        // ��������� ������� ������ Enter � Space
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (selectedButtonIndex >= 0)
            {
                buttons[selectedButtonIndex].onClick.Invoke(); // ���������� ��������� ������
            }
        }
        // ��������� ������� ������ Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panelOptions.SetActive(false);
            panelButtons.SetActive(true);
            SaveVolume(); // ��������� ������� ��������� ����� ��������� ������
        }
        if (panelOptions != null)
        {
            EventSystem.current.SetSelectedGameObject(volumeSlider.gameObject);
        }
        // ���������� ����
        if (Input.GetMouseButtonDown(0))
        {
            // ���������� ������� ����
        }
    }
    public void SelectButton(int index)
    {
        // ������� ��������� �� ������ ������
        if (selectedButtonIndex >= 0)
        {
            ColorBlock colors = buttons[selectedButtonIndex].colors;
            colors.normalColor = Color.gray; // ���������� ����
            buttons[selectedButtonIndex].colors = colors;
        }

        // ������������� ����� ��������� ������
        selectedButtonIndex = index;
        ColorBlock newColors = buttons[selectedButtonIndex].colors;
        newColors.normalColor = Color.white; // �������� ���� ���������� ������
        buttons[selectedButtonIndex].colors = newColors;
    }
    public void LoadVolume()
    {
        // ���������, ���������� �� ���������� ��������
        if (PlayerPrefs.HasKey(VolumeKey))
        {
            float volume = PlayerPrefs.GetFloat(VolumeKey);
            volumeSlider.value = volume; // ������������� �������� ��������
        }
        else
        {
            volumeSlider.value = 1.0f; // ������������� �������� �� ���������, ���� ��� ����������� ��������
        }

        // ���������, ���������� �� ���������� ��������
        if (PlayerPrefs.HasKey(PlayedKey))
        {
            Played = PlayerPrefs.GetInt(PlayedKey) == 1; // ��������� �������� � ����������� � bool
        }
    }
    public void SaveVolume()
    {
        PlayerPrefs.SetFloat(VolumeKey, volumeSlider.value); // ��������� ������� �������� ��������
        PlayerPrefs.SetInt(PlayedKey, Played ? 1 : 0); // ��������� �������� ��� int (1 ��� true, 0 ��� false)
        PlayerPrefs.Save(); // ��������� ���������
    }
    public void played()
    {
        if (Played == false)
        {
            PlayedText.text = "����� ����";
            newPlayButton.SetActive(false);
        }
        else if (Played == true)
        {
            PlayedText.text = "����������";
            newPlayButton.SetActive(true);
        }
    }

}
