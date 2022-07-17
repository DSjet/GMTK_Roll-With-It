using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public Transform HealthBar;

    private void Start()
    {
        HealthBar = GameObject.FindGameObjectWithTag("healthbar").transform;
        HealthBar.gameObject.GetComponent<Image>().fillAmount = GameManager.gameManager._playerHealth.GetPerHealth();
    }

    void Update()
    {
        
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    PlayerTakeDmg(1);
        //    Debug.Log(GameManager.gameManager._playerHealth.Health);
        //}
        
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    PlayerHeal(1);
        //    Debug.Log(GameManager.gameManager._playerHealth.Health);
        //}
        
    }

    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DamageUnit(dmg);
        HealthBar.gameObject.GetComponent<Image>().fillAmount = GameManager.gameManager._playerHealth.GetPerHealth();
    }
    private void PlayerHeal(int heal)
    {
        GameManager.gameManager._playerHealth.HealUnit(heal);
        HealthBar.gameObject.GetComponent<Image>().fillAmount = GameManager.gameManager._playerHealth.GetPerHealth();
    }
}
