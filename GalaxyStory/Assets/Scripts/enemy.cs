using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class enemy : MonoBehaviour
{
    public enum Type { A, B, C, D};
    public Type enemyType;
    public int curHealth;
    public Transform target;
    public gamemanager manager;
    public bool isChase;

    Rigidbody rigid;
    BoxCollider boxcollider;
    Material mat;
    NavMeshAgent nav;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxcollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<MeshRenderer>().material;
        nav = GetComponent<NavMeshAgent>();

        Invoke("ChaseStart", 2);
    }
    void ChaseStart()
    {
        isChase = true;
    }

    void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(target.position);
            nav.isStopped = !isChase;
        }
        
    }
    void freezeVelocity()
    {
        if (isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }
    private void FixedUpdate()
    {
        freezeVelocity();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            bullet bullet = other.GetComponent<bullet>();
            curHealth -= bullet.damage;
            Vector3 reactVec = transform.position - other.transform.position;
            other.gameObject.SetActive(false);

            StartCoroutine(OnDamage(reactVec));
        }
    }
    IEnumerator OnDamage(Vector3 reactVec)
    {
        mat.color = Color.red;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.gray;
            gameObject.layer = 10;
            isChase = false;
            nav.enabled = false;
            //anim.SetTrigger("doDie");

            switch (enemyType)
            {
                case Type.A:
                    manager.enemyCntA--;
                    manager.money += 1;
                    break;
                case Type.B:
                    manager.enemyCntB--;
                    manager.money += 2;
                    break;
                case Type.C:
                    manager.enemyCntC--;
                    manager.money += 3;
                    break;
                case Type.D:
                    manager.enemyCntD--;
                    manager.money += 4;
                    break;
            }
            
            //reactVec = reactVec.normalized;
            //reactVec += Vector3.up;
            //rigid.AddForce(reactVec * 5, ForceMode.Impulse);

            Destroy(gameObject, 3);
        }
    }
}
