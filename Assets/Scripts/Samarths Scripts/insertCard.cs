using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insertCard : MonoBehaviour, interactObject
{
    public GameObject anchor;
    public bool isInserted = false;
    [SerializeField] private cardpick[] cards;
    public int slotNum;
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
        anchor.transform.GetChild(0).position = gameObject.transform.GetChild(0).position;
        anchor.transform.GetChild(0).SetParent(gameObject.transform);
        StartCoroutine(CardSetPosition());

    }

    IEnumerator CardSetPosition()
    {
        gameObject.transform.GetChild(1).localPosition = new Vector3(0,0,0);
        gameObject.transform.GetChild(1).localRotation = Quaternion.Euler(0,0,0);
        
        yield return new WaitForSeconds(1);
        
    }

    public bool ReInteract()
    {
        return false;
    }
}
