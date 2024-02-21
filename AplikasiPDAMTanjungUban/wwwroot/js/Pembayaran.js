function Search() {
    var id = document.getElementById("cbPelanggan").value;
   
    $.ajax({
        type: "GET",
        url: "/Pembayaran/GetDataPelanggan/" + id,
        success: function (data) {
            
            console.log(data, "BA");

            console.log(data['data']['pelanggan']['idPelanggan'], "MANISEE");

            $("#txtIdPelanggan").val(data['data']['pelanggan']['idPelanggan']);
            $("#txtAlamat").val(data['data']['pelanggan']['alamat']);
            $("#txtGolongan").val(data['data']['pelanggan']['kategori']);

            $("#txtBiaya010").val(data['data']['tarif']['biaya010']);
            $("#txtBiaya1120").val(data['data']['tarif']['biaya1120']);
            $("#txtBiaya2130").val(data['data']['tarif']['biaya2130']);
            $("#txtBiaya030").val(data['data']['tarif']['biaya30']);

        },
        error: function (data) {

            alert("GAGAL " + id);
        }
    });
}

function Summarize() {

    var tanggal = document.getElementById("txtTanggal").value;
    var alamat = document.getElementById("txtAlamat").value;
    var awal = document.getElementById("txtAwal").value;
    var akhir = document.getElementById("txtAkhir").value;
    var pakai = document.getElementById("txtPakai").value;

    var admin = document.getElementById("txtAdmin").value;
    var total = document.getElementById("txtTotal").value;
    var denda = document.getElementById("txtDenda").value;

    var biaya010 = document.getElementById("txtBiaya010").value;
    var biaya1120 = document.getElementById("txtBiaya1120").value;
    var biaya2130 = document.getElementById("txtBiaya2130").value;
    var biaya30 = document.getElementById("txtBiaya030").value;

    var totalPembayaran;
    var totalHari;
    var totalDenda;

    const formatter = new Intl.DateTimeFormat('en-US', { day: '2-digit', month: '2-digit', year: 'numeric' });
    const dendaDate = new Date();
    dendaDate.setDate(20);

    const currentDate = new Date();
    const formatDenda = formatter.format(dendaDate);
    const formatDate = formatter.format(currentDate);

    let Difference_In_Time =
        currentDate.getTime() - dendaDate.getTime();

    // Calculating the no. of days between
    // two dates
    totalHari =
        Math.round
            (Difference_In_Time / (1000 * 3600 * 24));

    if (alamat == "" || awal == "0" || akhir=="0") {
        swal({
            title: "Himbauan !",
            text: "Silahkan Pilih Nama Pelanggan Atau Input Pemakaian Awal dan Akhir !!",
            icon: "warning"
        });
    } else { 

        if (totalHari > 0) {

            totalDenda = parseInt(totalHari) * 5000;

        } else {
            totalDenda = 0;
        }


        var pakai = akhir - awal;

        $("#txtPakai").val(pakai);

        $("#txtDenda").val(totalDenda);

        if (pakai <= 10) {
            totalPembayaran = 35000 + parseInt(admin) + parseInt(totalDenda);
           
        } else if (pakai > 10 && pakai <= 20) {

            totalPembayaran = ((biaya1120 * parseInt(pakai)) + parseInt(admin) + parseInt(totalDenda));

        } else if (pakai > 20 && pakai <= 30) {

            totalPembayaran = ((biaya2130 * parseInt(pakai)) + parseInt(admin) + parseInt(totalDenda));

        } else if (pakai > 30) {

            totalPembayaran = ((biaya1120 * parseInt(pakai)) + parseInt(admin) + parseInt(totalDenda));

        }

        $("#txtTotal").val(totalPembayaran);

    }
}

var typingTimer;                //timer identifier
var doneTypingInterval = 2000;  //time in ms (5 seconds)
var $input = $('#txtAkhir');

//on keyup, start the countdown
$input.on('keyup', function () {
    clearTimeout(typingTimer);
    typingTimer = setTimeout(Summarize, doneTypingInterval);
});

//on keydown, clear the countdown 
$input.on('keydown', function () {
    clearTimeout(typingTimer);
});

function CetakStruk() {

    var jumlah = document.getElementById("txtPakai").value;

    var id = document.getElementById("txtId").value;
    var idPelanggan = document.getElementById("txtIdPelanggan").value;
    var nama = document.getElementById("cbPelanggan").value;
    var alamat = document.getElementById("txtAlamat").value;

    var golongan = document.getElementById("txtGolongan").value;
    var tanggal = document.getElementById("txtTanggal").value;
    var biaya010 = document.getElementById("txtBiaya010").value;
    var biaya1120 = document.getElementById("txtBiaya1120").value;
    var biaya2130 = document.getElementById("txtBiaya2130").value;
    var biaya030 = document.getElementById("txtBiaya030").value;
    
    var awal = document.getElementById("txtAwal").value;
    var akhir = document.getElementById("txtAkhir").value;
    var pakai = document.getElementById("txtPakai").value;
    var perawatan = document.getElementById("txtPerawatan").value;
    var admin = document.getElementById("txtAdmin").value;
    var total = document.getElementById("txtTotal").value;
    var denda = document.getElementById("txtDenda").value;

    if (jumlah <= 0) {

        toastr.error("Jumlah Pemakaian Tidak Boleh Minus Atau 0");

        document.getElementById('txtAkhir').value = "";
        document.getElementById('txtTotal').value = "";
        document.getElementById('txtPakai').value = "";

    } else {

        var bayar = {
            Id: id, NamaPelanggan: nama, Alamat: alamat, IdPelanggan: idPelanggan,
            Golongan: golongan, Tanggal: tanggal, Biaya010: biaya010, Biaya1120: biaya1120, Biaya2130: biaya2130, Biaya30: biaya030,
            Awal: awal, Akhir: akhir, Jumlah: pakai, Perawatan: perawatan, BiayaAdmin: admin, Denda:denda, Total: total
        };

        $.ajax({
            type: "POST",
            data:bayar,
            url: "/Pembayaran/SimpanData/",
            success: function (data) {
                
            },
            error: function (data) {

                alert("GAGAL " + id);
            }
        });

        document.getElementById('navBar').hidden = true;
        document.getElementById('divCetak').hidden = true;
        document.getElementById('divFooter').hidden = true;

        window.print();

        document.getElementById('navBar').hidden = false;
        document.getElementById('divCetak').hidden = false;
        document.getElementById('divFooter').hidden = false;

        location.reload();
    }
}
