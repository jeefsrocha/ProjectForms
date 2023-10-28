using Newtonsoft.Json;
using System.Net.Http;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI
{
    public class Pessoa
    {
        public  string id { get; protected set; } 
        public string nome { get; protected set; }
        public string senha { get; protected set; }  
        public BigInteger cpf { get; private set; }    
        public BigInteger rg { get; private set; }
        public BigInteger telefone { get; private set; }
        public String email { get; private set; }
        public string refreshtoken { get; protected set; }
        public string cargo { get; protected set; }
        public string token{ get; protected set; }


        public HttpClient httpClient { set; protected get; }
        public Pessoa()
        {
            httpClient = new HttpClient();
        }

        
    }
}
