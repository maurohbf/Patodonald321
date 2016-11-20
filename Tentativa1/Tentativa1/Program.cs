using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentativa1
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            string texto = string.Empty;
            string textoCrip = string.Empty;
            string textoDesc = string.Empty;
            string newTextCrip = string.Empty;
            string newTextDesc = string.Empty;
            do
            {
                Console.Clear();
                Console.WriteLine("Escolha uma opção\n");
                Console.WriteLine("1 - Opção 01 - Criptografar texto");
                Console.WriteLine("2 - Opção 02 - Descriptografar texto");
                Console.WriteLine("3 - Opção 03");
                Console.WriteLine("4 - Opção 04");
                Console.WriteLine("0 - Sair");
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Opção 01 - Criptografar texto");
                        Console.WriteLine("Digite o texto que deseja criptografar");
                        texto = Console.ReadLine();
                        textoCrip = criptografaTexto(texto);
                        Console.WriteLine("A mensagem \"{0}\", criptografada: \"{1}\"", texto, textoCrip);
                        Console.ReadKey();
                        break;
                    case 2:
                        string testes = string.Empty;
                        Console.WriteLine("Opção 02 - Descriptografar texto");
                        if (textoCrip != string.Empty)
                        {
                            Console.WriteLine("Deseja descriptografar o texto armazenado \"{0}\"?", textoCrip);
                            Console.WriteLine("Digite \"s\" para sim, e \"n\" para não.");
                            testes = Console.ReadLine();
                            if (testes == "s")
                            {
                                textoDesc = descriptografaTexto(textoCrip);
                                Console.WriteLine("A mensagem \"{0}\", descriptografada: \"{1}\"", textoCrip, textoDesc);
                            }
                            else if (testes == "n")
                            {
                                Console.WriteLine("Digite um novo texto para ser descriptografado: ");
                                newTextCrip = Console.ReadLine();
                                newTextDesc = descriptografaTexto(newTextCrip);
                                Console.WriteLine("A mensagem \"{0}\", criptografada: \"{1}\"", newTextCrip, newTextDesc);
                            }
                            else if(testes != "s" && testes != "n")
                            {
                                Console.WriteLine("Caractere invalido!");
                                Console.WriteLine("Digite um texto para ser descriptografado: ");
                                newTextCrip = Console.ReadLine();
                                newTextDesc = descriptografaTexto(newTextCrip);
                                Console.WriteLine("A mensagem \"{0}\", criptografada: \"{1}\"", newTextCrip, newTextDesc);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Digite um texto para ser descriptografado: ");
                            newTextCrip = Console.ReadLine();
                            newTextDesc = descriptografaTexto(newTextCrip);
                            Console.WriteLine("A mensagem \"{0}\", criptografada: \"{1}\"", newTextCrip, newTextDesc);
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Opção 03");
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Opção 04");
                        Console.ReadKey();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("O Software será encerrado...\n\n");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção Inválida, Tecle 'enter' e digite a opção novamente...\n\n");
                        Console.ReadKey();
                        break;
                }
            } while (op != 0);
        }
        static string criptografaTexto(string texto)
        {
            int chave = 0;
            char[] textoChar = texto.ToCharArray();
            int textoTamanho = texto.Length;
            string textoAscii = string.Empty;
            string textoCripAscii = string.Empty;
            Console.WriteLine("Digite a chave de criptografia: ");
            chave = int.Parse(Console.ReadLine());
            int contChave = chave;
            for (int cont = 0; cont < textoTamanho; cont++)
            {
                int textoValorTemp = (int)textoChar[cont];
                textoAscii = textoAscii + textoValorTemp + " ";
                int textoValorCrip = textoValorTemp + contChave;
                contChave = contChave + chave;
                textoCripAscii = textoCripAscii + textoValorCrip + " ";
            }
            Console.WriteLine("O valor do texto {0} em ASCII: {1}", texto, textoAscii);
            Console.WriteLine("O valor do texto {0}, criptografado e em ASCII: {1}", texto, textoCripAscii);
            string[] separador = new string[] { " " };
            string[] textoSemEspaco = textoCripAscii.Split(separador, StringSplitOptions.None);
            string textoCrip = string.Empty;
            foreach (string carac in textoSemEspaco)
            {
                int numCarac;
                bool teste = Int32.TryParse(carac, out numCarac);
                if (teste == true)
                {
                    int numCaracTeste = numCarac;
                    char caracCrip = (char)numCaracTeste;
                    textoCrip += caracCrip;
                }
            }
            return textoCrip;
        }
        static string descriptografaTexto(string texto)
        {
            int chave = 0;
            char[] textoChar = texto.ToCharArray();
            int textoTamanho = texto.Length;
            string textoAscii = string.Empty;
            string textoDescAscii = string.Empty;
            Console.WriteLine("Digite a chave de descriptografia: ");
            chave = int.Parse(Console.ReadLine());
            int contChave = chave;
            for (int cont = 0; cont < textoTamanho; cont++)
            {
                int textoValorTemp = (int)textoChar[cont];
                textoAscii = textoAscii + textoValorTemp + " ";
                int textoValorDesc = textoValorTemp - contChave;
                contChave += chave;
                textoDescAscii = textoDescAscii + textoValorDesc + " ";
            }
            Console.WriteLine("O valor do texto {0} em ASCII: {1}", texto, textoAscii);
            Console.WriteLine("O valor do texto {0}, descriptografado e em ASCII: {1}", texto, textoDescAscii);
            string[] separador = new string[] { " " };
            string[] textoSemEspaco = textoDescAscii.Split(separador, StringSplitOptions.None);
            string textoDesc = string.Empty;
            foreach (string carac in textoSemEspaco)
            {
                int numCarac;
                bool teste = Int32.TryParse(carac, out numCarac);
                if (teste == true)
                {
                    int numCaracTeste = numCarac;
                    char caracCrip = (char)numCaracTeste;
                    textoDesc += caracCrip;
                }
            }
            return textoDesc;
        }
    }
}

