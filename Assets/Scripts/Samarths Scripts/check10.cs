using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check10 : MonoBehaviour,interactObject
{
    [SerializeField] cardpick[] cardScript;
    [SerializeField] private insertCard[] slot;
    [SerializeField] private GameObject[] rfcards;
    [SerializeField] private GameObject[] slotHolder;
    [SerializeField] private GameObject[] Allcards;
    [SerializeField] private GameObject cardHolder;
    public int count;

    private void Awake()
    {

    }

    public void Interact()
    {
        for (int i = 0; i < rfcards.Length; i++)
        {
            if (slotHolder[i].transform.position == rfcards[i].transform.position &&
                slot[i].slotNum == cardScript[i].cardNum)
            {
                Debug.Log(i);
                count++;
            }
        }
        if (count == 5)
        {
            Debug.Log("ROYAL FLUSH");
        }
        else
        {
            for (int i = 0; i < Allcards.Length; i++)
            {
                Allcards[i].transform.position = cardScript[i].ResetPosition;
                Allcards[i].transform.SetParent(cardHolder.transform);
                Allcards[i].GetComponent<BoxCollider>().enabled = true;
                Allcards[i].GetComponent<Rigidbody>().isKinematic = false;
                count = 0;
            }

            for (int j = 0; j < slot.Length; j++)
            {
                slot[j].isInserted = false;
            }
        }
    }
    
    

    public bool ReInteract()
    {
        return false;
    }
}
