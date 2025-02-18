using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Health health;
    private Animator animator;
    public Image helBar;
    public float healFloat;
    private PlayerInput playerInput;
    private PlayerMovment playerMovment;
    private void Awake()
    {
        playerMovment = GetComponent<PlayerMovment>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
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
            Debug.Log("Наш герой погиб");
        }
    }

}
