    $(document).ready(function () {
        $("#addFunctionButton").click(async function (e) {
            e.preventDefault();
            var pregunta = $("#Preguntatxt").val();
            var url = '/Cuestionarios/CrearPreguntas';
            var data = {
                pregunta: pregunta,
            };

            $.post(url, data).done(function (result) {
                if (result.message == "No se creo el cuestionario") {
                    console.log("Error");
                    $("#exampleModal").modal('show');
                }
                else {
                    var nuevoDiv = `<div class="mt-3 añadirPreguntas d-flex align-items-center">
                        <div id="${result.idpregunta}" class="form-control mt-3">${result.pregunta}</div>                            <div class="d-flex ml-auto">
                                <button type="button" class="btn btn-primary agregarPregunta d-none flex-grow-1"><i class="fa fa-plus"></i>Editar</button>
                                <button type="button" class="btn btn-secondary cancelarPregunta d-none flex-grow-1"><i class="fa fa-times"></i>Eliminar</button>
                            </div>
                    </div>`;
                    
                    `<div id="${result.idpregunta}">
                            <div class="form-control mt-3">${result.pregunta}</div>
                    </div>`;
                    $(".añadirPreguntas").append(nuevoDiv);
                    AgregarRespuestas1();
                    console.log(result);
                }
            });
        });
    });
var array = [];

function AgregarItemsRespuestas() {
    $(document).ready(function () {
    let TempArray = [];
        for (var i = 0; i < 6; i++) {
            TempArray[i] = document.getElementById('numero' + (i + 1)).value;
        }
        array = TempArray.filter(function (elemento) {
            return elemento.trim()!=="";
        });

        for (var i = 0; i < array.length; i++) {
            console.log(array[i]);
            
        }
    
    });
};

$(document).ready(function () {
    $("#AddRespuesta").click(function () {
        AgregarItemsRespuestas();
    });
});
var respuestas2 = [];

    function AgregarRespuestas1() {
        $(document).ready(function () {
            for (var i = 0; i < array.length; i++) {
                var esCorrecta = false;

                respuestas2.push({ respuesta: array[i], RCorrecta: esCorrecta });
                textoRespuesta = "";
            }

            $.ajax({
                url: '/Cuestionarios/CrearRespuesta',
                type: 'Post',
                contentType: 'application/Json',
                data: JSON.stringify(respuestas2),
                success: function (result) {
                    console.log(result);
                    respuestas2 = [];
                    array = [];

                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    }




