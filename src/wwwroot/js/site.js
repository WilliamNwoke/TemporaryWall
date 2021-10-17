
// toggle dark mode
const btn = $(".dark-mode-switch");
const theme = $("#theme-link");

btn.on("click", () => {
    btn.prop("checked") ? theme.attr("href", "/css/dark_mode.css") :
        theme.attr("href", "/css/light_mode.css");
})
