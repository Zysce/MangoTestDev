# MangoTestDev

## Prérequis

Avoir installé Docker ou bien node.js (dernière stable), yarn et .net core 3.1.4

## Pour tester

Note: l'url présente dans le fichier .env (pour les tests en local) ou dans le docker-compose.yml (pour les tests avec Docker) sera peut être à changer

```
docker-compose up -d
```

Pour accéder au front: http://localhost (ou n'importe quel host associé à docker)

Le back et le front sont testables séparément via yarn et dotnet

## Points à améliorer

Ajouter des tests unitaires et de la validation et améliorer la gestion des erreurs front/back (renvoyer http code + code d'erreur custom)

Back: utiliser IdentitServer4 + améliorer la gestion des images (stocker en byte[] mais à voir si stocker en base64 n'aurait pas été plus intéressant, perf vs stockage ) + stocker les secrets dans un pipeline de build ou dans un vault

Front: loader + découper les pages en composants + style (après je ne suis pas designer, donc bon)
