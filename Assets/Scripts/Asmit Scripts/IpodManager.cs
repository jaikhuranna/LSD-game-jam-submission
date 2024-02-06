using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class IpodManager : MonoBehaviour
{
    public bool isPressed = false;
    public bool hasBeenPressed = false;
    public Collider boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other){
        isPressed = true;
        hasBeenPressed = true;
        //play audio
    }
    IEnumerator AudioTime()
    {
        //wait for the ticks
        yield return new WaitForSeconds(3);
        isPressed = false;
    }
    private void OnTriggerExit(Collider other){
        StartCoroutine("AudioTime");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
