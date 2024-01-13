using System;

public interface interactObject
{
    //When the Player sees the Object
    public String SeeObject();
    //When the object is interacted with
    public void Interact();
    //In case there is a counter situation
    public void Release();
}
