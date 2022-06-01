$(document).ready(function () {
    $('#Teklif_Şartları').Tabledit({
        editButton: false,
        deleteButton: false,
        hideIdentifier: true,
        autoFocus: true,
        columns: {
            identifier: [0, 'id'],
            editable: [[1, 'Alım_Miktarı'], [2, 'Mal_Fazlası'], [3, 'Iskonto_Yuzde'], [4, 'Iskonto_Tl'], [5, 'Net_Fiyayat']]
        }
    });
    $('input[id=Deneme]').click(function () {
        $('tbody[id=Teklif_Şartları_Tbody]').append(
            '<tr>' +
            '<td></td>' +
            '<td>15</td>' +
            '<td>15</td>' +
            '<td>15</td>' +
            '<td>15</td>' +
            '<td>15</td>' +
            '</tr>'
        );
        $('#Teklif_Şartları').Tabledit({
            editButton: false,
            deleteButton: false,
            hideIdentifier: true,
            autoFocus: true,
            columns: {
                identifier: [0, 'id'],
                editable: [[1, 'Alım_Miktarı'], [2, 'Mal_Fazlası'], [3, 'Iskonto_Yuzde'], [4, 'Iskonto_Tl'], [5, 'Net_Fiyayat']]
            }
        });

    })

    var Teklif_Şartları_Class_Liste = [];
    $('#Teklif_Şartları tr').each(function () {
        var Teklif_Şartları_Class = {
            Alım_Miktarı: null,
            Mal_Fazlası: null,
            Iskonto_Yuzde: null,
            Iskonto_Tl: null,
            Net_Fiyayat: null
        }

        Teklif_Şartları_Class.Alım_Miktarı = $(this).find('input[name=Alım_Miktarı]').val()
        Teklif_Şartları_Class.Mal_Fazlası = $(this).find('input[name=Mal_Fazlası]').val()
        Teklif_Şartları_Class.Iskonto_Yuzde = $(this).find('input[name=Iskonto_Yuzde]').val()
        Teklif_Şartları_Class.Iskonto_Tl = $(this).find('input[name=Iskonto_Tl]').val()
        Teklif_Şartları_Class.Net_Fiyayat = $(this).find('input[name=Net_Fiyayat]').val()

        Teklif_Şartları_Class_Liste.push(Teklif_Şartları_Class)
    })
    console.log(Teklif_Şartları_Class_Liste)

    function Tablo_Edit(Tablo,Options){
        Tablo.find('tbody').find('tr')(function(){
            var old_tr=$(this)
            var option_counter=0;
            $(this).find('td').each(function(){
                $(this).attr('class','tabledit-view-mode')
                var old_value=$(this).html();
                $(this).empty();
                $(this).append('<span class="tabledit-span">'+old_value+'</span>')
                $(this).append('<input class="tabledit-input form-control input-sm" type="text" name="'+Options[option_counter]+'" value="'+old_value+'" style="display: none;" disabled="">')
                $(this).click(function(){
                    $(this).attr('class','tabledit-edit-mode')
                })
                
                option_counter++;
            })
            
        })
    }
})