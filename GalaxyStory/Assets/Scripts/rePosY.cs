using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rePosY : MonoBehaviour
{
    public void RePositionY()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3(0, 1040, 0);
    }
}
