namespace Jokenpo
{
    public class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(Jogar(new Pedra(), new Tesoura()));
        }

        public static string Jogar(Movimento jogador, Movimento adversario)
        {
            if (jogador.Nome == adversario.Nome) return "Empate";
            return jogador.GanhaDe(adversario) ? "Vitória" : "Derrota";
        }

        public abstract class Movimento
        {
            public abstract string Nome { get; }
            public abstract bool GanhaDe(Movimento outro);
        }

        public class Pedra : Movimento
        {
            public override string Nome => "Pedra";
            public override bool GanhaDe(Movimento outro) => outro is Tesoura;
        }

        public class Papel : Movimento
        {
            public override string Nome => "Papel";
            public override bool GanhaDe(Movimento outro) => outro is Pedra;
        }

        public class Tesoura : Movimento
        {
            public override string Nome => "Tesoura";
            public override bool GanhaDe(Movimento outro) => outro is Papel;
        }
    }
}
