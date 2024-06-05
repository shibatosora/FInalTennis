using UnityEngine;

namespace Script
{
    public class Racket : MonoBehaviour
    {
        [SerializeField] Transform SpawnPoint;
        [SerializeField] GameObject ballPrefab;
        [SerializeField] private float ballpower = 0.01f;
        [SerializeField] GameManager _gameManager;
        [SerializeField] private LogManager logManager;
        private Vector3 lastPosition;
        public Vector3 velocity;
        private int ballCount = 0;

        private bool AttackChance = false;

        //ステータス
        private int HP = 5;
        public int Power = 2;
        private int MP = 10;
        private int define;


        public bool playerTurn = false;

        void Start()
        {
            lastPosition = transform.position;
        }

        public void StartTurn()
        {
            playerTurn = true;
            StartCoroutine(logManager.TypeLog($"あなたのターンです。"));
        }

        public void EndTurn()
        {
            playerTurn = false;
        }

        public void Attack()
        {
            AttackChance = true;
            ballCount = 1;

        }

        public void Defend()
        {
            define = 2;
        }

        public void Skill()
        {

        }

        public void PlayerDamage()
        {

        }

        void Update()
        {
            velocity = (transform.position - lastPosition) / Time.deltaTime;
            lastPosition = transform.position;


            if (OVRInput.GetDown(OVRInput.Button.One) && playerTurn == true)
            {
                GameObject ball;
                Rigidbody ballRigidbody;

                ball = Instantiate(ballPrefab, SpawnPoint.position, Quaternion.identity);

                ballRigidbody = ball.GetComponent<Rigidbody>();
                ballRigidbody.AddForce(new Vector3(0f, ballpower, 0f), ForceMode.Impulse);
            }
        }
    }
}
