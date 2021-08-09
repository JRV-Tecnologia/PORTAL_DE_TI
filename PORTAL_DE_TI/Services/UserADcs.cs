using System;
using System.DirectoryServices;
using System.Linq;
using PORTAL_DE_TI.Models;
using System.Threading.Tasks;

namespace PORTAL_DE_TI.Services
{
    public class UserADcs
    {
        public ResultUserAD getName(string loginRede)
        {
            ResultUserAD res = new ResultUserAD();
             

            try
            {
                res.login = System.Security.Principal.WindowsIdentity.GetCurrent().Name;//teste
                //res.login = loginRede;//producao
                string login = res.login.Substring(res.login.IndexOf("\\") + 1);
                string path = "LDAP://DC=redecorp,DC=br";
                DirectoryEntry entry = new DirectoryEntry(path);
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = string.Format("(&(objectClass=user)(anr={0}*))", login);
                // especifica campos para retornar
                search.PropertiesToLoad.Add("displayName");
                search.PropertiesToLoad.Add("employeeID");
                // pesquisa
                SearchResult result = search.FindOne();

                if (result != null)
                {
                    DirectoryEntry user = result.GetDirectoryEntry();
                    res.nomeCompleto = user.Properties["displayName"].Value.ToString();
                    res.nome = res.nomeCompleto.Split(" ").First();
                    res.encontrado = true;
                    res.matricula = user.Properties["employeeID"].Value.ToString();
                    res.mail = user.Properties["mail"].Value.ToString();
                    return res;
                }
                else
                {
                    res.encontrado = false;
                    return res;
                }
            }
            catch (Exception e)
            {
                res.erro = true;
                res.message = e.ToString();
                return res;
            }
        }

        public UsuarioDB BuscaIdUsuario(UserResolverService _log)
        {
            //UsuarioDatas objUsuarioDatas = new UsuarioDatas();
            string username = _log.GetUser();
            UsuarioDB infoUsuario = new UsuarioDB();

            ResultUserAD infoAD = new ResultUserAD();

            infoAD = getName(username);

            if (infoAD.matricula != null)
            {
                //infoUsuario = objUsuarioDatas.localizaUsuario(infoAD.matricula);
            }

            infoUsuario.Matricula = infoAD.matricula;
            infoUsuario.Login = infoAD.login;
            infoUsuario.Nome = infoAD.nome;
            infoUsuario.NomeCompleto = infoAD.nomeCompleto;

            return infoUsuario;
        }
    }

}