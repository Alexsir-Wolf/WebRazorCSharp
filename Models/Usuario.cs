﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebRazorCSharp.Models
{
    public class Usuario
    {
        //CONEXÃO COM BANCO DE DADOS
        private readonly static string _connection = @"Data Source=(localdb)\MSSQLLocalDB;
            Initial Catalog = AgenciaAuto; Integrated Security = True; 
        Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string email, string nome, string senha)
        {
            Id = id;
            Email = email;
            Nome = nome;
            Senha = senha;
        }

        public bool Login()
        {
            var result = false;
            var sql = "SELECT id, NOME, SENHA FROM USUARIOS WHERE EMAIL = '" + this.Email + "'";

            try
            {
                using (var cn = new SqlConnection(_connection))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    if (this.Senha == dr["SENHA"].ToString())
                                    {
                                        this.Id = Convert.ToInt32(dr["ID"]);
                                        this.Nome = dr["NOME"].ToString();
                                        result = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
            return result;
        }




        //SALVAR NOVO USUARIO NO BANCO DE DADOS
        public void Salvar()
        {
            var sql = "INSERT INTO USUARIOS (NOME, EMAIL, SENHA) " +
                     "VALUES (@NOME, @EMAIL, @SENHA)";            
            try
            {
                using (var cn = new SqlConnection(_connection))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@NOME", Nome);
                        cmd.Parameters.AddWithValue("@EMAIL", Email);
                        cmd.Parameters.AddWithValue("@SENHA", Senha);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Falha: " + erro.Message);
            }

        }

    }
}