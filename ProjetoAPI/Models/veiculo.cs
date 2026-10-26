namespace ProjetoAPI.Models
{
    public class veiculo
    {
        public veiculo()
        {
            TanqueCombustivel = 40;
        }
        
        
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public int TanqueCombustivel { get; set; }

        public virtual void Acelerar()
        {
            InjeçãoCombustivel(2);
        }

        public void Frear()
        {

        }

        private void InjeçãoCombustivel(int QntCombustivel)
        {
            TanqueCombustivel -= QntCombustivel;
        }
        

    }
}
