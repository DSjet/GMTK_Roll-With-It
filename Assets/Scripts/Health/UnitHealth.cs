using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    //Fields
    float _curHealth;
    float _curMaxHealth;

    //Props
    public float Health
    {
        get
        {
            return _curHealth;
        }
        set
        {
            _curHealth = value;
        }
    }
    public float MaxHealth
    {
        get
        {
            return _curMaxHealth;
        }
        set
        {
            _curMaxHealth = value;
        }
    }

    //constructors
    public UnitHealth(int health, int maxhealth)
    {
        _curHealth = health;
        _curMaxHealth = maxhealth;
    }

    //methods
    public void DamageUnit(int dmgAmount)
    {
        if(_curHealth > 0)
        {
            _curHealth -= dmgAmount;
        }
    }
    public void HealUnit(int healmount)
    {
        if (_curHealth < _curMaxHealth)
        {
            _curHealth += healmount;
        }
        if (_curHealth > _curMaxHealth) _curHealth = _curMaxHealth;
    }
    public float GetPerHealth()
    {
        return _curHealth / _curMaxHealth;
    }
    public void SetMaxhealth(float maxhealth)
    {
        _curMaxHealth = maxhealth;
    }
}
