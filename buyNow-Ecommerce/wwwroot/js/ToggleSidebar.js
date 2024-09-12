$(function () {

    const NavheaderHeight = $("#NavHeader").height();
    const containerFluidHeight = $("#containerFluid").height()
    $("#sidebarHeader").height(NavheaderHeight);
    $("#sidebarHeaderCenter").height(containerFluidHeight)

    $(window).on("resize", function () {
        const screenWidth = screen.width;
        console.log(screenWidth)

        if (screenWidth <= 450) {

            var nav = $(".navbar-nav");
            $(".navbar-nav").css("display", "none");
            $("#openSidebar").css("display", "block");
            
            console.log("hello", nav)
        } else {
            $(".navbar-nav").css("display", "block")

            $("#openSidebar").css("display", "none");

            if (screenWidth >= 450) {
                $('#sideBar').removeClass('show-side-bar');
            }
};
    })
    

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
