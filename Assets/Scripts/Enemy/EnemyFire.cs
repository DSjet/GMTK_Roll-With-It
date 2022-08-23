using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 player;
            player.x = target.position.x;
            player.y = target.position.y;
            Vector2 lookAt = player - rb.position;

            float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
