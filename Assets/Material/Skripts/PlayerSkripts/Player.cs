using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // ������ �� ��������� SpriteRenderer
    public Color damageColor = Color.red; // ����, ������� ����� ����������� ��� ��������� �����
    public float flashDuration = 0.5f; // �����, �� ������� ���� ����� �������

    private Color originalColor; // �������� ���� �������

    private Health health;
    private Animator animator;
    public Image helBar;
    public float healFloat;
    private PlayerInput playerInput;
    private PlayerMovment playerMovment;
    public GameObject losPannel;
    private void Awake()
    {
        playerMovment = GetComponent<PlayerMovment>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }
    private void Start()
    {
        // ��������� �������� ���� �������
        originalColor = spriteRenderer.color;
    }
    // ����� ��� ��������� �����
    public void TakeDamage()
    {
        // ��������� �������� ��� ��������� �����
        StartCoroutine(FlashDamageColor());
    }

    public void Update()
    {
        healFloat = health.currentHealth / health.maxHealth;
        helBar.fillAmount = healFloat;

        if (health.isAlive == false)
        {
            playerMovment.enabled = false;
            playerInput.enabled = false;
            animator.SetBool("death", true);
            StartCoroutine(Lose());
            Debug.Log("��� ����� �����");
        }
    }
    private IEnumerator FlashDamageColor()
    {
        // ������ ���� �� �������
        spriteRenderer.color = damageColor;

        // ���� ��������� �����
        yield return new WaitForSeconds(flashDuration);

        // ���������� �������� ����
        spriteRenderer.color = originalColor;
    }
    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(1f);
        losPannel.SetActive(true);
        Time.timeScale = 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
            TakeDamage();
        }

    }
}