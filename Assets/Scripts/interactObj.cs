using System;

public interface interactObject
{
    //Interact with an object
    public void Interact();
    
    //When you can interact with the object while already interacted once
    public bool ReInteract();
}
