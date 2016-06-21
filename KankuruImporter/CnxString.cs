using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KankuruImporter
{
    class CnxString
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Instance { get; set; }
        //public bool IntegrateSecurity { get; set; }
        public string IntegrateSecurity { get; set; }
        public string User { get; set; }
        public string Psw { get; set; }

        public CnxString(string line)
        {
            Port = 1433;
            string[] col = line.Split(';');
            foreach (string s in col)
            {
                if (s.Contains("server") || s.Contains("data source"))
                {
                    string x = s.Replace("server=", "").Replace("data source=", "");

                    if (x.Contains(@"\"))
                    {
                        Server = x.Substring(0, x.IndexOf(@"\"));
                        Instance = x.Substring(x.IndexOf(@"\") + 1);
                    }
                    else
                    {
                        Server = x;
                        Instance = string.Empty;
                    }
                    if (Server.Contains(","))
                    {
                        int pPort = 1433;
                        int.TryParse(Server.Substring(x.IndexOf(@",") + 1), out pPort);
                        Port = pPort;
                        Server = x.Substring(0, x.IndexOf(@","));
                    }
                }
                if (s.Contains("integrated security"))
                {
                    string x = s.Replace("integrated security=", "");
                    bool isIntegrateSecurity = true;
                    bool.TryParse(x, out isIntegrateSecurity);
                    if (isIntegrateSecurity)
                    {
                        IntegrateSecurity = "1";
                    }
                    else
                    {
                        IntegrateSecurity = "2";
                    }
                }
                if (IntegrateSecurity == "2" && s.Contains("user id"))
                {
                    User = s.Replace("user id=", "");
                }
                if (IntegrateSecurity == "2" && s.Contains("password"))
                {
                    Psw = s.Replace("password=", "");
                }
            }
        }

        public string GenerateScript()
        {
            string script = string.Format(@"IF NOT EXISTS(SELECT * FROM dbo.k_serveur WHERE name = '{0}')
BEGIN
    INSERT INTO dbo.k_serveur (name, ipname, k_groupe_id) values('{0}', '{0}', 0)
    DECLARE @SERVER INT
    SELECT @SERVER = SCOPE_IDENTITY()
    INSERT INTO dbo.k_instances (name, ipport, authmode, authuser, authpsw, k_serveur_id) values('{1}', {2}, {3}, '{4}', '{5}', @SERVER)
END
GO"
                , Server, Instance, Port, IntegrateSecurity, User, Psw);
            return script;
        }
    }
}
