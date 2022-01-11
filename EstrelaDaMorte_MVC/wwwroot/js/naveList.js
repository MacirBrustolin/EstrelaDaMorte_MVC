var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load_naves').DataTable({
        "ajax": {
            "url": "/Naves/GetAll/",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idnave", "width": "10%" },
            { "data": "nome", "width": "10%" },
            { "data": "modelo", "width": "10%" },
            { "data": "passageiros", "width": "10%" },
            { "data": "carga", "width": "10%" },
            { "data": "classe", "width": "10%" },
            {
                "data": "idnave",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href="Naves/Upsert?id=${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                Edit
                            </a>
                            &nbsp;
                            <a class='btn btn-danger text-white' style='cursor:pointer; width:100px;'
                                onclick=Delete('/Naves/Delete?id='+${data})>
                            
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