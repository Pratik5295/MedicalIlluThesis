using System;
using UnityEngine;

namespace KrazyKrakenGames.ThesisProject.GameUI
{
    /// <summary>
    /// This UI helper script will be responsible for showcasing and toggling other gameobjects
    /// </summary>
    public class ToggleItem : MonoBehaviour
    {
        [SerializeField] private bool toggle = false;

        [SerializeField] private GameObject content;

        public Action<bool> OnToggleEvent;

        private void Start()
        {
            OnToggleEvent += OnToggleHandle;
            OnToggleHandle(false);
        }

        private void OnDestroy()
        {
            OnToggleEvent -= OnToggleHandle;
        }

        public void ChangeToggle()
        {
            toggle = !toggle;
            OnToggleEvent?.Invoke(toggle);
        }

        private void OnToggleHandle(bool _toggle)
        {
            content.SetActive(_toggle);
        }
    }
}
