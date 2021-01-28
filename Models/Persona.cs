/*
 * Mini serie di esempi su ereditarietà e polimorfismo.
 * maurizio.conti@ittsrimini.edu.it - Settembre 2020
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maurizio.conti.Uploadfile.Models
{
    public class Persona
    {
        public Persona()
        { }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        // Field data
        private int _ore;

        // Property appoggiata al field data
        public int Ore
        {
            get
            {
                return _ore;
            }

            set
            {
                if (value > 100)
                    throw new Exception("EhEhEh!!!! Non posso scrivere un valore maggiore di 100...");

                _ore = value;
            }
        }

        // Property virtual che serve per il dimostrare il pomlimorfismo
        
        // Reddito nella versione base, ritorna Ore * 10
        // Ma nelle classi figlie, ognuno so lo calcola come crede...
        //
        public virtual double Reddito 
        {
            get { return Ore * 10; }
        }
    }

    class IDT : Persona
    {
        // Costruttore di default che chiama il costruttore del padre...
        public IDT() : base() { }

        public override double Reddito
        {
            get{ return Ore * 12; }
        }
    }
    class ITP : Persona
    {
        // Costruttore di default che chiama il costruttore del padre...
        public ITP() : base() { }

        public override double Reddito
        {
            get { return Ore * 10; }
        }
    }
}
