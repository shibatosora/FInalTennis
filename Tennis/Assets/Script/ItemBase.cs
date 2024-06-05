using System.Collections.Generic;
using UnityEngine;
namespace Script
{
    [CreateAssetMenu]
    public class ItemBase :ScriptableObject
    {
        public List<Item> itemList = new List<Item>();


    }
}