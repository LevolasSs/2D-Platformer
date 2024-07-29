using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim; 
    private bool grounded;

    private void Awake()
    {
        //grab reference for rigidbody from object
        body = GetComponent<Rigidbody2D>();
        //grab reference for animator from object
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        //walk
        body.velocity = new Vector2(HorizontalInput * speed,body.velocity.y);

        //jump
        if(Input.GetKey(KeyCode.Space) && grounded) {
            jump();
        }

        //flip player to left and right
        if(HorizontalInput > 0.01f) {
            transform.localScale = Vector3.one;
        }
        else if(HorizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //set animator parameters
        anim.SetBool("run", HorizontalInput != 0);
        anim.SetBool("grounded", grounded); 
    }

    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, 5);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }
}
