var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable(data) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Tarif/GetAll"
        },
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "kategori", "width": "15%" },
            { "data": "biaya010", "width": "15%" },
            { "data": "biaya1120", "width": "15%" },
            { "data": "biaya2130", "width": "15%" },
            { "data": "biaya30", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
<div class="w-100">
    <a href="/Tarif/Upsert/${data}" style="background-color: grey" class="col-5 btn text-white">Edit</a>

    <a onclick=Delete("/Tarif/Delete/${data}") class="col-6 btn text-white text-center" style="background-color: red; cursor:pointer;">Delete</a>
   
</div>
                    `;
                }, "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to Delete?",
        text: "You will not be able to restore the data !",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}


