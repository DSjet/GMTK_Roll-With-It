using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraight : MonoBehaviour
{
    Transform parent;
    Transform player;
    SpriteRenderer sprite;

    private void Start()
    {
        parent = this.transform.parent;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        this.transform.rotation = Quaternion.AngleAxis(-1 * transform.rotation.z, Vector3.forward);
        var zRot = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;

        if (player.position.x > this.transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
