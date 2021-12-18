using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {

        T Get<T> (string key);
        object Get(string key);
        //gelecek data bir object. object herşeyin basedir.
        //bu cache de ne kadar duracak->duration (dk cinsinden falan)
        void Add(string key, object value , int duration);
        bool IsAdd(string key); //cache de var mı diye control yapmamıza yarayacak method
        void Remove(string key);
        void RemoveByPattern(string pattern);

    }
}
