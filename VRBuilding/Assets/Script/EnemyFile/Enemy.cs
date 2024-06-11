using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        [SerializeField] GameManager gameManager;
        [SerializeField] private List<EnemyBase> enemyBase=new List<EnemyBase>();
        [SerializeField] private EnemyBase bossEnemy;
        [SerializeField] private LogManager logManager;
        [SerializeField] private Transform EnemyBall;
        [SerializeField] GameObject ballPrefab;

        private int randamValue;
        //ステータス
        private int HP=1;
        private int power;
        private int define;
        private Skills skill;
        private EnemyElement element;
        
        //雑魚敵をランダムに選択し召喚<GameManager>.Spawn()>>
        public void EnemySelect()
        {
            randamValue = Random.Range(0, 3);
            GameObject enemy = Instantiate(enemyBase[randamValue].EnemyDate, enemyBase[randamValue].EnemyDate.transform.position, enemyBase[randamValue].EnemyDate.transform.rotation);
            HP = enemyBase[randamValue].MaxHP;
            power = enemyBase[randamValue].Attack;
            define = enemyBase[randamValue].Definese;
            skill = enemyBase[randamValue].Skills;
            element = enemyBase[randamValue].Element;
            StartCoroutine(logManager.TypeLog($"{enemyBase[randamValue].Names}が現れた\nあなたのターンです。行動を選択してください。"));
            gameManager.StartPlayerTurn();
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
            float randomValues = Random.value; // 0から1のランダムな値を生成

            if (randomValues < attackProbability)
            {
                StartCoroutine(logManager.TypeLog($"{enemyBase[randamValue].Names}の攻撃！"));
                Attack();
            }
            else if (randomValues < attackProbability + defendProbability)
            {
                StartCoroutine(logManager.TypeLog($"{enemyBase[randamValue].Names}は身構えた！"));
                Defend();
            }
            else
            {    
                StartCoroutine(logManager.TypeLog($"{enemyBase[randamValue].Names}は{enemyBase[randamValue].Skills}を使った！"));
                UseSkill();
            }
        }

        // 攻撃を実行するメソッド
        private void Attack()
        {
            GameObject ball;
            Rigidbody ballRigidbody;
            ball = Instantiate(ballPrefab, EnemyBall.position, Quaternion.identity);
            ballRigidbody = ball.GetComponent<Rigidbody>();
            ballRigidbody.AddForce(new Vector3(0f, 0.02f, 0.02f), ForceMode.Impulse);

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
                gameManager.Clear();
                Debug.Log("adsdda");
                Destroy(this.gameObject);
            }
        } 
    }
}