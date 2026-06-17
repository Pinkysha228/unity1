using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] waypoints; 
    public float speed = 2f;
    private int currentPointIndex = 0;
    public GameObject player;
    public float pushForce = 10f; 

    private void Update()
    {
        if (waypoints.Length == 0) return;
        Transform targetPoint = waypoints[currentPointIndex];
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex++;
            if (currentPointIndex >= waypoints.Length)
            {
                currentPointIndex = 0;
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.hp -= 20;
            }
            
            Rigidbody2D player_rb = player.GetComponent<Rigidbody2D>();
            if (player_rb != null)
            {
                Vector2 direction = -player_rb.linearVelocity.normalized;
                
                if (direction == Vector2.zero)
                {
                    direction = new Vector2(transform.position.x > player.transform.position.x ? -1f : 1f, 0.5f).normalized;
                }

                player_rb.AddForce(direction * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}