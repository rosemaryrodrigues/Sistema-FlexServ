using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace ProjetoFlexservTeste
{
    class Banco
    {
        private static OleDbConnection conexao;

        private static OleDbConnection ConexaoBanco()
        {
            conexao = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Rose\\Documents\\ProjetoFlexservAtualizado\\EmpresaFlex.mdb");
            conexao.Open();
            return conexao;    
        }
        public static DataTable ObterTodosUsuarios()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
               var vcon = ConexaoBanco();
               var cmd = vcon.CreateCommand();                
               cmd.CommandText = "SELECT *FROM Usuario";
               da = new OleDbDataAdapter(cmd.CommandText, vcon);
               da.Fill(dt);
               vcon.Close();
               return dt;               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObterTodosClientes()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT *FROM Clientes";
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public static DataTable ObterTodosFrete()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT *FROM Frete";
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public static DataTable ObterTodosColeta()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT *FROM Coleta";
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       

        public static DataTable ObterTodosFuncioario()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT *FROM Funcionario";
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObterTodosVeiculos()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT *FROM Veiculo";
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObterTodosEntrega()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT *FROM Entrega";
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static DataTable consulta(string sql)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();                
                cmd.CommandText = sql;
                da = new OleDbDataAdapter(cmd.CommandText,vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable consultaFrete(string f)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = f;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable consultaCliente(string sql)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FUNÇOES DO FORM F_GestaoUsuario
        public static DataTable ObterUsuariosIdNome()
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT Código,Nome,Username,Senha,Status,Nivel FROM  Usuario";
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObterDadosUsuario(string id)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM  Usuario WHERE Código="+id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable ObterDadosFrete(string id)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM  Frete WHERE Código=" + id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public static void AtualizarUsuario(Usuario u)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE Usuario SET Nome='"+u.nome+ "',Username='" + u.username + "',Senha='" + u.senha + "',Status='" + u.status + "',Nivel="+u.nivel+" WHERE Código="+u.id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DeletarUsuario(string id)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = " DELETE FROM Usuario WHERE Código=" +id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FIM DAS FUNÇÕES GESTAO USUARIO


        ////FUNÇOES DO FROM F_NovoUsuario
        public static void NovoUsuario(Usuario u)
        {
            if (existeUsername(u)) 
            {
                MessageBox.Show("Usuario já existe");
                return;

            }
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO Usuario(Nome,Username, Senha,Status,Nivel) VALUES(@nome,@username,@senha,@status,@nivel)";
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@senha", u.senha);
                cmd.Parameters.AddWithValue("@status", u.status);
                cmd.Parameters.AddWithValue("@nivel", u.nivel);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo Usuário Inserido");
                vcon.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Erro ao Gravar novo usuário");               
            }
                       
        }


        //FIM DAS FUNÇÕES GESTAO USUARIO
        ////ROTINA GERAIS
        public static bool existeUsername(Usuario u)
        {
            bool res;
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT Username FROM Usuario WHERE Username='"+u.username+"'";
            da = new OleDbDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            vcon.Close();
            return res;
        }

        ////FUNÇOES DO FROM F_CadCliente

        public static void NovoCliente(Cliente u)
        {
            if (existeCliente(u))
            {
                MessageBox.Show("Cliente  já existe");
                return;

            }
            if (string.IsNullOrEmpty(u.nome))
            {
                MessageBox.Show("Preencha o nome");
                return;
            }
           
            try

            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO Cliente(Nome,CpfCnpj, DataNasc,Telefone,Email,Endereço,Cep,Numero,Bairro,Cidade) VALUES(@nome,@cpfcnpj,@datanasc,@telefone,@email,@endereco,@cep,@numero,@bairro,@cidade)";
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@cpfcnpj", u.cpfcnpj);
                cmd.Parameters.AddWithValue("@datanasc", u.datanasc);
                cmd.Parameters.AddWithValue("@telefone", u.telefone);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@endereco", u.endereco);
                cmd.Parameters.AddWithValue("@cep", u.cep);
                cmd.Parameters.AddWithValue("@numero", u.numero);
                cmd.Parameters.AddWithValue("@bairro", u.bairro);
                cmd.Parameters.AddWithValue("@cidade", u.cidade);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo Cliente cadastrado");
                vcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro ao Gravar novo Cliente"+ex.Message);
            }

        }
        //FIM DAS FUNÇÕES Cadastro Cliente
        ////ROTINA GERAIS Cliente

        public static bool existeCliente(Cliente u)
        {
            bool res;
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT CpfCnpj FROM Cliente WHERE CpfCnpj='" + u.cpfcnpj + "'";
            da = new OleDbDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            vcon.Close();
            return res;
        }


        public static void AtualizarCliente(Cliente u)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE Cliente SET Nome='" + u.nome + "',CpfCnpj='" + u.cpfcnpj + "',DataNasc='" + u.datanasc +"',Telefone='" + u.telefone +"',Email='" + u.email + "',Endereço='" + u.endereco + "',Cep='" + u.cep + "',Numero='" + u.numero + "',Bairro='" + u.bairro + "',Cidade='" + u.cidade + "' WHERE Código=" + u.id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alterado com sucesso!");
                vcon.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         public static void DeletarCliente(string id)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = " DELETE FROM Cliente WHERE Código=" +id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FIM DAS FUNÇÕES Cliente
        ////FUNÇOES DO FROM F_ConsVeiculo
        public static void DeletarVeiculo(string id)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = " DELETE FROM Veiculo WHERE Código=" + id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AtualizarVeiculo(Veiculo u)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE Veiculo SET Dono='" + u.dono + "',Motorista='" + u.motorista + "',IdFuncionario='" + u.IdFuncionario + "' WHERE Código=" + u.id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alterado com sucesso!");
                vcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar: " + ex.Message);
            }
        }

        ////FIM DAS FUNÇÕES F_ConsVeiculo
        /// ////FUNÇOES DO FROM F_NovoVeiculo
        public static void NovoVeiculo(Veiculo u)
        {

            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO Veiculo(Tipo,Modelo, Placa,Ano,Dono,Motorista,IdFuncionario) VALUES(@tipo,@modelo,@placa,@ano,@dono,@motorista,@idfuncionario)";
                cmd.Parameters.AddWithValue("@tipo", u.tipo);
                cmd.Parameters.AddWithValue("@modelo", u.modelo);
                cmd.Parameters.AddWithValue("@placa", u.placa);
                cmd.Parameters.AddWithValue("@ano", u.ano);
                cmd.Parameters.AddWithValue("@dono", u.dono);
                cmd.Parameters.AddWithValue("@motorista", u.motorista);
                cmd.Parameters.AddWithValue("@idfuncionario", u.IdFuncionario);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo Veículo cadastrado");
                vcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro ao Gravar novo veículo" + ex.Message);
            }

        }

        ///  ////FIM DAS FUNÇÕES F_NovoVeiculo
        ///  ////FUNÇOES DO FROM F_RealizarEntrega
       
        public static void AtualizarEntrega(Frete u)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE Frete SET IdVeiculo='" + u.Idveiculo + "',Hora_Coleta='" + u.horac + "',Hora_Entrega='" + u.horae + "' WHERE Código=" + u.id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();                
                vcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao alterar: " + ex.Message);
            }
        }
        ///  ////FIM DAS FUNÇÕES F_RealizarEntrega

        ////FUNÇOES DO FROM F_CadFrete
        public static void NovoFrete(Frete f)
        {


            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO Frete(Data,Hora, QtdTotal,TipoVeiculo,Valor,CpfCnpj,Produto) VALUES(@data,@hora,@qtdtotal,@tipoveiculo,@valor,@cpfcnpj,@produto)";
                cmd.Parameters.AddWithValue("@data", f.data);
                cmd.Parameters.AddWithValue("@hora", f.hora);
                cmd.Parameters.AddWithValue("@qtdtotal", f.qtdtotal);
                cmd.Parameters.AddWithValue("@tipoveiculo", f.tipoveiculo);
                cmd.Parameters.AddWithValue("@valor", f.valor);
                cmd.Parameters.AddWithValue("@cpfcnpj", f.cpfcnpj);
                cmd.Parameters.AddWithValue("@produto", f.produto);
                cmd.ExecuteNonQuery();               
                vcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erro ao Gravar novo frete");
            }

        }
        public static void NovoColeta(Coleta c)
        {
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO Coleta(Endereço, Cep, Numero, Bairro, Cidade, Qtd,IdFrete) VALUES(@endereco, @cep, @numero, @bairro, @cidade, @qtd,@idfrete)";
                cmd.Parameters.AddWithValue("@endereco", c.endereco);
                cmd.Parameters.AddWithValue("@cep", c.cep);
                cmd.Parameters.AddWithValue("@numero", c.numero);
                cmd.Parameters.AddWithValue("@bairro", c.bairro);
                cmd.Parameters.AddWithValue("@cidade", c.cidade);
                cmd.Parameters.AddWithValue("@qtd", c.qtd);
                cmd.Parameters.AddWithValue("@idfrete", c.idfrete);                
                cmd.ExecuteNonQuery();               
                vcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar coleta: " + ex.Message);
            }
        }
      
        public static void NovoEntrega(Entrega e)
        {
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO Entrega(Destinatario, Endereço, Cep, Numero, Bairro, Cidade,IdFrete) VALUES(@destinatario, @endereco, @cep, @numero, @bairro, @cidade,@idfrete)";
                cmd.Parameters.AddWithValue("@destinatario", e.destinatario);
                cmd.Parameters.AddWithValue("@endereco", e.endereco);
                cmd.Parameters.AddWithValue("@cep", e.cep);
                cmd.Parameters.AddWithValue("@numero", e.numero);
                cmd.Parameters.AddWithValue("@bairro", e.bairro);
                cmd.Parameters.AddWithValue("@cidade", e.cidade);
                cmd.Parameters.AddWithValue("@idfrete", e.idfrete);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Frete resgistrado  com sucesso!");
                vcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar entrega: " + ex.Message);
            }
        }
      

        //FIM DAS FUNÇÕES Frete
        ////FUNÇOES DO FROM F_CadFuncionario

        public static void NovoFuncionario(Funcionario u)
        {
           
            try
            {
                if (existeFuncionario(u))
                {
                    MessageBox.Show("Funcionário já existe");
                    return;
                }

                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "INSERT INTO Funcionario(Nome,CPF, DataNasc,Telefone,Email,Cargo,Endereço,Cep,Numero,Bairro,Cidade,Salario) VALUES(@nome,@cpf,@datanasc,@telefone,@email,@cargo,@endereco,@cep,@numero,@bairro,@cidade,@salario)";
                cmd.Parameters.AddWithValue("@nome", u.nome);
                cmd.Parameters.AddWithValue("@cpf", u.cpf);
                cmd.Parameters.AddWithValue("@datanasc", u.datanasc);
                cmd.Parameters.AddWithValue("@telefone", u.telefone);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@cargo", u.cargo);
                cmd.Parameters.AddWithValue("@endereco", u.endereco);
                cmd.Parameters.AddWithValue("@cep", u.cep);
                cmd.Parameters.AddWithValue("@numero", u.numero);
                cmd.Parameters.AddWithValue("@bairro", u.bairro);
                cmd.Parameters.AddWithValue("@cidade", u.cidade);
                cmd.Parameters.AddWithValue("@salario", u.salario);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Novo funcionário cadastrado com sucesso");
                vcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar novo funcionário: " + ex.Message);
            }
        
    }
        //FIM DAS FUNÇÕES Cadastro Funcionario
        ////ROTINA GERAIS Funcionario

        public static bool existeFuncionario(Funcionario u)
        {
            bool res;
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();

            var vcon = ConexaoBanco();
            var cmd = vcon.CreateCommand();
            cmd.CommandText = "SELECT Cpf FROM Funcionario WHERE CPF='" + u.cpf + "'";
            da = new OleDbDataAdapter(cmd.CommandText, vcon);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                res = true;
            }
            else
            {
                res = false;
            }

            vcon.Close();
            return res;
        }


        public static void AtualizarFuncionario(Funcionario u)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = "UPDATE Funcionario SET Nome='" + u.nome + "',CPF='" + u.cpf + "',DataNasc='" + u.datanasc + "',Telefone='" + u.telefone + "',Email='" + u.email + "',Cargo='" + u.cargo + "',Endereço='" + u.endereco + "',Cep='" + u.cep + "',Numero='" + u.numero + "',Bairro='" + u.bairro + "',Cidade='" + u.cidade + "',Salario='" + u.salario +  "' WHERE Código=" + u.id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Alterado com sucesso!");
                vcon.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeletarFuncionario(string id)
        {
            OleDbDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = " DELETE FROM Funcionario WHERE Código=" + id;
                da = new OleDbDataAdapter(cmd.CommandText, vcon);
                cmd.ExecuteNonQuery();
                vcon.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FIM DAS FUNÇÕES Funcionario







    }
}
      