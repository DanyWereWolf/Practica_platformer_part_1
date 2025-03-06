using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Players"))
        {
            GameManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }

}
