function Login() {

    var user = document.getElementById("txtUsername").value;
    var pasw = document.getElementById("txtPassword").value;

    var login = {
        Username: user, Password: pasw
    };

    if (user == "") {
        toastr.error("Silahkan Input Username");
    } else if (pasw == "") {
        toastr.error("Silahkan Input Password");
    } else {

        $.ajax({
            type: "POST",
            data: login,
            url: "/Home/Index/",
            success: function (data) {

                var dataKu = JSON.stringify("Password atau Username Salah !!");

                if (dataKu == JSON.stringify(data['data'])) {
                    toastr.error(data['data']);
                } else {
                    location.reload();
                }
            },
            error: function (data) {

                alert("GAGAL " + id);
            }
        });
    }
}