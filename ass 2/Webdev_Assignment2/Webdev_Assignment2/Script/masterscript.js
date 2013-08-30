function showIt() {
    if (document.getElementById("SuccessBoxMessage").style.display == 'block')
        document.getElementById("SuccessBoxMessage").style.display = 'none';

    if (document.getElementById("FailBoxMessage").style.display == 'block')
        document.getElementById("FailBoxMessage").style.display = 'none';
}

function toggle_visibility(id) {
    var box = $('#' + id);
    box.fadeIn(3000);
}