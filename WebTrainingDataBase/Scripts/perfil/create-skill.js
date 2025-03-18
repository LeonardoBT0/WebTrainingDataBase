$(document).ready(function () {

    var skills = new Array();
    $('#txtAreaBio').prop('disabled', true);
    $('#btnGuardarSkill').click(function (event) {
        event.preventDefault();
        var txtSkill = $('#txtSkill').val();
        skills.push(txtSkill);
        ShowSpan(skills);
        Limpiar();
    });
    $('#btnBio').click(function (event) {
        event.preventDefault();
        $('#txtAreaBio').prop('disabled', false);
    });
});

function Limpiar() {
    $('#modalSkill').modal('hide');
    $('#txtSkill').val('');
}
function removeChip(element) {
    element.parentElement.remove();
};
function LoadInit() {
    $("#cardSkill, #carBio").hide();
    $("#cardRow").css("display", "none");
};
// Muestra solo el card seleccionado y oculta el otro
function ShowCard(cardId) {

    if (cardId === '#cardSkill') {
        $("#cardSkill").show();

    }
    if (cardId === '#carBio') {
        console.log("sadff");
        $("#carBio").append();
    }
}

function LoadSkillOnly() {
    $("#cardRow").css("display", "flex");
    $("#carBio").css("display", "none");
}

function ShowData(skills) {
    $("#skillBody").empty("");
    $("#spanId").empty("");
    $("#skillBody").append('<div class="card-title"><span class="roboto-Black-900 title-morado">Skill Profesionales</span ></div > <hr />');
    $.each(skills, function (index, skill) {
        $("#skillBody").append(`
            <span class="badge bg-success text-white me-2 mt-1 roboto-Light-300" id="spanId">
                ${skill} 
                <button type="button" class="btn-close btn-close-white ms-2" aria-label="Close" onclick="removeChip(this)"></button>
            </span>
        `);
    });
}

function ShowSpan(skills) {
    var skillContent = ''; // Variable para construir todo el contenido
    // Agregar encabezado inicial
    skillContent += '<div class="card-title"><span class="roboto-Black-900 title-morado">Skill Profesionales</span></div><hr/>';
    // Crear los elementos de habilidad
    $.each(skills, function (index, skill) {
        skillContent += `
            <span class="badge bg-success text-white me-2 mt-1 roboto-Light-300">
                ${skill} 
                <button type="button" class="btn-close btn-close-white ms-2" aria-label="Close" onclick="removeChip(this)"></button>
            </span>
        `;
    });
    // Limpiar el contenido actual de skillBody
    $("#skillBody").empty();
    // Insertar todo el contenido de una sola vez
    $("#skillBody").append(skillContent);
}