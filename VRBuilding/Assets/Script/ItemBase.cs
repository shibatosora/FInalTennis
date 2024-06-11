using System.Collections.Generic;
using UnityEngine;
namespace Script
{

    [CreateAssetMenu]
    public class ItemBase :ScriptableObject
    {
        [SerializeField] GameObject itemObject;
        [SerializeField] ID ids;
        [SerializeField] private GameObject Monster;
        public ID Ids { get => ids; }
        public GameObject ItemObject { get => itemObject; } 
        public GameObject Monster1 { get => Monster; } 
        public enum ID
        {
            Card, 
            Enemy, 
            Apple, 
            Boss, 
        }
    }
}