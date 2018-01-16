using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Switchs : MonoBehaviour, IInteractiveObject {

    public int index;
    public string test;

    public event OnInteractionHandler InteractionStarted;

    static List<int> sequence = new List<int>();

    public void StartInteraction()
    {
        sequence.Add(index);
        test = string.Join(",", sequence.Select(x => x.ToString()).ToArray());
        Debug.Log(test);
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
