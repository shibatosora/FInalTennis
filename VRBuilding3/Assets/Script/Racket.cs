using UnityEditorInternal;
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
        private int MaxHP = 10;
        private int Power = 2;
        private int MP = 10;
        private int Define;

        public int _HP;
        public int _power;
        public int _MP;
        public int _define;
        //スキル
        private bool fireBall = false;
        private bool aquaCure = false;
        private bool leafGard = false;
        public bool playerTurn = false;

        void Start()
        {
            lastPosition = transform.position;
            _HP = MaxHP;
            _power = Power;
            _define = Define;
            _MP = MP;
        }

        public void SkillFireBall() { fireBall = true; _gameManager.Spawn(); }
        public void SkillAquaCure() { aquaCure = true;_gameManager.Spawn(); }
        public void SkillLeafGard() { leafGard = true;_gameManager.Spawn();  }
        //行動選択<GameManager>.StartPlayerTurn()>>
        public void StartTurn()
        {
            playerTurn = true;
            StartCoroutine(logManager.TypeLog($"あなたのターンです。\n行動を選択してください。"));
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
            _define = 2;
        }

        public void Skill()
        {
            if (fireBall == true)
            {
                
            }
            if (aquaCure == true)
            {
                
            }
            if (leafGard == true)
            {
                
            }
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
