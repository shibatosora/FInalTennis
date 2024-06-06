using Oculus.Interaction;
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

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Racket"))
            {
                Racket racketController = collision.gameObject.GetComponent<Racket>();
                Vector3 racketVelocity = racketController.velocity;

                // ラケットの速度に基づいてボールに力を加える
                rb.velocity = racketVelocity;
            }

            if (collision.gameObject.CompareTag("CPUArea"))
            {
                bounds++;
            }

            if (collision.gameObject.CompareTag("death"))
            {
                if (bounds <= 0||bounds>=2)
                {
                    
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