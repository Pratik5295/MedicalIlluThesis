using UnityEngine;
using UnityEngine.InputSystem;

namespace KrazyKrakenGames.ThesisProject.InputHandling
{
    public class PlayerActionInputHandler : MonoBehaviour
    {
        [Header("Player Input Values")]

        public Vector2 Look;
        public Vector2 Scroll;
        public Vector2 Location;

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

        public void OnLocation(InputValue inputValue)
        {
            SetLocationValue(inputValue.Get<Vector2>());
        }


        private void SetHoldValue(bool newHoldState)
        {
            Hold = newHoldState;
        }

        private void SetScrollValue(Vector2 newScrollState)
        {
            Scroll = newScrollState;
        }
        private void SetLocationValue(Vector2 newLocationValue)
        {
            Location = newLocationValue;
        }


        private void SetLookValue(Vector2 newLookState)
        {
            Look = newLookState;
        }

    }
}
