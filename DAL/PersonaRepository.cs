using Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace DAL
{
    public class PersonaRepository
    {
        private readonly string FileName = "Perona.txt";
        public void Guardar(Persona persona)
        {
            FileStream file = new FileStream(FileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{persona.Identificacion};{persona.Nombre};{persona.Edad};{persona.Sexo};{persona.Pulsacion} ");
            writer.Close();
            file.Close();
           
        }
        public Persona Buscar(string identificacion)
        {
            List<Persona> personas =ConsultarTodos();
            foreach (var item in personas)
            {
                if (EsEncontrado(item.Identificacion, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
        private bool EsEncontrado (string identificacioRegistrada, string identificacionBuscada)
        {
            return identificacioRegistrada == identificacionBuscada;
        }
        public List<Persona> ConsultarTodos()
        {
            List<Persona> personas = new List<Persona>();
            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {

                Persona persona = Map(linea);
                personas.Add(persona);
            }
            reader.Close();
            file.Close();
            return personas;
        }
        private Persona Map(string linea)
        {
            Persona persona = new Persona();
            char delimiter = ';';
            string[] matrizPersona = linea.Split(delimiter);
            persona.Identificacion = matrizPersona[0];
            persona.Nombre = matrizPersona[1];
            persona.Edad = int.Parse(matrizPersona[2]);
            persona.Sexo = matrizPersona[3];
            persona.Pulsacion = Convert.ToDecimal(matrizPersona[4]);
            return persona;
        }
        public void Eliminar(string identificacion) 
        {
            List<Persona> personas = new List<Persona>();
            personas = ConsultarTodos();
            FileStream file = new FileStream(FileName, FileMode.Create);
            file.Close();
            foreach (var item in personas)
            {
                if (!EsEncontrado(item.Identificacion, identificacion))
                {
                    Guardar(item);
                }
                
            }

        }
        public void Modificar(Persona personaOld, Persona personaNew)
        {
            List<Persona> personas = new List<Persona>();
            personas = ConsultarTodos();
            FileStream file = new FileStream(FileName, FileMode.Create);
            file.Close();
            foreach (var item in personas)
            {
                if (!EsEncontrado(item.Identificacion, personaOld.Identificacion))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(personaNew);
                }

            }

        }

    }
}
