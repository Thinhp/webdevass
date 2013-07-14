using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHIA.Interface;
using OpenHIA.Model;
using OpenHIA.Exceptions;

namespace OpenHIA.Service
{
    class VisitCrud : IMaintanble<Visit>
    {
        public void GetAllRecords()
        {
            Console.WriteLine("Id" + "    " + "Name" + "               " + 
                "License Number" + "  " + "Address");
            foreach (Visit vis in Database.VisitList)
            {
                Console.WriteLine(vis.ToString());
            }
        }

        public void Create(Visit obj)
        {
            Database.VisitList.Add(obj);
            Database.VisitList.Sort();
        }

        public Visit Read(string key)
        {
            // Loop through doctor list and get doctor object based on 'key'
            foreach (Visit vis in Database.VisitList)
            {
                if (vis.Id.Equals(key))
                {
                    return vis;
                }
            }

            throw new InvalidVisitInformationException("No visit found");
        }

        public void Update(Visit obj)
        {
            foreach (Visit vis in Database.VisitList)
            {
                if (vis.Id.Equals(obj.Id))
                {
                    vis.TreatedPatient = obj.TreatedPatient;
                    vis.TreatingDoctor = obj.TreatingDoctor;
                    vis.Place = obj.Place;
                    vis.TreatedDate = obj.TreatedDate;
                    vis.Diagnosis = obj.Diagnosis;
                    vis.Outcome = vis.Outcome;
                    Database.VisitList.Sort();
                    break;
                }
            }
        }

        public void Delete(string key)
        {
            foreach (Visit vis in Database.VisitList)
            {
                if (vis.Id.Equals(key))
                {
                    Database.VisitList.Remove(vis);
                    break;
                }
            }
        }
    }
}
