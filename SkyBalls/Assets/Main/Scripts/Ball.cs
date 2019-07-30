using UnityEngine;
using EventAggregation;

namespace SkyBall
{

    public class Ball : MonoBehaviour
    {

        private Transform _trans;
        private Vector3 startPosition;
        private Vector3 endPosition;
        private float progress;

        public float speed { private set; get; }
        public float scale { private set; get; }


        void Update()
        {
            progress += Time.deltaTime * speed;
            _trans.position = Vector3.Lerp(startPosition, endPosition, progress);

            if (progress >= 1f)
            {
                EventAggregator.Publish(new Event_BallGotEnd(this));
            }
        }


        public void Init(float scale, float speed, Vector3 startPosition, Vector3 endPosition, Color color)
        {
            _trans = transform;
            progress = 0f;

            this.scale = scale;
            this.speed = speed;
            this.startPosition = startPosition;
            this.endPosition = endPosition;

            _trans.localScale = Vector3.one * scale;
            _trans.position = startPosition;
            GetComponent<Renderer>().material.color = color;

            gameObject.SetActive(true);
        }

        public void Deinit()
        {
            gameObject.SetActive(false);
        }

    }

}