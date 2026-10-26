namespace ProjetoAPI.Models
{
    public class carro : veiculo
    {

        public carro() 
        {
            QuantidadeRodas = 4;
        }
        public int QuantidadeRodas { get; set; }

        public override void Acelerar()
        {
            InjeçãoCombustivel(4);
        }
        
        private void InjeçãoCombustivel(int QntCombustivel)
        {
            base.TanqueCombustivel -= QntCombustivel;
        }
    }
}
