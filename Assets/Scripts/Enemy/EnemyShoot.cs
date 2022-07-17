using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    AnimatorClipInfo[] m_CurrentClipInfo;

    public float bulletForce = 20f;
    public float fireRate;
    public bool canShoot = true;

    void Update()
    {
        m_CurrentClipInfo = EnemyAI.anim.GetCurrentAnimatorClipInfo(0);
        string name = m_CurrentClipInfo[0].clip.name;
        EnemyAI.anim.SetBool("isAttacking", EnemyAI.isInAttackRange && canShoot);
        if (name == "isShooting" && EnemyAI.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && canShoot)
        {
            StartCoroutine("BasicFire");
            canShoot = false;
        }
    }

    private IEnumerator BasicFire()
    {
        Shoot();
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
