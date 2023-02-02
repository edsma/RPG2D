using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private int quantity;

    private List<GameObject> list;
    public  GameObject containerList { get; private set;  }

    public void CreatePooler(GameObject objectToCreate)
    {
        list= new List<GameObject>();
        containerList= new GameObject($"Pool - {objectToCreate.name}");

        for (int i = 0; i < quantity; i++)
        {
            list.Add(AddInstance(objectToCreate));
        }
    }

    private GameObject AddInstance(GameObject objectToCreate)
    {
        GameObject newObject = Instantiate(objectToCreate, containerList.transform);
        newObject.SetActive(false);
        return newObject;
    }

    public GameObject ObtainInstance() 
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeSelf )
            {
                return list[i];
            }
        }

        return null;
    }
}
