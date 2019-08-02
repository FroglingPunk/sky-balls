using UnityEngine;

namespace SkyBall
{

    public class InputManager : MonoBehaviour
    {

        private Camera mainCamera;

        static public event System.Action<Ball> onTappingOnBall;



        void Start()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit))
                {
                    Ball ball = hit.collider.GetComponent<Ball>();

                    if(ball != null)
                    {
                        onTappingOnBall?.Invoke(ball);
                    }
                }
            }
        }

    }

}