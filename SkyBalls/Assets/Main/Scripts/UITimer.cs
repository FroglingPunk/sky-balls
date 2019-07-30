using UnityEngine;
using UnityEngine.UI;

namespace SkyBall
{

    public class UITimer : MonoBehaviour
    {

        [SerializeField]
        private Text time_text;
        private int previousTime;


        void Update()
        {
            if (previousTime != (int)GameManager.LeftTime)
            {
                previousTime = (int)GameManager.LeftTime;
                time_text.text = previousTime.ToString();
            }
        }


        public void Show()
        {
            gameObject.SetActive(true);
            previousTime = (int)GameManager.LeftTime;
            time_text.text = previousTime.ToString();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }

}