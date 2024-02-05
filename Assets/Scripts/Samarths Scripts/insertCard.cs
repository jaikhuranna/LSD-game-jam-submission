using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insertCard : MonoBehaviour, interactObject
{
    public GameObject anchor;
    private bool isInserted = false;
    public void Interact()
    {
        if (!isInserted)
        {
            Inserted();
        }
    }

    public void Inserted()
    {
        isInserted = true;
        anchor.transform.GetChild(0).position = gameObject.transform.position;
        anchor.transform.GetChild(0).SetParent(gameObject.transform);
        
    }

    public bool ReInteract()
    {
        return false;
    }
}
