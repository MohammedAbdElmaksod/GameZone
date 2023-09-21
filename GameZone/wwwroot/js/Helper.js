var Helper = {
    previewImg: function (event) {
        var image = document.getElementById('previewImg');
        image.style.display = 'block';
        var reader = new FileReader();
        reader.onload = function () {
            image.src = reader.result;
        }
        reader.readAsDataURL(event.target.files[0]);
    },
     
}
