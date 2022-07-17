using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject hitEffect;
    public static int enemybulletDamage = 1;

    private void Start()
    {
        StartCoroutine("Expiry");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerBehavior>().PlayerTakeDmg(enemybulletDamage);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        //end hit
        Destroy(gameObject);
    }

    private IEnumerator Expiry()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
