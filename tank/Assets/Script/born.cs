﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject[] emenyPrefabList;

    public bool createPlayer;

	// Use this for initialization
	void Start () {
        Invoke("BornTank", 1.0f);
        Destroy(gameObject, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void BornTank()
    {
        if (createPlayer)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(emenyPrefabList[num], transform.position, Quaternion.identity);
        }
    }
}
