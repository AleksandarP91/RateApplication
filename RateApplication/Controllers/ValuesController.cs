using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace RateApplication.Controllers
{
    public class ValuesController : ApiController
    {

        
        // GET api/values
        public IEnumerable<Skill> Get()
        {
            List<Skill> list = new List<Skill>();


            var session = HttpContext.Current.Session;
            if (session != null)
            {
                if (session["skills"] == null)
                {
                    list.Add(new Skill() { Name = "JavaScript", Level = 4 });
                    list.Add(new Skill() { Name = "HTML", Level = 2 });
                    list.Add(new Skill() { Name = "C#", Level = 3 });

                    session["skills"] = list;
                }
                list = (List<Skill>)session["skills"];

            }

            return list;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<Skill> Post(Skill skill)
        {
            List<Skill> list = new List<Skill>();
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                
            list = (List<Skill>)session["skills"];
            list.Add(skill);
            session["skills"] = list;

            }

            return list;
        }

        // PUT api/values/
 
        public IEnumerable<Skill> Put(Skill skill, int modifiedLevel)
        {
            List<Skill> list = new List<Skill>();
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                list = (List<Skill>)session["skills"];
                var index = list.FindIndex(i => i.Name == skill.Name && i.Level == skill.Level);
                list[index].Level = modifiedLevel;
                session["skills"] = list;
            }
            return list;
        }
        // DELETE api/values/
        public IEnumerable<Skill> Delete(Skill skill)
        {
            List<Skill> list = new List<Skill>();
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                list = (List<Skill>)session["skills"];
                list.RemoveAll(i => i.Name == skill.Name && i.Level == skill.Level);
                session["skills"] = list;
            }
            return list;
        }


      

    }
    public class Skill
    {
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
