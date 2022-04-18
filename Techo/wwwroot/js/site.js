// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(function () {
    $('button[data-toggle="modal"]').click(function (event) {
        //alert('button clicked');
        var placeholderElement  = $("#modal-placeholder");

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });

        placeholderElement.off();
        placeholderElement.on('click', '[data-save="modal"]', function (event) {
            event.preventDefault();

            var form = $(this).parents('.modal').find('form');
            var actionUrl = form.attr('action');
            var dataToSend = form.serialize();

            $.post(actionUrl, dataToSend).done(function (data) {
                //placeholderElement.find('.modal').modal('hide');
                //$('#productList').DataTable().ajax.reload();

                // data is the rendered _ContactModalPartial
                var newBody = $('.modal-body', data);
                // replace modal contents with new form
                placeholderElement.find('.modal-body').replaceWith(newBody);

                var isValid = newBody.find('[name="IsValid"]').val() == 'True';
                if (isValid) {
                    placeholderElement.find('.modal').modal('hide');
                    //$('#productList').DataTable().ajax.reload();
                    //$('#proveedoresTable').DataTable().ajax.reload();
                    $('table[role="grid"]').DataTable().ajax.reload();
                    alert("Item creado correctamente", false);
                }
            });
        });
    });

    $('#updateDBProd').click(function (event) {
        var placeholderElement = $("#modal-placeholder");
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });



        //placeholderElement.off();
        //placeholderElement.on('submit', '[data-save="modal"]', function (event) {
        //    event.preventDefault();

        //    var form = $(this).parents('.modal').find('form');
        //    var actionUrl = form.attr('action');
        //    var dataToSend = form.serialize();

        //    $.post(actionUrl, dataToSend).done(function (data) {

        //        // data is the rendered _ContactModalPartial
        //        var newBody = $('.modal-body', data);
        //        // replace modal contents with new form
        //        placeholderElement.find('.modal-body').replaceWith(newBody);

        //        var isValid = newBody.find('[name="IsValid"]').val() == 'True';
        //        if (isValid) {
        //            placeholderElement.find('.modal').modal('hide');
        //            //$('#productList').DataTable().ajax.reload();
        //            //$('#proveedoresTable').DataTable().ajax.reload();
        //            $('table[role="grid"]').DataTable().ajax.reload();
        //            showResultMessage("Producto creado correctamente", false);

        //        }
        //    });
        //});
    });


    $('#updateDBMessage').click(function (event) {
        var placeholderElement = $("#modal-placeholder");

        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });



        //placeholderElement.off();
        //placeholderElement.on('click', '[data-save="modal"]', function (event) {
        //    event.preventDefault();

            //var form = $(this).parents('.modal').find('form');
            //var actionUrl = form.attr('action');
            //var dataToSend = form.serialize();

            //$.post(actionUrl, dataToSend).done(function (data) {

            //    // data is the rendered _ContactModalPartial
            //    var newBody = $('.modal-body', data);
            //    // replace modal contents with new form
            //    placeholderElement.find('.modal-body').replaceWith(newBody);

            //    var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            //    if (isValid) {
            //        placeholderElement.find('.modal').modal('hide');
            //        //$('#productList').DataTable().ajax.reload();
            //        //$('#proveedoresTable').DataTable().ajax.reload();
            //        $('table[role="grid"]').DataTable().ajax.reload();
            //        showResultMessage("Producto creado correctamente", false);

            //    }
            //});
       /* });*/
    });


});

//function showResultMessage(msg, error) {
//    //$('#resultMsg').addClass("show").addClass("alert-success");
//    //var text = $('#resultMsg').text();
//    //text = text.replace("{resultMessage}", msg);
//    //$('#resultMsg').text(text);
//    $('#resultMsg').each(function () {
//        var text = $('#resultMsg label').text();
//        $('label', this).text(text.replace("{ResultMessage}", msg));
//        $(this).addClass("show").addClass("alert-success");
//    });
//}

function showResultMessage(error) {
    if (!error) {
        $('#resultMsgSuccess').addClass("show").addClass("alert-success");
    } else {
        $('#resultMsgError').addClass("show").addClass("alert-error");
    }
}