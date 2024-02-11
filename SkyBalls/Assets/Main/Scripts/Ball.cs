using UnityEngine;

namespace SkyBall
{
    public class Ball : MonoBehaviour
    {
        private Vector3 startPosition;
        private Vector3 endPosition;
        private float progress;

        public float speed { private set; get; }
        public float scale { private set; get; }

        public event System.Action<Ball> onGotToEnd;


        void Update()
        {
            progress += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, progress);

            if (progress >= 1f)
            {
                onGotToEnd?.Invoke(this);
            }
        }


        public void Init(float scale, float speed, Vector3 startPosition, Vector3 endPosition, Color color)
        {
            progress = 0f;

            this.scale = scale;
            this.speed = speed;
            this.startPosition = startPosition;
            this.endPosition = endPosition;

            transform.localScale = Vector3.one * scale;
            transform.position = startPosition;
            GetComponent<Renderer>().material.color = color;

            gameObject.SetActive(true);
        }

        public void Deinit()
        {
            gameObject.SetActive(false);
        }
    }
}