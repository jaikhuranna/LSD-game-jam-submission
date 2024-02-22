using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public Rigidbody rb;
    public float jumpspeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        Vector3 moveVec = Vector3.ClampMagnitude(transform.right * x + transform.forward * z, 1.0f)*  speed;
        moveVec += Vector3.up * rb.velocity.y;    
        rb.velocity = moveVec;
        
        // if (Input.GetKeyDown("space"))
        // {
        //     RaycastHit Hit;
        //     
        //     if (Physics.Raycast(player.transform.position, Vector3.down, out Hit, 1.1f))
        //     {
        //         rb.velocity += new Vector3(0, jumpspeed, 0);
        //     }
        // }
        
        
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
}
