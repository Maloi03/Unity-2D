using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isInvincible = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            HealthManager.health--;
            if (HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.Play("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(9, 10);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        isInvincible = true;
        yield return new WaitForSeconds(3);
        isInvincible = false;
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(9, 10, false);
    }
    public void TakeDamage()
    {
        HealthManager.health--;
        if (HealthManager.health <= 0)
        {
            PlayerManager.isGameOver = true;
            AudioManager.instance.Play("GameOver");
            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(GetHurt());
        }
    }
}
