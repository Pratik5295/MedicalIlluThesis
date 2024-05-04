using UnityEngine;
using UnityEngine.InputSystem;

namespace KrazyKrakenGames.ThesisProject.InputHandling
{
    public class PlayerActionInputHandler : MonoBehaviour
    {
        [Header("Player Input Values")]

        public Vector2 Look;
        public Vector2 Scroll;

        public bool Hold;

        public void OnHold(InputValue inputValue)
        {
            SetHoldValue(inputValue.isPressed);
        }

        public void OnScroll(InputValue inputValue)
        {
            SetScrollValue(inputValue.Get<Vector2>());
        }

        public void OnLook(InputValue inputValue)
        {
            SetLookValue(inputValue.Get<Vector2>());
        }


        private void SetHoldValue(bool newHoldState)
        {
            Hold = newHoldState;
        }

        private void SetScrollValue(Vector2 newScrollState)
        {
            Scroll = newScrollState;
        }

        private void SetLookValue(Vector2 newLookState)
        {
            Look = newLookState;
        }

    }
}
