module.exports = {
    content: [
        "./**/*.razor",
        "./**/*.cshtml"
    ],
    darkMode: 'class',
    theme: {
        extend: {
            spacing: {
                '13%': '13%',
                '87%': '87%'
            },
            fontFamily: {
                tajawalRegular: ['Tajawal-Regular', 'sans-serif'],
                tajawalBold: ['Tajawal-Bold', 'sans-serif'],
            },
            colors: {
                lightPrimary: '#fffcfc',
                lightSecondary: '#e0dede',
                lightTertiary: '#cccaca',
                darkPrimary: '#212121',
                darkSecondary: '#242323',
                darkTertiary: '#919090',
            },
        },
    },

    plugins: [],
}