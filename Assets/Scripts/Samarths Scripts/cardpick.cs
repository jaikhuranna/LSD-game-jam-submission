using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardpick : MonoBehaviour,interactObject
{
    public bool cardpickedup = false;
    private bool holdingObj = false;
    [SerializeField] private GameObject card, anchor;
    public void Interact()
    {
        if (!cardpickedup && !holdingObj)
        {
            PickUpCard();
        }
        else
        {
            PutDownCard();
        }
    }

    void PickUpCard()
    {
        holdingObj = true;
        cardpickedup = true;
        card.transform.SetParent(anchor.transform);
        card.transform.position = anchor.transform.position;
        card.GetComponent<Rigidbody>().isKinematic = true;
        card.GetComponent<BoxCollider>().enabled = false;
    }

    void PutDownCard()
    {
        cardpickedup = false;
        holdingObj = true;
        

    }

    public bool ReInteract()
    {
        return false;
    }
}