using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Produto.Importacao.DTO
{
    public class ResponseDTO<T> where T : class
    {
        [JsonIgnore]
        [XmlIgnore]
        public int? TotalRecords;

        public ResponseDTO() { }

        public T Results { get; set; }
    }
}
