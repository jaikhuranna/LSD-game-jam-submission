using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class sitSofa : MonoBehaviour , interactObject
{
    //References the character
    public charactermovement cmScript;
    private GameObject player;

    //Caches the value of the scale of the player
    private Vector3 startScale;
    //bool for the player sitting on the sofa
    private bool isSitting = false;
    //The GameObject that is used to put the player into sitting mode
    public GameObject SitPosition;
    //The Message from the sofa that is returned to the player
    public String InteractMessage;


    void Start()
    {
        player = cmScript.GameObject();
        startScale = player.transform.localScale;
    }

    public bool ReInteract()
    {
        return true;
    }
    
    //Show the message of the sofa
    // public String SeeObject()
    // {
    //     if (!isSitting)
    //     {
    //         return InteractMessage; 
    //     }
    //     else
    //     {
    //         return " ";
    //     }
    //     
    // }
    
    //When the sofa fires the interact function
    public void Interact()
    {
        if (isSitting)
        {
                //disable sitting the move player back
                isSitting = false;
                player.transform.position += new Vector3(0f, 0f, -1f);
                //enable player movement and revert scale change
                cmScript.enabled = true;
                player.transform.localScale = startScale;
        }
        else
        {
            //Only fire if the player is sitting
            //set the player to sit position
            player.transform.position = SitPosition.transform.position;
            //cancel the player movement
            isSitting = true;
            cmScript.rb.velocity = Vector3.zero;
            cmScript.enabled = false;
            //Set the scale for the player
            player.transform.localScale = new Vector3(player.transform.localScale.x, 0.35f, player.transform.localScale.z);  
        }
        

}

    //When the sofa fires the release function
    public void Release()
    {
        

    }
    
}
