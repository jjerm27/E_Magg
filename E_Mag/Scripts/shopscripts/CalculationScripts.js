
function add_to_cart_complete(request, status) {
    var mas = request["responseText"].split("|");

    //for (var key in mas) {
    //    // этот код будет вызван для каждого свойства объекта
    //    // ..и выведет имя свойства и его значение

    //    alert("Ключ: " + key + " значение: " + mas[key]);
    //}


    $("#mInp_" + mas[1]).val(mas[0]);
    var sum = Number(mas[0]) * Number(mas[2].replace(",", "."));
    $("#tot_" + mas[1]).text(sum.toFixed(2));

    $("#sub_total").text((Number($("#sub_total").text().replace(",", ".")) + Number(mas[2].replace(",", "."))).toFixed(2));

    $("#total_sum").text((((Number($("#tax").text()) / 100) * Number($("#sub_total").text())) + Number($("#sub_total").text())).toFixed(2));

}

function remove_from_cart_minus(request, status) {
    var mas = request["responseText"].split("|");

    if ($("#mInp_" + mas[1]).val() > 1) {
        $("#sub_total").text((Number($("#sub_total").text().replace(",", ".")) - Number(mas[2].replace(",", "."))).toFixed(2));

        $("#total_sum").text((((Number($("#tax").text()) / 100) * Number($("#sub_total").text())) + Number($("#sub_total").text())).toFixed(2));
    }

    $("#mInp_" + mas[1]).val(mas[0]);
    var sum = Number(mas[0]) * Number(mas[2].replace(",", "."));
    $("#tot_" + mas[1]).text(sum.toFixed(2));
}

function remove_from_cart_complete(request, status) {
    var mas = request["responseText"].split("|");
    $("#row_" + mas[0]).remove();
    if ($("#_tbody").children().length == 0) {
        $("#cart_items").remove();
        $("#empty_cart").append("<p class=\"cart_description\">Ваша корзина пуста</p>");
    }

    if ($("#_tbody").children().length > 0) {

        var first = Number($("#sub_total").text().replace(",", "."));
        var x = (first - (Number(mas[1].replace(",", ".")) * Number(mas[2]))).toFixed(2);

        $("#sub_total").text(x);

        $("#total_sum").text((((Number($("#tax").text()) / 100) * Number($("#sub_total").text())) + Number($("#sub_total").text())).toFixed(2));
    }
    else {
        $("#sub_total").text("0");
        $("#total_sum").text("0");
    }
}
