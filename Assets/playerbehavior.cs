using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 17;
    [SerializeField] private float groundedDistance = 2;
    [SerializeField] private LayerMask groundedMask;
    [SerializeField] private GameObject dot;


    Rigidbody2D rb2D;
    SpriteRenderer sr;
    public Animator animator;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(rb2D.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(speed));
        Move();
        Jump();
                
    }


    private void Jump()
    {


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb2D.velocity = jumpForce * Vector3.up;
        }


    }
   
    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + speed * Time.deltaTime * Vector3.right;
            //IsMoving
            animator.SetBool("IsMoving", true);
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + speed * Time.deltaTime * Vector3.left;
            animator.SetBool("IsMoving", true);
            sr.flipX = true;
        } else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance, groundedMask);
        Debug.DrawRay(transform.position, Vector2.down * groundedDistance, Color.red);
        if (hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }

}
