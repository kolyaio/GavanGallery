if (navigator.userAgent.toLowerCase().indexOf("chrome") >= 0) {
    $(window).load(function () {
        setTimeout(function () {
            $('input:-webkit-autofill').each(function () {
                var text = $(this).val();
                var name = $(this).attr('name');
                $(this).after(this.outerHTML).remove();
                $('input[name=' + name + ']').val(text);
            });
        }, 50);
    });
}