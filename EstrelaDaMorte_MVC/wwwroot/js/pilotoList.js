var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load_pilotos').DataTable({
        "ajax": {
            "url": "/Pilotos/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idpiloto", "width": "20%" },
            { "data": "nome", "width": "20%" },
            { "data": "anonascimento", "width": "20%" },
            { "data": "idplaneta", "width": "20%" },
            {
                "data": "idpiloto",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="Pilotos/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                Edit
                            </a>
                            &nbsp;
                            <a class='btn btn-danger text-white' style='cursor:pointer; width:100px;'
                                onclick=Delete('/Pilotos/Delete?id='+${data})>
                            
                                Delete
                            </a>
                        </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTacle": "no data found"
        },
        "width": "100%"

    })
}

function Delete(url) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message)
                        dataTable.ajax.reload();

                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            });
        }
    });
}