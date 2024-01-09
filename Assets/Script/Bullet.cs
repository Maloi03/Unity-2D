using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.tag == "Zombie")
        {
            collision.GetComponent<Zombie>().TakeDamage(25);
            Destroy(gameObject);
        }
    }
/*    void Update()
    {
        //destroy the projectile when it reach a distance of 1000.0f from the origin
        if (transform.position.magnitude > 5.0f)
            Destroy(gameObject);
    }*/
}
