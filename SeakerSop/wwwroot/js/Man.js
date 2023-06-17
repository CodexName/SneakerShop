window.addEventListener('DOMContentLoaded', function () {
    const images = document.querySelectorAll('.image-container img');
    let currentIndex = 0;

    function fadeInNextImage() {
        const currentImage = images[currentIndex];
        const nextIndex = (currentIndex + 1) % images.length;
        const nextImage = images[nextIndex];

        currentImage.classList.add('fade-out');
        nextImage.classList.remove('fade-out');

        currentIndex = nextIndex;
    }

    setInterval(fadeInNextImage, 3000);
});