using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    private Health health;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
    }
    private void Update()
    {
        if (health.isAlive == false)
        {
            Debug.Log("Враг повержен");
            animator.SetBool("Die", true);
            StartCoroutine(DestroyObject());
        }
    }
    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Players"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
