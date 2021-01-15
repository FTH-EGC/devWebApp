

const btnEditar = document.querySelectorAll('#editar');
const btnAgregar = document.querySelector('#agregar');
const btnEditarAregar = document.querySelector('#editarAgregar');
const btnAgregarCampo = document.querySelector('#agregarCampo');
const modalH2 = document.querySelector('#modalCrearEditar h2');


eventListeners();
function eventListeners() {

    btnEditar.forEach(btnedit => {
        btnedit.addEventListener('click', mostrarBtnEditar);
    });
    btnAgregar.addEventListener('click', mostrarBtnAgregar);

}

function mostrarBtnEditar() {
    btnAgregarCampo.style.display = 'none';
    btnEditarAregar.style.display = 'inline-block';
    modalH2.textContent = 'Editar Usuario';

}

function mostrarBtnAgregar() {
    btnAgregarCampo.style.display = 'inline-block';
    btnEditarAregar.style.display = 'none';
    modalH2.textContent = 'Crear Usuario';
}