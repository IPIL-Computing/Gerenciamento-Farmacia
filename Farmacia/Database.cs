using System;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Farmacia
{
    class Database
    {
        public string connectionString = "server=127.0.0.1;uid=root;password=;Sslmode=none";
        public string database = "farmacia";

        public MySqlConnection connection()
        {
            return new MySqlConnection(connectionString);
        }

        public bool DatabaseExiste(string nomeConexao, string nomeDatabase)
        {
            string query = $"SELECT COUNT(*) FROM information_schema.schemata WHERE schema_name = '{nomeDatabase}';";
            using (MySqlConnection con = connection())
            {
                con.Open();
                MySqlCommand command = new MySqlCommand(query, con);
                int cont = Convert.ToInt32(command.ExecuteScalar());
                return cont > 0;
            }
        }

        public void CriarBancoETabela()
        {
            if (!DatabaseExiste(connectionString, database))
            {
                MySqlConnection con = connection();
                try
                {
                    string scriptFile = "../../../dump.sql";
                    string script = File.ReadAllText(scriptFile);

                    using (con)
                    {
                        con.Open();
                        MySqlCommand command = new MySqlCommand(script, con);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Base de dados criada e conectada com sucesso");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + " ");
                    MessageBox.Show(e + " ");
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Dump()
        {
            string arguments = $"--host=127.0.0.1 --user=root --password= --databases {database} --result-file=\"../../../dump\"";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "mysqldump",
                Arguments = arguments,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            try
            {
                // Inicie o processo
                Process process = Process.Start(psi);

                // Espere o término do processo
                process.WaitForExit();

                Console.WriteLine("Backup concluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fazer o backup do banco de dados: " + ex.Message);
            }
        }
    }
}
