using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChamado
{
    class EquipamentoDados
    {
        private string nomeEquipamento, serieEquipamento, nomeFabricante;
        private double precoAquisicao;
        private DateTime dataFabricacao;
        private int idEquipamento = 0;

        public EquipamentoDados(int idEquipamento, string nomeEquipamento, string serieEquipamento, string nomeFabricante, double precoAquisicao, DateTime dataFabricacao)
        {
            this.idEquipamento = idEquipamento;
            this.nomeEquipamento = nomeEquipamento;
            this.serieEquipamento = serieEquipamento;
            this.nomeFabricante = nomeFabricante;
            this.precoAquisicao = precoAquisicao;
            this.dataFabricacao = dataFabricacao;

        }
        public EquipamentoDados(){}

        public string NomeEquipamento { get => nomeEquipamento; set => nomeEquipamento = value; }
        public string SerieEquipamento { get => serieEquipamento; set => serieEquipamento = value; }
        public string NomeFabricante { get => nomeFabricante; set => nomeFabricante = value; }
        public double PrecoAquisicao { get => precoAquisicao; set => precoAquisicao = value; }
        public DateTime DataFabricacao { get => dataFabricacao; set => dataFabricacao = value; }
        public int IdEquipamento { get => idEquipamento; set => idEquipamento = value; }
    }
}
