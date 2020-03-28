using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emeny : MonoBehaviour {

    //属性值
    public float moveSpeed = 3;
    private Vector3 bullectEulerAngles;
    private float v=-1;
    private float h;
    private bool isDefended = false;
    //引用
    private SpriteRenderer sr;
    public Sprite[] sp; //上，右，下，左
    public GameObject bulletpre;
    public GameObject explodepre;
    //计时器
    private float timeVal = 0;
    private float timeValChangeDirection=0;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        print(timeVal);
        //攻击的时间间隔
        if (timeVal >= 1.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }

    }

    private void FixedUpdate() //固定物理帧
    {
        move(); //坦克的移动方法
    }
    private void Attack()
    {
        Instantiate(bulletpre, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
        timeVal = 0f;
    }


    private void move()
    {
        if (timeValChangeDirection >= 2)
        {
            int num = Random.Range(0, 8);
            if (num > 5) { v = -1; h = 0; }
            else if (num == 0) { v = 1; h = 0; }
            else if (num > 0 && num <= 2) { h = -1; v = 0; }
            else { h = 1; v = 0; }
            timeValChangeDirection = 0;
        }
        else timeValChangeDirection += Time.fixedDeltaTime;

        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = sp[2];
            bullectEulerAngles = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = sp[0];
            bullectEulerAngles = new Vector3(0, 0, 0);

        }
        if (v != 0) return;

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = sp[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = sp[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }

    }

    private void die()
    {
        if (isDefended) return;
        playManger.Instance.playerScore++;
        Instantiate(explodepre, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            timeValChangeDirection = 4;
        }
    }
}
