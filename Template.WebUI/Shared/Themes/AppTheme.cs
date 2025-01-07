using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Template.WebUI.Shared.Themes
{
    public class AppTheme
    {
        private readonly IJSRuntime _jsRuntime;

        public string CurrentTheme { get; private set; } = "light";

        public AppTheme(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializeThemeAsync()
        {
            var storedTheme = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "theme");
            CurrentTheme = string.IsNullOrEmpty(storedTheme) ? "light" : storedTheme;

            // Applique la classe "dark" si nécessaire
            await ApplyThemeAsync();
        }

        public async Task ToggleThemeAsync()
        {
            CurrentTheme = CurrentTheme == "light" ? "dark" : "light";
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", "theme", CurrentTheme);

            // Applique le nouveau thème
            await ApplyThemeAsync();
        }

        private async Task ApplyThemeAsync()
        {
            await _jsRuntime.InvokeVoidAsync("document.documentElement.classList.toggle", "dark", CurrentTheme == "dark");
        }
    }
}
