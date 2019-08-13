namespace StarWarPlanets.Domain.Entidades
{
    public class Planeta: Entidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Clima { get; set; }
        public string Terreno { get; set; }
        public int QtdAparicao { get; set; }

        public override void Validate()
        {
            LimparMensagemValidacao();
            if(string.IsNullOrEmpty(Nome))
            {
                AdicionarCritica("Crítica - Nome deve estar preenchido.");
            }
            if(string.IsNullOrEmpty(Clima))
            {
                AdicionarCritica("Crítica - Clima deve estar preenchido.");
            }

            if (string.IsNullOrEmpty(Terreno))
            {
                AdicionarCritica("Crítica - Terreno deve estar preenchido.");
            }

            if (QtdAparicao < 0)
            {
                AdicionarCritica("Crítica - Quantidade de Aparições não pode ser menor que zero.");
            }
        }
    }
}
