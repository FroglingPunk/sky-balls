using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SkyBall.UI
{
    public class UIGameOverPanel : MonoBehaviour
    {
        [SerializeField] private Text score_text;


        public void Show()
        {
            gameObject.SetActive(true);
            score_text.text = GameManager.Score.ToString();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }



        public void OnRestartGameButtonPressed()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnExitGameButtonPressed()
        {
            Application.Quit();
        }
    }
}