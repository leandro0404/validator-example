using Exemplo.Validator.Interfaces;
using Exemplo.Validator.ValidatorProcesso.Fields;
using System;
using Microsoft.Extensions.DependencyInjection;
using Exemplo.Validator.Services;

namespace Exemplo.Validator
{
    class Program
    {

        // Avaliar {Interfaces / Core}   -> restante para exemplo de uso
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddTransient<IValidatorCustom<Processo>, UpdateValidatorProcesso>()
            .AddScoped<IValidatorFieldCustom<Processo>, ValidatorItemForo>()
            .AddScoped<IValidatorFieldCustom<Processo>, ValidatorItemVara>()
            .AddScoped<IVaraService, VaraService>()
            .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<IValidatorCustom<Processo>>();

            var validator = serviceProvider.GetService<IValidatorCustom<Processo>>();

            var processoAntigo = new Processo { Id = 1, VaraId = 3, ForoId = 3 };
            // alterado para dar exception
            var processoAtual = new Processo { Id = 1, VaraId = 20, ForoId = 1 };
            string[] fieldsPayLoad = { "VaraId", "ForoId" };

            validator.ValidateRules(processoAtual, processoAntigo, fieldsPayLoad);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}


