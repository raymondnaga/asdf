using UnityEngine;
using System.Collections;
using System;

public class BorderController : GameObjectController
{
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

    void Start()
    {
        this.startPos = transform.position;
    }
}
