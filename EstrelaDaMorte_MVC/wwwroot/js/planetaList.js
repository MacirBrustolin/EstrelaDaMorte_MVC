var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load_planetas').DataTable({
        "ajax": {
            "url": "/Planetas/getall/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idplaneta", "width": "20%" },
            { "data": "nome", "width": "20%" },
            { "data": "rotacao", "width": "20%" },
            { "data": "orbita", "width": "20%" },
            { "data": "diametro", "width": "20%" },
            { "data": "clima", "width": "20%" },
            { "data": "populacao", "width": "20%" },
            {
                "data": "idplaneta",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="Planetas/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                Edit
                            </a>
                            &nbsp;
                            <a class='btn btn-danger text-white' style='cursor:pointer; width:100px;'
                                onclick=Delete('/Planetas/Delete?id='+${data})>
                            
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