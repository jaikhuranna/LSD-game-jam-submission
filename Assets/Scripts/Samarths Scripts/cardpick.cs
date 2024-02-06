using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardpick : MonoBehaviour,interactObject
{
    public bool cardpickedup = false;
    [SerializeField] private GameObject card, anchor;
    [SerializeField] private RoyalFlushChecker RFCscript;
    public int cardNum;
    public void Interact()
    {
        if (!cardpickedup && !RFCscript.holdingObj)
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
        RFCscript.holdingObj = true;
        cardpickedup = true;
        card.transform.SetParent(anchor.transform);
        card.transform.position = anchor.transform.position;
        card.GetComponent<Rigidbody>().isKinematic = true;
        card.GetComponent<BoxCollider>().enabled = false;
    }

    void PutDownCard()
    {
        cardpickedup = false;
        RFCscript.holdingObj = true;
    }

    public bool ReInteract()
    {
        return false;
    }
}