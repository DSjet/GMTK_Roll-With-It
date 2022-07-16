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

    private void Update()
    {
        //for testing
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetInt("a1", 0);
            PlayerPrefs.SetInt("a2", 0);
            PlayerPrefs.SetInt("a3", 0);
            PlayerPrefs.SetInt("a4", 0);
            PlayerPrefs.SetInt("a5", 0);
            Powers();
            Debug.Log(PlayerPrefs.GetInt("a1"));

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.SetInt("a1", 1);
            PlayerPrefs.SetInt("a2", 1);
            PlayerPrefs.SetInt("a3", 1);
            PlayerPrefs.SetInt("a4", 1);
            PlayerPrefs.SetInt("a5", 1);
            Debug.Log(PlayerPrefs.GetInt("a1"));
            Powers();
        }
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
            GameManager.gameManager._playerHealth.HealUnit(6);
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
            //...
        }
    }

}
