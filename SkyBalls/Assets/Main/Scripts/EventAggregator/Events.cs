using UnityEngine;
using SkyBall;

namespace EventAggregation
{

    public class Event_TapOnBall : IEventBase
    {

        public readonly Ball ball;

        public Event_TapOnBall(Ball ball)
        {
            this.ball = ball;
        }

    }

    public class Event_TimeIsLeft : IEventBase { }

    public class Event_BallGotEnd : IEventBase
    {

        public readonly Ball ball;

        public Event_BallGotEnd(Ball ball)
        {
            this.ball = ball;
        }

    }

}