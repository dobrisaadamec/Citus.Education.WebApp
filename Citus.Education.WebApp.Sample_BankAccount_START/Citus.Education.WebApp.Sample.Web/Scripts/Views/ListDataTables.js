function initDataTableBankAccounts() {

    $('#dtBankAccountList').DataTable({
        ajax: ajaxPath,
        processing: false,
        serverSide: true,
        lengthChange: false,
        pageLength: 5,
        searching: true,
        ordering: true,
        columns: [
            {
                data: "Id",
                ordering: true,
            },
           {
               data: "Code",
               ordering: true,
           },
            {
                data: "Name",
                ordering: true,
            },
           {
               data: "IBAN",
               ordering: true,
           },
           {
               data: "Status",
               ordering: true,
           },
           {
               data: "Id",
               ordering: false,
               render: function (obj, type, f) {
                   return "<a href='" + editPath + "/" + f.Id + "'>Edit...<a>";
               }
           },
        ],
        language: {
            processing: "Učitavanje podataka...",
            search: "Pretraži:",
            loadingRecords: "Ućitavanje...",
            zeroRecords: "Ne postoji ni jedan zapis",
            emptyTable: "Ne postoji ni jedan zapis",
            info: "Od _START_ do  _END_ (od ukupno _TOTAL_)",
            infoEmpty: "Nema potvrda za prikazati",
            paginate: {
                first: "Prva",
                previous: "Natrag",
                next: "Naprijed",
                last: "Zadnja"
            }
        }
    });

}

$(function () {
    console.log('tu sam');
    if (viewname == "ListDataTables") {
        $(document).ready(function () {
            initDataTableBankAccounts();
        });
    }
});