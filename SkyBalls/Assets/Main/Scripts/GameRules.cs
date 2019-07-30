namespace SkyBall
{

    [System.Serializable]
    public class GameRules
    {

        public float levelDuration = 60f;

        public float minBallSpeed = 0.25f;
        public float maxBallSpeed = 0.5f;

        public float minBallScale = 0.5f;
        public float maxBallScale = 2f;

        public int scoreForBaseBall = 20;
        public int ballsAmount = 90;



        public GameRules(float levelDuration, float minBallSpeed, float maxBallSpeed, float minBallScale, float maxBallScale, int scoreForBaseBall, int ballsAmount)
        {
            this.levelDuration = levelDuration;

            this.minBallSpeed = minBallSpeed;
            this.maxBallSpeed = maxBallSpeed;

            this.minBallScale = minBallScale;
            this.maxBallScale = maxBallScale;

            this.scoreForBaseBall = scoreForBaseBall;
            this.ballsAmount = ballsAmount;
        }

        static public GameRules DefaultGameRules
        {
            get { return new GameRules(60f, 0.25f, 0.5f, 0.5f, 2f, 20, 90); }
        }

    }

}