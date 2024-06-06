// See https://aka.ms/new-console-template for more information
Console.WriteLine("Sistema de estacionamento Everton Lima 2024");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Digite o preço inicial: ");
decimal precoInicial = Convert.ToDecimal(Console.ReadLine());
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Agora digite o preço por hora: ");
decimal precoHora = Convert.ToDecimal(Console.ReadLine());
string placa;
int opcao = 0;
List<Estacionamento> veiculoEscacionado = new List<Estacionamento>();
bool validarPlaca()
{
    int l = 0;
    int n = 0;


    for (int i = 0; i < placa.Length; i++)
    {
        if (placa[i].ToString() != "-")
        {

            int number;
            if (int.TryParse(placa[i].ToString(), out number))
            {
                n++;
            }
            else
            {
                l++;
            }
        }
    }
    if (l == 3 && n == 4)
    {
        Console.WriteLine("Placa valida");
        Console.WriteLine("");
        Console.WriteLine("");
        
        return true;
    }
        


    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine($"Placa inválida: {placa} para ser uma placa válida é necessário seguir esse exemplo: ABC-1234");
    Console.WriteLine("Por favor digite qualquer tecla para voltar ao menu");
    Console.ReadLine();
    Console.Clear();
    return false;
}
bool ChecarPlaca()
{
    if (placa == string.Empty)
    {
        Console.WriteLine("Por favor informe uma placa válida com 3 letras e 4 números e separados por -(hífem)");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("ex: ABC-1111");
        Console.ReadLine();
        Console.Clear();
        return false;
    }
    else if (placa.Length < 8)
    {
        Console.WriteLine($"A placa: {placa} está inválida, será necessário seguir o padrão de 3 letras e 4 números separados por -(hifem)");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Exemplo: ABC-1234");
        Console.ReadLine();
        Console.Clear();
        return false;
    }
    else
    {
        return validarPlaca();
    }


}
///<sumary>
///</sumary
void menu()
{
    if (opcao == 0)
    {
        Console.Clear();
        
        Console.WriteLine("Por favor escolha uma das opções abaixo:");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("1- Cadastrar veículo");
        Console.WriteLine("2- Remover veículo");
        Console.WriteLine("3- Listar veículo");
        Console.WriteLine("4- Encerrar");
        Console.WriteLine("");
        Console.WriteLine("Sistema desenvolvido por Everton Lima inovacaointeligentes@gmail.com");
        Console.WriteLine("");

        string opcaoBanco = Console.ReadLine().ToString();
        if (opcaoBanco.Trim() == string.Empty)
        {
            opcao = 4;
        }
        else
        {
            opcao = Convert.ToInt32(opcaoBanco);
        }
        
    }

}

//opcao = Convert.ToInt32(Console.ReadLine().ToString());
while (opcao < 4)
{
    //Console.WriteLine(opcao);
    menu();
    switch (opcao)
    {
        case 1:
            Console.Clear();
            Console.WriteLine("Placa do veiculo: ");
            Console.WriteLine("");
            Console.WriteLine("");
            placa = Console.ReadLine().ToUpper();
            if (ChecarPlaca())
            {
                Console.WriteLine("digite qualquer tela para voltar");
                string voltar = Console.ReadLine();
                Estacionamento s = new Estacionamento();
                s.PlacaVeiculo = placa;
                //s.ValorTotal = precoInicial + precoHora;

                veiculoEscacionado.Add(s);
                if (voltar != "n")
                {
                    opcao = 0;
                }
            } 
            else 
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Placa invalida");
            }
            break;
        case 2:
            Console.Clear();

            if (veiculoEscacionado.Count > 0)
            {
                string opcaoRemover;
                Console.WriteLine("Por favor informe a placa do Veículo: ");
                Console.WriteLine("");
                Console.WriteLine("");
                placa = Console.ReadLine().ToUpper();
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                decimal quatidadeHorasEscationado = Convert.ToDecimal(Console.ReadLine());

                int posicaoVeiculo = veiculoEscacionado.FindIndex(e => e.PlacaVeiculo == placa);
                if (posicaoVeiculo >= 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine($"Tem certeza que deseja remover essse veiculo de placa: {veiculoEscacionado[posicaoVeiculo].PlacaVeiculo} ? s para sim n para não");
                    opcaoRemover = Console.ReadLine();
                    //Console.WriteLine("posicao " + posicaoVeiculo.ToString());
                    //Console.WriteLine(opcaoRemover);
                    if (opcaoRemover.ToLower() == "s")
                    {
                        decimal valorTotalTemp = precoInicial + (precoHora * quatidadeHorasEscationado);
                        veiculoEscacionado.RemoveAt(posicaoVeiculo);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("Veículo Removido com sucesso!!");
                        Console.WriteLine("");
                        Console.WriteLine("E o preço total foi: R$ " + valorTotalTemp);
                        Console.WriteLine("");
                        Console.WriteLine("Por favor aperte qualquer tecla para voltar ao menu!");
                        string opcaoOk = Console.ReadLine();
                        Console.Clear();
                        if (opcaoOk != "n")
                        {
                            opcao = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Não se preoculpe o veiculo de placa " + veiculoEscacionado[posicaoVeiculo].PlacaVeiculo + " não foi removido!");
                        Console.WriteLine("");
                        Console.WriteLine("Por favor aperte qualquer tecla para voltar ao menu!");
                        Console.ReadLine();
                        opcao = 0;
                    }

                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Veículo de placa: {placa} não encontrato");
                    Console.WriteLine("");
                    Console.WriteLine("Deseja tentar novamente aperte s para sim ou qualquer tecla para não");
                    string tempOpcao = Console.ReadLine();
                    if (tempOpcao.ToLower() == "s")
                    {
                        opcao = 2;
                    }
                    else
                    {
                        opcao = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Não existe nenhum veículo estacionado para remover");
                Console.WriteLine("");
                Console.WriteLine("Por favor acione qualquer tecla para continunar e voltar ao menu");
                Console.ReadLine();
                opcao = 0;
            }

            break;
        case 3:
            Console.Clear();
            if (veiculoEscacionado.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("No momento existe essas veiculos estacionados: ");
                foreach (Estacionamento estacionamento in veiculoEscacionado)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Placa: " + estacionamento.PlacaVeiculo);
                }
                Console.WriteLine("");
                Console.WriteLine("por favor aperte qualquer tecla para voltar ao menu");
                Console.ReadLine();

                Console.Clear();
                opcao = 0;

            }
            else
            {

                Console.WriteLine("");
                Console.WriteLine("Não existem veiculos estacionados para exibir no momento");
                Console.WriteLine("");
                Console.WriteLine("Por favor acione qualquer tecla para continunar e voltar ao menu");
                Console.ReadLine();
                opcao = 0;
                //Console.Clear();
            }
            break;
        default:
            Console.WriteLine("");
            Console.WriteLine("Sistema encerrado!");
            break;

    }
}

