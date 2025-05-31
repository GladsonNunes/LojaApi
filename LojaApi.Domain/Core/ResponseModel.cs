namespace LojaApi.Domain
{
    public class ResponseModel<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Dados { get; set; }

        public static ResponseModel<T> Falha(string msg) => new() { Sucesso = false, Mensagem = msg };
        public static ResponseModel<T> Ok(T dados) => new() { Sucesso = true, Dados = dados };
    }


}
