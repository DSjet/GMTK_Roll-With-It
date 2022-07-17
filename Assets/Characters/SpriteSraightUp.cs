using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSraightUp : MonoBehaviour
{
    Transform parent;
    SpriteRenderer sprite;

    private void Start()
    {
        parent = this.transform.parent;
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        this.transform.rotation = Quaternion.AngleAxis(-1 * transform.rotation.z, Vector3.forward);
        var zRot = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;

        var playerScreenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector2 mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

        if (mouse.x < playerScreenPoint.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
