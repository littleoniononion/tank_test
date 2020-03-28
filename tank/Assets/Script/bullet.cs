using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : MonoBehaviour {

    public float moveSpeed = 10;

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                break;
            case "bullet":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Wall":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "airbarriar":
                Destroy(gameObject);
                break;
            case "Barriar":
                collision.SendMessage("playAudio");
                Destroy(gameObject);
                break;
            case "Grass":
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                collision.SendMessage("die");
                Destroy(gameObject);
                break;
            default:
                break;

        }
    }


    // Update is called once per frame
    void Update () {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
	}
}
