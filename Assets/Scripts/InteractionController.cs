using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    //The Range that the Player can interact
    public float InteractRange;
    //Source of the Ray to interact
    public Transform interactorSource;
    //The Latest GameObject the player sees
    private GameObject SeenGameObject;
    //The Current Interactable Onbject
    private interactObject currentInteractableObject;
    //The UI message that is displayed
    public TMP_Text InteractMessage;

    public void Start()
    {
        interactorSource = gameObject.transform;
    }

    void Update()
    {
        //Shoot out a ray
        Ray r = new Ray(interactorSource.position, interactorSource.forward);
        
        //Check if the ray has hit anything
        if (Physics.Raycast(r, out RaycastHit Hit, InteractRange))
        {
            //If the hit gameobject is something new
            if (Hit.collider.gameObject != SeenGameObject)
            {
                //set seen to the new object
                SeenGameObject = Hit.collider.gameObject;
                Debug.Log(SeenGameObject.name);
                
                //check if the gameobject is interactable
                if (SeenGameObject.TryGetComponent(out interactObject interactObj))
                {
                    //Show a custom message if it can be interacted
                   InteractMessage.text = interactObj.SeeObject();
                   currentInteractableObject = interactObj;
                }
                else
                {
                    //reset the message of the UI, and reset the interactable object
                    InteractMessage.text = " ";
                    currentInteractableObject = null;
                }
            }
            
        }
        else
        {
            //reset the message of the UI, and reset the interactable object
            InteractMessage.text = " ";
            currentInteractableObject = null;
            SeenGameObject = null;
        }
        
        
        
        //Try to interact with the object
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Check if the seen object can be interacted with
            if (currentInteractableObject != null)
            {
                currentInteractableObject.Interact();
            }
        }
        
        //Try to Release with the object
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Check if the seen object can be interacted with
            if (currentInteractableObject != null)
            {
                currentInteractableObject.Release();
            }
        }
    }
}
