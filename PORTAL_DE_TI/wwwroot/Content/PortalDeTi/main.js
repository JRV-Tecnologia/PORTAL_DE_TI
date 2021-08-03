+function ($) {
    //$.fn.dataTable.moment('DD/MM/YYYY');    //Formatação sem Hora
    $.fn.dataTable.moment('YYYY/MM/DD HH:mm:ss');    //Formatação com Hora
    var oTable = $('.data-tables').DataTable({
        "ordering": false,
        "columns": [
            { "type": "html" },
            { "type": "string" },
            { "type": "string" },
        ],
        sDom: 'lrtip',
        "bPaginate": true,
        "bLengthChange": false,
        "bFilter": true,
        "bInfo": false,
        "bAutoWidth": true,
        "bAutoHeight": true,
        "pageLength": 5
    });
    $('.data-tables-search').keyup(function () {
        oTable.search($(this).val()).draw();
    })
}(jQuery);