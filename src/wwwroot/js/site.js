
// Toggle between light and dark mode
//const btn = document.querySelector("a.navbar-brand");
const btn = $(".dark-mode-switch");
//const theme = document.querySelector("#theme-link");
const theme = $("#theme-link");

console.log("Button and theme selected");

btn.on("click", () => {
    console.log(theme.prop("href"));
    console.log(theme.prop("href") == "~/css/light_mode.css");
    console.log(window.location.href);

    btn.prop("checked") ? theme.attr("href", "css/dark_mode.css") :
        theme.attr("href", "css/light_mode.css");

    console.log("Current file: " + theme.prop("href"));
})

// $(function () {
//     btn.prop("checked") ? theme.attr("href", "~/css/light_mode.css")
//     : theme.attr("href", "~/css/dark_mode.css");
//     console.log("Button was clicked");
    // if (btn.prop("checked"))
    //     theme.attr("href", "~/css/light_mode.css");
    // else
    //     theme.attr("href", "~/css/dark_mode.css");
// });

// Listen for a click on the button 
// btn.addEventListener("click", function () {
//     console.log("Button was clicked");
//     if (theme.getAttribute("href") == "~/css/light_mode.css") {
//         theme.href = "~/css/dark_mode.css";
//     } else {
//         theme.href = "~/css/light_mode.css";
//     }
// });

// $(function () {
//     $('#theme-link').click(function (e) {
//         $('link').attr('href', $(this).attr('rel'));
//         e.preventDefault();
//     });


// });

