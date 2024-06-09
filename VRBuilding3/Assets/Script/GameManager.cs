using Unity.VisualScripting;
using UnityEngine;

namespace Script
{
    public class GameManager :MonoBehaviour
    {
        [SerializeField] Racket racket;
        [SerializeField] Enemy enemy;
        [SerializeField] private LogManager logManager;
        [SerializeField] private GameObject Card;
        //カード選択
        void Start() { Card.SetActive(true); }
        //敵ランダム選択
        public void Spawn() { enemy.EnemySelect(); }
        
        public void Clear()
        {
            
        }
            // プレイヤーのターンを開始する
        public void StartPlayerTurn() { racket.StartTurn(); }

        // プレイヤーが攻撃を選択したときに呼び出されるメソッド
        public void OnAttackButtonClicked()
        {
            if (racket != null && racket.isActiveAndEnabled && racket.playerTurn)
            {
                racket.Attack();
                EndPlayerTurn();
            }
        }

        // プレイヤーが防御を選択したときに呼び出されるメソッド
        public void OnDefendButtonClicked()
        {
            if (racket != null && racket.isActiveAndEnabled && racket.playerTurn)
            {
                racket.Defend();
                EndPlayerTurn();
            }
        }

        // プレイヤーがスキルを選択したときに呼び出されるメソッド
        public void OnSkillButtonClicked()
        {
            if (racket != null && racket.isActiveAndEnabled && racket.playerTurn)
            {
                racket.Skill();
                EndPlayerTurn();
            }
        }

        public void EndPlayerTurn()
        {
            // プレイヤーのターンを終了する
            racket.EndTurn();
            // 次のターンを開始する
            StartEnemyTurn();
        }
        void StartEnemyTurn()
        {
            // 敵のターンを開始する
            enemy.StartTurn();
        }

        // 敵のターン終了時に呼び出されるメソッド
        public void EndEnemyTurn()
        {
            // 敵のターンを終了する
            enemy.EndTurn();
            // 次のターンを開始する
            StartPlayerTurn();
        }
    }
}