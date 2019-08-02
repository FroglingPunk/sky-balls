using System.Collections.Generic;
using System;

namespace SkyBall
{

    public class BallSpawner : IDisposable
    {

        private Ball ball_prefab;
        private Stack<Ball> pool = new Stack<Ball>();


        public BallSpawner(Ball ball_prefab)
        {
            this.ball_prefab = ball_prefab;
            InputManager.onTappingOnBall += AddToPool;
        }


        public Ball CreateBall()
        {
            Ball ball = (pool.Count > 0) ? pool.Pop() : UnityEngine.Object.Instantiate(ball_prefab);
            ball.onGotToEnd += AddToPool;
            return ball;
        }

        private void AddToPool(Ball ball)
        {
            ball.onGotToEnd -= AddToPool;
            ball.Deinit();
            pool.Push(ball);
        }

        public void Dispose()
        {
            InputManager.onTappingOnBall -= AddToPool;
        }

    }

}