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




document.addEventListener('DOMContentLoaded', function () {
    var images = document.querySelectorAll('.carousel1 img');
    var currentIndex = 0;


    function updateCarousel() {
        images[currentIndex].classList.remove('active1');
        currentIndex = (currentIndex + 1) % images.length;
        images[currentIndex].classList.add('active1');
    }


    setInterval(updateCarousel, 2000);


    var nextButton = document.querySelector('.next1');
    var prevButton = document.querySelector('.prev1');

    nextButton.addEventListener('click', function () {
        updateCarousel();
    });

    prevButton.addEventListener('click', function () {
        images[currentIndex].classList.remove('active1');
        currentIndex = (currentIndex - 1 + images.length) % images.length;
        images[currentIndex].classList.add('active1');
    });
});


function scrollToSection() {
    var section = document.getElementById('services1');
    section.scrollIntoView({ behavior: 'smooth', block: 'start' });
}



function redirectTo(url) {

    document.getElementById('loading').style.display = 'block';


    setTimeout(function () {
        document.getElementById('loading').style.display = 'none';
        window.location.href = url;
    }, 1000);
}


document.addEventListener('DOMContentLoaded', function () {
    document.querySelectorAll('.detail-button1').forEach(function (button) {
        button.addEventListener('click', function () {
            var cardContent = this.parentElement;
            var summary = cardContent.querySelector('.summary1');
            var fullMessage = cardContent.querySelector('.full-message1');

            summary.style.display = 'none';
            fullMessage.style.display = 'block';
        });
    });
});