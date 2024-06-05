using UnityEngine;

namespace Script
{
    public enum ID
    {
        Card =0,
        Enemy=1,
        Apple =2,
        Boss =3,
    }
    [SerializeField]
    public class Item :MonoBehaviour
    {
        [SerializeField] GameObject itemObject;
        [SerializeField] private ID ids;
        
        public GameObject ItemObject { get => itemObject; }
        public ID Ids { get => ids; }
        
        
    }
}

