using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZF.DesignPatterns.AdapterDemo
{
    interface IConverter<TItem, TResult>
    {
        TResult Convert(TItem item);

    }

    class PersonConverter : IConverter<PersonDTO, Person>
    {
        public Person Convert(PersonDTO item)
        {
            return new Person
            {
                FirstName = item.Imie,
                LastName = item.Nazwisko
            };
        }
    }

    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    class PersonDTO
    {
        public string Imie { get; set; }

        public string Nazwisko { get; set; }
    }
}
