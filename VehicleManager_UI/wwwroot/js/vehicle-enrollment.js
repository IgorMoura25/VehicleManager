Vehicle_Enrollment = {
    InitializeComponent: function () {

        //Constrói o formulário
        Vehicle_Enrollment.BuildEnrollmentForm();

        //Inicializa as máscaras
        Vehicle_Enrollment.InitializeMasks();

        $('.button').click(function () {

            debugger;

            //Valida inputs
            if (Vehicle_Enrollment.ValidateInputs()) {
                return;
            }

            var assembler = $("#search-bar").val();
            var model = $("#model").val();
            var plate = $("#plate").val();

            var Vehicle = new Object();
            Vehicle.AssemblerName = assembler;
            Vehicle.Model = model;
            Vehicle.Plate = plate;

            Vehicle_Enrollment.ExecuteAjax(Vehicle, "enrollment", "enrollvehicle");

        });

    },
    BuildEnrollmentForm: function () {

        debugger;

        //Define todos os inputs somente como maiúsculos
        Vehicle_Enrollment.SetInputsUpperCase();

        var terms = new Array();
        $.each(assemblers, function (key, value) {
            terms.push(value.Name);
        });

        var $terms = terms.sort(),
            $return = [];

        function strInArray(str, strArray) {
            for (var j = 0; j < strArray.length; j++) {
                if (strArray[j].match(str) && $return.length < 5) {
                    var $h = strArray[j].replace(str, '<strong>' + str + '</strong>');
                    $return.push('<li class="prediction-item"><span class="prediction-text">' + $h + '</span></li>');
                }
            }
        }

        function nextItem(kp) {
            if ($('.focus').length > 0) {
                var $next = $('.focus').next(),
                    $prev = $('.focus').prev();
            }

            if (kp == 38) { // Up

                if ($('.focus').is(':first-child')) {
                    $prev = $('.prediction-item:last-child');
                }

                $('.prediction-item').removeClass('focus');
                $prev.addClass('focus');

            } else if (kp == 40) { // Down

                if ($('.focus').is(':last-child')) {
                    $next = $('.prediction-item:first-child');
                }

                $('.prediction-item').removeClass('focus');
                $next.addClass('focus');
            }
        }

        $(function () {
            $('#search-bar').keydown(function (e) {
                $key = e.keyCode;
                if ($key == 38 || $key == 40) {
                    nextItem($key);
                    return;
                }

                setTimeout(function () {
                    var $search = $('#search-bar').val().toUpperCase();
                    $return = [];

                    strInArray($search, $terms);

                    if ($search == '' || !$('input').val) {
                        $('.output').html('').slideUp();
                    } else {
                        $('.output').html($return).slideDown();
                    }

                    $('.prediction-item').on('click', function () {
                        $text = $(this).find('span').text();
                        $('.output').slideUp(function () {
                            $(this).html('');
                        });
                        $('#search-bar').val($text);
                    });

                    $('.prediction-item:first-child').addClass('focus');

                }, 50);
            });
        });

        $('#search-bar').focus(function () {
            if ($('.prediction-item').length > 0) {
                $('.output').slideDown();
            }

            $('#searchform').submit(function (e) {
                e.preventDefault();
                $text = $('.focus').find('span').text();
                $('.output').slideUp();
                $('#search-bar').val($text);
                $('input').blur();
            });
        });

        $('#search-bar').blur(function () {
            if ($('.prediction-item').length > 0) {
                $('.output').slideUp();
            }
        });
    },
    InitializeMasks: function () {

        //Máscara para placa, aceitando Mercosul
        $('#plate').mask('AAA-BZBB', {
            'translation': {
                Z: { pattern: /[A-Za-z0-9]/ },
                A: { pattern: /[A-Za-z]/ },
                B: { pattern: /[0-9]/ },
            }
        });
    },
    SetInputsUpperCase: function () {

        //Montadora
        $('#search-bar').keyup(function () {
            $(this).val($(this).val().toUpperCase());
        });

        //Modelo
        $('#model').keyup(function () {
            $(this).val($(this).val().toUpperCase());
        });

        //Placa
        $('#plate').keyup(function () {
            $(this).val($(this).val().toUpperCase());
        });
    },
    ValidateInputs: function () {

        //Valida montadora
        if ($('#search-bar').val().length == 0) {
            Swal.fire({
                title: 'É necessário digitar a montadora',
                icon: 'info',
                confirmButtonText: 'Ok'
            })

            return true;
        }
        else if ($('#model').val().length == 0) {
            Swal.fire({
                title: 'É necessário digitar o modelo',
                icon: 'info',
                confirmButtonText: 'Ok'
            })

            return true;
        }
        else if ($('#plate').val().length == 0) {
            Swal.fire({
                title: 'É necessário digitar a placa',
                icon: 'info',
                confirmButtonText: 'Ok'
            })

            return true;
        }
        else {
            return false;
        }

    },
    ExecuteAjax: function (formData, controller, action) {

        $.ajax({
            url: "https://localhost:44390/" + controller + "/" + action,
            data: JSON.stringify(formData),
            dataType: 'json',
            contentType: "application/json",
            type: "POST",
            traditional: true,
            async: true,
        }).fail(function (data) {

            debugger;
            Swal.fire({
                title: data,
                icon: 'info',
                confirmButtonText: 'Ok'
            })

        }).done(function (data) {

            debugger;
                        
            Swal.fire({
                title: data,
                //text: 'Modal with a custom image.',
                imageUrl: "/images/vehicle-driving.gif",
                imageWidth: 400,
                imageHeight: 200,
                imageAlt: 'Custom image',
            })

            debugger;

        })
    }
};

window.onload = Vehicle_Enrollment.InitializeComponent();