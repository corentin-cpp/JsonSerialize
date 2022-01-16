# Comment Sérizlizer et ajouter des éléments à une liste avec Newtownsoft.JSON

---------Pour commancer on va s'ocuuper des fichiers---------


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
Ensuite on va commancer par la condition `else` car c'est dans le premiers endroits ou le programme va se rendre lors du premier lancement.

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
