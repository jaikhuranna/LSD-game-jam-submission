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
    public GameObject needlePivot;
    public GameObject safe;
    public GameObject playerObj;
    // public bool isEntry = true;
    public int count = 0;
    public int hasBeenMoved = 0;
    public bool isInteracted;
    private Quaternion initialRotation;

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
            // isEntry = false;
            ipod.hasBeenPressed = false;
            playerObj.GetComponent<MeshRenderer>().enabled = false;

        }
    }
    public bool ReInteract()
    {
        return false;
    }
    
    //to use esc to get back to the original camera, the player movement is unlocked again, the puzzle is reset
    private void EscapeKey()
    {
        if (isInteracted)
        {
            if (Input. GetKeyDown(KeyCode.Escape))
            {
                charMoverment.speed = 4f;
                cameraObj.SetActive(true);
                safeCamera.SetActive(false);
                hasBeenMoved = 0;
                count = 0;
                playerObj.GetComponent<MeshRenderer>().enabled = true;
                isInteracted = false;
            }
        }
    } 
    public void Solution()                             //checks the logic for the correct answer
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (count == 0 || count == 2 || count == 4)
            {
                hasBeenMoved ++;
                count++;
                needlePivot.transform.Rotate(0, 0, 90);
            }
            else
            {
                hasBeenMoved++;
                needlePivot.transform.Rotate(0, 0, 90);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (count == 1 || count == 3)
            {
                hasBeenMoved++;
                count++;
                needlePivot.transform.Rotate(0, 0, -90);
            }
            else
            {
                hasBeenMoved++;
                needlePivot.transform.Rotate(0, 0, -90);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = needlePivot.transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        EscapeKey();
        if (hasBeenMoved == 5 && count == 5)                    //checks for the correct answer
        {
            Debug.Log("Correct answer");
            charMoverment.speed = 4f;
            cameraObj.SetActive(true);
            safeCamera.SetActive(false);
            safe.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            needlePivot.SetActive(false);
            playerObj.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (hasBeenMoved == 5 && count != 5)               //checks for anything other than the correct answer
        {
            Debug.Log("Wrong answer");
            charMoverment.speed = 4f;
            cameraObj.SetActive(true);
            safeCamera.SetActive(false);
            hasBeenMoved = 0;
            count = 0;
            isInteracted = false;
            playerObj.GetComponent<MeshRenderer>().enabled = true;
            needlePivot.transform.rotation = initialRotation;
        }
        if (isInteracted)
        { 
            Solution();
        }
    }
    
}
