
namespace TDE
{
	public class Program
	{
        static FilaDinamica filaPrefencial;
        static FilaDinamica filaComum; 

        static int proximaSenhaPrefencial;
        static int proximaSenhaComum;
        static No<string> SenhaAtualPreferencial;
        static No<string> SenhaAtualComum;



        static void Main(string[] args)
        {
            filaPrefencial = new FilaDinamica();
            filaComum = new FilaDinamica();
            proximaSenhaComum = 1;
            proximaSenhaPrefencial = 1;
            SenhaAtualPreferencial = null;
            SenhaAtualComum = null;
            Menu();
        }

        static void PrintarMenu(){
            Console.WriteLine("**********************************");
            Console.WriteLine("* Bem vindo ao TDE de Filas!     *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("* 1 - Gerar Senha Preferencial   *");
            Console.WriteLine("* 2 - Gerar Senha Comum          *");
            Console.WriteLine("* 3 - Consultar Senhas           *");
            Console.WriteLine("* 4 - Chamar Senha Prefencial    *");
            Console.WriteLine("* 5 - Chamar Senha Comum         *");
            Console.WriteLine("* 9 - Sair                       *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("*                                *");
            Console.WriteLine("**********************************");
        }


        static void Menu(){
            int opcao;
            do
            {
                PrintarMenu();
                Console.Write("Digite a ação desejada: ");
                if(int.TryParse(Console.ReadLine(), out opcao))
                {
                    switch (opcao){
                        case 1:
                            GerarSenhaPreferencial();
                            break;
                        case 2:
                            GerarSenhaComum();
                            break;
                        case 3:
                            ConsultarSenhas();
                            break;
                        case 4:
                            ChamarSenhaPreferencial();
                            break;
                         case 5:
                            ChamarSenhaComum();
                            break;
                        case 9:
                            break;
                        default:
                            Console.WriteLine("Valor inválido! Digite um valor valido");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Valor inválido! Digite um valor valido");
                }

                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();
                Console.Clear();
            } while(opcao != 9);

            Console.WriteLine("Pressione ENTER para sair");
            Console.ReadLine();
        }

        static void GerarSenhaPreferencial(){
            string senhaGerada = $"CXP_{proximaSenhaPrefencial}";
            filaPrefencial.Enfilerar(senhaGerada);
            proximaSenhaPrefencial++;
            Console.WriteLine($"Sua senha é: {senhaGerada}");
        }

        static void GerarSenhaComum(){
            string senhaGerada = $"CXN_{proximaSenhaComum}";
            filaComum.Enfilerar(senhaGerada);
            proximaSenhaComum++;
            Console.WriteLine($"Sua senha é: {senhaGerada}");
        }

        static void ConsultarSenhas(){
            Console.Clear();
            Console.WriteLine("**********************************");
            Console.WriteLine("FILA PREFERENCIAL: ");
            Console.WriteLine($"Senha Atual {SenhaAtualPreferencial?.Valor} - Proxima Senha {filaPrefencial.Inicio?.Valor}");
            Console.WriteLine("FILA COMUM: ");
            Console.WriteLine($"Senha Atual {SenhaAtualComum?.Valor} - Proxima Senha {filaComum?.Inicio?.Valor}");
            Console.WriteLine("**********************************");
        }

        static void ChamarSenhaPreferencial(){
            if(filaPrefencial.EstaVazia()){
                SenhaAtualPreferencial = null;
                Console.Clear();
                Console.WriteLine("Fila está vazia");
                return;
            }

            SenhaAtualPreferencial = filaPrefencial.Desenfilerar();
            Console.Clear();
            Console.WriteLine("**********************************");
            Console.WriteLine($"SENHA PREFENCIAL CHAMADA: {SenhaAtualPreferencial.Valor}");
            Console.WriteLine("**********************************");
        }

        static void ChamarSenhaComum(){
            if(filaComum.EstaVazia()){
                SenhaAtualComum = null;
                Console.Clear();
                Console.WriteLine("Fila está vazia");
                return;
            }
            
            SenhaAtualComum = filaComum.Desenfilerar();
            Console.Clear();
            Console.WriteLine("**********************************");
            Console.WriteLine($"SENHA PREFENCIAL CHAMADA: {SenhaAtualComum.Valor}");
            Console.WriteLine("**********************************");
        }

    }

}

