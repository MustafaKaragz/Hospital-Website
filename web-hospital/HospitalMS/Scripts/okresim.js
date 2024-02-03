

    document.addEventListener('DOMContentLoaded', function() {
        var nextButton = document.querySelector('.next');
    var prevButton = document.querySelector('.prev');

    if (nextButton && prevButton) {
        nextButton.addEventListener('click', function () {
            navigate(1); // Next image
        });

    prevButton.addEventListener('click', function() {
        navigate(-1); // Previous image
            });
        }

    function navigate(step) {
            var current = document.querySelector('.carousel img.active');
    var images = document.querySelectorAll('.carousel img');
    var index = Array.prototype.indexOf.call(images, current);

    current.classList.remove('active');
    var newIndex = (index + step + images.length) % images.length;

    for (var i = 0; i < images.length; i++) {
        images[i].classList.remove('active');
            }

    images[newIndex].classList.add('active');
        }
    });




  