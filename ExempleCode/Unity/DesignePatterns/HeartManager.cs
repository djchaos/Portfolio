using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class HeartManager:MonoBehaviour
{
    private SingletonHeart _singleton;

    void Awake()
    {
        _singleton = SingletonHeart.getInstance();
    }

    void Start()
    {
        Debug.Log(_singleton._value);
    }
   
}

