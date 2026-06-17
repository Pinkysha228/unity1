using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    
    public float offsetX = 0.5f;
    public float offsetY = 0.2f; 

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        float direction = transform.localScale.x > 0 ? 1f : -1f;
        
        Vector3 spawnPosition = new Vector3(
            transform.position.x + (offsetX * direction), 
            transform.position.y + offsetY, 
            transform.position.z
        );
        
        Quaternion spawnRotation = direction > 0 ? Quaternion.identity : Quaternion.Euler(0, 0, 180);
        
        Instantiate(bulletPrefab, spawnPosition, spawnRotation);
    }
}
