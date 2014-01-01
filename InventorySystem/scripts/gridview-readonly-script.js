
function pageLoad(sender, args) {
    if (args.get_isPartialLoad()) {
        InitializeToolTip();
    }
}



function InitializeToolTip() {
    $(".gridViewToolTip").tooltip({
        track: true,
        delay: 0,
        showURL: false,
        fade: 100,
        bodyHandler: function () {
            return $($(this).next().html());
        },
        showURL: false
    });
}