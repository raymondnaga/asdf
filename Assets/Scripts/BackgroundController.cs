using UnityEngine;
using System.Collections;
using System;

public class BackgroundController : GameObjectController
{

    public float moveSpeed;
    private Rigidbody2D rigidBody;
    private PlayerController player;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player").GetComponent<PlayerController>();
        this.startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(moveSpeed, rigidBody.velocity.y);
        if (player.isDead)
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
    }

    public override void move()
    {
        //Debug.Log("move");
        float width = 29.5f;

        Vector3 pos = transform.position;
        pos.x += width * 3;

        transform.position = pos;
    }

    public override void reset()
    {
        transform.position = startPos;
    }
}
