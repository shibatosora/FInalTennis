using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Script
{
    [CreateAssetMenu]
    public class EnemyBase :ScriptableObject
    {
        //名前
        [SerializeField] new string name;
        //オブジェクト
        [SerializeField] private GameObject enemyDate;
        //属性
        [SerializeField] EnemyElement element;
        //ステータス
        [SerializeField] private int maxHP;
        [SerializeField] private int attack;
        [SerializeField] private int definese;
        //スキル
        [SerializeField] private Skills skills;
        public Skills Skills { get => skills; }
        public EnemyElement Element { get => element; }
        public int Attack { get => attack; }
        public int MaxHP { get => maxHP; }
        public int Definese { get => definese; }
        
    }

    public enum Skills
    {
        SpinyBall,//サボテンの棘ボール
        FlappingSpore,//キノコのわたわた胞子
        
    }
    public enum EnemyElement
    {
        None,
        Fire,
        Grass,
        Water,
    }
    
}