

const btnEditar = document.querySelector('#editar');
const btnAgregar = document.querySelector('#agregar');
const btnEditarAregar = document.querySelector('#editarAgregar');
const btnAgregarCampo = document.querySelector('#agregarCampo');

eventListeners();
function eventListeners() {

    btnEditar.addEventListener('click', mostrarBtn);
    btnAgregar.addEventListener('click', mostrarBtnAgregar);
}

function mostrarBtn() {
    btnAgregarCampo.style.display = 'none';
    btnEditarAregar.style.display = 'inline-block';
}

function mostrarBtnAgregar() {
    btnAgregarCampo.style.display = 'inline-block';
    btnEditarAregar.style.display = 'none';

}