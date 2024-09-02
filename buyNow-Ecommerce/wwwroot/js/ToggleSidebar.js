$(function () {

    $('#openSidebar').on(
        'click',
        function (e) {

            const element = $('#sideBar');
            console.log("open", element);
            $('#sideBar').addClass('show-side-bar');
        });


    $('#closeSidebar').on(
        'click',
        function (e) {
            const element = $('#sideBar');
            console.log("close", element.attr("class"));
           
            $('#sideBar').removeClass('show-side-bar');
        });

});
