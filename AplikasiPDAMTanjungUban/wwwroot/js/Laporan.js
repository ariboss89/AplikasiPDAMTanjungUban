var dataTable;

document.getElementById('divHeader').hidden = true;

$(document).ready(function () {

    //var tglAwal = document.getElementById("tglAwal").value;
    //var tglAkhir = document.getElementById("tglAkhir").value;

    //if (tglAwal != "" && tglAkhir != "") {
    //    dataTable = $('#tblData').DataTable({
    //        "ajax": {
    //            "url": "/Laporan/TampilData?tglAwal=" + tglAwal + "&tglAkhir=" + tglAkhir
    //        },
    //        "columns": [
    //            { "data": "idPelanggan", "width": "5%" },
    //            { "data": "namaPelanggan", "width": "15%" },
    //            { "data": "golongan", "width": "15%" },
    //            { "data": "tanggal", "width": "15%" },
    //            { "data": "jumlah", "width": "15%" },
    //            { "data": "denda", "width": "15%" },
    //            { "data": "total", "width": "20%" },
    //        ]
    //    });
    //}
    //else {
    //    loadDataTable();
    //}


});

function loadDataTable(data) {
    //dataTable = $('#tblData').DataTable({
    //    "ajax": {
    //        "url": "/Laporan/GetAll"
    //    },
    //    "columns": [
    //        { "data": "idPelanggan", "width": "5%" },
    //        { "data": "namaPelanggan", "width": "15%" },
    //        { "data": "golongan", "width": "15%" },
    //        { "data": "tanggal", "width": "15%" },
    //        { "data": "jumlah", "width": "15%" },
    //        { "data": "denda", "width": "15%" },
    //        { "data": "total", "width": "20%" },
    //    ]
    //});

    var tglAwal = document.getElementById("tglAwal").value;
    var tglAkhir = document.getElementById("tglAkhir").value;

        dataTable = $('#tblData').DataTable({
            "ajax": {
                "url": "/Laporan/TampilData?tglAwal=" + tglAwal + "&tglAkhir=" + tglAkhir
            },
            "columns": [
                { "data": "idPelanggan", "width": "5%" },
                { "data": "namaPelanggan", "width": "15%" },
                { "data": "golongan", "width": "15%" },
                { "data": "tanggal", "width": "15%" },
                { "data": "jumlah", "width": "15%" },
                { "data": "denda", "width": "15%" },
                { "data": "total", "width": "20%" },
            ]
        });
}

function TampilData() {

    var tglAwal = document.getElementById("tglAwal").value;
    var tglAkhir = document.getElementById("tglAkhir").value;

    if (tglAwal == "" || tglAkhir=="") {

        swal({
            title: "Himbauan !",
            text: "Silahkan Pilih Tanggal !!",
            icon: "warning"
        });

    } 
    else {

        $.ajax({
            type: "GET",
            url: "/Laporan/TampilData?tglAwal=" + tglAwal + "&tglAkhir=" + tglAkhir,
            success: function (data) {
                loadDataTable();
            },
            error: function (data) {

                alert("GAGAL " + id);
            }
        });
    }
}

function Print() {
    var countTbl = document.getElementById("tblData");
    
    var count = countTbl.rows.length;

    console.log(count, "jml");

    if (tglAwal == "" || tglAkhir == "") {

        swal({
            title: "Himbauan !",
            text: "Silahkan Pilih Tanggal !!",
            icon: "warning"
        });

    } else {
       
        document.getElementById('navBar').hidden = true;
        document.getElementById('btnCetak').hidden = true;
        document.getElementById('divFooter').hidden = true;
        document.getElementById('divHeader').hidden = false;
        document.getElementById('btnLaporan').hidden = true;

        window.print();

        document.getElementById('navBar').hidden = false;
        document.getElementById('btnCetak').hidden = false;
        document.getElementById('divFooter').hidden = false;
        document.getElementById('btnLaporan').hidden = false;
        document.getElementById('divHeader').hidden = true;

        document.getElementById('tglAwal').value = "";
        document.getElementById('tglAkhir').value = "";

        location.reload();
        
    }
}

