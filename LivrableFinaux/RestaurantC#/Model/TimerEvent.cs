using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace ProjectResto.Models
{
    class TimerEvent
    {
        private Timer timer; //Déclaration de notre composant timer
        private int compteur = 0;
        private int limite = 0;
        private String message = "";
        public TimerEvent()
        {
            this.compteur = 0;
            this.limite = 0;
            this.message = "";
            Start();
        }
        
        public TimerEvent(String message)
        {
            this.compteur = 0;
            this.limite = 0;
            this.message = message;
            Start();
        }
        
        public TimerEvent(int limite,int delay = 1000)
        {
            this.compteur = 0;
            this.limite = limite;
            this.message = "";
            Start(delay);
        }
        
        public TimerEvent(int limite,String message, int delay = 1000)
        {
            this.compteur = 0;
            this.limite = limite;
            this.message = message;
            Start(delay);
        }

        private void Start(int delay=1000)
        {
            //Délai de 1 seconde  (valeur en millisecondes)
            this.timer = new Timer(delay); //On définit l'intervalle entre chaque exécution
            //timer.Interval = delay; //On définit l'intervalle entre chaque exécution

            this.timer.Elapsed += OnTimedEvent; //Abonnement à l'événement Tick du timer
            this.timer.AutoReset = true;
            this.timer.Enabled = true; //Activation du timer
        }
        public void Stop()
        {
            this.timer.Stop();
            this.timer.Dispose();
            this.compteur = 0;
            this.limite = 0;
            this.message = "";
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Cette méthode s'exécutera toutes les [delay] millisecondes
            //Vous pouvez ajouter votre code à exécuter après un certain délai ici
            if (this.compteur < this.limite) {
                this.compteur++;
            } else
            {
                if (this.limite == 0 && this.message.Length > 0)
                {
                    this.compteur++;
                } else
                {
                    Stop();
                }
            }

            Console.WriteLine(this.message);
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",e.SignalTime);
        }

        public String GetMessage()
        {
            return this.message;
        }

        public int GetCompteur()
        {
            return this.compteur;
        }

        public int GetLimite()
        {
            return this.limite;
        }

        public void SetMessage(String message)
        {
            this.message = message;
        }
    }
}
