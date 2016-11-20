using UnityEngine;
using System.Collections;

public class BackgroundMover : MonoBehaviour {

    public int numOfObjects;
    public bool isBG;
    public ObstacleController[] obstacle;

    private Collider2D myCollider;
    private float semakX;
    private float kelelawarX;
    private float max;

    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        obstacle = FindObjectsOfType<ObstacleController>();
        //Debug.Log(obstacle.Length);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        bool first = true;
        //Debug.Log("Triggered " + collider.name);
        //Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.tag=="killTag")
        {
            for (int i = 0; i < obstacle.Length; i++)
            {
                if(collider.name == "semak")
                {
                    semakX = semakX < obstacle[i].transform.position.x ? obstacle[i].transform.position.x : semakX;
                    //max = max < obstacle[i].transform.position.x ? obstacle[i].transform.position.x : max;
                }
                else
                {
                    //max = max < obstacle[i].transform.position.x ? obstacle[i].transform.position.x : max;
                    kelelawarX = kelelawarX < obstacle[i].transform.position.x ? obstacle[i].transform.position.x : kelelawarX;
                }
            }
            if (semakX > kelelawarX)
            {
                if (semakX - kelelawarX < 20)
                {
                    semakX = kelelawarX + Random.Range(20, 30);
                }
            }
            else
            {
                if (kelelawarX - semakX < 20)
                {
                    kelelawarX = semakX + Random.Range(20, 30);
                }
            }
            Debug.Log("semak "+semakX);
            Debug.Log("kelelawar " + kelelawarX);
            ObstacleController tmp = collider.GetComponentInParent<ObstacleController>();
            if (first)
            {
                tmp.setX(FindObjectOfType<PlayerController>().transform.position.x);
                tmp.move();
                first = false;
                return;
            }
            if (collider.name == "semak")
            {
                tmp.setX(semakX);
                //tmp.setX(max);

            }else
            {
                tmp.setX(kelelawarX);
                //tmp.setX(max);
            }
            tmp.move();
        }
        else if(collider.gameObject.tag == "BG")
        {
            collider.GetComponentInParent<BackgroundController>().move();
        }else
        {
            collider.GetComponentInParent<BorderController>().move();
        }
    }
}