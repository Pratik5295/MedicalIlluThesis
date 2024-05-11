using System;
using UnityEngine;


namespace KrazyKrakenGames.ThesisProject.InputHandling
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Input Handler Reference")]
        [SerializeField] private PlayerActionInputHandler _input;

        [Space(5)]
        [Header("UI Variable Handlers")]
        [SerializeField] private bool raycasterFired = false;


        private Vector3 startPos, endPos, direction;

        //Actions for model script
        public Action<bool> OnShowModelInfoInput;
        public Action<Vector2> OnRotateModelInput;

        //Actions for camera script
        public Action<Vector2> OnScrollModelInput;

        private void Start()
        {
            _input = GetComponent<PlayerActionInputHandler>();
        }

        private void Update()
        {
            if (_input.Hold)
            {
                //Left mouse button is being held
                ActivateRaycaster();
                RotationInput();
            }
            else
            {
                DeactivateRaycaster();
            }

            ScrollInput();
        }

        private void RotationInput()
        {
            if (_input.Look != Vector2.zero)
            {
                OnRotateModelInput(_input.Look);
            }
        }

        private void ScrollInput()
        {
            if(_input.Scroll != Vector2.zero)
            {
                OnScrollModelInput(_input.Scroll);
            }
        }

        private void ActivateRaycaster()
        {
            if (!raycasterFired)
            {
                raycasterFired = true;
                RaycasterInputHandler();
            }
        }

        private void DeactivateRaycaster()
        {
            if (raycasterFired)
            {
                raycasterFired = false;
            }
        }

        private void RaycasterInputHandler()
        {
            startPos = Camera.main.ScreenToWorldPoint(new Vector3(_input.Location.x, _input.Location.y, Camera.main.nearClipPlane));

            endPos = Camera.main.ScreenToWorldPoint(new Vector3(_input.Location.x, _input.Location.y, 100f));
            RaycastHit hit;

            direction = endPos - startPos;
            Debug.DrawRay(startPos, direction);

            if(Physics.Raycast(startPos, direction, out hit, Mathf.Infinity))
            {
                OnShowModelInfoInput?.Invoke(true);
            }
            else
            {
                OnShowModelInfoInput?.Invoke(false);
            }
        }

        private void OnDrawGizmos()
        {
            if (_input != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(startPos, 0.2f);

                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(endPos, 0.2f);

                Vector3 direction = endPos - startPos;

                Gizmos.DrawRay(startPos, direction);
            }
        }
    }
}
