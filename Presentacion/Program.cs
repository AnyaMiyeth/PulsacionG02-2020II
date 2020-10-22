using System;
using BLL;
using Entity;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            int edad;
            string nombre;
            string sexo;
            string identificacion;


            Console.WriteLine("Digite la identificacion");
            identificacion = Console.ReadLine();

            Console.WriteLine("Digite el nombre");
            nombre = Console.ReadLine();

            Console.WriteLine("Digite el sexo");
            sexo = Console.ReadLine();

            Console.WriteLine("Digite la edad");
            edad = int.Parse(Console.ReadLine());

            Persona persona = new Persona(identificacion, nombre, edad, sexo);
            PersonaService personaService = new PersonaService();
            persona.CalcularPulsacion();
            string message = personaService.Guardar(persona);
            Console.WriteLine($"Su Pulsaciones {persona.Pulsacion} " + message);

            PersonaResponse personaResponse = personaService.BuscarPorIdentificacion("1");
            if (personaResponse.PersonaEncontrada == true)
                Console.WriteLine(personaResponse.Persona.ToString());
            else
            {
                Console.WriteLine(personaResponse.Message);
            }

            Consultar(personaService);

            Console.WriteLine("Eliminar Personas");
            Console.WriteLine("Digite la identificacion");
            identificacion = Console.ReadLine();
            string messageEliminacion = personaService.Eliminar(identificacion);
            Console.WriteLine(messageEliminacion);

            Consultar(personaService);


            Console.ReadKey();


        }

        private static void Consultar(PersonaService personaService)
        {
            ConsultaPersonaResponse consultaPersonaResponse = personaService.ConsultarTodos();
            if (consultaPersonaResponse.PersonaEncontrada == true)
            {
                Console.WriteLine("Lista de Personas");
                foreach (var item in consultaPersonaResponse.Personas)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine(consultaPersonaResponse.Message);
            }
        }
    }
}
