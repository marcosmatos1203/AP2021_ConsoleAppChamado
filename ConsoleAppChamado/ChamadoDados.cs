using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChamado
{
    class ChamadoDados
    {
        private string tituloChamdo, descricaoChamado;
        EquipamentoDados equipamento =new EquipamentoDados();
        private DateTime dataAbertura;
        private int idChamado;

        public string TituloChamdo { get => tituloChamdo; set => tituloChamdo = value; }
        public string DescricaoChamado { get => descricaoChamado; set => descricaoChamado = value; }
        internal EquipamentoDados Equipamento { get => equipamento; set => equipamento = value; }
        public DateTime DataAbertura { get => dataAbertura; set => dataAbertura = value; }
        public int IdChamado { get => idChamado; set => idChamado = value; }

        public ChamadoDados(int idChamado, string tituloChamdo, string descricaoChamado, EquipamentoDados equipamento, DateTime dataAbertura)
        {
            this.IdChamado = idChamado;
            this.TituloChamdo = tituloChamdo;
            this.DescricaoChamado = descricaoChamado;
            this.Equipamento = equipamento;
            this.DataAbertura = dataAbertura;
        }
        public ChamadoDados(){}
    }
}
