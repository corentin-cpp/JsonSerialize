# Comment Sérizlizer et ajouter des éléments à une liste avec Newtownsoft.JSON

---------Etape 1---------

On va lui ajouter des propriété, pour l'exemple je vais créer des prpiété qui vont être accessible dans n'importe qu'elle 
classe et qui vont pouvoir être modifier comme on le souhaite. Elles s'appelleront `Title` et `Description` : 
```cs
    public class Data
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
```
Maintenant on peut passer à l'étape suivante

---------Etape 2---------

On va demander à notre programme de vérifier si notre fichier dans lequelle on veut traviller existe bien : 
```cs
if (File.Exists("data.json"))
{
	//On le lite puison ajoute les données
}
else
{
	On le créer
}
```
On va commancer par la condition `else` car c'est dans le premiers endroits ou le programme va se rendre lors du premier lancement.

---------Etape 3---------


On va créer notre Liste qui va contenir nos données : 
```cs
List<Data> a = new List<Data>();
```

Ensuite on va lui ajouter nos données car pour l'instant elle est nul : 
```cs
a.Add(new Data
{
    Title = title,
    Description = description
});
```

Puis on serializer notre liste :
```cs
string json2 = JsonConvert.SerializeObject(a, Formatting.Indented);
```

Et pour finir on l'écrit dans notre fichier

```cs
using (StreamWriter sw = new StreamWriter("data.json"))
{
    sw.WriteLine(json2);
    sw.Close();
}
```

Maintenant on va pouvoir lancer notre programme et voici le résultats : 

```json
[
  {
    "Title": "Titre 1",
    "Description": "Description 1"
  }
]
```
---------Etape 4---------


Et si on veut ajouter un autre éléments de la même manière on va devoir : Lire le fichier, le recupérer sous forme de liste, ajouter des nouvelles données dans notre liste, le reserializer, et l'écrire dans notre fichier (Cette étape va refaire le ficheir à zéro, mais sans perte de données)

On va se pacer dans notre `if` de l'étape de la vérification des fichiers.
On va ensuite lire notre fichier : 
```cs
string json;
using (StreamReader sr = new StreamReader("data.json"))
{
    json = sr.ReadToEnd();
    sr.Close();
}
```

Ensuite on va le récupérer sous forme de liste popur piuvoir ensuite y ajouter de nouvelles données : 
```cs
List<Data> a = JsonConvert.DeserializeObject<List<Data>>(json);
```

Puis y ajouter de nouvelles données : *
```cs
a.Add(new Data
{
    Title = title,
    Description = description
});
```

Enuite on va le convertir en Json : 
```cs
string json2 = JsonConvert.SerializeObject(a, Formatting.Indented);
```

Et pour finir on va l'ecrire dans notre fichier : 
```cs
using (StreamWriter sw = new StreamWriter("data.json"))
{
	sw.WriteLine(json2);
	sw.Close();
}
```

Si on relance notre programme on va pouvoir voir que dans notre fichier on y trouve nos nouvelles données qu'on a ajouter :
```json
[
  {
    "Title": "Titre ",
    "Description": "Description"
  },
  {
    "Title": "Tittre 4542",
    "Description": "hqgdfibqdhugiqsdbviiqhdsufcgvqkjhsdv"
  },
  {
    "Title": "qojgvbusfhgvbksfdbvbqlkdvbq",
    "Description": "qdvqdkghvqsdgvfigutyqsdfv"
  }
] 
```
