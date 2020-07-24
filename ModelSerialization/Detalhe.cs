using System.Xml.Serialization;

namespace LerXML.ModelSerialization
{
    public class Detalhe
    {

        [XmlAttribute("nItem")]
        public int nItem { get; set; }

        [XmlElement("prod")]
        public Produto Produto { get; set; }


    }
}
