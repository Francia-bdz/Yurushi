using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 17;
    [SerializeField] private float groundedDistance = 2;
    [SerializeField] private LayerMask groundedMask;


    Rigidbody2D rb2D;
    SpriteRenderer sr;
    public Animator animator;

    public int nombreSouvenirs = 2;
    public int nombreSouvenirsRecuperes = 0;
    [SerializeField] private List<GameObject> souvenirs;
    bool isSouvenirOn = false;
    public string LevelToLoad;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetSouvenirDisplay();
        }

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
        if (Input.GetKey(KeyCode.RightArrow) && !isSouvenirOn)
        {
            transform.position = transform.position + speed * Time.deltaTime * Vector3.right;
            //IsMoving
            animator.SetBool("IsMoving", true);
            sr.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !isSouvenirOn)
        {
            transform.position = transform.position + speed * Time.deltaTime * Vector3.left;
            animator.SetBool("IsMoving", true);
            sr.flipX = true;
        }
        else
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

    private void ResetSouvenirDisplay()
    {
        for (int i = 0; i < souvenirs.Count; i++)
        {
            souvenirs[i].SetActive(false);
        }

        isSouvenirOn = false;
    }

    void LoadLevel(Collision2D collision)
    {
        if (collision.gameObject.tag == "Statue" && nombreSouvenirsRecuperes == nombreSouvenirs)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == "Souvenir")
        {

            Destroy(collision.gameObject);
            Thread.Sleep(200);
            souvenirs[nombreSouvenirsRecuperes].SetActive(true);
            nombreSouvenirsRecuperes++;
            isSouvenirOn = true;
        }

        LoadLevel(collision);


    }
}
