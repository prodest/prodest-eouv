let app = VueFactory.createApp();

app.component('despacho-manifestacao', DespachoManifestacao);
app.component('despacho-form', DespachoForm);
app.component('selecao-destinatarios', SelecaoDestinatarios);
app.component('selecao-papel', SelecaoPapel);
app.mount('#app');