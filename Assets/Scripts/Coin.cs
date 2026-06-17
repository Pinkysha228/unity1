using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player playerScript = player.GetComponent<Player>();
            playerScript.coins += 1;
            Destroy(gameObject);
        }
    }
}
