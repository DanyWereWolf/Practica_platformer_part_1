using UnityEngine;

public class Box : MonoBehaviour
{
    public Explosion explosion; // ������ �� ��������� Explosion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Box"))
        {
            // �������� ����� ��� ����������� �����
            explosion.TriggerExplosion(transform.position);
        }
    }
}
