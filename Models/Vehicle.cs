using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.ComponentModel.DataAnnotations;
using WebRazorCSharp.Models.Enuns;

namespace WebRazorCSharp.Models
{
    public class Vehicle
    {
        //CONNECTION STRING
        private readonly static string _connection = WebConfigurationManager.ConnectionStrings
            ["connect"].ConnectionString;

        public int Id { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name { get; set; }

        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Model { get; set; }


        [Required(ErrorMessage = "Campo obrigatório.")]
        public short Year { get; set; }

        [Display(Name = "Ano de Fabricação")]
        [Range (1950, 2022, ErrorMessage = "Ano deve estar entre {1} e {2}")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public short Manufacturing { get; set; }

        [Display(Name = "Cor")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Color { get; set; }

        [Display(Name = "Combustível")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public Fuel Fuel { get; set; }

        [Display(Name = "Transmissão")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Transmission { get; set; }

        [Range(0.01, 999999999.99, ErrorMessage = "O valor não pode ser menor que {1}")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Valor { get; set; }


       [Required(ErrorMessage = "Campo obrigatório.")]
        public bool Active { get; set; }

        public Vehicle()
        {
        }
        public Vehicle(int id, string name, string model, short year, short manufacturing, string color, Fuel fuel, int transmission, decimal valor, bool active)
        {
            Id = id;
            Name = name;
            Model = model;
            Year = year;
            Manufacturing = manufacturing;
            Color = color;
            Fuel = fuel;
            Transmission = transmission;
            Valor = valor;
            Active = active;
        }

        public static List<Vehicle> GetCars()
        {
            var listaCarros = new List<Vehicle>();
            var sql = "SELECT * FROM tb_Veiculos";

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
                                while (dr.Read())
                                {
                                    listaCarros.Add(new Vehicle(
                                        Convert.ToInt32(dr["Id"]),
                                        dr["Nome"].ToString(),
                                        dr["Modelo"].ToString(),
                                        Convert.ToInt16(dr["Ano"]),
                                        Convert.ToInt16(dr["Fabricacao"]),
                                        dr["Cor"].ToString(),
                                        (Fuel)Convert.ToByte(dr["Combustivel"]),
                                        Convert.ToInt16(dr["Automatico"]),
                                        Convert.ToDecimal(dr["Valor"]),
                                        Convert.ToBoolean(dr["Ativo"])
                                        ));
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("Falha: " + err.Message);
            }
            return listaCarros;
        }


        //SALVAR NOVO VEICULO NO BANCO DE DADOS
        public void Save()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO tb_Veiculos (nome, modelo, ano, fabricacao, cor, combustivel, automatico, valor, ativo) " +
                     "VALUES (@nome, @modelo, @ano, @fabricacao, @cor, @combustivel, @automatico, @valor, @ativo)";
            }
            else
            {
                sql = @"UPDATE tb_Veiculos SET nome=@nome, modelo=@modelo, ano=@ano, fabricacao=@fabricacao, cor=@cor, combustivel=@combustivel, automatico=@automatico, valor=@valor, ativo=@ativo WHERE id=" + Id;
            }

            try
            {
                using (var cn = new SqlConnection(_connection))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@nome", Name);
                        cmd.Parameters.AddWithValue("@Modelo", Model);
                        cmd.Parameters.AddWithValue("@ano", Manufacturing);
                        cmd.Parameters.AddWithValue("@fabricacao", Manufacturing);
                        cmd.Parameters.AddWithValue("@cor", Color);
                        cmd.Parameters.AddWithValue("@combustivel", Fuel);
                        cmd.Parameters.AddWithValue("@automatico", Transmission);
                        cmd.Parameters.AddWithValue("@valor", Valor);
                        cmd.Parameters.AddWithValue("@ativo", Active);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Falha: " + erro.Message);
            }

        }

        // DELETAR VEICULO NO BANCO DE DADOS
        public void Delete()
        {
            var sql = "DELETE FROM tb_Veiculos WHERE id=" + Id;

            try
            {
                using (var cn = new SqlConnection(_connection))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception erro)
            {
                Console.WriteLine("Falha " + erro.Message);
            }

        }



        // RETORNA DADOS NA PAGINA DE EDIÇÃO
        public void GetVehicle(int id)
        {
            var sql = "SELECT nome, modelo, ano, fabricacao, cor, combustivel, automatico, " +
                "valor, ativo FROM tb_Veiculos WHERE id=" + id;

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
                                    Id = id;
                                    Name = dr["nome"].ToString();
                                    Model = dr["modelo"].ToString();
                                    Year = Convert.ToInt16(dr["ano"]);
                                    Manufacturing = Convert.ToInt16(dr["fabricacao"]);
                                    Color = dr["cor"].ToString();
                                    Fuel = (Fuel)Convert.ToByte(dr["combustivel"]);
                                    Transmission = Convert.ToInt16(dr["automatico"]);
                                    Valor = Convert.ToDecimal(dr["valor"]);
                                    Active = Convert.ToBoolean(dr["ativo"]);

                                }
                            }
                        }
                    }
                }
            }
            catch(Exception erro)
            {
                Name = "Falha: " + erro.Message;
                Console.WriteLine("Falha: " + erro.Message);
            }
        }

    }
}