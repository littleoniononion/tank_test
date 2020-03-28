using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //属性值
    public float moveSpeed = 3;
    private Vector3 bullectEulerAngles;
    private float timeVal = 0;
    private bool isDefended = true;
    private float defendtime = 3f;
    //引用
    private SpriteRenderer sr;
    public Sprite[] sp; //上，右，下，左
    public GameObject bulletpre;
    public GameObject explodepre;
    public GameObject shiedldpre;
    public AudioSource moveAudio;
    public AudioClip[] tankAudio;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //是否属于无敌状态
        if (isDefended)
        {
            shiedldpre.SetActive(true);
            defendtime -= Time.deltaTime;
            if(defendtime <= 0)
            {
                isDefended = false;
                shiedldpre.SetActive(false);
            }
        }
    }

    private void FixedUpdate() //固定物理帧
    {
        if (playManger.Instance.isDefeat) return;
        move(); //坦克的移动方法
        //攻击cd
        if (timeVal >= 0.4f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.fixedDeltaTime;
        }
    }
    private void Attack() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletpre, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
            timeVal = 0f;
        }

    }


    private void move()
    {

        float v = Input.GetAxisRaw("Vertical");
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
        if (Mathf.Abs(v) >= 0.05f)
        {
            moveAudio.clip = tankAudio[0];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        if (v != 0) return;

        float h = Input.GetAxisRaw("Horizontal");
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
        if (Mathf.Abs(h) >= 0.05f)
        {
            moveAudio.clip = tankAudio[0];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }
        else
        {
            moveAudio.clip = tankAudio[1];
            if (!moveAudio.isPlaying)
            {
                moveAudio.Play();
            }
        }

    }

    private void die()
    {
        

        if (isDefended) return;
        playManger.Instance.isDead = true;
        Instantiate(explodepre, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    
}
