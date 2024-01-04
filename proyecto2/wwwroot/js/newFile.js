$(document).ready(function() {
    $("#addFunctionButton").click(async function(e) {
        e.preventDefault();
        var pregunta = $("#Preguntatxt").val();
        var url = "@Url.Action(", CrearPreguntas; ", "; Cuestionarios; ")";

        var data = {
            pregunta: pregunta,
        };
        $.post(url, data).done(function(result) {
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
