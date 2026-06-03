using System;

namespace Greeting_App.Services
{
    public class AuthenticationStateService
    {
        // Private backing field holding the authentication state status flag
        private bool _isAuthenticated = false;

        // Public property accessor exposed to all layout components
        public bool IsAuthenticated => _isAuthenticated;

        // Event handler mechanism that components subscribe to for UI state re-rendering
        public event Action? OnStateChange;

        public void LogIn()
        {
            if (!_isAuthenticated)
            {
                _isAuthenticated = true;
                NotifyStateChanged();
            }
        }

        public void LogOut()
        {
            if (_isAuthenticated)
            {
                _isAuthenticated = false;
                NotifyStateChanged();
            }
        }

        // Fired automatically to inform listening razor structural layers to re-evaluate state
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}