using System;

namespace Dio.Series
{
    public class Serie : EntidadeBase
    {
        private string entradaDescricao;

        private Genero Genero{get; set ;}

        private string Titulo {get; set ;}

        private string Descricao {get; set ;}

        private int Ano {get; set ;}

        private bool Excluido{get; set;}

        public Serie ( int Id, Genero genero,string Titulo,string Descricao,int Ano, bool Excluido)
        {
                this.Id=Id;
                this.Genero=Genero;
                this.Titulo= Titulo;
                this.Descricao=Descricao;
                this.Ano=Ano;
                this.Excluido =false;
        }

        

        public Serie (int Id, Genero genero, string Titulo, int Ano, string Descricao)
        {
            this.Id = Id;
            Genero = genero;
            this.Titulo = Titulo;
            this.Ano = Ano;
            this.Descricao = Descricao;
        }


        public override string ToString()
        {
            string retorno ="";
            retorno+= "Gênero " +this.Genero+ Environment.NewLine;
            retorno+= "Titulo " +this.Titulo+ Environment.NewLine;
            retorno+= "Descricao " +this.Descricao+ Environment.NewLine;
            retorno+= "Ano de Inicio " +this.Ano+ Environment.NewLine;
            retorno+= " Excluido" +this.Excluido;
            return retorno;
        }

        public string retornaTitulo(){

            return this.Titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public void Excluir(){
            this.Excluido=true;
        }

        public bool retornaExcluido()
		{
			return this.Excluido;
		}
    }
}