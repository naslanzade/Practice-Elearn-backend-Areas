$(document).ready(function () {


    $(document).on("click", ".show-more-btn", function () {

      
        let parent = $("#parent");      
        let skipCount = $(parent).children().length;
        let courseCount = $("#course").attr("data-count");

        $.ajax({
            url: `courses/showmoreorless?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                $(parent).append(res);
                let skipCount = $(parent).children().length;
                if (skipCount >= courseCount) {
                    $(".show-more-btn").addClass("d-none")
                    $(".show-less-btn").removeClass("d-none")
                }
            }
        })
    })


    $(document).on("click", ".show-less-btn", function () {

        let parent = $("#parent");
        let skipCount = 0;

        $.ajax({
            url: `courses/showmoreorless?skip=${skipCount}`,
            type: "Get",
            success: function (res) {
                $(parent).empty();
                $(parent).append(res);
                $(".show-less-btn").addClass("d-none")
                $(".show-more-btn").removeClass("d-none")

            }
        })
    })





})