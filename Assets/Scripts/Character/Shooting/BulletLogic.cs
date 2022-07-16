using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletLogic : MonoBehaviour
{
    public CinemachineVirtualCamera cam;
    public GameObject hitEffect;
    public static int bulletDamage = 1;

    private void Start()
    {
        cam = GameObject.Find("VCam_Follow").GetComponent<CinemachineVirtualCamera>();
        StartCoroutine("Expiry");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        cam.GetComponent<CinemachineImpulseSource>().GenerateImpulse();
        Destroy(effect, 1f);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().unitTakeDmg(bulletDamage);
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
