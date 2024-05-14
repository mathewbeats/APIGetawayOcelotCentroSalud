//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.SwaggerGen;

//namespace APIGetaway
//{
//    public class SwaggerDocumentFilter : IDocumentFilter
//    {
//        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
//        {
//            // Ejemplo de cómo añadir una ruta manualmente
//            swaggerDoc.Paths.Add("/citas", new OpenApiPathItem
//            {
//                Operations = new Dictionary<OperationType, OpenApiOperation>
//                {
//                    [OperationType.Get] = new OpenApiOperation
//                    {
//                        Summary = "Obtiene todas las citas",
//                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Citas" } },
//                        Responses = new OpenApiResponses
//                        {
//                            ["200"] = new OpenApiResponse { Description = "Listado de citas" }
//                        }
//                    }
//                }
//            });


//            // Añadir rutas para Pacientes
//            swaggerDoc.Paths.Add("/Pacientes", new OpenApiPathItem
//            {
//                Operations = new Dictionary<OperationType, OpenApiOperation>
//                {
//                    [OperationType.Get] = new OpenApiOperation
//                    {
//                        Summary = "Obtiene todos los pacientes",
//                        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Pacientes" } },
//                        Responses = new OpenApiResponses
//                        {
//                            ["200"] = new OpenApiResponse { Description = "Listado de pacientes" }
//                        }
//                    }
//                }
//            });

//            // Añade más rutas según las configuraciones de Ocelot
//        } 
//    }

//}



using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace APIGetaway
{
    public class SwaggerDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
           
            var citasPathItem = new OpenApiPathItem();
            citasPathItem.Operations.Add(OperationType.Get, new OpenApiOperation
            {
                Summary = "Obtiene todas las citas",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Citas" } },
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse { Description = "Listado de citas exitosamente recuperado" }
                }
            });

            citasPathItem.Operations.Add(OperationType.Post, new OpenApiOperation
            {
                Summary = "Crea una nueva cita",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Citas" } },
                Responses = new OpenApiResponses
                {
                    ["201"] = new OpenApiResponse { Description = "Cita creada exitosamente" }
                }
            });

            // Ruta para operaciones de Citas por ID
            var citasByIdPathItem = new OpenApiPathItem();
            citasByIdPathItem.Operations.Add(OperationType.Get, new OpenApiOperation
            {
                Summary = "Obtiene una cita por ID",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Citas" } },
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse { Description = "Cita recuperada exitosamente" }
                }
            });

            citasByIdPathItem.Operations.Add(OperationType.Put, new OpenApiOperation
            {
                Summary = "Actualiza una cita",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Citas" } },
                Responses = new OpenApiResponses
                {
                    ["204"] = new OpenApiResponse { Description = "Cita actualizada exitosamente" }
                }
            });

            citasByIdPathItem.Operations.Add(OperationType.Patch, new OpenApiOperation
            {
                Summary = "Actualiza parcialmente una cita",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Citas" } },
                Responses = new OpenApiResponses
                {
                    ["204"] = new OpenApiResponse { Description = "Cita actualizada parcialmente exitosamente" }
                }
            });

            citasByIdPathItem.Operations.Add(OperationType.Delete, new OpenApiOperation
            {
                Summary = "Elimina una cita",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Citas" } },
                Responses = new OpenApiResponses
                {
                    ["204"] = new OpenApiResponse { Description = "Cita eliminada exitosamente" }
                }
            });

            swaggerDoc.Paths.Add("/citas", citasPathItem);
            swaggerDoc.Paths.Add("/citas/{id}", citasByIdPathItem);

            // Añadir rutas para Pacientes
            var patientsPathItem = new OpenApiPathItem();
            patientsPathItem.Operations.Add(OperationType.Get, new OpenApiOperation
            {
                Summary = "Obtiene todos los pacientes",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Pacientes" } },
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse { Description = "Listado de pacientes exitosamente recuperado" }
                }
            });

            patientsPathItem.Operations.Add(OperationType.Post, new OpenApiOperation
            {
                Summary = "Crea un nuevo paciente",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Pacientes" } },
                Responses = new OpenApiResponses
                {
                    ["201"] = new OpenApiResponse { Description = "Paciente creado exitosamente" }
                }
            });

            // Ruta para operaciones por ID
            var patientByIdPathItem = new OpenApiPathItem();
            patientByIdPathItem.Operations.Add(OperationType.Get, new OpenApiOperation
            {
                Summary = "Obtiene un paciente por ID",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Pacientes" } },
                Responses = new OpenApiResponses
                {
                    ["200"] = new OpenApiResponse { Description = "Paciente recuperado exitosamente" }
                }
            });

            patientByIdPathItem.Operations.Add(OperationType.Put, new OpenApiOperation
            {
                Summary = "Actualiza un paciente",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Pacientes" } },
                Responses = new OpenApiResponses
                {
                    ["204"] = new OpenApiResponse { Description = "Paciente actualizado exitosamente" }
                }
            });

            patientByIdPathItem.Operations.Add(OperationType.Patch, new OpenApiOperation
            {
                Summary = "Actualiza parcialmente un paciente",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Pacientes" } },
                Responses = new OpenApiResponses
                {
                    ["204"] = new OpenApiResponse { Description = "Paciente actualizado parcialmente exitosamente" }
                }
            });

            patientByIdPathItem.Operations.Add(OperationType.Delete, new OpenApiOperation
            {
                Summary = "Elimina un paciente",
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Pacientes" } },
                Responses = new OpenApiResponses
                {
                    ["204"] = new OpenApiResponse { Description = "Paciente eliminado exitosamente" }
                }
            });

            swaggerDoc.Paths.Add("/Patients", patientsPathItem);
            swaggerDoc.Paths.Add("/Patients/{id}", patientByIdPathItem);
        }
    }
}
