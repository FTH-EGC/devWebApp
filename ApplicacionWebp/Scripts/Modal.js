

const btnEditar = document.querySelectorAll('#editar');
const btnAgregar = document.querySelector('#agregar');
const btnEditarAregar = document.querySelector('#editarAgregar');
const btnAgregarCampo = document.querySelector('#agregarCampo');
const modalH2 = document.querySelector('#modalCrearEditar h2');
const modal = document.querySelector('#modalCrearEditar');
const modalForm = document.querySelector('#modalCrearEditar form');
const nombre = document.querySelector('#nombreInput');
const apellidoP = document.querySelector('#apellidoPInput');
const apellidoM = document.querySelector('#apellidoMInput');
const edad = document.querySelector('#edadInput');
const select = document.querySelector('#select');


eventListeners();
function eventListeners() {

    btnEditar.forEach(btnedit => {
        btnedit.addEventListener('click', mostrarBtnEditar);
    });
    btnAgregar.addEventListener('click', mostrarBtnAgregar);
    btnEditarAregar.addEventListener('click', validar);
    btnAgregarCampo.addEventListener('click', validar);
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


function validar() {
    if (nombre.value === "" || apellidoP.value === "" || apellidoM.value === "" || edad.value === "" || select.value === "") {
        const error = document.querySelector('.error');
        if (!error) {
            mostrarError();
        }
        return;
    }
}

function mostrarError() {
    const div = document.createElement('div');
    const parrafo = document.createElement('p');
    parrafo.textContent = 'Todos los campos son obligatorios';
    parrafo.classList.add('text-danger', 'h4');
    div.appendChild(parrafo);
    div.classList.add('text-center', 'error');
    modalForm.insertBefore(div, modalForm.children[0]);

    const error = document.querySelector('.error');
    setTimeout(() => {
        error.remove();
    }, 3000)
}