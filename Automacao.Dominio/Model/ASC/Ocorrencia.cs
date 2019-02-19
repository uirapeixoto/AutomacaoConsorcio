using System;
using System.Collections.Generic;
using System.Text;

namespace Automacao.Domain.Model.ASC
{
    public class Ocorrencia
    {

        public string OID { get; set; }
        public string QueueItemID { get; set; }
        public string Tipo { get; set; }
        public string TipoId { get; set; }
        public string Titulo { get; set; }
        public string Grupo { get; set; }
        public string Email { get; set; }
        public string Cota { get; set; }
        public string NumeroOcorrencia { get; set; }
        public string CriadoPor { get; set; }
        public DateTime? DataPrevistaConclusao { get; set; }
        public string DataPrevistaConclusaoStr { get; set; }
        public DateTime? DataConclusao { get; set; }
        public string DataConclusaoStr { get; set; }
        public DateTime? DataCriacao { get; set; }
        public string DataCriacaoStr { get; set; }
        public string CanalEntrada { get; set; }
        public string ReferenteA { get; set; }
        public string CPFCNPJ { get; set; }
        public string NomeCliente { get; set; }
        public string Status { get; set; }
        public string Fila { get; set; }
        public string StatusAtividade { get; set; }
        public List<Anexo> Anexos { get; set; }
        public bool SinistroOnline { get; set; }
        public ReferenteAEnum EnunReferenteA { get; set; }

        public Ocorrencia()
        {
            Anexos = new List<Anexo>();
        }

        public enum ReferenteAEnum
        {
            Outros = 0,
            Comunicado = 1,
            SinistroOnline = 2,
            Email = 3,
            Indenizacao = 8,
            Reanalise = 6,
            Andamento = 7,
            APoliceEspeficica = 4,
            AlteracaoApoliceEspecifica = 5
        }
    }

}
