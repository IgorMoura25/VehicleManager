Manage_Enrollment = {
    InitializeComponent: function () {

        debugger;

        Manage_Enrollment.DrawDataTable();
        Manage_Enrollment.InitializeMasks();
        Manage_Enrollment.InitializeButtons();

    },
    DrawDataTable: function () {

        var table = $('#example').DataTable({
            // hiding columns via datatable column.visivle API
            "columnDefs": [{
                "targets": [2],
                "visible": false
            }, {
                "targets": [3],
                "visible": false
            }, {
                // adding a more info button at the end
                "targets": -1,
                "data": null,
                "defaultContent": "<button data-target='#myModal' role='button' data-toggle='modal' type='button' class='btn btn-default'><span class='glyphicon glyphicon-plus' aria-hidden='true'></span></button>"
            }]
        });

        $('#example tbody').on('click', 'button', function () {

            var data = table.row($(this).parents('tr')).data(); // getting target row data
            $('.insertHere').html(
                '<input id="plate" type="text" class="input" value="' + data[0] + '"> <input id="assembler" type="text" class="input" value="' + data[1] + '"> <input id="model" type="text" class="input" value="' + data[4] + '"><input id="vehicle-id" type="hidden" class="input" value="' + data[5] + '">'
            );
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
    ValidateInputs: function () {

        //Valida montadora
        if ($('#assembler').val().length == 0) {
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
    InitializeButtons: function () {

        //Botão de deletar
        $('#delete-item').click(function () {


            const swalWithBootstrapButtons = Swal.mixin({
                customClass: {
                    confirmButton: 'btn btn-success',
                    cancelButton: 'btn btn-danger'
                },
                buttonsStyling: false
            })

            swalWithBootstrapButtons.fire({
                title: 'Tem certeza?',
                text: "Não será possível reverter!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim, deletar.',
                cancelButtonText: 'Não, voltar.',
                reverseButtons: true
            }).then((result) => {

                if (result.value) {

                    var id = $("#vehicle-id").val();

                    var Vehicle = new Object();
                    Vehicle.Id = id;

                    Manage_Enrollment.ExecuteAjax(Vehicle, "manager", "deletevehicle", false);

                    swalWithBootstrapButtons.fire(
                        'Deletado!',
                        'Veículo descadastrado.',
                        'success'
                    ).then(function () {
                        location.reload();
                    });
                } else if (
                    /* Read more about handling dismissals below */
                    result.dismiss === Swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons.fire(
                        'Cancelado!',
                        'Veículo permanece na base.',
                        'error'
                    ).then(function () {
                        location.reload();
                    });
                }
            })

        });

        //Botão de salvar
        $('#save-changes').click(function () {

            debugger;

            //Valida inputs
            if (Manage_Enrollment.ValidateInputs()) {
                return;
            }

            var id = $("#vehicle-id").val();
            var assembler = $("#assembler").val();
            var model = $("#model").val();
            var plate = $("#plate").val();

            var Vehicle = new Object();
            Vehicle.Id = id;
            Vehicle.AssemblerName = assembler;
            Vehicle.Model = model;
            Vehicle.Plate = plate;

            Manage_Enrollment.ExecuteAjax(Vehicle, "manager", "updatevehicle", true);

        });

    },
    ExecuteAjax: function (formData, controller, action, showAlerts) {

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

            if (showAlerts) {
                Swal.fire({
                    title: data,
                    icon: 'info',
                    confirmButtonText: 'Ok'
                })
            }


        }).done(function (data) {

            debugger;

            Swal.fire({
                title: data,
                imageUrl: "/images/vehicle-driving.gif",
                imageWidth: 400,
                imageHeight: 200,
                imageAlt: 'Custom image',
            }).then(function () {
                location.reload();
            });

            //location.reload();

            debugger;

        })
    }
};

window.onload = Manage_Enrollment.InitializeComponent();