﻿using API2022WithSwegger.Models;
using API2022WithSwegger.Models.Comman;
using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace API2022WithSwegger.Controllers.Comman
{
    [Area("Comman")]
    [ApiVersion("2.0")]
    [ControllerName("Department")]
    public class DepartmentV2Controller : CustomApiBase
    {
        private static List<Department> Departments = new List<Department>()
        {
            new Department() { Id = 1,Code="ACC V2",Name="Account Department V2"},
            new Department() { Id = 2,Code="RES V2",Name="Resarch Department V2"},
            new Department() { Id = 3,Code="SAL V2",Name="Sales Department V2"},
            new Department() { Id = 4,Code="STO V2",Name="Store Department V2"}
        };

        public DepartmentV2Controller()
        {
        }

        /// <summary>
        /// Get department details based on department id.
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns>Department Details</returns>
        [HttpGet]
        [ActionName("GetDepartmentById")]
        public ResultReponse GetDepartmentById(int id)
        {
            ResultReponse resultReponse;
            Department? department;
            if (Departments != null)
            {
                department = Departments.FirstOrDefault(col => col.Id == id);
                if (department != null)
                {
                    resultReponse = ResponseSend(true, department);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
            }
            return resultReponse;
        }

        /// <summary>
        /// Get all departments details.
        /// </summary>
        /// <returns>Departments details</returns>
        [HttpGet]
        [ActionName("GetAllDepartments")]
        public ResultReponse GetAllDepartments()
        {
            return ResponseSend(true, Departments); ;
        }

        /// <summary>
        /// Add department details.
        /// </summary>
        /// <param name="department">Department details</param>
        /// <returns>Department details</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///         "id": 0,
        ///         "name": "string",
        ///         "code": "string"
        ///     }
        /// 
        /// </remarks>
        [HttpPost]
        [ActionName("AddDepartment")]
        public ResultReponse AddDepartment(Department department)
        {
            Departments.Add(department);
            return ResponseSend(true, department);
        }

        /// <summary>
        /// Update department details based on department id.
        /// </summary>
        /// <param name="department">Department details</param>
        /// <returns>Department details</returns>
        [HttpPost]
        [ActionName("UpdateDepartment")]
        public ResultReponse UpdateUser(Department department)
        {
            ResultReponse? resultReponse;
            if (Departments != null)
            {
                Department? dbDepartment = Departments.FirstOrDefault(col => col.Id == department.Id);
                if (dbDepartment != null)
                {
                    dbDepartment.Code = department.Code;
                    dbDepartment.Name = department.Name;
                    resultReponse = ResponseSend(true, department);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"Department with id {department.Id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"Department with id {department.Id} does not exists.");
            }
            return resultReponse;
        }

        /// <summary>
        /// Delete department based on department id.
        /// </summary>
        /// <param name="id">department id</param>
        /// <returns>Department Details</returns>
        [HttpPost]
        [ActionName("DeleteDepartment")]
        public ResultReponse DeleteDepartment(int id)
        {
            ResultReponse? resultReponse;
            Department? department;
            if (Departments != null)
            {
                department = Departments.FirstOrDefault(col => col.Id == id);
                if (department != null)
                {
                    Departments.Remove(department);
                    resultReponse = ResponseSend(true, department);
                }
                else
                {
                    resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
                }
            }
            else
            {
                resultReponse = ResponseSend(false, null, $"Department with id {id} does not exists.");
            }
            return resultReponse;
        }
    }
}
