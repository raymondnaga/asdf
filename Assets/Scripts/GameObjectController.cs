using UnityEngine;
using System.Collections;

public abstract class GameObjectController : MonoBehaviour {
    protected Vector3 startPos;

    public abstract void reset();

    public abstract void move();
}
