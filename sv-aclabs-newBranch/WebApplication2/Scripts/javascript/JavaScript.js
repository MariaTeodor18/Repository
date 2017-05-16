
$(document).ready(function() {

    var updateResources = function () {

        updateResource("Clay");
        updateResource("Wheat");
        updateResource("Wood");
        updateResource("Iron");
    };

    var updateResource = function (resourceName) {
        console.log('apel ok');

        var start = new Date();
        var currentProduction = 0;
        var currentValue = parseFloat($(".res-value." + resourceName).text());
        var lastUpdate = Date.parse($(".res-lastUpdate." + resourceName).text());

        var mines = $(".mine-wrapper").find("." + resourceName);

        $.each(mines, function (index, value) {

             currentProduction += parseInt($(value).find(".hourProduction").text());        

        });

        console.log(currentValue, currentProduction);
        var nextValue = (currentValue + ((start.getTime() - lastUpdate) / 1000 / 60 / 60) * currentProduction).toFixed(4);

        $(".res-value." + resourceName).text(nextValue); /*seteaza valoarea*/
        $(".res-lastUpdate." + resourceName).text(start.strftime("%Y-%m-%d %H:%M:%S"));

        console.log(nextValue);
    };

    setInterval(updateResources, 1000);


    var getMineDetailsHTML = function (mineId) {
        $('#mine-details-container > .content').empty();
        $('#mine-details-container > .content').load('/Mines/Details?mineId=' + mineId);
        $('#mine-details-container').addClass('show');
    }

    $('.mine-details-btn').click(function () {
        var mineId = $(this).data('mine-id');
        getMineDetailsHTML(mineId);
    });

    $('#mine-details-container > .close-btn').click(function () {
        $('#mine-details-container').removeClass('show');
    });
});
