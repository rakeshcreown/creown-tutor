var callnext = true;
$(function () {
    //callnext = false;
    setInterval(ShowLaunch, 1000);
});

function ShowLaunch() {
    if (callnext == true) {
        $.each($(".coursecreateddate"), function (i, item) {
            var dt = $(item).attr("crdate").replace('-', '/').replace('-', '/');
            console.log("dt", dt);
            var arr = dt.split(' ');
            var orgdate = new Date((arr[0] + "T" + arr[1] + "Z").replace(/\-/g, '\/').replace(/[T|Z]/g, ' '));
            var date = new Date((arr[0] + "T" + arr[1] + "Z").replace(/\-/g, '\/').replace(/[T|Z]/g, ' '));
            date.setMinutes(date.getMinutes() - 15);
            var currentdate = new Date();

            if (currentdate >= date && currentdate <= orgdate) {
                $(".btnLaunch").show();

                var dataObject = JSON.stringify({
                    'userid': currentuserid,
                    'courseid': $(item).attr("courseid")
                });
                callnext = false;
                $.ajax({
                    url: '/Ajax/SendPreNotification',
                    type: 'POST',
                    contentType: 'application/json',
                    done: function () {
                        console.log("success");
                        callnext = true;
                    },
                    fail: function () {
                        console.log("fail");
                        callnext = true;
                    },
                    data: dataObject
                });
            }
            else {
                $(".btnLaunch").hide();
            }
        });
    }
}