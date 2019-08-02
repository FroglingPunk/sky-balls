using UnityEngine;

namespace SkyBall.UI
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

            GameManager.onTimeIsLeft += ShowGameOverPanel;
        }

        void OnDisable()
        {
            GameManager.onTimeIsLeft -= ShowGameOverPanel;
        }


        private void ShowGameOverPanel()
        {
            gameoverPanel.Show();
            timer.Hide();
            scoreboard.Hide();
        }

    }

}