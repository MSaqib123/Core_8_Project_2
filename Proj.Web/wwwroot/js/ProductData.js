
$(document).ready(function () {
    loadDataTabel();


    function loadDataTabel() {
        dataTable = $('#tblData').DataTable({
            "ajax": { url: '/Admin/Product/GetAll' },
            "columns": [
                { data: 'id' },
                { data: 'title' },
                { data: 'author' },
                { data: 'isbn' },
                { data: 'price' },
                { data: 'category.name' },
                {
                    data: 'id',
                    "render": function (data) {
                        return `
                            <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary">Edit</a>
                            <a href="/Admin/Product/DeleteRecord?id=${data}" class="btn btn-danger">Delete</a>
                        `}
                },
            ]
        });
    }

});
