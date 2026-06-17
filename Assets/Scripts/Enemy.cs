using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 5f;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}