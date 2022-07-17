using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireRate = 5f;
    public bool canShoot = true;

    void Update()
    {
        EnemyAI.anim.SetBool("isAttacking", EnemyAI.isInAttackRange && canShoot);
        if (EnemyAI.anim.GetBool("isAttacking"))
        {
            if (EnemyAI.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                StartCoroutine("BasicFire");
            }
        }
    }

    private IEnumerator BasicFire()
    {
        Shoot();
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    void Shoot()
    {
        //instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        //adding force to bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
