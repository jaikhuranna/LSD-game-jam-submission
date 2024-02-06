using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SafeManager : MonoBehaviour, interactObject
{
    public IpodManager ipod;
    public charactermovement charMoverment;
    public GameObject cameraObj;
    public GameObject safeCamera;
    public bool isEntry = true;
    public int count = 0;
    public GameObject needlePivot;
    public bool isInteracted;
    private Quaternion rotation;
    //private Quaternion initialRotation;
    public void Interact()
    {
        //if the ipod has been pressed and the player interacts with the dial, the camera changes
        if (ipod.hasBeenPressed)
        {
            Debug.Log("Pressed E");
            charMoverment.speed = 0f;
            cameraObj.SetActive(false);
            safeCamera.SetActive(true);
            isInteracted = true;
            isEntry = false;
            ipod.hasBeenPressed = false;
        }
        else
        {
            Debug.Log("Again");
            if (isEntry == false)
            {
                Debug.Log(" Setting Camera back");
                charMoverment.speed = 4f;
                cameraObj.SetActive(true);
                safeCamera.SetActive(false); 
            }
        }
    }
    public bool ReInteract()
    {
        return false;
    }
    
    //to use esc to get back to the original camera and the player movement is unlocked again
    public void EscapeKey()
    {
        if (ipod.hasBeenPressed)
        {
            if (Input. GetKeyDown(KeyCode.Escape))
            {
                charMoverment.speed = 4f;
                cameraObj.SetActive(true);
                safeCamera.SetActive(false); 
            }
        }
    }

    public void RotateRight()
    { 
        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Rotating Right");
            //rotation = Quaternion.Euler(90, initialRotation.y + 90, 0);
            needlePivot.transform.Rotate(0,0,-90);
        }

    }
    public void RotateLeft()
    { 
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Rotating Left");
            //rotation = Quaternion.Euler(90, initialRotation.y + 90, 0);
            needlePivot.transform.Rotate(0,0,90);
        }

    }

    public void Solution()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (count == 0)
            {
                count++;
                needlePivot.transform.Rotate(0, 0, 90);
            }
            else
            {
                needlePivot.transform.Rotate(0, 0, 90);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (count == 1)
            {
                count++;
                needlePivot.transform.Rotate(0, 0, -90);
            }
            else
            {
                needlePivot.transform.Rotate(0, 0, -90);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (count == 2)
            {
                count++;
                needlePivot.transform.Rotate(0, 0, 90);
            }
            else
            {
                needlePivot.transform.Rotate(0, 0, 90);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (count == 3)
            {
                count++;
                needlePivot.transform.Rotate(0, 0, -90);
            }
            else
            {
                needlePivot.transform.Rotate(0, 0, -90);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (count == 4)
            {
                count++;
                needlePivot.transform.Rotate(0, 0, 90);
            }
            else
            {
                needlePivot.transform.Rotate(0, 0, 90);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EscapeKey();
        if (isInteracted)
        { 
            Solution();
        }
    }
    
}
