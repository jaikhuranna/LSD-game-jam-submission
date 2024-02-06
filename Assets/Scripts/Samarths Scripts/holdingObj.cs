using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalFlushChecker : MonoBehaviour
{
    public bool holdingObj = false;
    [SerializeField] private GameObject anchor;
    // Update is called once per frame
    void Update()
    {
        if (anchor.transform.childCount == 1)
        {
            holdingObj = true;
        }
        else
        {
            holdingObj = false;
        }
    }
}
