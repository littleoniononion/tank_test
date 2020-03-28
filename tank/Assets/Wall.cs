using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    public GameObject explosionPre;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Die()
    {
        Instantiate(explosionPre, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
