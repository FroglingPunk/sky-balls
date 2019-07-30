using System.Collections.Generic;
using EventAggregation;
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

            EventAggregator.Subscribe<Event_TapOnBall>(OnBallTapped);
            EventAggregator.Subscribe<Event_BallGotEnd>(OnBallGotEnd);
        }


        public Ball CreateBall()
        {
            return (pool.Count > 0) ? pool.Pop() : UnityEngine.Object.Instantiate(ball_prefab);
        }



        private void OnBallTapped(IEventBase event_tapOnBall)
        {
            AddToPool((event_tapOnBall as Event_TapOnBall).ball);
        }

        private void OnBallGotEnd(IEventBase event_ballGotEnd)
        {
            AddToPool((event_ballGotEnd as Event_BallGotEnd).ball);
        }

        private void AddToPool(Ball ball)
        {
            ball.Deinit();
            pool.Push(ball);
        }


        public void Dispose()
        {
            EventAggregator.Unsubscribe<Event_TapOnBall>(OnBallTapped);
            EventAggregator.Unsubscribe<Event_BallGotEnd>(OnBallGotEnd);
        }

    }

}