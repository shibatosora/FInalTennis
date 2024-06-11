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
        [SerializeField] private GameObject fireBallEffect;
        [SerializeField] private GameObject aquaCureEffct;
        [SerializeField] private GameObject leafGuardEffect;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            raket = GameObject.Find("PingPongBat").GetComponent<Racket>();
            gameManager = GameObject.Find("PingPongTable").GetComponent<GameManager>();
            enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        }

        public void FireBall()
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Instantiate(fireBallEffect, effectPosition, Quaternion.identity);
            
        }
        public void AquaBall()
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Instantiate(aquaCureEffct, effectPosition, Quaternion.identity);   
        }

        public void LeafGuard()
        {
            Vector3 effectPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Instantiate(leafGuardEffect, effectPosition, Quaternion.identity);   
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
                    Destroy(this.gameObject);
                }
                bounds = 0;
                gameManager.EndPlayerTurn();
            }
        }

    }
}