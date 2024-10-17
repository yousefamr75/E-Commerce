$(document).ready(function ()){
    loadDataTable();
}
function loadDataTable{
    datatable = $('#tblData').DataTable({
        "ajax": { URL: '/Admin/product/getall' },
   
        " columns": [
        { data: 'name' , "with" : "15%"},
            { data: 'position', "with": "15%" },
            { data: 'salary', "with": "15%" },
            { data: 'office', "with": "15%" }



    ]);
}

}

