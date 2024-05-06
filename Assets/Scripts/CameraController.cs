using KrazyKrakenGames.ThesisProject.InputHandling;
using UnityEngine;

namespace KrazyKrakenGames.ThesisProject.GameCamera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        [SerializeField] private float maxZoom = 2;
        [SerializeField] private float minZoom = 10;

        [SerializeField] private float scrollAmount = 0.25f;
        [SerializeField] private float zoomSpeed = 5f;

        private void Start()
        {
            if(playerController != null)
            {
                playerController.OnScrollModelInput += OnScrollModelInputHandler;
            }
        }

        private void OnDestroy()
        {
            if (playerController != null)
            {
                playerController.OnScrollModelInput -= OnScrollModelInputHandler;
            }
        }

        private void OnScrollModelInputHandler(Vector2 scrollPos)
        {
            if(scrollPos.y < 0)
            {
                Debug.Log("Zoom out");

                if (transform.position.z < minZoom)
                {
                    Vector3 targetPosition = transform.position + Vector3.forward * scrollAmount;

                    transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed);
                }
            }
            else if(scrollPos.y > 0)
            {
                Debug.Log("Zoom in");

                if(transform.position.z > maxZoom)
                {
                    Vector3 targetPosition = transform.position - Vector3.forward * scrollAmount;

                    transform.position = Vector3.Lerp(transform.position, targetPosition, zoomSpeed);
                }
            }
        }
    }
}
