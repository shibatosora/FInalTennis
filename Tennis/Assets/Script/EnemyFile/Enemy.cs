using System;
using System.Linq.Expressions;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class Enemy : MonoBehaviour
    {
        private bool enemyTurn = false;
        public float attackProbability = 0.4f;
        public float defendProbability = 0.3f;
        public float skillProbability = 0.3f;
        [SerializeField] GameManager _gameManager;
        [SerializeField] private EnemyBase enemyBase;
        private EnemyBase _base;
        [SerializeField] private LogManager logManager;
        //ステータス
        private int HP;
        private int power;
        private int define;
        private Skills skill;
        private EnemyElement element;

        private void Start()
        {
            HP = _base.MaxHP;
            power = _base.Attack;
            define = _base.Definese;
            skill = _base.Skills;
            element = _base.Element;
        }

        // ターンが敵に切り替わったときに呼び出されるメソッド
        public void StartTurn()
        {
            enemyTurn = true;
            PerformAction(); // 行動を実行
        }

        // 行動を決定し実行するメソッド
        private void PerformAction()
        {
            float randomValue = Random.value; // 0から1のランダムな値を生成

            if (randomValue < attackProbability)
            {
                Attack();
            }
            else if (randomValue < attackProbability + defendProbability)
            {
                Defend();
            }
            else
            {
                UseSkill();
            }
        }

        // 攻撃を実行するメソッド
        private void Attack()
        {
            // ここに攻撃の処理を追加
            Debug.Log("Enemy attacks!");
        }

        // 防御を実行するメソッド
        private void Defend()
        {
            define = 2;
        }

        // スキルを実行するメソッド
        private void UseSkill()
        {
            // ここにスキルの処理を追加
            Debug.Log("Enemy uses skill!");
        }

        public void EnemyDamage(int damage)
        {
            HP = damage / define;
        }

        // ターンが終了したときに呼び出されるメソッド
        public void EndTurn()
        {
            enemyTurn = false;
            // ここにターン終了時の処理を追加
        }

        void Update()
        {
            if (HP <= 0)
            {
                _gameManager.Clear();
                Destroy(this.gameObject);
                
            }
        } 
    }
}