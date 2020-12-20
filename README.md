# Bitly

## Pré-requis

Installer la dernière version 12 de NodeJS https://nodejs.org/en/
Installer la version 3.1 de dotnet Core https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.201-windows-x64-installer

## intallation
Allez dans le répertoire ./src/ClientApp
Lancer la commande npm i

Pour lancer le site, dans le répertoire .src
Lancer la commande dotnet watch run

## Exercices

Le but de l'exercice est de créer un minifier d'url.
Toutes les implémentation devrait être tester unitairement.

1) Implémenter l'ajout de nouveaux liens *Add* en utilisant *ITokenGenerator* pour génerer des tokens uniques et *IRepository* pour enregistrer les liens

2) Implémenter la liste de tous les liens *Get*
3) Implémenter la suppresssion d'un lien *Delete*
4) Implementer la redirection vers le bon lien dans *HomeController*
5) Brancher le code sur MongoDB grace au code déjà inclus dans *MongoRepository* et la chaine de connexion fourni dans connexionMongoDB.txt