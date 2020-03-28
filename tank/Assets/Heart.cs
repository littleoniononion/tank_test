using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    private SpriteRenderer sr;

    public GameObject explosionPre;
    public Sprite Broken;
    public AudioClip DieA;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        sr.sprite = Broken;
        Instantiate(explosionPre, transform.position, transform.rotation);
        playManger.Instance.isDefeat = true;
        AudioSource.PlayClipAtPoint(DieA, transform.position);
    }
    
}
