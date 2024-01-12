using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTV : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody rbPlayer;
    private Vector3 startPos;
    [SerializeField] mousetracker mtScript;
    private bool isSitting;
    
    public void Interact()
    {
        player.transform.position = transform.position;
        isSitting = true;



    }
    
    // Start is called before the first frame update
    void Start()
    {
        isSitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        startPos = player.transform.position;
        if (Input.GetKeyDown(KeyCode.E) && isSitting)
        {
            isSitting = false;
            player.transform.position = startPos + new Vector3(0f, 0f, -1f);
        }

        if (isSitting)
        {
            mtScript.mouseLook.x = Mathf.Clamp(mtScript.mouseLook.x, -270f, 270f);
        }
        
    }
}
