using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineBag : MonoBehaviour, interactObject
{
    public void Interact(){}

    public bool ReInteract()
    {
        return false;
    }
    public String SeeObject()
    {
        return "Medicine Baggie";
    }
    
}
