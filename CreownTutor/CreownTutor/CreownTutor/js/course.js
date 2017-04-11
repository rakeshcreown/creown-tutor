var sessions = [];
$(document).ready(function () {
    sessions = [];
});

$(function () {
    $('#datetimepicker1').datetimepicker();
    $('.datetimepicker1').datetimepicker();
});

function createcourse() {
    if (sessions.length == 0) {
        alert("please add atleast 1 session");
        return false;
    }
}

$("#addsession").click(function () {
    var sname = $("#CourseName").val();
    var desc = $("#Description").val();
    var sstartdate = $("#sstartdate").val();
    var senddate = $("#senddate").val();
    if (sname != undefined && sname != '' && desc != undefined && desc != '' && desc != undefined && desc != '' && sstartdate != undefined && sstartdate != '' && senddate != undefined && senddate != '') {
        var session = { "name": sname, "desc": desc, "sdate": sstartdate, "enddate": senddate };
        sessions.push(session);
        $("#tblsession .tbd").html('');
        $.each(sessions, function (i, item) {
            $("#tblsession .tbd").append("<tr><td>" + item.name + "</td><td>" + item.desc + "</td><td>" + item.sdate + "</td><td>" + item.enddate + "</td></tr>");
        });
        var jsond = "{\"jsondata\":" + JSON.stringify(sessions) + "}";
        $("[id*=SessionData]").val(jsond);
        console.log("Sessions", jsond);
    }
});