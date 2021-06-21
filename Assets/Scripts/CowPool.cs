using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowPool : MonoBehaviour
{
    private GameObject[] cowPool;

    [SerializeField]
    private GameObject cowGameObj;

    [SerializeField]
    private int amountPool;

    [SerializeField]
    private float spawnRate = 3f;

    private float timeLastSpawn = 0f;

    void Start()
    {
        cowPool = new GameObject[amountPool];

        for (int i = 0; i < amountPool; i++)
        {
            GameObject obj = Instantiate<GameObject>(cowGameObj);

            obj.SetActive(false);

            cowPool[i] = obj;
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountPool; i++)
        {
            if (!cowPool[i].activeInHierarchy)
            {
                return cowPool[i];
            }
        }

        return null;
    }

    void Update()
    {
        timeLastSpawn += Time.deltaTime;

        if (timeLastSpawn >= spawnRate)
        {
            timeLastSpawn = 0f;

            GameObject obj = GetPooledObject();

            if (obj != null)
            {
                
                obj.transform.position = new Vector2(8f, -0.5f);

                obj.GetComponent<CowText>().ChangeText("bla bla bla");

                obj.SetActive(true);
            }
        }
    }
}
