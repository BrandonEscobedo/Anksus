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
                    var nuevoDiv = `<div id="${result.idpregunta}">
                            <div class="form-control mt-3">${result.pregunta}</div>
                    </div>`;
                    $(".añadirPreguntas").append(nuevoDiv);
                    AgregarRespuestas1();
                    console.log(result);
                }
            });
        });
    });
var RespuestaTotal = new Array(5) ;
    function agregarRespuesta() {
        let respuestasContenedor = $("#RespuestasContenedor");
        let numRespuestas =2;
        if (numRespuestas < 6) {
            let siguienteIndice = numRespuestas;
            let nuevaRespuesta = $(
              `   <div class="input-group dynamic-respuesta">
                        <input type="text" class="form-control"  placeholder="Ingresa tu Respuesta aqui" />
                      <div class="input-group-text">
                            <input id="eye" type="checkbox" id="${RespuestaTotal[numRespuestas]}" class="form-check-input" value="True"  />
                      </div>
                        <button type="button" class="btn btn-danger remove-respuesta">Eliminar</button>
                  </div>`
            );
            respuestasContenedor.append(nuevaRespuesta);
        }
        else {
            alert("No se pueden agregar mas de 10 respuestas!");
        }
    }
    $(".add-respuesta").click(agregarRespuesta);
    $("#RespuestasContenedor").on("click", ".remove-respuesta", function () {
        let filarespuesta = $(this).closest("tr");
        filarespuesta.remove();
    });
    function AgregarRespuestas1() {
        $(document).ready(function () {
            var respuestas = [];
            for (var i = 1; i <= 4; i++) {
                var textoRespuesta = "hola1";
                var esCorrecta = false;

                respuestas.push({ respuesta: textoRespuesta, RCorrecta: esCorrecta });
                console.log(respuestas);
            }
            $.ajax({
                url: '/Cuestionarios/CrearRespuesta',
                type: 'Post',
                contentType: 'application/Json',
                data: JSON.stringify(respuestas),
                success: function (result) {
                    console.log(result);
                },
                error: function (error) {
                    console.log(result);
                }
            });
        });
    }




