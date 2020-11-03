using System;
using System.Collections.Generic;
using DAL;
using Entity;
namespace BLL
{
    public class PersonaService
    {
        private readonly PersonaRepository personaRepository;
        public PersonaService()
        {
            personaRepository = new PersonaRepository();
        }
        public string Guardar(Persona persona)
        {
            try
            {
               
                if (personaRepository.Buscar(persona.Identificacion) == null)
                {
                    personaRepository.Guardar(persona);
                    return $"se han guardado Satisfactoriamente los datos de: {persona.Nombre} ";
                }
                else
                {
                    return $"Lo sentimos, con la Identificación {persona.Identificacion} ya se encuentra registrada";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
        }
        public string Eliminar(string identificacion)
        {
            try
            {
                if (personaRepository.Buscar(identificacion) != null)
                {
                    personaRepository.Eliminar(identificacion);
                    return ($"se han Eliminado Satisfactoriamente los datos de la persona con Identificación: {identificacion} ");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra registrada una persona con Identificacion {identificacion}");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }

        }
        public PersonaResponse BuscarPorIdentificacion(string identificacion)
        {
         
            try
            {            
                Persona persona = personaRepository.Buscar(identificacion);
                if (persona != null)
                {
                   return  new PersonaResponse(persona);
                }
                else
                {
                    return  new PersonaResponse("La Persona buscada no se encuentra Registrada");
                }
                
            }
            catch (Exception e)
            {

                return  new PersonaResponse("Error de Aplicacion: "+e.Message);
            }
            
        }
        public  ConsultaPersonaResponse ConsultarTodos()
        {

            try
            {
                List<Persona> personas = personaRepository.ConsultarTodos();
                if (personas != null)
                { 
                    return  new ConsultaPersonaResponse(personas);
                }
                else
                {
                    return  new ConsultaPersonaResponse("La Persona buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return  new ConsultaPersonaResponse("Error de Aplicacion: " + e.Message);
            }
        }
        public ConsultaPersonaResponse ConsultarPorSexo(string sexo)
        {

            try
            {
                List<Persona> personas = personaRepository.FiltrarSexo(sexo);
                if (personas != null)
                {
                    return new ConsultaPersonaResponse(personas);
                }
                else
                {
                    return new ConsultaPersonaResponse("La Persona buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return new ConsultaPersonaResponse("Error de Aplicacion: " + e.Message);
            }
        }
    }

   public class PersonaResponse 
    {
        public Persona Persona { get; set; }
        public string Message { get; set; }
        public bool Encontrado { get; set; }

        public PersonaResponse(Persona persona)
        {
            Persona = new Persona();
            Persona = persona;
            Encontrado = true;
        }
        public PersonaResponse(string message)
        {
            Message = message;
            Encontrado = false;
        }
    }
    public class ConsultaPersonaResponse
    {
        public List<Persona> Personas { get; set; }
        public string Message { get; set; }
        public bool Encontrado { get; set; }

        public ConsultaPersonaResponse(List<Persona> personas)
        {
            Personas = new List<Persona>();
            Personas = personas;
            Encontrado = true;
        }
        public ConsultaPersonaResponse(string message)
        {
            Message = message;
            Encontrado = false;
        }
    }
}
