﻿using FE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE.Services
{
    public class EnrollmentsServices : IEnrollmentsServices
    {
        public void Delete(Enrollment t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    //EL BASEUR SE DECLARA EN EL PROGRAM
                    cl.BaseAddress = new Uri(Program.baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = cl.DeleteAsync("api/Enrollments/" + t.EnrollmentId.ToString()).Result;

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

        public IEnumerable<Enrollment> GetAll()
        {
            List<Models.Enrollment> aux = new List<Models.Enrollment>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Enrollments").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.Enrollment>>(auxres);
                }
            }
            return aux;
        }

        public Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Enrollment GetOneById(int id)
        {
            Models.Enrollment aux = new Models.Enrollment();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/Enrollments/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.Enrollment>(auxres);
                }
            }
            return aux;
        }

        public Task<Enrollment> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Enrollment t)
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
                    var postTask = cl.PostAsync("api/Enrollments", byteContent).Result;

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

        public void Update(Enrollment t)
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
                    var postTask = cl.PutAsync("api/Enrollments/" + t.EnrollmentId, byteContent).Result;


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

        //public void Delete(Enrollment t)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Enrollment> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Enrollment>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Enrollment GetOneById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Enrollment> GetOneByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(Enrollment t)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(Enrollment t)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
