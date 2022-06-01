$(document).ready(function () {
    //#region Tablodoldur
    var Talep_Listesi = [];
    Talepleri_Doldur(Talep_Listesi)
    function Talepleri_Doldur(Liste_) {
        $('#Talep_Listesi').empty();
        $('#Talep_Listesi').append('<table id="Talep_Listesi_Table" class="display nowrap" style="width: 100%">' +
            '<thead>' +
            '<tr>' +
            '<th>Kayt Tarih</th>' +
            '<th>Ürün Adı</th>' +
            '<th>Şart</th>' +
            '<th>Durum</th>' +
            '<th>Depo Fiyatı</th>' +
            '<th>Net Fiyat</th>' +
            '<th>Etiket Fiyatı</th>' +
            '<th>Barkod</th>' +
            '<th>Hedef Alım</th>' +
            '<th>Eczaneler Toplamı</th>' +
            '<th>Teklif Türü</th>' +
            '<th>Min/MAX</th>' +
            '<th>Eczane</th>' +
            '<th style="text-align: center;">İşlem</th>' +
            '</tr>' +
            '</thead>' +
            '<tbody id="Talep_Listesi_Table_Tbody">' +
            '</tbody>' +
            '<tfoot>' +
            ' <tr>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '<th></th>' +
            '</tr>' +
            '</tfoot>' +
            '</table>'
        );


        if (Liste_.length > 0) {
            var Tbody = $('tbody[id=Talep_Listesi_Table_Tbody]')
            for (var i = 0; i < Liste_.length; i++) {
                Tbody.append(
                    '<tr>' +
                    '<td>' + Liste_[i].Hastanın_Adı + '</td>' +
                    '<td>' + Liste_[i].Anne_Adı + '</td>' +
                    '<td>' + Liste_[i].Baba_Adı + '</td>' +
                    '<td>' + Liste_[i].Ödeme_Tipi_Txt + '</td>' +
                    '<td>' + Liste_[i].Cep_Tel + '</td>' +
                    '<td>' + Liste_[i].Cep_Tel_Sahibi_Txt + '</td>' +
                    '<td style="text-align: center;"><a style="font-size: 20px;    " id="Düzenle" value="' + Liste_[i].Hasta_Id + '"><i class="fa fa-edit"></i></a></td>' +
                    //'<td style="text-align: center;"><a style="font-size: 20px;    " id="Randevular" value="' + Liste_[i].Hasta_Id + '"><i class="fa fa-search"></i></a></td>' +
                    '<td style="text-align: center;"><a tabindex="0" id="Randevular" class="" value="' + Liste_[i].Hasta_Id + '" role="button" data-toggle="popover" data-placement="left" data-trigger="focus" title="Hastanın Randevuları" data-html="true" data-content=""><i class="fa fa-search"></i></a></td>' +
                    '<td style="text-align: center;"><a tabindex="0" id="Hastaya_Git" class="" value="' + Liste_[i].Hasta_Id + '" role="button" data-toggle="popover" data-placement="left" data-trigger="focus" title="Hastanın Randevuları" data-html="true" data-content=""><i class="fa fa-search"></i></a></td>' +
                    '</tr>'
                )
            }


        }

        $.fn.popover.Constructor.Default.whiteList.table = [];
        $.fn.popover.Constructor.Default.whiteList.tr = [];
        $.fn.popover.Constructor.Default.whiteList.td = [];
        $.fn.popover.Constructor.Default.whiteList.th = [];
        $.fn.popover.Constructor.Default.whiteList.div = [];
        $.fn.popover.Constructor.Default.whiteList.tbody = [];
        $.fn.popover.Constructor.Default.whiteList.thead = [];

        $("[data-toggle=popover]").popover({
            html: true,
            content: function () {
                var content = $(this).attr("data-popover-content");
                return $(content).children(".popover-body").html();
            },
            title: function () {
                var title = $(this).attr("data-popover-content");
                return $(title).children(".popover-heading").html();
            }
        });

        var today = new Date();
        var date = today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
        var dateTime = date;
        $('#Talep_Listesi_Table tfoot th').each(function () {
            var title = $(this).text();
            $(this).html('<input type="text" placeholder="Ara ' + title + '" />');
        });
        $('#Talep_Listesi_Table').dataTable({
            "lengthMenu": [10, 25, 50, 75, 100, 200, 500, 750, 1000],

            "language": {
                "url": "//cdn.datatables.net/plug-ins/1.10.22/i18n/Turkish.json"
            },

            initComplete: function () {
                // Apply the search
                this.api().columns().every(function () {
                    var that = this;

                    $('input', this.footer()).on('keyup change clear', function () {
                        if (that.search() !== this.value) {
                            that
                                .search(this.value)
                                .draw();
                        }
                    });
                });
            },
            scrollX: true,
            scrollCollapse: true,


            fixedColumns: true

        });

        var Randevular = $('a[id=Randevular]')


        var myvar = '<div class="row">' +
            '                        <div class="col-lg-12">' +
            '                           <div class="table-responsive">' +
            '                            <table class="table table-hover text-nowrap" style="font-size: 12px;">' +
            '                                <thead>' +
            '                                    <tr>' +

            '                                        <th >Tarih</th>' +
            '                                        <th >M/K</th>' +
            '                                    </tr>' +
            '                                </thead>' +
            '                                <tbody id="Hastanın_Önceki_Randevuları">' +
            '                                    <tr>' +
            '                                        <td>Hiç Veri Bulunamadı</td>' +
            '                                        <td>Hiç Veri Bulunamadı</td>' +
            '                                    </tr>' +
            '                                </tbody>' +
            '                                <tfoot>' +
            '                                    <tr>' +

            '                                        <td></td>' +
            '                                        <td></td>' +
            '                                    </tr>' +
            '                                </tfoot>' +
            '                            </table>' +
            '                        </div>' +
            '                    </div>' +
            '    </div>';


        Randevular.attr('data-content', myvar)


        Randevular.click(function () {
            $.ajax({
                url: '<%= ResolveUrl("Randevu.aspx/Hastanın_Önceki_Randevuları") %>',
                type: 'POST',
                async: false,
                global: false,
                dataType: "json",
                data: "{'Hasta_Id':'" + $(this).attr('value') + "'}",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var temp = JSON.parse(data.d)

                    var Hastanın_Önceki_Randevuları = $('tbody[id=Hastanın_Önceki_Randevuları]');
                    if (temp.length > 0) {
                        Hastanın_Önceki_Randevuları.empty();
                        for (var i = 0; i < temp.length; i++) {
                            Hastanın_Önceki_Randevuları.append(
                                '<tr id="Bugünkü_Randevu_Listesi_Tr" Hasta_Id="' + temp[i].Hasta_Id + '" Randevu_Id="' + temp[i].Randevu_Id + '">' +
                                '<td>' + temp[i].Randevu_Tar + '</td>' +
                                '<td>(' + temp[i].Randevu_Türü_Kısa + ')</td>' +
                                '</tr>'
                            )
                        }
                    }
                    else {
                        Hastanın_Önceki_Randevuları.empty();
                        Hastanın_Önceki_Randevuları.append(
                            '<tr>' +
                            '                                            <td style="text-align: center; background-color: #f5f5f5" colspan="2">Hiç Hasta Bulunamadı</td>' +
                            '                                        </tr>'
                        )
                    }

                    var Bugünkü_Randevu_Listesi_Tr = $('tr[id=Bugünkü_Randevu_Listesi_Tr]')
                    Bugünkü_Randevu_Listesi_Tr.click(function () {
                        window.location.href = "Randevu?Hasta_Id=" + $(this).attr('Hasta_Id') + "&" + "Randevu_Id=" + $(this).attr('Randevu_Id')
                    })

                },
                error: function () {
                    Swal.fire({
                        title: 'Hata!',
                        text: 'Talep esnasında sorun oluştu.Yeniden deneyin',
                        icon: 'error',
                        confirmButtonText: 'Kapat'
                    })
                }
            });
        })

    };
    //#endregion

    $('button[id=Yeni_Teklif_Ekle]').click(function () {
        $('div[id=Teklif_Oluştur]').modal('show')
    })
    $("#id_label_single").select2({
        "language": {
            "noResults": function () {
                return "Sonuç Bulunamadı";
            }
        },
    });
    $(document).on('keydown', 'input.select2-search__field', function () {
        console.log($(this).val())
    })

})