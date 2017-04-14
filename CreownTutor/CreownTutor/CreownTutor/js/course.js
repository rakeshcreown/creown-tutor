var sessions = [];
$(document).ready(function () {
    sessions = [];
});

$(function () {
    $('#datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY HH:mm:ss' });
    $('.datetimepicker1').datetimepicker({ format: 'DD/MM/YYYY HH:mm:ss' });
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
    if (jsoncourse != '' && jsoncourse != undefined) {
        var jsessions = JSON.parse(jsoncourse);
        $.each(jsessions, function (i, item) {
            item.ToDateTime = item.ToDateTime.replace('T', ' ');
            item.FromDateTime = item.FromDateTime.replace('T', ' ');
            var session = { "name": item.Title, "desc": item.Description, "sdate": item.FromDateTime, "enddate": item.ToDateTime };
            sessions.push(session);

            $("#tblsession .tbd").append("<tr><td>" + item.Title + "</td><td>" + item.Description + "</td><td>" + item.FromDateTime + "</td><td>" + item.ToDateTime + "</td></tr>");
        });
    }
}

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