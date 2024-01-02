using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtualAPI.Models
{
    public class UserModel
    {
        [Key]
        public Guid Id { get; set; }
        
        /*
        [ForeignKey("Company")]
        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }
        */

        public string Email { get; set; }
        public string Name { get; set; }
        public string? LastName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public List<Role> Roles { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //public List<Role> Roles { get; set; } = new List<Role>();



        //public static User RetornaUsuarioByMail(string sMail)
        //{
        //    User cUser = new User();
        //    DB data = new DB();
        //    data.AddParametro("@v_acao", "VERIFICA_EXISTENCIA");
        //    data.AddParametro("@v_Email", sMail);

        //    DataSet ds = data.ExecuteReaderDS("sp_edit_usuario");
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        cUser.idUser = row["id_User"].ToString();
        //        cUser.idEmpresa = row["id_Empresa"].ToString();
        //        cUser.sApelido = row["Apelido"].ToString();
        //        cUser.sNome = row["Nome"].ToString();
        //        cUser.sSobrenome = row["Sobrenome"].ToString();
        //        cUser.sPerfil = row["id_Perfil"].ToString();
        //        cUser.sStatus = row["estatus"].ToString();
        //    }

        //    return cUser;
        //}

        //public static User RegistraUser(User cUser)
        //{

        //    MD5 md5Hash = MD5.Create();
        //    cUser.sSenha = clPermissoes.GetMd5Hash(md5Hash, cUser.sSenha);

        //    DB data = new DB();
        //    data.AddParametro("@v_acao", "REGISTRA_USUARIO_OG1");
        //    data.AddParametro("@v_Nome", cUser.sNome);
        //    data.AddParametro("@v_Sobrenome", cUser.sSobrenome);
        //    data.AddParametro("@v_Email", cUser.sMail);
        //    data.AddParametro("@v_Apelido", cUser.sApelido);
        //    data.AddParametro("@v_Senha", cUser.sSenha);

        //    DataSet ds = data.ExecuteReaderDS("sp_edit_usuario");
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        cUser.idUser = row["id_User"].ToString();
        //    }

        //    return cUser;
        //}

        //public static User AtualizaUser(User cUser)
        //{
        //    DB data = new DB();
        //    data.AddParametro("@v_acao", "ATUALIZA_USER");
        //    data.AddParametro("@v_Empresa", cUser.idEmpresa);
        //    data.AddParametro("@v_Nome", cUser.sNome);
        //    data.AddParametro("@v_Perfil", cUser.sPerfil);
        //    data.AddParametro("@v_Sobrenome", cUser.sSobrenome);
        //    data.AddParametro("@v_Email", cUser.sMail);
        //    data.AddParametro("@v_Apelido", cUser.sApelido);
        //    data.AddParametro("@v_Senha", cUser.sSenha);
        //    data.AddParametro("@v_id", cUser.idUser);

        //    DataSet ds = data.ExecuteReaderDS("sp_edit_usuario");
        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        cUser.idEmpresa = row["id_Empresa"].ToString();
        //    }

        //    return cUser;
        //}

        //public static bool ExistUser(string sEMail)
        //{

        //    bool bRetorno = false;

        //    DB data = new DB();
        //    data.AddParametro("@v_acao", "VERIFICA_EXISTENCIA");

        //    data.AddParametro("@v_Email", sEMail);


        //    DataSet ds = data.ExecuteReaderDS("sp_edit_usuario");

        //    foreach (DataRow row in ds.Tables[0].Rows)
        //    {
        //        bRetorno = true;
        //    }

        //    return bRetorno;
        //}


    }
}
