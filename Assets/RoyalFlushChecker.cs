using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalFlushChecker : MonoBehaviour
{
    public List<GameObject> Cards;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cards[0].transform.GetChild(0).CompareTag("Ace"))
        {
            Debug.Log("Got it");
        }
        
    }
}
