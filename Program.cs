// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonSerializeData
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Permet de récupérer des données qui ne sont pas prédéfinis
            Console.WriteLine("Entrer le titre : ");
            string title = Console.ReadLine();
            Console.WriteLine("Entrer la description : ");
            string description = Console.ReadLine();
            serilaize(title, description);
            Console.ReadKey();
        }

        static void serilaize(string title, string description)
        {
            //Si le fichier existe, on commance por le lire puis ajouter nos donner
            
            if (File.Exists("data.json"))
            {
                //Lecture du fichier
                string json;
                using (StreamReader sr = new StreamReader("data.json"))
                {
                    json = sr.ReadToEnd();
                    sr.Close();
                }
                
                //Recuperation du ficher sous forme de liste
                List<Data> a = JsonConvert.DeserializeObject<List<Data>>(json);
                
                //Ajout des nouvelles données à paritr de la liste de base 
                a.Add(new Data
                {
                    Title = title,
                    Description = description
                });
                
                //Serialization
                string json2 = JsonConvert.SerializeObject(a, Formatting.Indented);
                
                //Ecriture de la nouvelle liste dans le ficher
                using (StreamWriter sw = new StreamWriter("data.json"))
                {
                    sw.WriteLine(json2);
                    sw.Close();
                }
            }
            //Sinon on le créer et on ajoute nos données
            else
            {
                //Creation de la liste à partior de notre object
                List<Data> a = new List<Data>();
                
                //Ajout de nos données à la liste
                a.Add(new Data
                {
                    Title = title,
                    Description = description
                });
                
                //Serialization de la liste
                string json2 = JsonConvert.SerializeObject(a, Formatting.Indented);
                
                //Ecriture dans le fichiers
                using (StreamWriter sw = new StreamWriter("data.json"))
                {
                    sw.WriteLine(json2);
                    sw.Close();
                }
            }
        }
    }
}

