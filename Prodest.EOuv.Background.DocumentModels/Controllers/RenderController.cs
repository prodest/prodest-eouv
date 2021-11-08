using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prodest.EOuv.UI.Apresentacao;

namespace DocumentModels.Controllers
{
    public class RenderController : Controller
    {
        public IActionResult ResumoManifestacao([FromBody] ManifestacaoViewModel manifestacao)
        {
            return View(manifestacao);
        }

        public IActionResult ResumoManifestacao2()
        {
            string manifestacaostr = @"{
'idManifestacao': 583,
'numProtocolo': '2021090001',
'idOrgaoResponsavel': 877,
'idUsuarioAnalise': 29,
'idTipoManifestacao': 1,
'idTipoIdentificacao': 1,
'idTipoManifestante': 1,
'idAssunto': 701,
'idOrgaoInteresse': 862,
'idCanalEntrada': 7,
'idModoResposta': 5,
'idSituacaoManifestacao': 9,
'tipoManifestacao': {
'descTipoManifestacao': 'Denúncia'
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Encerrada'
},
'orgaoResponsavel': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'orgaoInteresse': {
'idOrgao': 862,
'guidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
'siglaOrgao': 'PRODEST                                           ',
'nomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
'razaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           '
},
'assunto': {
'descAssunto': 'Cargo Público'
},
'dataRegistro': '2021-09-23T09:38:09.307',
'dataRegistroFormat': '23/09/2021',
'prazoResposta': '2021-12-06T23:59:59',
'prazoRespostaFormat': '06/12/2021',
'usuarioCadastrador': null,
'registradoPorFormat': 'Cidadão',
'canalEntrada': {
'descCanalEntrada': 'Internet'
},
'modoResposta': {
'descModoResposta': 'Internet'
},
'textoManifestacao': 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse vel auctor metus. Nam nec quam non eros posuere tristique vel at lorem. Ut in nisl eget quam placerat vestibulum sit amet non ipsum. Mauris eget lorem eget dui imperdiet ultricies ut vitae felis. Nullam porttitor elit ex, non ultrices nulla dignissim a. Suspendisse dignissim quam eget magna luctus malesuada. Sed nisl ipsum, eleifend at feugiat eu, rhoncus vitae urna. Sed ultrices sapien orci. Nulla facilisi. Morbi non tristique sem. Curabitur porta est maximus, volutpat turpis vel, blandit libero. Phasellus euismod mauris sem, ac gravida ipsum malesuada vitae. Mauris condimentum eleifend dolor vitae interdum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed mollis, mi et dapibus fringilla, justo ex pretium eros, viverra euismod lorem felis at magna. Donec nec mauris eu sem pretium pretium.',
'municipio': null,
'municipioLocalFatoFormat': 'Todo o Estado',
'anexoManifestacao': [],
'complementoManifestacao': [
{
'txtComplemento': 'teste de complemento\r\nEtiam nisl nisl, finibus in ullamcorper nec, efficitur nec metus. Donec nec enim sit amet eros dapibus suscipit. Etiam nulla magna, tincidunt sed orci sit amet, malesuada malesuada enim. Fusce at scelerisque felis, sed luctus augue. Ut sit amet bibendum velit, ut vehicula nibh. Curabitur ac viverra quam. Phasellus tincidunt, tellus at viverra facilisis, purus nisi pretium eros, ac lacinia nibh ligula sed nisi. Mauris pretium, sem non ultrices sollicitudin, ante nisi sollicitudin velit, id dignissim lacus turpis id augue. Donec tristique gravida eros in ornare. Mauris ut convallis ante. Phasellus et vehicula augue. Mauris dapibus lobortis metus, eu dignissim est porta eu.',
'dtComplemento': '2021-09-23T09:44:05.44',
'dtComplementoFormat': '23/09/2021',
'usuarioLeitura': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dtLeitura': '2021-09-23T09:45:00.26',
'dtLeituraFormat': '23/09/2021'
}
],
'tipoIdentificacao': {
'descTipoIdentificacao': 'Identificada'
},
'tipoManifestante': {
'descTipoManifestante': 'Pessoa Física'
},
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': {
'descMunicipio': 'Vitória',
'sigUf': 'ES',
'uf': {
'descUf': 'ESPÍRITO SANTO'
}
}
},
'pessoaJuridica': null,
'prorrogacaoManifestacao': [
{
'prazoOriginal': '2021-11-04T23:59:59',
'prazoOriginalFormat': '04/11/2021',
'novoPrazo': '2021-12-06T23:59:59',
'novoPrazoFormat': '06/12/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'txtJustificativaProrrogacao': 'teste de prorrogação\r\nPhasellus iaculis eget sem nec cursus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nam urna dolor, cursus eu tortor sit amet, finibus bibendum orci. Praesent tempus, dui lacinia suscipit cursus, metus diam tristique ligula, vitae bibendum eros lacus at metus. Interdum et malesuada fames ac ante ipsum primis in faucibus. Suspendisse eu ipsum vitae magna vehicula ornare eu nec velit. Vivamus consectetur sollicitudin viverra. Vivamus aliquet sodales augue. Pellentesque ullamcorper mauris sit amet feugiat eleifend. Aliquam auctor ornare quam, quis fermentum nisi venenatis non. Proin scelerisque sapien id quam venenatis, ullamcorper iaculis tellus hendrerit. Duis dui libero, pretium in venenatis eu, tristique quis ante.',
'dataProrrogacao': '2021-09-23T09:45:42.653',
'dataProrrogacaoFormat': '23/09/2021'
}
],
'diligenciaManifestacao': [
{
'txtDiligencia': 'teste de diligencia\r\nProin pharetra pretium leo, et laoreet sem laoreet sit amet. Sed quis augue ut sem commodo porttitor bibendum tincidunt lectus. Fusce ac augue ut dui rutrum condimentum. Aliquam ut elit a dolor molestie consequat sed quis metus. Nunc ullamcorper libero orci, et lobortis ipsum tempor elementum. Nulla facilisi. Pellentesque vel ultricies ipsum. Praesent at pulvinar felis. Curabitur tincidunt mollis sem, et tincidunt tellus ultrices malesuada.',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataDiligencia': '2021-09-23T09:41:20.787',
'dataDiligenciaFormat': '23/09/2021',
'txtRespostaDiligencia': 'teste resposta diligencia\r\nInteger pellentesque turpis elit, et ullamcorper orci mollis eu. Phasellus sit amet velit tincidunt, elementum est non, dictum neque. Nam luctus, leo vitae vulputate consequat, dui massa scelerisque justo, et pretium tellus felis sed erat. Ut rhoncus ultricies metus, non sodales ipsum auctor quis. Phasellus porttitor sem et erat egestas, eu dignissim risus convallis. Morbi cursus lorem eget varius tincidunt. Pellentesque eget urna consectetur, luctus tortor laoreet, ultrices libero. In vitae condimentum nisl. Morbi sodales, dui in convallis varius, metus justo consequat ex, vitae lacinia augue enim vel felis. Maecenas sed gravida nunc. Maecenas ligula sem, malesuada at tempus eget, tincidunt et nisl. Quisque sem tortor, laoreet ac felis nec, lacinia consectetur lacus. Maecenas facilisis libero vel convallis eleifend.',
'dataRespostaDiligencia': '2021-09-23T09:43:47.967',
'dataRespostaDiligenciaFormat': '23/09/2021'
}
],
'encaminhamentoManifestacao': [
{
'orgaoOrigem': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'orgaoDestino': {
'idOrgao': 862,
'guidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
'siglaOrgao': 'PRODEST                                           ',
'nomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
'razaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'txtEncaminhamento': 'Mauris dignissim, enim a rutrum pellentesque, lectus turpis imperdiet dui, sit amet vestibulum risus risus vitae ex. Phasellus eu sapien sed libero egestas vehicula. Ut purus lacus, interdum non turpis eget, vestibulum dictum quam. Proin id mauris quam. In turpis neque, placerat tincidunt purus ac, ornare tempor purus. Aenean dignissim, tortor at viverra varius, nulla ligula feugiat diam, eget fermentum velit nulla vitae est. Aenean ac blandit metus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec molestie laoreet sem, nec eleifend felis fermentum eu.',
'dataEncaminhamento': '2021-09-23T09:39:54.853',
'dataEncaminhamentoFormat': '23/09/2021'
},
{
'orgaoOrigem': {
'idOrgao': 862,
'guidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
'siglaOrgao': 'PRODEST                                           ',
'nomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
'razaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           '
},
'orgaoDestino': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'txtEncaminhamento': 'dados de devolução \r\nMaecenas convallis fermentum nisl sit amet tristique. Phasellus in ipsum erat. Cras pellentesque commodo nunc, in condimentum mi molestie et. Suspendisse lacinia egestas felis ac faucibus. Nam ut mi et tortor eleifend porta. Nam venenatis vulputate ex sed vestibulum. Donec tristique sagittis odio. Aliquam feugiat nibh vitae iaculis commodo. Duis tempor nulla et neque convallis, auctor consectetur nisi laoreet. Nunc non dui in libero condimentum gravida. Sed mattis vulputate ex, fringilla varius velit malesuada a. Nunc porta odio lobortis enim hendrerit tristique.',
'dataEncaminhamento': '2021-09-23T09:40:53.343',
'dataEncaminhamentoFormat': '23/09/2021'
}
],
'respostaManifestacao': [
{
'txtResposta': 'respsota de apuração\r\nDonec id ligula ac ex faucibus varius mattis eu turpis. Nullam luctus vehicula placerat. Donec nunc libero, consequat id nisl ut, aliquet eleifend risus. Sed volutpat diam dolor, ac mollis leo mollis at. Maecenas arcu sem, condimentum in rutrum quis, fringilla sed purus. Phasellus gravida dignissim arcu vel luctus. Sed iaculis cursus ex, quis semper ante efficitur vel. Vivamus eget tristique orci, ac ornare dolor. Phasellus vel nisl laoreet, blandit est vel, facilisis lacus. Etiam pharetra eu massa quis auctor.\r\n\r\nResposta final\r\nInterdum et malesuada fames ac ante ipsum primis in faucibus. Suspendisse potenti. Cras aliquet commodo nulla et consequat. Sed pellentesque mattis posuere. Cras sollicitudin posuere orci. Cras diam nibh, fermentum vitae consequat at, varius non ligula. Pellentesque quis ipsum porttitor, malesuada leo a, tincidunt leo. Maecenas molestie orci ac ipsum rhoncus, sed interdum magna accumsan. Curabitur tincidunt sed felis et varius. Curabitur volutpat vehicula euismod. Maecenas rutrum lacus quis tortor lacinia, eu ultricies diam pretium. Praesent ex felis, malesuada a dapibus a, suscipit sed lorem. Nunc ut pellentesque ipsum. Proin vitae aliquam mi, et bibendum sapien. Maecenas euismod, felis eu bibendum viverra, leo leo bibendum justo, vitae finibus dolor nunc vel nisi.\r\n',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-09-23T09:47:49.223',
'dataRespostaFormat': '23/09/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-10-27T16:29:40.287',
'dataRespostaFormat': '27/10/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:31:27.547',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:32:44.633',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:35:37.793',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:35:38.69',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:35:39.293',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:35:55.317',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:37:03.98',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:38:03.483',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-03T14:38:06.18',
'dataRespostaFormat': '03/11/2021'
},
{
'txtResposta': 'TESTE DE RESPOSTA!!!',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataResposta': '2021-11-04T10:36:16.383',
'dataRespostaFormat': '04/11/2021'
}
],
'apuracaoManifestacao': [
{
'txtSolicitacaoApuracao': 'solicito apuração\r\nNulla viverra nec nunc a vestibulum. Vivamus interdum volutpat mauris quis pulvinar. Phasellus nisi nibh, tempor vitae urna a, finibus pellentesque magna. Praesent in hendrerit augue, quis varius sapien. Quisque rutrum, ex ut placerat molestie, nulla magna maximus lorem, commodo sodales justo nulla eget purus. Nulla convallis faucibus est, ut finibus enim rutrum et. Morbi vehicula lorem turpis, et pharetra augue feugiat ac. Cras quis condimentum orci. Nullam turpis enim, lobortis nec laoreet id, euismod vitae ante. Phasellus id sapien dictum, semper augue vitae, pulvinar urna. Fusce in auctor nisi, in egestas tortor. Nullam a neque elit. Nulla suscipit consequat lectus sed ullamcorper. Aenean vitae lacus ullamcorper, varius magna non, mollis lorem. Suspendisse at ante sed lacus pellentesque accumsan.',
'dataSolicitacaoApuracao': '2021-09-23T09:46:30.973',
'dataSolicitacaoApuracaoFormat': '23/09/2021',
'txtRespostaApuracao': 'respsota de apuração\r\nDonec id ligula ac ex faucibus varius mattis eu turpis. Nullam luctus vehicula placerat. Donec nunc libero, consequat id nisl ut, aliquet eleifend risus. Sed volutpat diam dolor, ac mollis leo mollis at. Maecenas arcu sem, condimentum in rutrum quis, fringilla sed purus. Phasellus gravida dignissim arcu vel luctus. Sed iaculis cursus ex, quis semper ante efficitur vel. Vivamus eget tristique orci, ac ornare dolor. Phasellus vel nisl laoreet, blandit est vel, facilisis lacus. Etiam pharetra eu massa quis auctor.',
'dataRespostaApuracao': '2021-09-23T09:46:52.207',
'dataRespostaApuracaoFormat': '23/09/2021',
'orgaoOrigem': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'orgaoDestino': {
'idOrgao': 862,
'guidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
'siglaOrgao': 'PRODEST                                           ',
'nomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
'razaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           '
},
'usuario': null
}
],
'despachoManifestacao': [
{
'idDespachoManifestacao': 5,
'idManifestacao': 583,
'idOrgao': 877,
'textoSolicitacaoDespacho': 'ddddddddddddddd',
'idUsuarioSolicitacaoDespacho': 29,
'dataSolicitacaoDespacho': '2021-10-29T16:18:08.327',
'dataSolicitacaoDespachoFormat': '29/10/2021',
'prazoResposta': '2021-11-18T00:00:00',
'prazoRespostaFormat': '18/11/2021',
'protocoloEdocs': '2021-NJFCS3',
'idEncaminhamento': '49051110-4b39-4c36-8978-adf0bc98e713',
'idAgenteDestinatario': 3,
'idAgenteResposta': 0,
'dataRespostaDespacho': '2021-10-29T16:21:37.297',
'dataRespostaDespachoFormat': '29/10/2021',
'idSituacaoDespacho': '2',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuarioSolicitacaoDespacho': {
'orgao': null,
'pessoa': null
},
'agenteDestinatario': null,
'agenteResposta': null,
'situacaoDespacho': null,
'agenteDestinatarioFormat': ''
},
{
'idDespachoManifestacao': 6,
'idManifestacao': 583,
'idOrgao': 877,
'textoSolicitacaoDespacho': 'oooooooooooo',
'idUsuarioSolicitacaoDespacho': 29,
'dataSolicitacaoDespacho': '2021-10-29T16:19:30.15',
'dataSolicitacaoDespachoFormat': '29/10/2021',
'prazoResposta': '2021-11-18T00:00:00',
'prazoRespostaFormat': '18/11/2021',
'protocoloEdocs': '2021-HC6C6K',
'idEncaminhamento': '5175b487-889e-4d2b-92d7-7afea75a319b',
'idAgenteDestinatario': 4,
'idAgenteResposta': 0,
'dataRespostaDespacho': '2021-10-29T16:21:38.99',
'dataRespostaDespachoFormat': '29/10/2021',
'idSituacaoDespacho': '2',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuarioSolicitacaoDespacho': {
'orgao': null,
'pessoa': null
},
'agenteDestinatario': null,
'agenteResposta': null,
'situacaoDespacho': null,
'agenteDestinatarioFormat': ''
},
{
'idDespachoManifestacao': 7,
'idManifestacao': 583,
'idOrgao': 877,
'textoSolicitacaoDespacho': 'knnnnnnn',
'idUsuarioSolicitacaoDespacho': 29,
'dataSolicitacaoDespacho': '2021-10-29T16:21:12.917',
'dataSolicitacaoDespachoFormat': '29/10/2021',
'prazoResposta': '2021-11-18T00:00:00',
'prazoRespostaFormat': '18/11/2021',
'protocoloEdocs': '2021-B3ZX7L',
'idEncaminhamento': '7b29b580-3aeb-4128-975d-24c2c2877d6f',
'idAgenteDestinatario': 5,
'idAgenteResposta': 0,
'dataRespostaDespacho': '2021-10-29T16:24:09.15',
'dataRespostaDespachoFormat': '29/10/2021',
'idSituacaoDespacho': '2',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuarioSolicitacaoDespacho': {
'orgao': null,
'pessoa': null
},
'agenteDestinatario': null,
'agenteResposta': null,
'situacaoDespacho': null,
'agenteDestinatarioFormat': ''
},
{
'idDespachoManifestacao': 8,
'idManifestacao': 583,
'idOrgao': 877,
'textoSolicitacaoDespacho': 'aaaaaaaa ',
'idUsuarioSolicitacaoDespacho': 29,
'dataSolicitacaoDespacho': '2021-11-03T09:16:40.47',
'dataSolicitacaoDespachoFormat': '03/11/2021',
'prazoResposta': '2021-11-23T00:00:00',
'prazoRespostaFormat': '23/11/2021',
'protocoloEdocs': '2021-XXRRV9',
'idEncaminhamento': '77c510b0-9634-4c47-9ddf-ac4b59cde2e1',
'idAgenteDestinatario': 6,
'idAgenteResposta': 0,
'dataRespostaDespacho': '2021-11-03T09:18:35.033',
'dataRespostaDespachoFormat': '03/11/2021',
'idSituacaoDespacho': '3',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuarioSolicitacaoDespacho': {
'orgao': null,
'pessoa': null
},
'agenteDestinatario': null,
'agenteResposta': null,
'situacaoDespacho': null,
'agenteDestinatarioFormat': ''
},
{
'idDespachoManifestacao': 9,
'idManifestacao': 583,
'idOrgao': 877,
'textoSolicitacaoDespacho': 'teste df',
'idUsuarioSolicitacaoDespacho': 29,
'dataSolicitacaoDespacho': '2021-11-04T17:14:15.757',
'dataSolicitacaoDespachoFormat': '04/11/2021',
'prazoResposta': '2021-11-04T00:00:00',
'prazoRespostaFormat': '04/11/2021',
'protocoloEdocs': '2021-RL6M2C',
'idEncaminhamento': '1e34120b-0ece-4ea7-89ea-102ebe665eee',
'idAgenteDestinatario': 7,
'idAgenteResposta': 0,
'dataRespostaDespacho': null,
'dataRespostaDespachoFormat': '',
'idSituacaoDespacho': '1',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuarioSolicitacaoDespacho': {
'orgao': null,
'pessoa': null
},
'agenteDestinatario': null,
'agenteResposta': null,
'situacaoDespacho': null,
'agenteDestinatarioFormat': ''
}
],
'notificacaoManifestacao': [
{
'txtNotificacao': 'teste de notificação\r\nDonec sollicitudin nunc nulla, nec tincidunt felis tristique quis. Vivamus accumsan ex leo. Etiam nec nisl id eros varius fringilla ac ut tellus. Donec bibendum justo massa, id porta augue placerat ut. Nullam sed ex quis dolor maximus scelerisque et in eros. Vivamus in ex auctor, sagittis turpis id, pellentesque ipsum. Nulla maximus metus eget tincidunt tincidunt. Cras in tincidunt massa. Pellentesque ac lacus nunc. Ut et eros maximus mauris cursus laoreet vel ac quam. In molestie felis id pretium venenatis. Pellentesque maximus neque at eros rhoncus rutrum. Fusce urna sem, viverra eu metus nec, volutpat tincidunt sem.',
'dataNotificacao': '2021-09-23T09:42:03.36',
'dataNotificacaoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
}
}
],
'anotacaoManifestacao': [
{
'txtAnotacao': 'teste de anotação\r\nDuis non est nec sapien interdum congue vel sit amet magna. Nulla sed justo nec leo consectetur tempor ac vel dui. Mauris rhoncus consectetur nibh, at luctus elit facilisis quis. In hac habitasse platea dictumst. Mauris urna leo, imperdiet sed risus vel, vulputate condimentum mauris. Donec vulputate, elit eu sagittis pretium, dolor elit pellentesque lorem, vel laoreet lectus dolor et urna. Sed ultrices neque vitae lorem tristique, vel consequat risus faucibus. Cras quis ex at sapien tempus rutrum vel a turpis. Curabitur tempus cursus ligula quis interdum. Suspendisse eros nunc, suscipit eu vulputate vitae, bibendum ac velit. Aliquam erat volutpat.',
'dataAnotacao': '2021-09-23T09:42:21.307',
'dataAnotacaoFormat': '23/09/2021',
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
}
}
],
'interpelacaoManifestacao': [
{
'txtInterpelacao': 'teste',
'dataInterpelacao': '2021-04-05T15:23:47.66',
'dataInterpelacaoFormat': '05/04/2021',
'txtRespostaInterpelacao': 'ok',
'orgaoResposta': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuarioResposta': {
'orgao': null,
'pessoa': null
},
'dataRespostaInterpelacao': '2021-04-05T15:30:47.273',
'dataRespostaInterpelacaoFormat': '05/04/2021',
'situacaoInterpelacao': {
'idSituacaoInterpelacao': 2,
'descSituacaoInterpelacao': 'Acatada'
}
},
{
'txtInterpelacao': 'mas pq?',
'dataInterpelacao': '2021-04-05T15:38:58.797',
'dataInterpelacaoFormat': '05/04/2021',
'txtRespostaInterpelacao': 'ta certo',
'orgaoResposta': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuarioResposta': {
'orgao': null,
'pessoa': null
},
'dataRespostaInterpelacao': '2021-04-05T15:44:28.323',
'dataRespostaInterpelacaoFormat': '05/04/2021',
'situacaoInterpelacao': {
'idSituacaoInterpelacao': 2,
'descSituacaoInterpelacao': 'Acatada'
}
}
],
'reclamacaoOmissaoManifestacaoPai': [
{
'dataReclamacaoOmissao': '2020-11-05T12:25:44.457',
'dataReclamacaoOmissaoFormat': '05/11/2020',
'manifestacaoFilha': {
'numProtocolo': '2020110018'
},
'manifestacaoPai': {
'numProtocolo': '2021090001'
}
}
],
'recursoNegativa': [
{
'numeroRecurso': '1',
'txtRecursoNegativa': 'asd asd as dad ',
'dataRecursoNegativa': '2019-06-26T10:25:26.173',
'dataRecursoNegativaFormat': '26/06/2019',
'txtRespostaRecursoNegativa': ' gdfgd gdfg dfg dgdf gd',
'dataRespostaRecursoNegativa': '2019-06-26T10:25:58.987',
'dataRespostaRecursoNegativaFormat': '26/06/2019',
'usuarioResposta': {
'orgao': null,
'pessoa': null
}
},
{
'numeroRecurso': '2',
'txtRecursoNegativa': ' sfds fs fsd fsfs',
'dataRecursoNegativa': '2019-06-26T10:54:30.257',
'dataRecursoNegativaFormat': '26/06/2019',
'txtRespostaRecursoNegativa': ' asd asd as dasd a',
'dataRespostaRecursoNegativa': '2019-07-26T16:29:51.297',
'dataRespostaRecursoNegativaFormat': '26/07/2019',
'usuarioResposta': {
'orgao': null,
'pessoa': null
}
}
],
'desdobramentoManifestacaoManifestacaoPai': [
{
'manifestacaoFilha': {
'numProtocolo': '2019060030'
},
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'dataDesdobramento': '2019-06-26T16:06:39.23',
'dataDesdobramentoFormat': '26/06/2019'
}
],
'historicoManifestacao': [
{
'dataHistorico': '2021-09-23T09:38:09.357',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Triagem'
}
},
{
'dataHistorico': '2021-09-23T09:39:54.86',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 862,
'guidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
'siglaOrgao': 'PRODEST                                           ',
'nomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
'razaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           '
},
'usuario': null,
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Aberta'
}
},
{
'dataHistorico': '2021-09-23T09:40:02.787',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 862,
'guidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
'siglaOrgao': 'PRODEST                                           ',
'nomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
'razaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Em Andamento'
}
},
{
'dataHistorico': '2021-09-23T09:40:53.347',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Devolvida'
}
},
{
'dataHistorico': '2021-09-23T09:41:20.803',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Diligência'
}
},
{
'dataHistorico': '2021-09-23T09:43:47.97',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': null,
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Resposta de Diligência'
}
},
{
'dataHistorico': '2021-09-23T09:44:44.187',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Em Andamento'
}
},
{
'dataHistorico': '2021-09-23T09:46:30.98',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 862,
'guidOrgao': '3ca6ea0e-ca14-46fa-a911-22e616303722',
'siglaOrgao': 'PRODEST                                           ',
'nomeFantasia': 'INST DE TECNOLOGIA DA INF E COMUNIC DO ESP SANTO                                                                                                                                                                                                          ',
'razaoSocial': 'INSTITUTO DE TECNOLOGIA DA INFORMACAO E COMUNICACAO DO ESTADO DO ESPIRITO SANTO                                                                                                                                                                           '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Em Apuração'
}
},
{
'dataHistorico': '2021-09-23T09:46:52.207',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': {
'orgao': null,
'pessoa': {
'nome': 'Caio Miled Rocha Souza',
'cpf': '11886930775',
'email': 'caiomiled@gmail.com',
'cep': '29050925',
'idMunicipio': 320530,
'logradouro': 'Av Teste',
'numero': '400',
'complemento': null,
'bairro': 'JC',
'sexo': 'M',
'sexoFormat': 'Masculino',
'telefone': '27999093297',
'municipio': null
}
},
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Apurada'
}
},
{
'dataHistorico': '2021-09-23T09:47:49.273',
'dataHistoricoFormat': '23/09/2021',
'orgao': {
'idOrgao': 877,
'guidOrgao': 'fe115990-a1c8-45f7-9876-4adfbb99bc1d',
'siglaOrgao': 'SECONT                                            ',
'nomeFantasia': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA                                                                                                                                                                                                          ',
'razaoSocial': 'SECRETARIA DE ESTADO DE CONTROLE E TRANSPARENCIA - SECONT                                                                                                                                                                                                 '
},
'usuario': null,
'situacaoManifestacao': {
'descSituacaoManifestacao': 'Encerrada'
}
}
]
}";
            ManifestacaoViewModel manifestacao = new ManifestacaoViewModel();
            manifestacao = JsonConvert.DeserializeObject<ManifestacaoViewModel>(manifestacaostr);
            return View("ResumoManifestacao", manifestacao);
        }
    }
}