using UnityEngine;

public class Box : MonoBehaviour
{
    public Explosion explosion; // Ссылка на компонент Explosion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            // Вызываем взрыв при уничтожении ящика
            explosion.TriggerExplosion(transform.position);
        }
    }
}
