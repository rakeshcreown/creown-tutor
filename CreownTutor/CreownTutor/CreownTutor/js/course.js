var sessions = [];
$(document).ready(function () {
    sessions = [];
});

$(function () {
    $('#datetimepicker1').datetimepicker({ format: 'MM-DD-YYYY HH:mm:ss' });
    $('.datetimepicker1').datetimepicker({ format: 'MM-DD-YYYY HH:mm:ss' });
    $("#datetimepicker1").on("dp.change", function (e) {
        if (sessions.length == 0) {
            $('#sdatetimepicker12').data("DateTimePicker").minDate(e.date);
        }
    });
    $("#sdatetimepicker12").on("dp.change", function (e) {
        $('#enddatetimepicker12').data("DateTimePicker").minDate(e.date);
    });
    loadsessions();
});

function loadsessions() {
    try {
        if (jsoncourse != '' && jsoncourse != undefined) {
            var jsessions = JSON.parse(jsoncourse);
            $.each(jsessions, function (i, item) {
                item.ToDateTime = item.ToDateTime.replace('T', ' ');
                item.FromDateTime = item.FromDateTime.replace('T', ' ');
                var session = { "name": item.Title, "desc": item.Description, "sdate": item.FromDateTime, "enddate": item.ToDateTime, "id": item.SessionID };
                sessions.push(session);

                $("#tblsession .tbd").append("<tr><td>" + item.Title + "</td><td>" + item.Description + "</td><td>" + item.FromDateTime + "</td><td>" + item.ToDateTime + "</td><td><a href='javascript:void();' class='UpdateSession btn btn-block btn-dark btn-theme-colored btn-sm mt-20 pt-10 pb-10' sessionid='" + item.SessionID + "'  >Update</a><a href='javascript:void();' class='DeleteSession btn btn-block btn-dark btn-theme-colored btn-sm mt-20 pt-10 pb-10' sessionid='" + item.SessionID + "'  >Delete</a>  </td></tr>");
            });
        }
    }
    catch (e) { console.log(e); }
}

$(document).on('click', '.UpdateSession', function () {
    var sessionid = $(this).attr("sessionid");
    var jsessions = JSON.parse(jsoncourse);
    $.each(jsessions, function (i, item) {
        if (item.SessionID == sessionid) {
            $(".sessionname").val(item.Title);
            $(".sessiondesc").val(item.Description);
            $("#sstartdate").val(item.FromDateTime);
            $("#senddate").val(item.ToDateTime);
            $("#hdnSession").val(item.SessionID);
        }
    });
});

$(document).on('click', '.DeleteSession', function () {
    var sessionid = $(this).attr("sessionid");
    $.ajax({
        type: "POST",
        url: "/Ajax/DeleteSession",
        data: '{id: "' + sessionid + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("Deleted");
        },
        failure: function (response) {
            alert("failure");
        },
        error: function (response) {
            alert("error");
        }
    });

});

$("#clearsession").click(function () {
    $(".sessionname").val('');
    $(".sessiondesc").val('');
    $("#sstartdate").val('');
    $("#senddate").val('');
    $("#hdnSession").val('');
});

function createcourse() {
    if (sessions.length == 0) {
        alert("please add atleast 1 session");
        return false;
    }
}

$("#addsession").click(function () {
    var sname = $(".sessionname").val();
    var desc = $(".sessiondesc").val();
    var sstartdate = $("#sstartdate").val();
    var senddate = $("#senddate").val();
    if (sname != undefined && sname != '' && desc != undefined && desc != '' && desc != undefined && desc != '' && sstartdate != undefined && sstartdate != '' && senddate != undefined && senddate != '') {
        var session = { "name": sname, "desc": desc, "sdate": sstartdate, "enddate": senddate };
        if ($("#hdnSession").val() != '' && $("#hdnSession").val() != undefined) {
            $.each(sessions, function (i, item) {
                if (item.id == $("#hdnSession").val()) {
                    item.name = sname; item.desc = desc; item.sdate = sstartdate; item.enddate = senddate;
                }
            });
        }
        else {
            sessions.push(session);
        }

        $("#tblsession .tbd").html('');
        $.each(sessions, function (i, item) {
            $("#tblsession .tbd").append("<tr><td>" + item.name + "</td><td>" + item.desc + "</td><td>" + item.sdate + "</td><td>" + item.enddate + "</td></tr>");
        });
        var jsond = "{\"jsondata\":" + JSON.stringify(sessions) + "}";
        $("[id*=SessionData]").val(jsond);
        //console.log("Sessions", jsond);
    }
});