using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace API.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly MySqlConnection    connectionDB;
        public FuncionarioRepository(IConfiguration configuration)
        {
            this.connectionDB = new MySqlConnection(configuration.GetConnectionString("Default"));

        }
        public async Task AddFuncionario(Funcionario funcionario)
        {
            MySqlCommand command = new MySqlCommand($"INSERT INTO funcionario (name, age, cpf) VALUES (" +
                $"'{funcionario.Name}', '{funcionario.Age}', '{funcionario.Cpf}')", connectionDB);
            command.CommandType = CommandType.Text;
            await connectionDB.OpenAsync();
            await command.ExecuteNonQueryAsync();
            await connectionDB.CloseAsync();
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionarios()
        {
            List<Funcionario> lstFuncionario = new List<Funcionario>();

            MySqlCommand command = new MySqlCommand("SELECT id, name, age, cpf FROM funcionario", connectionDB);
            command.CommandType = CommandType.Text;
            await connectionDB.OpenAsync();

            MySqlDataReader reader = command.ExecuteReader();

            while( await reader.ReadAsync() )
            {
                lstFuncionario.Add(
                    new Funcionario( (int)reader["id"], 
                                        (string)reader["name"], 
                                        (int)reader["age"], 
                                        (string)reader["cpf"])
                );
            }

            await connectionDB.CloseAsync();
            return lstFuncionario;
        }

        public async Task<Funcionario> GetFuncionarioById(int id)
        {
            Funcionario funcionario = null;
            MySqlCommand command = new MySqlCommand($"SELECT * FROM funcionario WHERE id = {id}", connectionDB);
            command.CommandType = CommandType.Text;

            await connectionDB.OpenAsync();

            MySqlDataReader reader = command.ExecuteReader();

            if( await reader.ReadAsync() )
            {
                funcionario = new Funcionario( (int)reader["id"], 
                                                        (string)reader["name"], 
                                                        (int)reader["age"], 
                                                        (string)reader["cpf"]);
            }
            
            await connectionDB.CloseAsync();
            return funcionario;
        }

        public Task RemoveFuncionario(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateFuncionario(Funcionario funcionario)
        {
            throw new System.NotImplementedException();
        }
    }
}