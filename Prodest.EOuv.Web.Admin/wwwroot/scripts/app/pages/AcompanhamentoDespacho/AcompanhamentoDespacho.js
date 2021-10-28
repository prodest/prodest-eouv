let app = VueFactory.createApp();
app.component('lista-despachos', ListaDespachos);
app.component('rastreio-encaminhamento', RastreioEncaminhamento);
app.component('rastreio', Rastreio);
app.mount('#app');