const bootstrapHelper = {

    openModal(ref) {
        var modal = new mdb.Modal(ref)
        modal.show()
        return modal;
    },

    openModalStatic(ref) {
        let options = {
            backdrop: 'static',
        };
        var modal = new bootstrap.Modal(ref, options);
        modal.show();
        return modal;
    },

    closeModal(modal) {
        modal.hide();        
    },

    showToast(toastEl) {

        let toastContainer = document.querySelector('.toast-container');
        toastContainer.appendChild(toastEl);

        let toast = new bootstrap.Toast(toastEl);
        toast.show();
    },

    // outros utilitarios

    htmlToElement(html) {
        var template = document.createElement('template');
        template.innerHTML = html.trim();
        return template.content.childNodes;
    }

}