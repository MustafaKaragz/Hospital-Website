
function toggleSidebar() {
        var sidebar = document.getElementById("sidebar");
        var mainContent = document.getElementById("main-content");

        if (sidebar.style.width === "250px") {
            sidebar.style.width = "0";
            mainContent.style.marginLeft = "0";
        } else {
            sidebar.style.width = "250px";
            mainContent.style.marginLeft = "250px";
        }
    }