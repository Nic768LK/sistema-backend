namespace ProjetoAPI.Models
{
    public class moto : veiculo
    {

        public moto() 
        {
            QuantidadeRodas = 2;
        }
        public int QuantidadeRodas { get; set; }

        public override void Acelerar()
        {
            InjeçãoCombustivel(1);
        }

        private void InjeçãoCombustivel(int QntCombustivel)
        {
            base.TanqueCombustivel -= QntCombustivel;
        }
    }
}
