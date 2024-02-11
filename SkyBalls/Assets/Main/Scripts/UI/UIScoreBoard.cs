using UnityEngine;
using UnityEngine.UI;

namespace SkyBall.UI
{
    public class UIScoreBoard : MonoBehaviour
    {
        [SerializeField] private Text score_text;


        public void Show()
        {
            gameObject.SetActive(true);
            GameManager.onScoreChange += SetScoreText;
            score_text.text = GameManager.Score.ToString();
        }

        public void Hide()
        {
            GameManager.onScoreChange -= SetScoreText;
            gameObject.SetActive(false);
        }


        private void SetScoreText()
        {
            score_text.text = GameManager.Score.ToString();
        }
    }
}