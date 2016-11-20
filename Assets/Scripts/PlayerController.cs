using UnityEngine;
using System.Collections;
using System;

public class PlayerController : GameObjectController
{

    public float moveSpeed;
    public float jumpForce;
    public float score;
    public bool GodMode;

    private float curSpeed;

    private Rigidbody2D rigidBody;
	private Animator animator;
    private ObstacleController[] obstacles;

    public bool groundTouching;
    public bool isDead;
    public LayerMask groundLayer;
    private Collider2D collider;

    public GameManager theGameManager;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
		animator = GetComponent<Animator>();
        obstacles = FindObjectsOfType<ObstacleController>();
        isDead = false;
        this.startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDead)
        {
            if (groundTouching)
            {
                Debug.Log("dead");
                theGameManager.RestartGame();
                FindObjectOfType<AudioController>().stop();
                GetComponent<AudioSource>().Play();
                return;
            }
        }
        else if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && transform.position.y < 13 && score>1f)
        {
            if (groundTouching)
            {
                jump();
            }
            else
            {
                fly();
            }
        }
        curSpeed = rigidBody.velocity.y;
        score = transform.position.x - startPos.x;
        score *= 2;
        if(score>100 && score%250<1)
        {
            moveSpeed *= 1.03f;
        }
        groundTouching = Physics2D.IsTouchingLayers(collider, groundLayer);
        animator.SetBool("isTouchingGround", groundTouching);
        animator.SetFloat("verticalSpeed", curSpeed);
        run();
    }

    private void jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    private void run()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
    }

    private void fly()
    {
        rigidBody.AddForce(new Vector2(0, 8 * jumpForce));
    }

    IEnumerator OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (GodMode) yield break;
        if (other.gameObject.tag == "killTag")
        {
            for (int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].GetComponent<Collider2D>().isTrigger = true;
            }
            animator.SetBool("isDead", true);
            yield return new WaitForSeconds(0.1f);
            //Debug.Log("hit");
            isDead = true;
            //collider.gameObject.SetActive(false);
        }
    }

    public override void move()
    {
        run();
    }

    public override void reset()
    {
        //collider.isTrigger = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Collider2D>().isTrigger = false;
        }
        isDead = false;
        transform.position = startPos;
        //collider.gameObject.SetActive(true);
        animator.SetBool("isDead", false);
    }

    public void god()
    {
        GodMode = !GodMode;
    }
}
