using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CircleBehaviour : MonoBehaviour
{

    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 15;
    [SerializeField] private float groundedDistance = 1f;
    [SerializeField] private LayerMask groundedMask;
    Rigidbody2D rb2D;

    public int nombreSouvenirs = 2;
    public int nombreSouvenirsRecuperes = 0;
    [SerializeField] private List<GameObject> souvenirs;
    bool isSouvenirOn = false;
    public string LevelToLoad;


    /*bool mustMakeSouvenirDisappeur = false;
    float souvenirTime = 0f;
    public float maxSouvenirTime = 10f;*/

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Jump();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetSouvenirDisplay();
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

    private void Jump()
    {
        if (isGrounded() && !isSouvenirOn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2D.velocity = jumpForce * Vector2.up;
            }
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !isSouvenirOn)
        {
            transform.position = transform.position + speed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !isSouvenirOn)
        {
            transform.position = transform.position + speed * Time.deltaTime * Vector3.left;
        }
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundedDistance, groundedMask);
        Debug.DrawRay(transform.position, Vector2.down * groundedDistance);

        if (hit.collider == null)
        {
            return false;
        }
        else
        {
            return true;
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

    /* public void LevelUp()
    {
        if (nombreSouvenirsRecuperes == 2)
        {
            SceneManager.LoadScene(Scene2);
        }
    }
  
      */
    void LoadLevel(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pierre" && nombreSouvenirsRecuperes == nombreSouvenirs)
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
    

}
