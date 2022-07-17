function resetForm() {
    $("#name").val("");
    $("#price").val("");
    $("#formImageFile").val(null);
}
document.getElementById("formImageFile").onchange = function () {
    var reader = new FileReader();
    if (this.files[0].size > 528385*10) {
        alert("Image Size should not be greater than 5MB");
        $("#formImageFile").attr("src", "blank");
        $("#formImageFile").hide();
        $('#formImageFile').wrap('<form>').closest('form').get(0).reset();
        $('#formImageFile').unwrap();
        return false;
    }
    if (this.files[0].type.indexOf("image") == -1) {
        alert("Invalid Type");
        $("#formImageFile").attr("src", "blank");
        $("#formImageFile").hide();
        $('#formImageFile').wrap('<form>').closest('form').get(0).reset();
        $('#formImageFile').unwrap();
        return false;
    }
    reader.onload = function (e) {
        document.getElementById("formImageFile").src = e.target.result;
        $("#formImageFile").show();
    };

    reader.readAsDataURL(this.files[0]);
};

$('.float-number').keypress(function (event) {
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});