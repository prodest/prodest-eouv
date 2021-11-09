using Prodest.EOuv.Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Prodest.EOuv.Dominio.Modelo.Model.AcessoCidadao
{
    public interface IUsuarioLogadoModel
    {
        public Guid? IdExterno { get; set; }
        string Nome { get; }
        string Login { get; }
        int IdUsuarioEouv { get; }
        int IdPerfilEouv { get; }
        int? IdOrgaoEouv { get; }
    }

    public class UsuarioLogadoModel : IUsuarioLogadoModel
    {
        public Guid? IdExterno { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public int IdUsuarioEouv { get; set; }
        public int IdPerfilEouv { get; set; }
        public int? IdOrgaoEouv { get; set; }
        public ICollection<PapelLogadoModel> Papeis { get; set; }

        private ICollection<KeyValuePair<string, string>> permissoes;

        [JsonIgnore]
        public ICollection<KeyValuePair<string, string>> Permissoes
        {
            get
            {
                if (permissoes == null)
                {
                    permissoes = new List<KeyValuePair<string, string>> {
                       // new KeyValuePair<string, string>("apelido", Apelido),
                        new KeyValuePair<string, string>("nome", Nome),
                    };

                    permissoes.Add(new KeyValuePair<string, string>("servidor", "true"));

                    foreach (PapelLogadoModel papel in Papeis)
                    {
                        if (papel.Perfis != null && papel.Perfis.Any())
                        {
                            foreach (PerfilLogadoModel perfil in papel.Perfis)
                            {
                                if (perfil != null)
                                {
                                    permissoes.Add(new KeyValuePair<string, string>("Role", perfil.IdExterno.ToString()));

                                    if (perfil.Recursos != null && perfil.Recursos.Any())
                                    {
                                        foreach (RecursoModel recurso in perfil.Recursos)
                                        {
                                            if (recurso != null)
                                            {
                                                KeyValuePair<string, string> permissaoRecurso = new KeyValuePair<string, string>("Recurso", recurso.IdentificadorExterno.ToString());
                                                permissoes.Add(permissaoRecurso);

                                                if (recurso.Acoes != null && recurso.Acoes.Any())
                                                {
                                                    foreach (AcaoModel acao in recurso.Acoes)
                                                    {
                                                        if (acao != null)
                                                        {
                                                            KeyValuePair<string, string> permissaoRecursoAcao = new KeyValuePair<string, string>($"Acao${recurso.Nome}", acao.IdentificadorExterno.ToString());
                                                            permissoes.Add(permissaoRecursoAcao);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                return permissoes;
            }
        }
    }
}