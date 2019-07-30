using UnityEngine;
using EventAggregation;

namespace SkyBall
{

    public class UIManager : MonoBehaviour
    {

        [SerializeField]
        private UITimer timer;

        [SerializeField]
        private UIScoreBoard scoreboard;

        [SerializeField]
        private UIGameOverPanel gameoverPanel;



        void Start()
        {
            gameoverPanel.Hide();
            timer.Show();
            scoreboard.Show();

            EventAggregator.Subscribe<Event_TimeIsLeft>(OnTimeIsLeft);
        }

        void OnDisable()
        {
            EventAggregator.Unsubscribe<Event_TimeIsLeft>(OnTimeIsLeft);
        }


        private void OnTimeIsLeft(IEventBase event_timeIsLeft)
        {
            gameoverPanel.Show();
            timer.Hide();
            scoreboard.Hide();
        }

    }

}