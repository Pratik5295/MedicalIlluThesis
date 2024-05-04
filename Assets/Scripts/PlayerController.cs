using System;
using UnityEngine;


namespace KrazyKrakenGames.ThesisProject.InputHandling
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Input Handler Reference")]
        [SerializeField] private PlayerActionInputHandler _input;

        [Space(5)]
        [Header("Model References")]
        [SerializeField] private GameObject modelReference;


        public Action<Vector2> OnRotateModelInput;
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

                RotationInput();
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
    }
}
