$(function () {

    const NavheaderHeight = $("#NavHeader").height();
    const containerFluidHeight = $("#containerFluid").height()
    $("#sidebarHeader").height(NavheaderHeight);
    $("#sidebarHeaderCenter").height(containerFluidHeight)

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
