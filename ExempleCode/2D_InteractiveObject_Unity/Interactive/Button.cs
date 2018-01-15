using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractiveObject {

    public event OnInteractionHandler InteractionStarted;

    public void StartInteraction()
    {
        
        Debug.Log("door active");
        if (InteractionStarted != null)
        {
            InteractionStarted(this);
        }
    }

    void Start ()
    {
		
	}
	
	void Update ()
    {
		 
	}
}
