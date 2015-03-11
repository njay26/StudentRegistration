var per_page = $("table").data("per_page");
$(document).ready(function() {
    //For Student Table
    GetReadyDataForStudentTable();
    $("#example").DataTable({
        sScrollX: "100%",
        "columnDefs": [{
            "width": "5%",
            "targets": 0
        }],
        bJQueryUI: true,
        iDisplayLength: per_page,
        "fnDrawCallback": function(oSettings) {
            if (oSettings._iDisplayLength == per_page)
                return true;
            else {
                $.post($(this).data("url"), {
                        iDisplayLength: oSettings._iDisplayLength
                    })
                    .done(function(data) {
                        if (data.success)
                            per_page = oSettings._iDisplayLength;
                    });
            }
            return true;
        },
        "ajax": 'Data/Data.txt'
    });

    function GetReadyDataForStudentTable() {
        $.ajax({
            type: "POST",
            url: "StudentsTable.aspx/Data",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            failure: function(response) {
                alert(response.d);
            }
        });
    };
    //SEnable the search box in each columns
    $('#SearchBox th').each(function() {
        var title = $('#SearchBox th').eq($(this).index()).text();
        $(this).html('<input type="text" placeholder="Search ' + title + '" />');
    });
    //End for Student Table
    AdminUsersTable();
    $("#AdminUsersTable").dataTable({
        bProcessing: true,
        "ajax": 'Data/AdminUsersData.txt',


        "aoColumnDefs": [{
            "aTargets": [7],
            "mData": null,
            "mRender": function(data, type, full) {
                return '<a href="#" onclick="RegistrationAccepted(\'' + full[0] + '\')">Accept</a><span>  </span><a href="#" onclick="RegistrationRejected(\'' + full[0] + '\')">Reject</a>';
            }
        }],
    });
    var table = $('#example').DataTable();

    table.columns().eq(0).each(function(colIdx) {
        $('input', table.column(colIdx).footer()).on('keyup change', function() {
            table
                .column(colIdx)
                .search(this.value)
                .draw();
        });
    });

    function AdminUsersTable() {
        $.ajax({
            type: "POST",
            url: "AdmainUsersPage.aspx/GetAllStudentInformation",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            failure: function(response) {
                alert(response.d);
            }
        });
    }
    //client side validation
    $("#StudentContainer_FirstName").keydown(function() {
        alert('sa');
    });
});