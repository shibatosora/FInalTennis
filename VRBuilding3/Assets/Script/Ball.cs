using Oculus.Interaction;
using Unity.VisualScripting;
using UnityEngine;
namespace Script
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody rb;
        private int bounds = 0;
        public Racket raket;
        public GameManager gameManager;
        public Enemy enemy;
        public int playerPower = 0;
        private bool playerTrun = true;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            raket = GameObject.Find("PingPongBat").GetComponent<Racket>();
            gameManager = GameObject.Find("PingPongTable").GetComponent<GameManager>();
            enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Racket"))
            {
                bounds = 0;

                Racket racketController = collision.gameObject.GetComponent<Racket>();
                Vector3 racketVelocity = racketController.velocity;

                // ラケットの速度に基づいてボールに力を加える
                rb.velocity = racketVelocity;
            }

            if (collision.gameObject.CompareTag("CPUArea") && playerTrun == true)
            {
                bounds++;
            }
            if (collision.gameObject.CompareTag("PlayerArea") && playerTrun == false)
            {
                bounds++;
            }
            if (collision.gameObject.CompareTag("death"))
            {
                if (bounds <= 0||bounds>=2)
                {
                    raket.PlayerDamage();
                    Destroy(this.gameObject);
                }
                if (bounds == 1)
                {
                    playerPower = raket._power;
                    enemy.EnemyDamage(playerPower);
                }
                Destroy(this.gameObject);
                bounds = 0;
                gameManager.EndPlayerTurn();
            }
        }

    }
}