using UnityEngine;
using System.Collections;

public class ObstacleController : GameObjectController {

    public PlayerController player;
    private float xPos;
    public Sprite semak;
    public Sprite batu;

    void Update()
    {
        //xPos = player.transform.position.x;
    }

    void Start()
    {
        this.startPos = transform.position;
        if (name == "semak")
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-10, 10);
            transform.position = pos;
            if (Random.value >= 0.5)
            {
                changeToBatu();
            }
            else
            {
                changeToSemak();
            }
        }
        else
        {
            Vector3 pos = transform.position;
            pos.x += Random.Range(-5, 10);
            pos.y = random();
            transform.position = pos;
        }
    }

	public override void move()
    {
        //Debug.Log("lalala");

        if (name == "semak")
        {
            Vector3 pos = transform.position;
            pos.x = xPos;
            pos.x += Random.Range(30,50);
            transform.position = pos;
            if (Random.value >= 0.5)
            {
                changeToBatu();
            }else
            {
                changeToSemak();
            }
        }else
        {
            Vector3 pos = transform.position;
            pos.x = xPos;
            pos.x += Random.Range(40, 60);
            pos.y = random();
            transform.position = pos;
        }
    }

    public override void reset()
    {
        transform.position = startPos;
        Start();
    }

    private float random()
    {
        float res = 0;
        do
        {
            res = Random.Range(4.4f, 12.4f);
        } while (res > 8 && res < 12);
        //Debug.Log(res);
        return res;
    }

    public void setX(float x)
    {
        this.xPos = x;
    }

    void changeToSemak()
    {
        GetComponent<SpriteRenderer>().sprite = semak;
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = new Vector3(transform.position.x,2.7f, transform.position.z);
        GetComponent<BoxCollider2D>().transform.localScale= new Vector3(1, 1, 1);
    }

    void changeToBatu()
    {
        GetComponent<SpriteRenderer>().sprite = batu;
        transform.localScale = new Vector3(0.8f,0.8f,0.8f);
        transform.position = new Vector3(transform.position.x, 2.3f, transform.position.z);
        GetComponent<BoxCollider2D>().size = new Vector2(6, 3);
    }
}
