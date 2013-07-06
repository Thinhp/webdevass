using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenHIA.Interface
{
    public interface IMaintanble<T>
    {
        void GetAllRecords(); 
        void Create(T obj);
        T Read(string key);
        void Update(T obj);
        void Delete(string key);
    }
}
