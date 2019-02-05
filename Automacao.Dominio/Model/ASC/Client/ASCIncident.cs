using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Automacao.Domain.Model.ASC.Client
{
    [XmlRoot(ElementName = "codek_parametro_calculo_previsao")]
    public class Codek_parametro_calculo_previsao
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "casetypecode")]
    public class Casetypecode
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_fila_retorno_clienteid")]
    public class Codek_fila_retorno_clienteid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_quantidade_horas_central")]
    public class Codek_quantidade_horas_central
    {
        [XmlAttribute(AttributeName = "formattedvalue")]
        public string Formattedvalue { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_tipo_horas_sla_central")]
    public class Codek_tipo_horas_sla_central
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_cobranca_duplicidade")]
    public class Gcs_cobranca_duplicidade
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_sla_pausa")]
    public class Codek_sla_pausa
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_data_prevista_conclusao_central")]
    public class Codek_data_prevista_conclusao_central
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_criador_portalid")]
    public class Gcs_criador_portalid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_assunto_2_nivelid")]
    public class Codek_assunto_2_nivelid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "ownerid")]
    public class Ownerid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_iniciar_processo")]
    public class Codek_iniciar_processo
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_renovacao_caixa_seguros")]
    public class Gcs_renovacao_caixa_seguros
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_grupo_trabalhoid")]
    public class Codek_grupo_trabalhoid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "statuscode")]
    public class Statuscode
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "createdon")]
    public class Createdon
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_tentou_imprimir_boleto_sol")]
    public class Gcs_tentou_imprimir_boleto_sol
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "modifiedon")]
    public class Modifiedon
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_assunto_1_nivelid")]
    public class Codek_assunto_1_nivelid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_enviar_email_abertura")]
    public class Codek_enviar_email_abertura
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_assunto_3_nivelid")]
    public class Codek_assunto_3_nivelid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_processo_atendimentoid")]
    public class Codek_processo_atendimentoid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_forma_resposta")]
    public class Gcs_forma_resposta
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_data_nascimento")]
    public class Gcs_data_nascimento
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_data_real_conclusao_central")]
    public class Codek_data_real_conclusao_central
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_tipo_sinistro")]
    public class Gcs_tipo_sinistro
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_enviar_email_fechamento")]
    public class Codek_enviar_email_fechamento
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_conta_terceiros")]
    public class Gcs_conta_terceiros
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_alterador_portalid")]
    public class Gcs_alterador_portalid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "modifiedby")]
    public class Modifiedby
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "followupby")]
    public class Followupby
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "createdby")]
    public class Createdby
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "subjectid")]
    public class Subjectid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_contatoid")]
    public class Codek_contatoid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_aviso_exibido_em")]
    public class Codek_aviso_exibido_em
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_acao_conclusao_area")]
    public class Codek_acao_conclusao_area
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_canal_abertura")]
    public class Gcs_canal_abertura
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "statecode")]
    public class Statecode
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_data_inicial_estimada_conclusao_central")]
    public class Codek_data_inicial_estimada_conclusao_central
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "gcs_sexo")]
    public class Gcs_sexo
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "codek_atraso_central")]
    public class Codek_atraso_central
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "customerid")]
    public class Customerid
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "incident")]
    public class Incident
    {
        [XmlElement(ElementName = "codek_parametro_calculo_previsao")]
        public Codek_parametro_calculo_previsao Codek_parametro_calculo_previsao { get; set; }
        [XmlElement(ElementName = "casetypecode")]
        public Casetypecode Casetypecode { get; set; }
        [XmlElement(ElementName = "incidentid")]
        public string Incidentid { get; set; }
        [XmlElement(ElementName = "codek_fila_retorno_clienteid")]
        public Codek_fila_retorno_clienteid Codek_fila_retorno_clienteid { get; set; }
        [XmlElement(ElementName = "gcs_email")]
        public string Gcs_email { get; set; }
        [XmlElement(ElementName = "codek_quantidade_horas_central")]
        public Codek_quantidade_horas_central Codek_quantidade_horas_central { get; set; }
        [XmlElement(ElementName = "gcs_produto")]
        public string Gcs_produto { get; set; }
        [XmlElement(ElementName = "codek_tipo_horas_sla_central")]
        public Codek_tipo_horas_sla_central Codek_tipo_horas_sla_central { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "gcs_cobranca_duplicidade")]
        public Gcs_cobranca_duplicidade Gcs_cobranca_duplicidade { get; set; }
        [XmlElement(ElementName = "codek_sla_pausa")]
        public Codek_sla_pausa Codek_sla_pausa { get; set; }
        [XmlElement(ElementName = "codek_data_prevista_conclusao_central")]
        public Codek_data_prevista_conclusao_central Codek_data_prevista_conclusao_central { get; set; }
        [XmlElement(ElementName = "gcs_end_beneficiario")]
        public string Gcs_end_beneficiario { get; set; }
        [XmlElement(ElementName = "gcs_criador_portalid")]
        public Gcs_criador_portalid Gcs_criador_portalid { get; set; }
        [XmlElement(ElementName = "codek_assunto_2_nivelid")]
        public Codek_assunto_2_nivelid Codek_assunto_2_nivelid { get; set; }
        [XmlElement(ElementName = "ownerid")]
        public Ownerid Ownerid { get; set; }
        [XmlElement(ElementName = "gcs_telefone")]
        public string Gcs_telefone { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "codek_iniciar_processo")]
        public Codek_iniciar_processo Codek_iniciar_processo { get; set; }
        [XmlElement(ElementName = "gcs_renovacao_caixa_seguros")]
        public Gcs_renovacao_caixa_seguros Gcs_renovacao_caixa_seguros { get; set; }
        [XmlElement(ElementName = "codek_grupo_trabalhoid")]
        public Codek_grupo_trabalhoid Codek_grupo_trabalhoid { get; set; }
        [XmlElement(ElementName = "statuscode")]
        public Statuscode Statuscode { get; set; }
        [XmlElement(ElementName = "createdon")]
        public Createdon Createdon { get; set; }
        [XmlElement(ElementName = "gcs_tentou_imprimir_boleto_sol")]
        public Gcs_tentou_imprimir_boleto_sol Gcs_tentou_imprimir_boleto_sol { get; set; }
        [XmlElement(ElementName = "modifiedon")]
        public Modifiedon Modifiedon { get; set; }
        [XmlElement(ElementName = "gcs_nomebeneficiario")]
        public string Gcs_nomebeneficiario { get; set; }
        [XmlElement(ElementName = "codek_assunto_1_nivelid")]
        public Codek_assunto_1_nivelid Codek_assunto_1_nivelid { get; set; }
        [XmlElement(ElementName = "codek_enviar_email_abertura")]
        public Codek_enviar_email_abertura Codek_enviar_email_abertura { get; set; }
        [XmlElement(ElementName = "gcs_parentesco")]
        public string Gcs_parentesco { get; set; }
        [XmlElement(ElementName = "codek_assunto_3_nivelid")]
        public Codek_assunto_3_nivelid Codek_assunto_3_nivelid { get; set; }
        [XmlElement(ElementName = "codek_processo_atendimentoid")]
        public Codek_processo_atendimentoid Codek_processo_atendimentoid { get; set; }
        [XmlElement(ElementName = "gcs_forma_resposta")]
        public Gcs_forma_resposta Gcs_forma_resposta { get; set; }
        [XmlElement(ElementName = "gcs_nome")]
        public string Gcs_nome { get; set; }
        [XmlElement(ElementName = "gcs_data_nascimento")]
        public Gcs_data_nascimento Gcs_data_nascimento { get; set; }
        [XmlElement(ElementName = "codek_data_real_conclusao_central")]
        public Codek_data_real_conclusao_central Codek_data_real_conclusao_central { get; set; }
        [XmlElement(ElementName = "gcs_tipo_sinistro")]
        public Gcs_tipo_sinistro Gcs_tipo_sinistro { get; set; }
        [XmlElement(ElementName = "gcs_data_sinistro")]
        public string Gcs_data_sinistro { get; set; }
        [XmlElement(ElementName = "codek_enviar_email_fechamento")]
        public Codek_enviar_email_fechamento Codek_enviar_email_fechamento { get; set; }
        [XmlElement(ElementName = "gcs_conta_terceiros")]
        public Gcs_conta_terceiros Gcs_conta_terceiros { get; set; }
        [XmlElement(ElementName = "gcs_alterador_portalid")]
        public Gcs_alterador_portalid Gcs_alterador_portalid { get; set; }
        [XmlElement(ElementName = "modifiedby")]
        public Modifiedby Modifiedby { get; set; }
        [XmlElement(ElementName = "ticketnumber")]
        public string Ticketnumber { get; set; }
        [XmlElement(ElementName = "gcs_cpf_beneficiario")]
        public string Gcs_cpf_beneficiario { get; set; }
        [XmlElement(ElementName = "followupby")]
        public Followupby Followupby { get; set; }
        [XmlElement(ElementName = "createdby")]
        public Createdby Createdby { get; set; }
        [XmlElement(ElementName = "subjectid")]
        public Subjectid Subjectid { get; set; }
        [XmlElement(ElementName = "codek_contatoid")]
        public Codek_contatoid Codek_contatoid { get; set; }
        [XmlElement(ElementName = "gcs_cobertura")]
        public string Gcs_cobertura { get; set; }
        [XmlElement(ElementName = "codek_aviso_exibido_em")]
        public Codek_aviso_exibido_em Codek_aviso_exibido_em { get; set; }
        [XmlElement(ElementName = "gcs_cpfcnpjcliente")]
        public string Gcs_cpfcnpjcliente { get; set; }
        [XmlElement(ElementName = "codek_acao_conclusao_area")]
        public Codek_acao_conclusao_area Codek_acao_conclusao_area { get; set; }
        [XmlElement(ElementName = "gcs_canal_abertura")]
        public Gcs_canal_abertura Gcs_canal_abertura { get; set; }
        [XmlElement(ElementName = "statecode")]
        public Statecode Statecode { get; set; }
        [XmlElement(ElementName = "codek_data_inicial_estimada_conclusao_central")]
        public Codek_data_inicial_estimada_conclusao_central Codek_data_inicial_estimada_conclusao_central { get; set; }
        [XmlElement(ElementName = "codek_resposta_cliente")]
        public string Codek_resposta_cliente { get; set; }
        [XmlElement(ElementName = "gcs_certificado")]
        public string Gcs_certificado { get; set; }
        [XmlElement(ElementName = "gcs_sexo")]
        public Gcs_sexo Gcs_sexo { get; set; }
        [XmlElement(ElementName = "codek_atraso_central")]
        public Codek_atraso_central Codek_atraso_central { get; set; }
        [XmlElement(ElementName = "customerid")]
        public Customerid Customerid { get; set; }
    }

}
