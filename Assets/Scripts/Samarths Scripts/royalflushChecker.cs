using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public class royalflushChecker : MonoBehaviour,interactObject
{
    [SerializeField] private List<cardpick> cpScript;
    [SerializeField] private List<GameObject> SlotHolder;
    public int count;
    
    public void Interact()
    {
        CardChecker();
    }

    public bool ReInteract()
    {
        return false;
    }

    public void CardChecker()
    {
        if (SlotHolder[0].transform.GetChild(1).GetComponent<insertCard>().slotNum == cpScript[3].cardNum)
        {
            count++;
        }
        if (SlotHolder[1].transform.GetChild(1).GetComponent<insertCard>().slotNum == cpScript[0].cardNum)
        {
            count++;
        }
        if (SlotHolder[2].transform.GetChild(1).GetComponent<insertCard>().slotNum == cpScript[4].cardNum)
        {
            count++;
        }
        if (SlotHolder[3].transform.GetChild(1).GetComponent<insertCard>().slotNum == cpScript[5].cardNum)
        {
            count++;
        }
        if (SlotHolder[4].transform.GetChild(1).GetComponent<insertCard>().slotNum == cpScript[1].cardNum)
        {
            count++;
        }
        if (count == 5)
        {
            Debug.Log("YAY ROYAL FLUSH");
        }
        else
        {
            Debug.Log("SADGE");
        }
    }
}
