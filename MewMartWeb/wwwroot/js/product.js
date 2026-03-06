
var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'title', "width": "25%" },
            { data: 'isbn', "width": "15%" },
            { data: 'listPrize', "width": "10%" },
            { data: 'manufacturer', "width": "10%" },
            { data: 'category.name', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                     <a href="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Redigera</a>               
                     <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Radera</a>
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Är du säker?",
        text: "Du kommer inte kunna att ångra det!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Ja, radera!",
        cancelButtonText: "Avbryt"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}
