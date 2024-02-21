var dataTable;

var id = document.getElementById("txtId").value;
var idPelanggan = document.getElementById("txtPelanggan").value;
var alamat = document.getElementById("txtAlamat").value;
var kontak = document.getElementById("txtKontak").value;
var gol = document.getElementById("cbKategori").value;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable(data) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Pelanggan/GetAll"
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "nama", "width": "15%" },
            { "data": "kontak", "width": "15%" },
            { "data": "alamat", "width": "20%" },
            { "data": "kategori", "width": "20%" }
        ]
    });
}

function Delete() {

    var id = document.getElementById("txtId").value;

    if (id != 0) {

        swal({
            title: "Are you sure you want to Delete?",
            text: "You will not be able to restore the data !",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        }).then((willDelete) => {
            if (willDelete) {

                var urlx = "/Pelanggan/Delete/" + id;

                $.ajax({
                    type: "DELETE",
                    url: urlx,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            dataTable.ajax.reload();

                            document.getElementById('txtAlamat').value = "";
                            document.getElementById('txtId').value = "0";
                            document.getElementById('txtPelanggan').value = "0";
                            document.getElementById('txtNama').value = "";
                            document.getElementById('txtKontak').value = "";
                            document.getElementById('cbKategori').value = "Pilih Golongan";

                            $('#btnSave').attr('disabled', false);
                            $('#btnEdit').attr('disabled', true);
                            $('#btnDelete').attr('disabled', true);
                        }
                        else {
                            toastr.error(data.message);
                        }
                    }
                });
            }
        });
    }
    else {
        swal({
            title: "Himbauan !",
            text: "Silahkan Pilih data dahulu sebelum akan menghapus data !!",
            icon: "warning"
        });
    }
}

function Edit() {

        var id = document.getElementById("txtId").value;
        var idPelanggan = document.getElementById("txtPelanggan").value;
        var alamat = document.getElementById("txtAlamat").value;
        var kontak = document.getElementById("txtKontak").value;
        var gol = document.getElementById("cbKategori").value;
        var nama = document.getElementById("txtNama").value;

    if (idPelanggan == "") {
        swal({
            title: "Himbauan !",
            text: "Silahkan Input Id Pelanggan !!",
            icon: "warning"
        });
    } else if (alamat == "") {
        swal({
            title: "Himbauan !",
            text: "Silahkan Input Alamat !!",
            icon: "warning"
        });
    } else if (kontak == 0 || kontak=="") {
        swal({
            title: "Himbauan !",
            text: "Silahkan Input Kontak!!",
            icon: "warning"
        });
    } else if (gol == "Pilih Golongan") {
        swal({
            title: "Himbauan !",
            text: "Silahkan Pilih golongan !!",
            icon: "warning"
        });

    } else {

        var pelanggan = { Id: id, IdPelanggan: idPelanggan, Alamat: alamat, Nama: nama, Kontak: kontak, Kategori: gol };

        //console.log(pelanggan, "Pelanggan");

        $.ajax({
            type: "POST",
            data: pelanggan,
            url: "/Pelanggan/Edit/",
            success: function (data) {
                toastr.success("Data berhasil di ubah");
                dataTable.ajax.reload();
                
                document.getElementById('txtAlamat').value = "";
                document.getElementById('txtId').value = "0";
                document.getElementById('txtPelanggan').value = "0";
                document.getElementById('txtNama').value = "";
                document.getElementById('txtKontak').value = "";
                document.getElementById('cbKategori').value = "Pilih Golongan";

                $('#btnSave').attr('disabled', false);
                $('#btnEdit').attr('disabled', true);
                $('#btnDelete').attr('disabled', true);
            },
            error: function (data) {

                alert("GAGAL " + id);
            }
        });

    }

}

function SelectData() {
    const tbody = document.querySelector('#tblData');
    tbody.addEventListener('click', function (e) {
        const cell = e.target.closest('td');
        if (!cell) { return; } // Quit, not clicked on a cell
        const row = cell.parentElement;
        console.log(cell.innerHTML, row.rowIndex, cell.cellIndex);

        var id = row.rowIndex;

        $.ajax({
            type: "GET",
            url: "/Pelanggan/Index/" + id,
            success: function (data) {

                var data2 = JSON.stringify(data);

                var pelanggan = JSON.parse(data2);

                $("#txtPelanggan").val(data['data']['idPelanggan']);
                $("#txtAlamat").val(data['data']['alamat']);
                $("#txtNama").val(data['data']['nama']);
                $("#txtKontak").val(data['data']['kontak']);
                $("#txtId").val(data['data']['id']);

                $('#btnSave').attr('disabled', true);
                $('#btnEdit').attr('disabled', false);
                $('#btnDelete').attr('disabled', false);
            },
            error: function (data) {

                alert("GAGAL " + id);
            }
        });

    });
}

