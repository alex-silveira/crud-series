using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using Microsoft.Data.Sqlite;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        Conexao conn = new Conexao();
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Genero genero, string titulo, int ano, string descricao)
        {
			using (var connection = conn.DbCon())
			{
				var command = connection.CreateCommand();

				command.CommandText =
				@"
                update 
                    Series 
                set 
                    genero = $genero,
                    titulo = $titulo,
                    ano = $ano,
                    descricao = $descricao
                where 
                    id = $id
                ";
                
                command.Parameters.AddWithValue("$id", id);
                command.Parameters.AddWithValue("$genero", genero);
                command.Parameters.AddWithValue("$titulo", titulo);
                command.Parameters.AddWithValue("$ano", ano);
                command.Parameters.AddWithValue("$descricao", descricao);

                command.ExecuteNonQuery();
            }
        }

        public void Exclui(int id)
        {
			using (var connection = conn.DbCon())
			{
				var command = connection.CreateCommand();

				command.CommandText =
				@"
                update 
                    Series 
                set 
                    excluido = true
                where 
                    id = $id
                ";
                
                command.Parameters.AddWithValue("$id", id);
                command.ExecuteNonQuery();
            }
        }

        public void Insere(Genero genero, string titulo, int ano, string descricao, bool excluido)
        {
			using (var connection = conn.DbCon())
			{
				var command = connection.CreateCommand();

				command.CommandText =
				@"
					insert into Series(
							  Genero
							, Titulo
							, Ano
							, Descricao
							, Excluido
						) 
						values(
							  $genero
							, $titulo
							, $ano							
							, $descricao
							, $excluido)
				";

				command.Parameters.AddWithValue("$genero", genero);
				command.Parameters.AddWithValue("$titulo", titulo);
				command.Parameters.AddWithValue("$ano", ano);
				command.Parameters.AddWithValue("$descricao", descricao);
				command.Parameters.AddWithValue("$excluido", excluido);
				command.ExecuteNonQuery();																
			}
        }

        public void Lista()
        {
            Console.WriteLine("Listar séries");

			using (var connection = conn.DbCon())
			{
				var command = connection.CreateCommand();

				command.CommandText =
				@"select id, titulo, excluido from series";
               
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Nenhuma série cadastrada.");
                        return;
                    }

                    while (reader.Read())
                    {
                        var id = reader["id"];
                        var titulo = reader["titulo"];
                        var excluido = reader["excluido"].ToString();
                        
                        bool _excluido = false;

                        if(excluido == "0"){
                            _excluido = false;
                        }
                        else{
                            _excluido = true;
                        }

                        Console.WriteLine("#ID {0}: - {1} {2}", id, titulo, (_excluido ? "*Excluído*" : ""));
                    }
                }
            }
        }

        public int ProximoId()
        {
           return listaSerie.Count;
        }

        public void RetornaPorId(int id)
        {
            Console.WriteLine("Listar séries");
            
			using (var connection = conn.DbCon())
			{
				var command = connection.CreateCommand();

				command.CommandText =
				@"select id, titulo, excluido from series where id = $id";

                command.Parameters.AddWithValue("$id", id);
               
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("Nenhuma série cadastrada.");
                        return;
                    }

                    while (reader.Read())
                    {
                        var _id = reader["id"];
                        var titulo = reader["titulo"];
                        var excluido = reader["excluido"].ToString();
                        
                        bool _excluido = false;

                        if(excluido == "0"){
                            _excluido = false;
                        }
                        else{
                            _excluido = true;
                        }

                        Console.WriteLine("#ID {0}: - {1} {2}", _id, titulo, (_excluido ? "*Excluído*" : ""));
                    }
                }
            }
        }
    }
}