using System.Text.RegularExpressions;


namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        //Aqui, iniciei duas instancias de classe Regex para fim de validação do formato da placa que o usuário inserir no método AdicionarVeiculo
        private Regex placaMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}"); 
        private Regex placaAntiga = new Regex("[a-zA-Z]{3}-[0-9]{4}");
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            //Aqui será feita a comparação da string capturada com os formatos específicos das instancias da classe Regex.
            //Se a placa digitada se encaixar em UM dos dois formatos, será adicionada na lista de veículos com sucesso 
            if (placaMercosul.IsMatch(placa) || placaAntiga.IsMatch(placa)) {
            veiculos.Add(placa);
            } 
            else
            {
                Console.WriteLine("Placa Inválida");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
