using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emenybullet : MonoBehaviour
{

    public float moveSpeed = 10;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "tank":
                collision.SendMessage("die");

                Destroy(gameObject);
                break;
            case "Wall":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "airbarriar":
            case "Barriar":
                Destroy(gameObject);
                break;
            case "Grass":
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":

                break;
            default:
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}