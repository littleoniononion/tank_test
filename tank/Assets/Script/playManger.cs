using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playManger : MonoBehaviour {
    //属性值
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead = false;
    public bool isDefeat = false;

    //引用
    public GameObject born;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public GameObject isDefeat_UI;
    //单例模式
    private static playManger instance;

    public static playManger Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isDefeat)
        {
            isDefeat_UI.SetActive(true);
            Invoke("ReturnTotheMenu", 3f);
            return;
        }
        if (isDead) Recover();
        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text = lifeValue.ToString();
    }
    private void Recover()
    {
        if(lifeValue <= 0)
        {
            //游戏失败
            isDefeat = true;

        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.transform.parent = gameObject.transform;
            isDead = false;
            go.GetComponent<born>().createPlayer = true;

        }

    }
    private void ReturnTotheMenu()
    {
        SceneManager.LoadScene(0);
    }

}
