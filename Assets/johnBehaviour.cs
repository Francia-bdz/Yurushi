using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;

public class johnBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 17;
    [SerializeField] private float groundedDistance = 2;
    [SerializeField] private LayerMask groundedMask;


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
        animator.SetFloat("Speed", Mathf.Abs(speed));
        Move();
        
    }


 

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //IsMoving
            animator.SetBool("isMoving", true);
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) )
        {
            animator.SetBool("isMoving", true);
            sr.flipX = true;
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

   

}
