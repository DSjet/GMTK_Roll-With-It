using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    public Vector2 movement;
    public Vector2 mousePosition;

    private void Start()
    {
        cam = Camera.main;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //move player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //player direction
        Vector2 lookAt = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
