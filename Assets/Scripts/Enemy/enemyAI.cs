using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;


    public bool shouldRotate;

    public LayerMask playerLayer;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float angle;
    public Vector3 dir;
    public static Animator anim;

    public static bool isInChaseRange;
    public static bool isInAttackRange;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        
        transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));

    }
    private void Update()
    {
        anim.SetBool("isMoving", isInChaseRange);
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, playerLayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, playerLayer);
        
        dir = target.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //bool flipped = movement.x < 0;
        //transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 0f : 180f, 0f));
        dir.Normalize();
        movement = dir;
        if(shouldRotate)
        {
            anim.SetFloat("X", dir.x);
            anim.SetFloat("Y", dir.y);
        }
    }

    private void FixedUpdate()
    {
        if(isInChaseRange && !isInAttackRange)
        {
            rb.rotation = angle;
            MoveCharacter(movement);
        }
        if(isInAttackRange)
        {
            rb.rotation = angle;
            rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }
}
