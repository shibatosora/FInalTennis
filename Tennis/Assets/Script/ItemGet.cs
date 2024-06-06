using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    [SerializeField] private ItemBase itemBase ;
    [SerializeField] private Racket raket;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject enemySpawn;

    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (itemBase.Ids == ItemBase.ID.Apple)
            {
                raket._HP += 5;
                Destroy(this.gameObject);
            }

            if (itemBase.Ids == ItemBase.ID.Boss)
            {
                Destroy(this.gameObject);
                float enemyx = itemBase.Monster1.transform.position.x;
                float enemyy = itemBase.Monster1.transform.position.y;
                float enemyz = itemBase.Monster1.transform.position.z;
                GameObject Prefab = itemBase.Monster1.gameObject;
                Instantiate(Prefab, new Vector3(enemyx, enemyy, enemyz), itemBase.Monster1.transform.rotation);
                
                gameManager.StartPlayerTurn();
            }
            
            if (itemBase.Ids == ItemBase.ID.Enemy)
            {
                Destroy(this.gameObject);
                float enemyx = enemySpawn.transform.position.x;
                float enemyy = enemySpawn.transform.position.y;
                float enemyz = enemySpawn.transform.position.z;
                GameObject Prefab = itemBase.Monster1.gameObject;
                Instantiate(Prefab, new Vector3(enemyx, enemyy, enemyz), itemBase.Monster1.transform.rotation);
                
                gameManager.StartPlayerTurn();
            }

            if (itemBase.Ids == ItemBase.ID.Card)
            {
                Destroy(this.gameObject);
            }
        }

    }
    
}
