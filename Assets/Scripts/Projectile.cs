using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ProjectileData data; 

    private void Start()
    {        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * data.speed;

        Destroy(this.gameObject, 2f); 
    }
}
