using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

interface IInteractable
{
    //use the below function on the Game Object with which you want to interact
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    // this is the point from where raycast will emit
    public Transform interactorSource;
    // this is the distance from where player can interact
    public float interactRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(interactorSource.position, interactorSource.forward);
            if(Physics.Raycast(r,out RaycastHit hitInfo,interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}
