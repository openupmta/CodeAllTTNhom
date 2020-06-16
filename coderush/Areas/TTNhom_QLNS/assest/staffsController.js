var user = {
    init: function () {

        //user.loadProvince();
        user.registerEvent();
    },
    registerEvent: function () {
        $('#ddlProvince').off('change').on('change', function () {
            var id = $(this).val();
            if (id != '') {
                user.loadDistrict(parseInt(id));
            }
            else {
                $('#ddlDistrict').html('');
            }
        });
        $('#ddlDistrict').off('change').on('change', function () {
            var id = $(this).val();
            if (id != '') {
                user.loadWard(parseInt(id));
            }
            else {
                $('#ddlWard').html('');
            }
        });
    },
    loadProvince: function () {

        $.ajax({
            url: '/TTNhom_QLNS/staffs/LoadProvince',
            type: "POST",
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--Chọn tỉnh thành--</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.Id + '">' + item.Name + '</option>'
                    });
                    $('#ddlProvince').html(html);
                }
            }
        })
    },
    loadDistrict: function (id) {
        $.ajax({
            url: '/TTNhom_QLNS/staffs/LoadDistrict',
            type: "POST",
            data: { provinceID: id },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--Chọn quận huyện--</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.Id + '">' + item.Name + '</option>'
                    });
                    $('#ddlDistrict').html(html);
                }
            }
        })
    },
    loadWard: function (id) {
        $.ajax({
            url: '/TTNhom_QLNS/staffs/LoadWard',
            type: "POST",
            data: { districtID: id },
            dataType: "json",
            success: function (response) {
                if (response.status == true) {
                    var html = '<option value="">--Chọn phường xã--</option>';
                    var data = response.data;
                    $.each(data, function (i, item) {
                        html += '<option value="' + item.Id + '">' + item.Name + '</option>'
                    });
                    $('#ddlWard').html(html);
                }
            }
        })
    }
}
user.init();
