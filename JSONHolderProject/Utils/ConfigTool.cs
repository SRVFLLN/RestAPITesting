using System.Xml;

namespace JSONHolderProject.Utils
{
    public static class ConfigTool
    {
        private static readonly XmlDocument Config = new XmlDocument();

        private const string filename = "Resources/Config.xml";

        public static string GetTagValue(string nodeName)
        {
            try
            {
                Config.Load(filename);
                return Config.SelectSingleNode($"config/{nodeName}").InnerText;
            }
            catch (System.IO.FileNotFoundException)
            {
                return null;
            }
        }
    }
}