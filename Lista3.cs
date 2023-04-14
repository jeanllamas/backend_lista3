using System;

namespace backend_lista3
{
    class Lista3
    {
        static void Main(string[] args)
        {
            int ligado = 1; //"Liga" o programa
            do
            {
                Console.Clear();
                Console.WriteLine("Jean Augusto - Lista 3" + Environment.NewLine);

                for (int i = 1; i <= 6; i++)
                {
                    Console.WriteLine($"{i} - Exercício {i}");
                }
                Console.WriteLine(Environment.NewLine + "Sair - Encerrar programa");
                Console.WriteLine(Environment.NewLine + "Selecione um número para acessar o exercício (Ex.: '4' para exercício 4):");

                var entrada = Console.ReadLine();

                switch (entrada) //Encerra quando o usuário escolher a opção de sair
                {
                    case "sair":
                    case "Sair":
                        ligado = 0; //"Desliga" o programa
                        continue;
                }

                bool checagem = int.TryParse(entrada, out int num_exercicio); /*Retorna verdadeiro se a conversão da entrada para inteiro der certo
                                                                                e move o número correspondente ao exercício para uma int */
                if (checagem)
                {
                    if (num_exercicio >= 1 && num_exercicio <= 6)
                    {
                        Console.Clear();
                        Exercicios(num_exercicio); //Encaminha para o exercício escolhido
                    }
                    else
                    {
                        Console.WriteLine(Environment.NewLine + $"Não há Exercício {num_exercicio}. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "Opção inválida. Tente novamente.");
                }

                //Mensagem para retornar ou encerrar
                Console.WriteLine(Environment.NewLine + "Voltar ao início? (S/N)");
                var voltar = Console.ReadLine();

                switch (voltar)
                {
                    case "S":
                    case "s":
                        continue; //Mantém o programa "ligado"
                    default:
                        ligado = 0; //"Desliga" o programa
                        continue;
                }

            } while (ligado == 1);
        }

        public static int[] LerEntradas(int NumeroDeEntradas)
        {
            int[] entradas = new int[NumeroDeEntradas];

            for (int i = 0; i < NumeroDeEntradas; i++)
            {
                Console.WriteLine("Digite um número:");
                entradas[i] = Convert.ToInt32(Console.ReadLine());
            }

            return entradas;
        }

        public static void ImprimirEntradas(int[] arrayNumeros)
        {
            foreach (int numero in arrayNumeros)
            {
                Console.WriteLine(numero);
            }
        }

        public static int[] GerarEntradas(int NumerosAleatorios)
        {
            Random r = new Random();
            int[] NumerosGerados = new int[NumerosAleatorios];

            for (int i = 0; i < NumerosAleatorios; i++)
            {
                NumerosGerados[i] = r.Next(0, 100);
            }
            return NumerosGerados;            
        }

        static void Exercicios(int escolha)
        {
            switch (escolha)
            {
                case 1: //Exercício 1
                    {                        ;
                        ImprimirEntradas(LerEntradas(10));
                        break;
                    }

                case 2: //Exercício 2
                    {
                        int[] matriculas = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                        Console.WriteLine("Matrículas de Alunos");

                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"Digite o nº da matrícula do aluno {i + 1}:");
                            matriculas[i] = Convert.ToInt32(Console.ReadLine());

                            if (matriculas.Length != matriculas.Distinct().Count())
                            {
                                Console.WriteLine("Essa matrícula já foi inserida!" + Environment.NewLine);
                                i--;
                            }
                        }

                        Console.WriteLine(Environment.NewLine + "===== Matrículas =====");

                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine($"Aluno {i+1} = {matriculas[i]}");
                        }
                        break;
                    }

                case 3: //Exercício 3
                    {
                        Console.Write("Quantidade de números do vetor: ");
                        int quantidade = Convert.ToInt32(Console.ReadLine());
                        int[] vetor = new int[quantidade];

                        Console.Write("Digite um número (999 para parar): ");
                        int i = 0;
                        while (i < quantidade && (vetor[i] = Convert.ToInt32(Console.ReadLine())) != 999)
                        {
                            i++;
                            if (i < quantidade)
                            {
                                Console.Write("Digite um número (999 para parar): ");
                            }
                        }

                        Console.WriteLine(Environment.NewLine + "Vetor invertido");
                        for (i = quantidade-1; i >= 0; i--)
                        {
                            Console.Write(vetor[i] + " ");
                        }
                        break;
                    }

                case 4: //Exercício 4
                    {
                        //4A
                        Console.WriteLine("Matrículas");
                        int[] matriculas = LerEntradas(10);

                        Console.WriteLine("Verificar matrícula:");

                        int matricula = Convert.ToInt32(Console.ReadLine());

                        if (LerMatricula(matricula, matriculas))
                        {
                            Console.WriteLine($"Matrícula {matricula} já inserida");
                        }
                        else
                        {
                            Console.WriteLine($"Não há matrícula {matricula}");
                        }

                        //4B
                        static bool LerMatricula(int matricula, int[] matriculas)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (matriculas[i] == matricula)
                                {
                                    return true;
                                }
                            }
                            return false;
                        }
                        break;
                    }

                case 5: //Exercício 5
                    {
                        double[] primeiraProva = new double[50];
                        double[] segundaProva = new double[50];
                        double[] media = new double[50];

                        int i;
                        for (i = 0; i < 50; i++)
                        {
                            Console.Write($"Nota da 1ª prova do aluno {i + 1} (-1 para sair): ");
                            primeiraProva[i] = Convert.ToDouble(Console.ReadLine());
                            if (primeiraProva[i] == -1)
                            {
                                break;
                            }
                            Console.Write(Environment.NewLine + $"Nota da 2ª prova do aluno {i + 1}: ");
                            segundaProva[i] = Convert.ToDouble(Console.ReadLine());
                            media[i] = (primeiraProva[i] + segundaProva[i]) / 2;
                        }

                        Console.WriteLine(Environment.NewLine + "Resultado:");
                        for (int j = 0; j < i; j++)
                        {
                            if (media[j] >= 6)
                            {
                                Console.WriteLine("Aluno " + (j + 1) + ": APROVADO");
                            }
                            else
                            {
                                Console.WriteLine("Aluno " + (j + 1) + ": REPROVADO");
                            }
                        }

                        break;
                    }

                case 6: //Exercício 6
                    {
                        int[] vetor = LerEntradas(10);
                        int somaImpares = 0;

                        for (int i = 0; i < 10; i++)
                        {
                            if (vetor[i] % 2 != 0)
                            {
                                somaImpares += vetor[i];
                            }
                        }
                        Console.WriteLine("A soma dos números ímpares no vetor é: " + somaImpares);

                        break;
                    }
            }
        }
    }
}