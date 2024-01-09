using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Player controls;
    public Animator animator;
    public GameObject bullet;
    public Transform bulletHole;
    public float force = 200;
    // Start is called before the first frame update

    void Awake()
    {
        controls = new Player();
        controls.Enable();
        controls.Land.Shoot.performed += ctx => Fire();
    }
    void Fire()
    {
        animator.SetTrigger("shoot");
        GameObject go = Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
        if (GetComponent<PlayerMovement>().isFacingRight)
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * force);
        }
        else
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * force);


    }
}
