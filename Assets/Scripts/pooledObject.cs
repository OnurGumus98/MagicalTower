using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooledObject : MonoBehaviour
{
    private objectPool pool;
    public objectPool Pool { get => pool; set => pool = value; }
    public void Release()
    {
        pool.ReturnToPool(this, GetComponent<spell>().variables.ID);
    }
}
