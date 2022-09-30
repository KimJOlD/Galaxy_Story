using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public VariableJoystick joy;
    public GameObject bulletPrefab;
    GameObject[] bullet;
    public Transform bulletPos;
    public gamemanager manager;

    public int life;
    public float speed;
    public float bulletspeed;
    public float maxShotDelay;
    public float curShotDelay;
    public Sprite[] sprites;
    public Image[] lifeImage;

    Rigidbody rigid;
    Animator anim;
    MeshRenderer[] meshs;
   
    Vector3 moveVec;

    bool isDamage = false;
    bool isBorder;

    void Awake()
    {
        bullet = new GameObject[30];

        Generate();
    }
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        meshs = GetComponentsInChildren<MeshRenderer>();
    }
    void Update()
    {
        Move();
        Shot();
        Reload();
    }
    void FixedUpdate()
    {
        freezeRotation();
        StopToWall();
    }
    void Move()
    {
        float x = joy.Horizontal;
        float z = joy.Vertical;

        moveVec = new Vector3(x, 0, z).normalized;
        
        if(!isBorder)
            transform.position += moveVec * speed * Time.deltaTime;

        anim.SetBool("isWalk", moveVec != Vector3.zero);

        transform.LookAt(transform.position + moveVec);
    }

    void Generate()
    {
        for (int index = 0; index < bullet.Length; index++)
        {
            bullet[index] = Instantiate(bulletPrefab);
            bullet[index].SetActive(false);
        }
    }
    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "bullet":
                for (int index = 0; index < bullet.Length; index++)
                {
                    if (!bullet[index].activeSelf)
                    {
                        bullet[index].SetActive(true);
                        return bullet[index];
                    }
                }
                break;
        }
        
        return null;
    }


    GameObject bullets;

    void Shot()
    {
        if (curShotDelay < maxShotDelay)
            return;

        bullets = MakeObj("bullet");
       
        bullets.transform.position = bulletPos.transform.position;
        bullets.transform.rotation = bulletPos.transform.rotation;
        Rigidbody bulletRigid = bullets.GetComponent<Rigidbody>();
        bulletRigid.velocity = bulletPos.forward * bulletspeed;
        Invoke("Trailoff", 0.1f);
        curShotDelay = 0;
    }


    void Trailoff()
    {
        bullets.GetComponent<TrailRenderer>().enabled = true;
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }
    void freezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }
    void StopToWall()
    {
        isBorder = Physics.Raycast(transform.position, transform.forward, 1, LayerMask.GetMask("Wall"));
    }
    void OnCollisionEnter(Collision collision)
    {
        
    }
    public GameObject setting;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            if (setting.GetComponent<Settings>().vibrate == true)
            {
                Handheld.Vibrate();
            }
            if (life == 1)
            {
                manager.GameOver();
            }
            else if (!isDamage)
            {
                life--;
                manager.UpdateLifeIcon(life);
                StartCoroutine(OnDamage());
            }
        }
    }
    IEnumerator OnDamage()
    {
        isDamage = true;
        foreach(MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.yellow;
        }

        yield return new WaitForSeconds(0.5f);

        isDamage = false;
        foreach (MeshRenderer mesh in meshs)
        {
            mesh.material.color = Color.white;
        }
    }
}
