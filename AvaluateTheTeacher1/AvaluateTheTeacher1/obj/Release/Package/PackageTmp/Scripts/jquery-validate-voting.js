$('input[type="submit"]').click(function () {
    var index = 0;
    $("tr").addClass("validate-border");
    $('input[type="radio"]:checked').each(function () {
        if (this.value >= 1 && this.value <= 10) {
            var idSelectedElement = $(this).parent().parent().attr('id');
            $('tr[id=' + idSelectedElement + ']').children('td:last-child').css('border', 'none');
            index++;
        }
    });
    $('tfoot td')
        .css('border', 'none');
    if (index < 17) {
        $(".text-danger").text("Дайте відповідь на всі запитання!");
    }
});