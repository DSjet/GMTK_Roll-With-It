using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupItems : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = this.gameObject;
        Powers();
    }

    private void Powers()
    {
        if (PlayerPrefs.GetInt("a1") == 1)
        {
            //projectile amount
            player.GetComponent<Shooting>().altShooting = true;
        }
        else
        {
            player.GetComponent<Shooting>().altShooting = false;
        }

        if (PlayerPrefs.GetInt("a2") == 1)
        {
            //projectile speed
            player.GetComponent<Shooting>().fireRate = 0.5f;
        }
        else
        {
            player.GetComponent<Shooting>().fireRate = 1f;
        }

        if (PlayerPrefs.GetInt("a3") == 1)
        {
            //extra health
            GameManager.gameManager._playerHealth.SetMaxhealth(12);
        }
        else
        {
            GameManager.gameManager._playerHealth.SetMaxhealth(6);
        }

        if (PlayerPrefs.GetInt("a4") == 1)
        {
            //bonus atk
            BulletLogic.bulletDamage = 2;
        }
        else
        {
            BulletLogic.bulletDamage = 1;
        }

        if (PlayerPrefs.GetInt("a5") == 1)
        {
            //bonus speed
            player.GetComponent<CharacterMove>().moveSpeed *= 1.25f;
        }
        else
        {
            player.GetComponent<CharacterMove>().moveSpeed = 10f;
        }

        if (PlayerPrefs.GetInt("a6") == 1)
        {
            //faster bullets
            player.GetComponent<Shooting>().bulletForce = 75f;
        }
        else
        {
            player.GetComponent<Shooting>().bulletForce = 50f;
        }
    }

}
