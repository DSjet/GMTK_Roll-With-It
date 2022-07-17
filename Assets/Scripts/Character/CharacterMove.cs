using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    public Animator animator;

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
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("Walk", true);
        }else
        {
            animator.SetBool("Walk", false);

        }

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //move player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        //player direction
        Vector2 lookAt = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookAt.y, lookAt.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
