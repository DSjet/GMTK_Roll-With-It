using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public UnitHealth _unitHealth;
    public int maxHealth = 2;

    private void Start()
    {
        _unitHealth = new UnitHealth(maxHealth, maxHealth);
    }

    public void unitTakeDmg(int dmg)
    {
        _unitHealth.DamageUnit(dmg);
        if (_unitHealth.Health <= 0)
        {
            unitDeath();
        }
    }

    private void unitDeath()
    {
        Destroy(this.gameObject);
    }
}
