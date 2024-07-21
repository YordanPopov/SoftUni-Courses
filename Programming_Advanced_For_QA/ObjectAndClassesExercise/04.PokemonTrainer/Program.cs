namespace _04.PokemonTrainer
{
    internal class Program
    {
        public class Trainer
        {
            public string Name { get; set; }

            public int NumberOfBadges { get; set; }

            public List<Pokemon> Pokemons { get; set; }

            public Trainer(string name)
            {
                this.Name = name;
                this.NumberOfBadges = 0;
                this.Pokemons = new List<Pokemon>();
            }
        }

        public class Pokemon
        {
            public string Name { get; set; }

            public string Element {  get; set; }

            public int Health {  get; set; }

            public Pokemon(string name, string element, int health)
            {
                this.Name = name;
                this.Element = element;
                this.Health = health;
            }            
        }
        static void Main(string[] args)
        {
            List<Trainer> trainers = new();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                string trainerName = input.Split()[0];
                string pokemonName = input.Split()[1];
                string pokemonElement = input.Split()[2];
                int health = int.Parse(input.Split()[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, health);

                Trainer trainer = trainers.FirstOrDefault(trainer => trainer.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(pokemon => pokemon.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }

                    trainer.Pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(trainer => trainer.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}