using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriar : MonoBehaviour {

    // Use this for initialization
    public AudioClip hitAudio;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playAudio()
    {
        AudioSource.PlayClipAtPoint(hitAudio, transform.position);
    }
}
