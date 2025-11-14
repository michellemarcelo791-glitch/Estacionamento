Console.Write("Informe o tamanho do veículo (P/G): ");
       string? tamanhoInput = Console.ReadLine();
       string tamanho = tamanhoInput != null ? tamanhoInput.ToUpper() : "";
 Console.Write("Informe o total de minutos estacionado: ");
 if (!int.TryParse(Console.ReadLine(), out int minutos) || minutos <= 0)
        {
            Console.WriteLine("Tempo inválido.");
            return;
        }

 if (minutos > 720) 
        {
            Console.WriteLine("Tempo de permanência superior a 12 horas não é aceito.");
            return;
        }

Console.Write("Utilizou serviço de valet? (S/N): ");

string valetInput = Console.ReadLine()?.ToUpper() ?? "";
bool valet = valetInput == "S";

Console.Write("Incluiu serviço de lavagem? (S/N): ");
string lavagemInput = Console.ReadLine()?.ToUpper() ?? "";
bool lavagem = lavagemInput == "S";

        const decimal precoPrimeiraHora = 20m;
        const decimal precoHoraAdicionalGrande = 20m;
        const decimal precoHoraAdicionalPequeno = 10m;
        const decimal diariaGrande = 80m;
        const decimal diariaPequeno = 50m;
        const int toleranciaMinutos = 5;
        const decimal percValet = 0.20m;
        const decimal lavagemGrande = 100m;
        const decimal lavagemPequeno = 50m;

      
        int tempoCobradoMinutos = minutos;

      
        int horasParcela = tempoCobradoMinutos / 60;
        int minutosRestantes = tempoCobradoMinutos % 60;


if (minutosRestantes <= toleranciaMinutos && horasParcela > 0) 
        {
            minutosRestantes = 0; 
        } 
else if (minutosRestantes > toleranciaMinutos)
        {
            horasParcela += 1;
            minutosRestantes = 0;
        }

        decimal valorEstacionamento = 0m;
        string descricaoEstacionamento = "";

        bool carroGrande = tamanho == "G";

if (horasParcela == 0)
        {
        
            horasParcela = 1;
        }

if (horasParcela >= 5)
        {
            
if (carroGrande)
{
                valorEstacionamento = diariaGrande;
                descricaoEstacionamento = $"Diária para carro grande: R$ {diariaGrande:F2}";
            }
else
            {
                valorEstacionamento = diariaPequeno;
                descricaoEstacionamento = $"Diária para carro pequeno: R$ {diariaPequeno:F2}";
            }
        }
else
        {
    
            valorEstacionamento = precoPrimeiraHora;
            descricaoEstacionamento = $"Primeira hora: R$ {precoPrimeiraHora:F2}";

            int horasAdicionais = horasParcela - 1;
if (horasAdicionais > 0)
            {
                decimal valorAdicional = 0m;
if (carroGrande)
                    valorAdicional = precoHoraAdicionalGrande * horasAdicionais;
else
                    valorAdicional = precoHoraAdicionalPequeno * horasAdicionais;

                valorEstacionamento += valorAdicional;
                descricaoEstacionamento += $"\nHoras adicionais ({horasAdicionais}): R$ {valorAdicional:F2}";
            }
        }

        
        decimal valorValet = 0m;
if (valet)
        {
            valorValet = valorEstacionamento * percValet;
        }
        decimal valorLavagem = 0m;
if (lavagem)
{
if (carroGrande)
                valorLavagem = lavagemGrande;
else
                valorLavagem = lavagemPequeno;
        }


        decimal total = valorEstacionamento + valorValet + valorLavagem;

        Console.WriteLine("\nResumo do cálculo:");
Console.WriteLine(descricaoEstacionamento);
if (valet)
            Console.WriteLine($"Serviço valet (20%): R$ {valorValet:F2}");
if (lavagem)
            Console.WriteLine($"Lavagem: R$ {valorLavagem:F2}");
        Console.WriteLine($"Total a pagar: R$ {total:F2}");
