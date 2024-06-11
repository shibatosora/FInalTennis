using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerComa : MonoBehaviour
{
    [SerializeField] private List<GameObject> comaList = new List<GameObject>();

    void Step()
    {
        for (int i = 0; i < comaList.Count; i++)
        {
            if (comaList[i])
            {
               // comaList[i + 1].transform
            }
        }
    }
}
