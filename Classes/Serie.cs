using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero _genero; 
        private string _titulo; 
        private string _descricao;
        private int _ano;

        private bool _excluido;

        public Genero Genero    
        {
            get => _genero;
            set => _genero = value;
        }

        public string Titulo    
        {
            get => _titulo;
            set => _titulo = value;
        }

        public string Descricao    
        {
            get => _descricao;
            set => _descricao = value;
        }

        public int Ano    
        {
            get => _ano;
            set => _ano = value;
        }

        public bool Excluido    
        {
            get => _excluido;
            set => _excluido = value;
        }       
        //Métodos
        
        public Serie(int id, Genero genero, string titulo, string descricao, int ano, bool excluido){
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = excluido;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
		{
			return this.Excluido;
		}

        public void Excluir()
        {
            this.Excluido = true;
        }
    }

}