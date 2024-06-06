using UnityEngine;

namespace Script
{
    public class GameManager :MonoBehaviour
    {
        [SerializeField] Racket racket;
        [SerializeField] Enemy enemy;
        [SerializeField] private LogManager logManager;
        void Start()
        {
            
        }

        public void Clear()
        {
            
        }

        public void StartPlayerTurn()
        {
            // プレイヤーのターンを開始する
            racket.StartTurn();
        }

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