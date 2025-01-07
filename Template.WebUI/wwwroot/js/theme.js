function applyStoredTheme() {
    console.log("Test")
    const storedTheme = localStorage.getItem('theme') || 'light';
    document.documentElement.classList.toggle('dark', storedTheme === 'dark');
}

//function toggleTheme() {
//    const isDarkMode = document.documentElement.classList.toggle('dark');
//    localStorage.setItem('theme', isDarkMode ? 'dark' : 'light');
//}

applyStoredTheme();