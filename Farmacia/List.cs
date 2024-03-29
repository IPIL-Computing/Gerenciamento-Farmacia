using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Farmacia
{
    class List:Database
    {
        public void ListCombobox(ComboBox comboBox)
        {
            using(MySqlConnection con = connection())
            {
                try
                {
                    con.Open();
                    string query = "use farmacia; SELECT nome from categoria";
                    MySqlCommand command = new MySqlCommand(query, con);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        comboBox.Items.Clear();
                        
                        while (reader.Read())
                        {
                            comboBox.Items.Add(reader.GetString("nome"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
                }
            }
        }
        public void See(DataGridView dataGridView)
        {
            using (MySqlConnection con = connection())
            {
                try
                {
                    con.Open();

                    string query = "use farmacia; SELECT m.idmedicamento AS 'Id Medicamento', " +
                                   "m.nomemedicamento AS 'Nome do Medicamento', " +
                                   "c.nome AS 'Categoria', " +
                                   "m.qtdestoque AS 'Quantidade no Estoque', " +
                                   "m.preco AS 'Preço' " +
                                   "FROM medicamento m " +
                                   "INNER JOIN categoria c ON m.categoria = c.id";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, con))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
                }
            }
        }
        public void Add(int idMedicamento, string nomeMedicamento, int categoria, double preco, int qtdEstoque)
        {
            using (MySqlConnection con = connection())
            {
                try
                {
                    con.Open();
                    string query = "use farmacia;INSERT INTO medicamento " +
                                   "VALUES (@idMedicamento, @nomeMedicamento, @categoria, @preco, @qtdEstoque)";
                    
                    using (MySqlCommand command = new MySqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@idMedicamento", idMedicamento);
                        command.Parameters.AddWithValue("@nomeMedicamento", nomeMedicamento);
                        command.Parameters.AddWithValue("@categoria", categoria);
                        command.Parameters.AddWithValue("@preco", preco);
                        command.Parameters.AddWithValue("@qtdEstoque", qtdEstoque);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Medicamento adicionado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Falha ao adicionar o medicamento!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar o medicamento: " + ex.Message);
                }
            }
        }
        public void Search(string stringSearch, DataGridView gridView)
        {
            using (MySqlConnection con = connection())
            {
                string query = @"USE farmacia;
                                SELECT DISTINCT m.idmedicamento, m.nomemedicamento AS Nome, c.categoria
                                FROM medicamento m
                                JOIN categoria c ON m.categoria = c.id
                                WHERE idmedicamento LIKE CONCAT('%', @stringSearch, '%') 
                                OR nomemedicamento LIKE CONCAT('%', @stringSearch, '%') 
                                OR categoria LIKE CONCAT('%', @stringSearch, '%'); ";

                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@stringSearch", stringSearch);
                    con.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable table = new System.Data.DataTable();
                    adapter.Fill(table);
                    gridView.Rows.Clear();

                    if (gridView.Columns.Count == 0)
                    {
                        foreach (System.Data.DataColumn column in table.Columns)
                        {
                            gridView.Columns.Add(column.ColumnName, column.ColumnName);
                        }
                    }

                    foreach (System.Data.DataRow row in table.Rows)
                    {
                        object[] rowData = new object[row.ItemArray.Length + 1];
                        for (int i = 0; i < row.ItemArray.Length; i++)
                        {
                            rowData[i + 1] = row[i];
                        }

                        gridView.Rows.Add(rowData);
                    }
                }
            }
        }
    }
}
