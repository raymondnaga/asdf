using UnityEngine;
using System.Collections;
using System;

public class AudioController : GameObjectController {

    private AudioSource sound;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        sound.Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void reset()
    {
        sound.Play();
    }

    public override void move()
    {
        throw new NotImplementedException();
    }

    public void stop()
    {
        sound.Stop();
    }
}
