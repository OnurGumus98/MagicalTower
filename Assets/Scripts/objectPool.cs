using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : MonoBehaviour
{
    [SerializeField] PoolSO[] poolVariables;
    [SerializeField] List<Stack<pooledObject>> spellsStack = new List<Stack<pooledObject>>();

    private void Start()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        for (int i = 0; i < poolVariables.Length;i++)
        {
            Stack<pooledObject> stack = new Stack<pooledObject>();
            pooledObject instance = null;

            for (int j = 0; j < poolVariables[i].PoolVariables.poolSize; j++)
            {
                instance = Instantiate(poolVariables[i].PoolVariables.poolPrefab.GetComponent<pooledObject>());
                instance.Pool = this;
                instance.gameObject.SetActive(false);
                stack.Push(instance);
            }
            spellsStack.Add(stack);
        }
    }

    public pooledObject GetPooledObject(int spellValue)
    {
        pooledObject nextInstance = spellsStack[spellValue].Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }
    public void ReturnToPool(pooledObject pooledObject, int spellValue)
    {
        spellsStack[spellValue].Push(pooledObject);
        pooledObject.gameObject.SetActive(false);
    }
}
