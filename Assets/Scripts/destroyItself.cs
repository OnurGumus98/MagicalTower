using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyItself : MonoBehaviour
{
    void Start()
    {
        Invoke("kill_me", 2);    
    }

    void kill_me()
    {
        Destroy(gameObject);
    }
}
