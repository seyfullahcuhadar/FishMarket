function resetForm() {
    $("#name").val("");
    $("#Price").val("");
    $("#formImageFile").val(null);
}

$('.float-number').keypress(function (event) {
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});