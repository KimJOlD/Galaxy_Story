using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceremony : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0f,  2.5f, 0f);
        transform.rotation = Quaternion.Euler(13f, 180f, 0f);
        //transform.localScale = new Vector3 (150f,150f,150f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
