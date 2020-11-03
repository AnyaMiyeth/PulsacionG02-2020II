using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
        public List<Persona> FiltrarSexo(string sexo)
        {
            return ConsultarTodos().Where(p => p.Sexo.Equals(sexo)).ToList();
        }

        public List<Persona> FiltrarPorHombres()
        {

            List<Persona> personas= ConsultarTodos();
            List<Persona> personasFiltradas =
                (from persona in personas
                where persona.Sexo.Equals("M")
                select persona).ToList();
            return personasFiltradas;
        }

        public List<Persona> FiltrarPorMujeres()
        {

            List<Persona> personas = ConsultarTodos();
            return personas.Where(p=>p.Edad>5 && p.Edad<10).ToList();
        }

        public int ContarSexo(string sexo)
        {
            return ConsultarTodos().Count(p=>p.Sexo.Equals(sexo));
        }

        public List<Persona> FiltroPorNombre(string nombre)
        {
            return ConsultarTodos().Where(p => p.Nombre.Contains(nombre)).ToList();
        }
    }
}
