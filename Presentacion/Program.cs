using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Persona persona = new Persona(identificacion,nombre,edad,sexo);
            PersonaService personaService = new PersonaService();
            persona.Pulsacion=personaService.CalcularPulsacion(sexo,edad);
            
            Console.WriteLine($"Su Pulsaciones {persona.Pulsacion}");

            Console.ReadKey();


        }
    }
}
