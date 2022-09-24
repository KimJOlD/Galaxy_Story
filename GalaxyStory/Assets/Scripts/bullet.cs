using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            GetComponent<TrailRenderer>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
