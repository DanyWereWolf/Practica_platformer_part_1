using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public static NextLevel Instance { get; private set; }

    public Animator anim;
    public GameObject nextLoadLevel;

    public GameObject ScorePannel;

    private void Awake()
    {
        // ���������, ���� �� ��� ��������� LevelController
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ��� �������� ����� �����
        }
        else
        {
            Destroy(gameObject); // ������� ���������
        }
    }

    void Start()
    {
        ScorePannel.SetActive(false);
        anim.enabled = false;
        nextLoadLevel.SetActive(false);
    }

   
    private IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        ScorePannel.SetActive(true);
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Players"))
        {
            anim.enabled = true;
            nextLoadLevel.SetActive(true);
            StartCoroutine(nextLevel());
        }
    }
}
