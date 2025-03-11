using System.Collections;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator anim;
    public GameObject inf;
    public bool isOpen = false;

    private void Start()
    {
        anim.enabled = false;
        inf.SetActive(false);
        anim.GetComponent<Animator>();
    }
    private IEnumerator Open()
    {
        yield return new WaitForSeconds(1f);
        GameManager.instance.AddScore(1000);
        Destroy(gameObject);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && isOpen == false)
        {
            anim.enabled = true;
            inf.SetActive(false);
            StartCoroutine(Open());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Players"))
        {
            inf.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inf.SetActive(false);
    }
}
