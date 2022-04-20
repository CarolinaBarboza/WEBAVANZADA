using FE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE.Services
{
    public class OfficeAssignmentsServices : IOfficeAssignmentsServices
    {
        public void Delete(OfficeAssignment t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    //EL BASEUR SE DECLARA EN EL PROGRAM
                    cl.BaseAddress = new Uri(Program.baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = cl.DeleteAsync("api/OfficeAssignment/" + t.InstructorId.ToString()).Result;

                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception(res.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public IEnumerable<OfficeAssignment> GetAll()
        {
            List<Models.OfficeAssignment> aux = new List<Models.OfficeAssignment>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/OfficeAssignment").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.OfficeAssignment>>(auxres);
                }
            }
            return aux;
        }

        public Task<IEnumerable<OfficeAssignment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public OfficeAssignment GetOneById(int id)
        {
            Models.OfficeAssignment aux = new Models.OfficeAssignment();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/OfficeAssignment/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.OfficeAssignment>(auxres);
                }
            }
            return aux;
        }

        public Task<OfficeAssignment> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OfficeAssignment t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(t);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/OfficeAssignment", byteContent).Result;

                    if (!postTask.IsSuccessStatusCode)
                    {
                        throw new Exception(postTask.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public void Update(OfficeAssignment t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(t);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PutAsync("api/OfficeAssignment/" + t.InstructorId, byteContent).Result;


                    if (!postTask.IsSuccessStatusCode)
                    {
                        throw new Exception(postTask.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        //public void Delete(OfficeAssignment t)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<OfficeAssignment> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<OfficeAssignment>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public OfficeAssignment GetOneById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<OfficeAssignment> GetOneByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(OfficeAssignment t)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(OfficeAssignment t)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
