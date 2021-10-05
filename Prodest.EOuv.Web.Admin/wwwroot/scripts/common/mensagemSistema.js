const mensagemSistema = {

    /**
    * @param {string} mensagem
    */
    showMensagemSucesso(mensagem) {

        let html = `
<div class="toast ext-toast" role="alert" aria-live="assertive" aria-atomic="true">
    <div class="container">
        <div class="toast-body">
            <i class="fas fa-check-circle text-success me-1"></i>
            <span class="me-auto">${mensagem}</span>
        </div>
        <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
    </div>
</div>
`;

        let toastEls = bootstrapHelper.htmlToElement(html);
        bootstrapHelper.showToast(toastEls[0]);
    },

    /**
    * @param {string} mensagem
    */
    showMensagemErro(mensagem) {

        let html = `
<div id="erroModal" class="modal" tabindex="-1">
    <div class="modal-dialog modal-dialog-centered modal-dialog-scrollable">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title">
                    <div class="d-flex align-items-center">
                        <i class="fas fa-exclamation-circle fa-3x text-danger me-2"></i>
                        <div class="fs-4 fw-bold">ERRO</div>
                    </div>
                </h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div>${mensagem}</div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
            </div>
        </div>
    </div>
</div>
`;

        //se j� existir o modal de erro no dom, remove-o
        let elModalJaExistente = document.getElementById('erroModal');
        if (elModalJaExistente)
            elModalJaExistente.remove();

        //insere o modal calculado acima, o obt�m, e abre o modal
        document.body.insertAdjacentHTML('beforeend', html);
        let el = document.getElementById('erroModal');
        bootstrapHelper.openModal(el);
    }
}