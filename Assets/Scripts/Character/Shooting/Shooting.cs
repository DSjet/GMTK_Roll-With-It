using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    public float bulletForce = 20f;
    public float fireRate = 1f;
    public bool canShoot = true;
    public bool altShooting = false;
    public Animator animator;

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            animator.SetTrigger("Fire");
            if (!altShooting)
            {
                StartCoroutine("BasicFire");
            }
            else
            {
                StartCoroutine("BurstFire");
            }
        }
    }

    private IEnumerator BasicFire()
    {
        canShoot = false;
        Shoot1();
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
    private IEnumerator BurstFire()
    {
        canShoot = false;
        Shoot1();
        yield return new WaitForSeconds(0.2f);
        Shoot1();
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    void Shoot1()
    {
        //instantiate bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        //adding force to bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
}
