using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTV : MonoBehaviour, IInteractable
{
    public GameObject player;
    public charactermovement cmScript;
    public mousetracker mtScript;
    private Vector3 startPos;
    private Vector3 startScale;
    private bool isSitting;
    
    public void Interact()
    {
        player.transform.position = new Vector3(12.83f, 1.01f, 3.16f);
        isSitting = true;
        cmScript.enabled = false;
        player.transform.localScale = new Vector3(player.transform.localScale.x, 0.35f, player.transform.localScale.z);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        isSitting = false;
        startScale = player.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        startPos = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Space) && isSitting)
        {
            isSitting = false;
            player.transform.position = startPos + new Vector3(0f, 0f, -1f);
            cmScript.enabled = true;
            player.transform.localScale = startScale;
        }

        //*if (isSitting)
        //{ 
            //mtScript.mouseLook.x = Mathf.Clamp(mtScript.mouseLook.x, -120f, 120f);
        //}
    }
}
