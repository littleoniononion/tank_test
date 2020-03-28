using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {
    // 0.老家 1.墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙
    public GameObject[] item;
    private List<Vector3> itemPositionList = new List<Vector3>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Awake()
    {
        InitMap();
    }

    private void InitMap()
    {
        //实例化老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        //用墙吧老家围起来
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        //初始化玩家
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.transform.parent = gameObject.transform;
        go.GetComponent<born>().createPlayer = true;

        //产生敌人
        CreateItem(item[3], new Vector3(-9, 7, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 7, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(9, 7, 0), Quaternion.identity);

        InvokeRepeating("createEnemy", 4, 2);
        //实例化地图,20墙
        for (int i = 0; i < 40; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }
    }

    private void CreateItem(GameObject createGameObject,Vector3 createPos, Quaternion createRotaion)
    {
        GameObject temp = Instantiate(createGameObject, createPos, createRotaion);
        temp.transform.parent = gameObject.transform;
        itemPositionList.Add(createPos);
    }
    //产生随机位置的方法
    private Vector3 CreateRandomPosition()
    {
        Vector3 createPosiotion = new Vector3(Random.Range(-9, 10), Random.Range(-7, 7), 0);
        while (itemPositionList.Contains(createPosiotion))
        {
            createPosiotion = new Vector3(Random.Range(-9, 10), Random.Range(-7, 7), 0);
        }
        itemPositionList.Add(createPosiotion);
        return createPosiotion;
    }

    private void createEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if(num == 0)
        {
            EnemyPos = new Vector3(-9, 7, 0);
        }else if(num == 1)
        {
            EnemyPos = new Vector3(0, 7, 0);
        }
        else
        {
            EnemyPos = new Vector3(9, 7, 0);
        }
        GameObject temp = Instantiate(item[3], EnemyPos, Quaternion.identity);
        temp.transform.parent = gameObject.transform;

    }
}
