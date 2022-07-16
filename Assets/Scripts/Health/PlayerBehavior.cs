using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Transform HealthBar;

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
        HealthBar.localScale = new Vector3(GameManager.gameManager._playerHealth.GetPerHealth(), 1f);
    }
    private void PlayerHeal(int heal)
    {
        GameManager.gameManager._playerHealth.HealUnit(heal);
        HealthBar.localScale = new Vector3(GameManager.gameManager._playerHealth.GetPerHealth(), 1f);
    }
}
