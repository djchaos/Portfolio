using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour{

    SingletonStar singletonStarInstance;
    SingletonHeart singletonHeartInstance;

    // Use this for initialization
    void Awake()
    {
        singletonStarInstance = SingletonStar.getInstance();
        singletonHeartInstance = SingletonHeart.getInstance();
    }

	void Start ()
    {
        for( int i = 0; i < 20; i++)
        {
            singletonStarInstance.CreateStar(true); 
        }
        for (int j = 0; j < 20; j++)
        {
            singletonHeartInstance.CreateHeart(true);
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            singletonStarInstance.TchekPoolS();
        }
        if(Input.GetMouseButtonDown(1))
        {
            singletonHeartInstance.TcheckPoolH();
        }
	}
}
