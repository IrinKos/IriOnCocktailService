$("#logout").on("click", () => {
    console.log("wlizam");
    $.ajax({
        type: "Get",
        url: "/Home/Logout",
        success: () => {
            window.location.replace("/");
        }
    })
})