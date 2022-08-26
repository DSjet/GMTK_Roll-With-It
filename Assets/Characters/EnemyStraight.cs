using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraight : MonoBehaviour
{
    Transform player;
    SpriteRenderer sprite;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player.position.x > this.transform.position.x)
        {
            sprite.flipY = false;
        }
        else
        {
            sprite.flipY = true;
        }
    }
}
