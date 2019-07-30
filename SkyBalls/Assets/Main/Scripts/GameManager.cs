using UnityEngine;
using EventAggregation;

namespace SkyBall
{

    public class GameManager : MonoBehaviour
    {

        public bool useDefaultRules;
        [SerializeField]
        private GameRules rules;


        static private GameManager _instance;

        static public int Score { get { return _instance.score; } }
        static public event System.Action onScoreChange;
        private int score;

        static public float LeftTime { get { return _instance.leftTime; } }
        private float leftTime;

        private float currentBaseSpeed;

        private BallSpawner ballSpawner;

        private Vector3 minPosition;
        private Vector3 maxPosition;
        private float endYPosition;


        void Awake()
        {
            _instance = this;

            if (useDefaultRules)
            {
                rules = GameRules.DefaultGameRules;
            }

            ballSpawner = new BallSpawner(Resources.Load<Ball>("Ball"));
            leftTime = rules.levelDuration;
            currentBaseSpeed = Mathf.Lerp(rules.maxBallSpeed, rules.minBallSpeed, leftTime / rules.levelDuration);

            CalcSpawnBounds();
            
            EventAggregator.Subscribe<Event_TapOnBall>(OnTapOnBall);

            InvokeRepeating("SpawnBall", 0f, rules.levelDuration / rules.ballsAmount);
            InvokeRepeating("DecreaseOneSecond", 1f, 1f);
        }

        void OnDisable()
        {
            EventAggregator.Unsubscribe<Event_TapOnBall>(OnTapOnBall);
        }


        private void DecreaseOneSecond()
        {
            leftTime -= 1f;
            currentBaseSpeed = Mathf.Lerp(rules.maxBallSpeed, rules.minBallSpeed, leftTime / rules.levelDuration);

            if (leftTime <= 0)
            {
                CancelInvoke("SpawnBall");
                CancelInvoke("DecreaseOneSecond");

                EventAggregator.Publish(new Event_TimeIsLeft());
            }
        }

        private void SpawnBall()
        {
            Vector3 startPosition = Vector3.Lerp(minPosition, maxPosition, Random.Range(0f, 1f));
            Vector3 endPosition = new Vector3(startPosition.x, endYPosition, startPosition.z);
            float scale = Random.Range(rules.minBallScale, rules.maxBallScale);
            float speed = currentBaseSpeed / scale;

            ballSpawner.CreateBall().Init(scale, speed, startPosition, endPosition, Random.ColorHSV());
        }

        private void CalcSpawnBounds()
        {
            Camera mainCamera = Camera.main;
            float maxBallScale_half = rules.maxBallScale * 0.5f;

            minPosition = mainCamera.ScreenToWorldPoint(Vector3.zero);
            minPosition.x += maxBallScale_half;
            minPosition.y -= maxBallScale_half;
            minPosition.z = 0f;

            maxPosition = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
            maxPosition.x -= maxBallScale_half;
            maxPosition.y -= maxBallScale_half;
            maxPosition.z = 0f;

            endYPosition = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + maxBallScale_half;
        }


        private void OnTapOnBall(IEventBase event_tapOnBall)
        {
            Ball ball = (event_tapOnBall as Event_TapOnBall).ball;
            AddScore((int)(rules.scoreForBaseBall / ball.scale));
        }

        private void AddScore(int increment)
        {
            score += increment;
            onScoreChange?.Invoke();
        }
        
    }

}