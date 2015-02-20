

window.onload = function (e) {

    remoteMediaApp.init();

}


var remoteMediaApp = {

    defination: {
        apiUrl: "http://localhost:9000/api/media/"
    },

    init: function() {
        $(".js-remoteMediaApp .media-controls button").on("click", function() {
            remoteMediaApp.apiRequest.get($(this).data("action"));
        });
    },
    apiRequest: {
        get: function (action) {

            //action validation
            switch (action) {
                case "playPause":
                    break;
                case "volumeUp":
                    break;
                case "volumeDown":
                    break;
                case "volumeMute":
                    break;
                default :
                    alert("unknown action. action:" + action);
                    break;
            }


            var url = remoteMediaApp.defination.apiUrl + action;
            
            $.ajax({
                type: "get",
                url: url,
                success: function (data) {
                    if (data) {
                        $(".js-alert-info").text(action).fadeIn(900, function () {
                            $(this).fadeOut(900);
                        });
                    }
                },
                error: function (a,b,c) {
                    alert("server not found.");
                }
            });

        }
    }
}