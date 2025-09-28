namespace Jokenpo
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Jogar(new Mao(), new Pedra()));      // Vitória
            Console.WriteLine(Jogar(new Mao(), new Pistola()));    // Derrota
            Console.WriteLine(Jogar(new Pistola(), new Tesoura())); // Vitória
            Console.WriteLine(Jogar(new Pistola(), new Mao()));    // Derrota
            Console.WriteLine(Jogar(new Tesoura(), new Pedra()));  // Derrota
            Console.WriteLine(Jogar(new Papel(), new Pedra()));    // Vitória
        }

        public static string Jogar(Movimento jogador, Movimento adversario)
        {
            if (jogador.Nome == adversario.Nome) return "Empate";
            return Regras.GanhaDe(jogador, adversario) ? "Vitória" : "Derrota";
        }
    }

    public abstract class Movimento
    {
        public abstract string Nome { get; }
    }

    public class Pedra : Movimento { public override string Nome => "Pedra"; }
    public class Papel : Movimento { public override string Nome => "Papel"; }
    public class Tesoura : Movimento { public override string Nome => "Tesoura"; }
    public class Mao : Movimento { public override string Nome => "Mão"; }
    public class Pistola : Movimento { public override string Nome => "Pistola"; }

    public static class Regras
    {
        private static readonly Dictionary<Type, HashSet<Type>> vitorias = new()
    {
        { typeof(Pedra), new HashSet<Type>{ typeof(Tesoura) } },
        { typeof(Papel), new HashSet<Type>{ typeof(Pedra) } },
        { typeof(Tesoura), new HashSet<Type>{ typeof(Papel) } },
        { typeof(Mao), new HashSet<Type>{ typeof(Pedra), typeof(Tesoura), typeof(Papel) } },
        { typeof(Pistola), new HashSet<Type>{ typeof(Pedra), typeof(Tesoura), typeof(Papel) } }
    };

        public static bool GanhaDe(Movimento jogador, Movimento adversario)
        {
            return vitorias.ContainsKey(jogador.GetType()) &&
                   vitorias[jogador.GetType()].Contains(adversario.GetType());
        }
    }
}