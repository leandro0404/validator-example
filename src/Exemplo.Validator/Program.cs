using Exemplo.Validator.Interfaces;
using Exemplo.Validator.ValidatorProcesso.Fields;
using Exemplo.Validator.Services;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace Exemplo.Validator
{
    class Program
    {

        // Avaliar {Interfaces / Core}   -> restante para exemplo de uso
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddTransient<IValidatorCommand<Processo>, UpdateValidatorProcesso>()
            .AddScoped<IValidatorFieldCommand<Processo>, ValidatorItemForo>()
            .AddScoped<IValidatorFieldCommand<Processo>, ValidatorItemVara>()
            .AddScoped<IVaraService, VaraService>()
            .BuildServiceProvider();

            var processoAntigo = new Processo { Id = 1, VaraId = 3, ForoId = 3 };
            // alterado para dar exception
            var processoAtual = new Processo { Id = 1, VaraId = 20, ForoId = 1 };
            string[] fieldsPayLoad = { "VaraId", "ForoId" };

            // usar primeiro o validador do fluentvalidator para  {fail fast validator}
            //verificações como se propriedade é nula  ou atende algum requisito básico 
            //onde não precise ir ao respositorio ou á algum serviço de gateway.  
            //gateway e validaçòes que precise usar serviços ficarão no ValidatorCommand 

            // Fail - Fast Validations
            //Em nosso exemplo iremos implementar um Behavior para validar os parâmetros de entrada dos Requests 
            //antes de seus respectivos Handlers serem disparados, dessa forma antecipamos a falha no Request 
            //e poupamos nossa aplicação de processar um Handler para descobrir que os parâmetros não são válidos.

            // validador Command
            var validator = serviceProvider.GetService<IValidatorCommand<Processo>>();
            validator.ValidateRules(processoAtual, processoAntigo, fieldsPayLoad);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

}


